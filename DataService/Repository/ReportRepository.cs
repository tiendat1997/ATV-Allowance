using DataService.Entity;
using DataService.Infrastructure;
using DataService.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataService.Repository
{
    public interface IReportRepository : IRepository<ArticleEmployee>
    {
        Task<List<ReportModel>> GetReport(DateTime startDate, DateTime endate, int articleType, int role);
    }

    public class ReportRepository : Repository<ArticleEmployee>, IReportRepository
    {
        public async Task<List<ReportModel>> GetReport(DateTime startDate, DateTime endate, int articleType, int role)
        {
            var list = context.Database.SqlQuery<ReportModel>("Select EmployeeId, MAX(Name) AS 'EmployeeName', MAX(OrganizationName) AS 'OrganizationName', Type AS 'PointType', Sum(Point) As 'TotalPoint', COUNT(Point) As 'Amount' " +
                                                    "from( " +

                                                            "Select * " +
                                                            "from Point " +
                                                            "where Type in ( " +
                                                            "Select PointTypeId " +
                                                            "from ArticlePointType " +
                                                            "where ArticleTypeId = " + articleType + ") " +

                                                    ") t1 inner join " +
                                                    "( " +
                                                            "select t.Id, t.EmployeeId, e.Name, o.Name as 'OrganizationName' " +
                                                            "from Employee e inner " +
                                                            "join " +
                                                            "( " +

                                                                    "select ae.Id, ae.EmployeeId " +
                                                                    "from ArticleEmployee ae inner " +
                                                                    "join Article a on ae.ArticleId = a.Id " +
                                                                    "where Date >= '" + startDate.ToString("yyyy/MM/dd") + "' and Date <= '" + endate.ToString("yyyy/MM/dd") + "' and TypeId = " + articleType + " " +
                                                            ") t on e.Id = t.EmployeeId inner join Organization o on e.OrganizationId = o.Id " +
                                                            "where e.RoleId = " + role + " " +
                                                    ") t2 " +
                                                    "on t1.ArticleEmployeeId = t2.Id " +
                                                    "group by t1.Type, t2.EmployeeId " +
                                                    "order by EmployeeId");
            var result = await list.ToListAsync();
            return result;
        }
    }
}
