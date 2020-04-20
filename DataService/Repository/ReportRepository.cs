using DataService.Entity;
using DataService.Infrastructure;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public interface IReportRepository : IRepository<ArticleEmployee>
    {
        List<ReportModel> GetReport(DateTime startDate, DateTime endate, int articleType, int role);
    }
    
    public class ReportRepository : Repository<ArticleEmployee>, IReportRepository
    {
        private readonly int CTV_ROLE = 4;

        public List<ReportModel> GetReport(DateTime startDate, DateTime endate, int articleType, int role)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ATVEntities"].ConnectionString))
            {
                connection.Open();
                var query = "Select EmployeeId, MAX(Name) AS 'EmployeeName', MAX(OrganizationName) AS 'OrganizationName', RoleId, Type AS 'PointType', Sum(Point) As 'TotalPoint', COUNT(CASE WHEN Point != 0 THEN Point ELSE NULL END) As 'Amount' " +
                                                    "from( " +

                                                            "Select * " +
                                                            "from Point " +
                                                            "where Type in ( " +
                                                            "Select PointTypeId " +
                                                            "from ArticlePointType " +
                                                            "where ArticleTypeId = " + articleType + ") " +

                                                    ") t1 inner join " +
                                                    "( " +
                                                            "select t.Id, t.EmployeeId, e.Name, e.Organization as 'OrganizationName', e.RoleId " +
                                                            "from Employee e inner " +
                                                            "join " +
                                                            "( " +

                                                                    "select ae.Id, ae.EmployeeId " +
                                                                    "from ArticleEmployee ae inner " +
                                                                    "join Article a on ae.ArticleId = a.Id " +
                                                                    "where Date >= '" + startDate.ToString("yyyy/MM/dd") + "' and Date <= '" + endate.ToString("yyyy/MM/dd") + "' and TypeId = " + articleType + " " +
                                                            ") t on e.Id = t.EmployeeId " +
                                                            (role == CTV_ROLE ? $"where e.RoleId = {CTV_ROLE} " : $"where e.RoleId != {CTV_ROLE} ") + 
                                                    ") t2 " +
                                                    "on t1.ArticleEmployeeId = t2.Id " +
                                                    "group by t1.Type, t2.EmployeeId, t2.RoleId " +
                                                    "order by EmployeeId";

                SqlCommand command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                List<ReportModel> result = new List<ReportModel>();
                while (reader.Read())
                {
                    var model = new ReportModel();
                    model.EmployeeId = (int)reader["EmployeeId"];
                    model.EmployeeName = (string)reader["EmployeeName"];
                    model.OrganizationName = (string)reader["OrganizationName"];
                    model.PointType = (int)reader["PointType"];
                    model.TotalPoint = (double)reader["TotalPoint"];
                    model.RoleId = (int)reader["RoleId"];
                    model.Amount = (int)reader["Amount"];

                    result.Add(model);
                }

                return result;
            }


            return null ;
        }
    }
}
