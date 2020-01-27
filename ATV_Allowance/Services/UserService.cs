using DataService.Infrastructure;
using DataService.Entity;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATV_Allowance.Common.Constants;
using ATV_Allowance.Common;
using ATV_Allowance.Common.Actions;

namespace ATV_Allowance.Services
{
    public interface IUserService
    {
        User GetLogin(string username, string password);
        void UpdateLastLogin(string username);
    }
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IAppLogger _logger;
        public UserService()
        {
            _userRepository = new UserRepository();
            _logger = new AppLogger();
        }
        public User GetLogin(string username, string password)
        {
            BusinessLog actionLog = new BusinessLog
            {
                ActorId = Common.Session.GetId(),
                Message = AppActions.Login,
                Status = Constants.BusinessLogStatus.FAIL,
                Type = Constants.BusinessLogType.LOGIN
            };
            try
            {
                HashHelper hashHelper = new HashHelper();
                var user = _userRepository.GetAll()
                    .Where(u => u.Username == username &&
                                u.StatusId == CommonStatus.ACTIVE &&
                                hashHelper.VerifyHashedPassword(u.Password, password))
                    .FirstOrDefault();
                _logger.LogBusiness(actionLog);
                return user;
            }
            catch (Exception ex)
            {
                actionLog.Status = Constants.BusinessLogStatus.FAIL;
                _logger.LogBusiness(actionLog);
                _logger.LogSystem(ex, "Login Failed");
                return null;
            }
        }

        public void UpdateLastLogin(string username)
        {
            _userRepository.Get(u => u.Username == username).FirstOrDefault()
                .LastLoginTime = DateTime.Now;
        }
    }
}
