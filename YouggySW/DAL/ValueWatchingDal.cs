using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;
using YouggySW.Model;

namespace YouggySW.DAL
{
    public class ValueWatchingDal
    {
        private DatabaseSQLServerManagerTools dbManager = new DatabaseSQLServerManagerTools();

        public void Insert(ValueWatching valueWatching)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllValueWatchings()
        {
            return dbManager.SelectStoredProcedure("usp_Values_WatchingsSelect", new Dictionary<string, object>());
        }

        public ValueWatching GetValueWatching(int id)
        {
            throw new NotImplementedException();
        }
    }
}
