# Избавляемся от точек генерации исключений, запрещая соответствующее ошибочное поведение на уровне интерфейса класса

Есть класс, который позволяет отвечает за операции над телефонными номерами, вычитываемые из файлов.

### ДО

Программа генерировала исключения каждый раз, когда мы не передевали корректный путь до файлов или когда происходила проблема чтения/записи в файл/из файла.

### ПОСЛЕ

Заменили проброс исключения возвращением аргумента по умолчанию. В местах, где необходимо было добавить дополнительную информацию о возможной проблеме, была записана ошибка в стандартный вывод.

Дизайн стал более органичным. На примере метода `WriteToFile`, который возвращает булево значение, теперь при наличии некорректных аргументов мы не выбросим ошибку, завершим свою работу, а вернем "false", предполагая, что запись в файл не была осуществлена.

~~~C#
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace StringFormatting
{
    public static class TelNumbers
    {
        public static List<string> GetNumbersFromFileAndWriteThemToFile(string fileToRead, string fileToWrite)
        {
            if (fileToRead is null || fileToWrite is null)
                return new List<string>();
            // throw new ArgumentNullException("Input argument is null");

            string fileContent = ReadFromFile(fileToRead);

            if (fileContent.Length == 0)
                // throw new ArgumentException("Text file is empty.");
                System.Console.WriteLine("Text file is empty.");
                return new List<string>();

            var numbers = GetNumbersFromInput(fileContent);

            if (numbers.Count == 0)
            {
                Console.WriteLine("There is no telephone numbers in input file.");
                return new List<string>();
            }

            WriteToFile(fileToWrite, numbers);

            return numbers;
        }

        private static string ReadFromFile(string file)
        {
            if (file is null)
                return "";
            // throw new ArgumentNullException("Input argument is null");

            try
            {
                var reader = File.Open(file, FileMode.Open, FileAccess.Read);
                var streamReader = new StreamReader(reader);

                StringBuilder fileContent = new StringBuilder();
                using (streamReader)
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        fileContent.Append(line);
                    }
                }

                return fileContent.ToString();
            }
            catch (IOException e)
            {
                System.Console.WriteLine("The read operation could not be performed.", e);
                return "";
                // throw new IOException("The read operation could not be performed.", e);
            }
        }

        private static bool WriteToFile(string file, List<string> data)
        {
            if (file is null || data is null)
                // throw new ArgumentNullException("Input argument is null");
                return false;

            try
            {
                if (data.Count == 0)
                    return false;

                var writer = File.Open(file, FileMode.Create, FileAccess.Write);
                var streamWriter = new StreamWriter(writer);
                using (streamWriter)
                {
                    int count = 0;
                    while (count < data.Count)
                    {
                        streamWriter.WriteLine(data[count]);
                        count++;
                    }
                }

                return true;
            }
            catch (IOException e)
            {
                 System.Console.WriteLine("The write operation could not be performed.", e);
                return false;
                // throw new IOException("The write operation could not be performed.", e);
            }
        }

        private static List<string> GetNumbersFromInput(string input)
        {
            // patterns: +X (XXX) XXX-XX-XX or X XXX XXX-XX-XX or +XXX (XX) XXX-XXXX
            string[] telPatterns = new[]
            {
                @"\+[1-9] \(\d{3}\) \d{3}-\d{2}-\d{2}",
                @"[1-9] \d{3} \d{3}-\d{2}-\d{2}",
                @"\+[1-9]\d{2} \(\d{2}\) \d{3}-\d{4}"
            };

            var numbers = new List<string>();

            foreach (string pattern in telPatterns)
            {
                Regex regex = new Regex(pattern);

                foreach (Match match in regex.Matches(input))
                    numbers.Add(match.Value);
            }

            return numbers;
        }
    }
}
~~~