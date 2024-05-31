using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RemoveDefaultConstructors.Example1
{
    public class DbPath
    {
        private readonly string _jsonDataBase;

        public DbPath(string jsonDataBase)
        {
            _jsonDataBase = jsonDataBase;
        }
    }

    public class DataAccessProvider
    {
        private DbPath _dbPath;

        public DataAccessProvider(DbPath path)
        {
            _dbPath = path;
        }

        public void SetJsonDataBase(DbPath path)
        {
            _dbPath = path;
        }
    }
}