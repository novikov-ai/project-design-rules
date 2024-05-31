# Отказываемся от дефолтных конструкторов без параметров, и передаем конструктору обязательные аргументы

Класс `DataAccessProvider` используется как провайдер БД, которую можно инициировать простой строкой.

### ДО

Класс `DataAccessProvider` содержит конструктор по умолчанию, так как не имеет явного определения. 

~~~C#
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RemoveDefaultConstructors.Example1
{
    public class DataAccessProvider
    {
        private string _jsonDataBase;

        public void SetJsonDataBase(string jsonDataBase)
        {
            _jsonDataBase = jsonDataBase;
        }
    }
}
~~~

### ПОСЛЕ

Добавляем конструктор с явной инициализацией первоначального состояния строки для подключения к БД. Теперь мы уверен, что значение всегда чем-то инициировано. 

~~~C#
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RemoveDefaultConstructors.Example1
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
~~~