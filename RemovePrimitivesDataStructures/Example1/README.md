# Избегаем увлечение примитивными типами данных, разрабатываем прикладную систему типов, на смысловом уровне моделирующую предметную область

Класс `DataAccessProvider` используется как провайдер БД, которую можно инициировать простой строкой.

### ДО

Инициирование провайдера БД происходит при помощи строки.

~~~C#
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
~~~

### ПОСЛЕ

Заменили использование примитивного типа данный `string` на класс `DbPath`, который инкапсулирует то же строковое поле. Преимущество состоит в том, что мы теперь без проблем можем добавить, например, валидацию на входящий путь и тем самым разделим ответственность. 

~~~C#
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
~~~