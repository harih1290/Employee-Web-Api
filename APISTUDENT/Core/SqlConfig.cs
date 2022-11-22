using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace APISTUDENT.Core
{
    public class SqlConfig
    {
        public string UnoConnStr = ConfigurationManager.AppSettings["UnoConnectionString"];//+ ConfigurationManager.AppSettings("DBAccess");
    }
}