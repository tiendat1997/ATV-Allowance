using DataService.Infrastructure;
using DataService.Entity;
using DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATV_Allowance.Common.Constants;

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
        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public User GetLogin(string username, string password)
        {
            HashHelper hashHelper = new HashHelper();
            return _userRepository.GetAll()
                .Where(u => u.Username == username &&
                            u.StatusId == CommonStatus.ACTIVE &&
                            hashHelper.VerifyHashedPassword(u.Password, password))
                .FirstOrDefault();
        }

        public void UpdateLastLogin(string username)
        {
            _userRepository.Get(u => u.Username == username).FirstOrDefault()
                .LastLoginTime = DateTime.Now;
        }
    }
}
