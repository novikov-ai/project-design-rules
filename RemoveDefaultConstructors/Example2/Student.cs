namespace RemoveDefaultConstructors.Example2
{
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
}