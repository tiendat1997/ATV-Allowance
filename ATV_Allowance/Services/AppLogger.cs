using ATV_Allowance.Common;
using DataService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Services
{
    public interface IAppLogger
    {
        void LogBusiness(DataService.Entity.BusinessLog businessLog);
        void LogSystem(Exception ex, string additionalMessage);
    }
    public class AppLogger : IAppLogger
    {
        public void LogBusiness(DataService.Entity.BusinessLog businessLog)
        {
            NLog.LogManager.Configuration.Variables[Constants.NLogVariable.ACTOR_ID] = businessLog.ActorId.ToString();
            NLog.LogManager.Configuration.Variables[Constants.NLogVariable.MESSAGE] = businessLog.Message;
            NLog.LogManager.Configuration.Variables[Constants.NLogVariable.TYPE] = businessLog.Type;
            NLog.LogManager.Configuration.Variables[Constants.NLogVariable.STATUS] = businessLog.Status;

            // this will use the "BusinessLogger" logger from our NLog.config file
            NLog.Logger logger = NLog.LogManager.GetLogger(Constants.LoggerType.BUSINESS);

            logger.Info(string.Empty);
        }

        public void LogSystem(Exception ex, string additionalMessage)
        {
            // get a Logger object and log exception here using NLog. 
            
            MethodBase site = ex.TargetSite;
            string methodName = site == null ? null : site.Name;

            NLog.LogManager.Configuration.Variables[Constants.NLogVariable.ADDITIONAL_INFO] = additionalMessage;
            NLog.LogManager.Configuration.Variables[Constants.NLogVariable.CALL_SITE] = methodName;

            // this will use the "SystemLogger" logger from our NLog.config file
            NLog.Logger logger = NLog.LogManager.GetLogger(Constants.LoggerType.SYSTEM);

            // add custom message and pass in the exception
            logger.Error(ex, additionalMessage);
        }
    }
}
