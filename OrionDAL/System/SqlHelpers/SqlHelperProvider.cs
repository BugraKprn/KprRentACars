using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace System
{
    public class SqlHelperProvider
    {
        private static Hashtable helperList = new Hashtable();

        static SqlHelperProvider()
        {
            AddHelper("Microsoft.Data.SqlClient", new MsSqlHelper());
            AddHelper("System.Data.SqlClient", new MsSqlHelper());
            AddHelper("MySql.Data.MySqlClient", new MySqlHelper());
            AddHelper("System.Data.SQLite", new MsSqlHelper());
        }

        public static void AddHelper(string dbType, ISqlHelper helper)
        {
            helperList[dbType] = helper;
        }

        public static ISqlHelper FindHelperFor(string dbType)
        {
            ISqlHelper helper;

            helper = (ISqlHelper)helperList[dbType];

            return helper;
        }
    }
}
