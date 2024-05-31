using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RemovePrimitivesDataStructures.Example1
{
    public class DataAccessProvider
    {
        private string _jsonDataBase;

        public DataAccessProvider(string jsonDataBase)
        {
            _jsonDataBase = jsonDataBase;
        }

        public void SetJsonDataBase(string jsonDataBase)
        {
            _jsonDataBase = jsonDataBase;
        }
    }
}