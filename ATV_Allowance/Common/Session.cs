using ATV_Allowance.Services;
using DataService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Common
{
    public static class Session
    {
        private static string FULLNAME = "";
        private static string CODE = "";
        private static int ID = -1;
        private static string ROLE = "";
        private static bool ISLOGIN = false;
        public static bool Login(string username, string password)
        {
            UserService userService = null;
            User user = null;
            bool result = false;

            try
            {
                userService = new UserService();
                if (!string.IsNullOrWhiteSpace(username))
                {
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        user = userService.GetLogin(username, password);
                        if (user != null)
                        {
                            ID = user.Id;
                            FULLNAME = user.Name;
                            //CODE = user.Code;
                            ROLE = user.Role.Name;
                            ISLOGIN = true;

                            //Update last login
                            userService.UpdateLastLogin(username);

                            result = true;
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                userService = null;
                user = null;
            }
        }
        public static bool CheckAuthorize(string role)
        {
            bool result = false;
            try
            {
                if (ISLOGIN)
                {
                    if (FULLNAME != "" && CODE != "" && ROLE != "")
                    {
                        result = role == ROLE;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void Logout()
        {
            ClearInfo();
        }

        public static void ClearInfo()
        {
            FULLNAME = "";
            CODE = "";
            ROLE = "";
            ISLOGIN = false;
        }

        public static string GetFullName()
        {
            return FULLNAME;
        }

        public static string GetCode()
        {
            return CODE;
        }

        public static string GetRole()
        {
            return ROLE;
        }

        public static int GetId()
        {
            return ID;
        }

        public static bool IsLogin()
        {
            ISLOGIN = false;

            if (!string.IsNullOrWhiteSpace(FULLNAME))
            {
                if (!string.IsNullOrWhiteSpace(ROLE))
                {
                    if (!string.IsNullOrWhiteSpace(ROLE))
                    {
                        if (ID > 0)
                        {
                            ISLOGIN = true;
                        }
                    }
                }
            }

            return ISLOGIN;
        }
    }
}
