# Отказываемся от дефолтных конструкторов без параметров, и передаем конструктору обязательные аргументы

Класс `Student` отвечает за информацию по студенту. 

### ДО

`Student` содержит конструктор по умолчанию, так как не имеет явного определения. 

~~~C#
public class Student
{
    public string Name { get; set; }
    public string Test { get; set; }
    public DateTime Date { get; set; }
    public int Mark { get; set; }
}
~~~

### ПОСЛЕ

Добавляем конструктор с обязательным указанием параметров. Также добавили удобный способ инициировать время, используя `DateTime.Now`. 

~~~C#
public class Student
{
    public string Name { get; set; }
    public string Test { get; set; }
    public DateTime Date { get; set; }
    public int Mark { get; set; }

    public Student(string name, string test)
    {
        Name = name;
        Test = test;
        Date = DateTime.Now;
    }
}
~~~