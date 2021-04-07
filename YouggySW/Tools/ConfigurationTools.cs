using System;
using System.Collections.Generic;
using System.Text;

namespace Tools
{
    public class ConfigurationTools
    {
        public static string ConnectionStringDB
        {
            get
            {
                return Environment.GetEnvironmentVariable("CONNECTIONSTRINGDB");
            }
        }
    }
}
