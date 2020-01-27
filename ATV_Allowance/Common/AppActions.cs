using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATV_Allowance.Common.Actions
{
    public static class AppActions
    {
        public const string Employee_Add = "Add Employee {0}";
        public const string Employee_Update = "Update Employee {0}";
        public const string Employee_Remove = "Remove Employee {0}";

        public const string Organization_Add = "Add Organization {0}";
        public const string Organization_Update = "Updata Organization {0}";

        public const string Article_Add = "Add Article {0}";
        public const string Article_Update = "Update Article {0}";
        public const string Article_Remove = "Remove Article {0}";

        public const string ArticleEmployee_Add = "Add Employee [{0}] to Article [{1}]";
        public const string ArticleEmployee_Update = "Update Employee [{0}] in Article [{1}]";
        public const string ArticleEmployee_Remove = "Remove Employee [{0}] in Article [{1}]";

        public const string Login = "Login";
    }
}
