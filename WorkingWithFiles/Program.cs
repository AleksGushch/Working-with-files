using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace WorkingWithFiles
{
    internal class Program
    {
        static void Writer(int id) 
        {
            id++;
            using (StreamWriter sw = new StreamWriter("Сотрудники.txt", true, Encoding.Unicode))
            {
                string date = DateTime.Now.ToShortDateString();
                string time = DateTime.Now.ToShortTimeString();
                Console.WriteLine("Ввод данных о сотруднике:");
                Console.Write("Введите Ф.И.О сотрудника: ");
                string fullName=Console.ReadLine();
                Console.Write("Введите рост сотрудника: ");
                byte height = Convert.ToByte(Console.ReadLine());
                Console.Write("Введите дату рождения сотрудника(дд/мм/гггг): ");
                string dateOfBirth = Console.ReadLine();
                DateTime parseOfBirth = DateTime.Parse(dateOfBirth);
                Console.Write("Введите место рождения сотрудника: ");
                string placeOfBirth = Console.ReadLine();
                int age= DateTime.Now.Year-parseOfBirth.Year;
                sw.WriteLine($"{id}#{date}#{time}#{fullName}#{age}#{height}#{parseOfBirth:D}#{placeOfBirth}");
            }
        }
        static void Reader() 
        {
            using (StreamReader sr = new StreamReader("Сотрудники.txt", Encoding.Unicode))
            {
                string infoAboutEmployee;
                Console.WriteLine($"" +
                    $"{"Таб.номер",10}|" +
                    $"{"Дата внесения в систему",24}|" +
                    $"{"Время внесения в систему",25}|" +
                    $"{"Ф.И.О",30}|" +
                    $"{"Возраст",8}|" +
                    $"{"Рост",5}|" +
                    $"{"Дата рождения",18}|" +
                    $"{"Место рождения",20}|");
                while ((infoAboutEmployee = sr.ReadLine()) != null) 
                {
                    string[] dataAboutEmployee = infoAboutEmployee.Split(Convert.ToChar("#"));
                    Console.WriteLine($"" +
                        $"{dataAboutEmployee[0],10}|" +
                        $"{dataAboutEmployee[1],24}|" +
                        $"{dataAboutEmployee[2],25}|" +
                        $"{dataAboutEmployee[3],30}|" +
                        $"{dataAboutEmployee[4],8}|" +
                        $"{dataAboutEmployee[5],5}|" +
                        $"{dataAboutEmployee[6],18}|" +
                        $"{dataAboutEmployee[7],20}|");
                }
            }
        }
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            bool check=true;
            int _id;
            while (check) 
            {
                Console.Write("Хотите внести данные(1) или посмотреть данные(2) или выйти (0)?: ");
                byte input = Convert.ToByte(Console.ReadLine());
                if (input == 1)
                {
                    if (File.Exists(path + @"\Сотрудники.txt"))
                    {
                        string[] lastID = File.ReadAllLines(path + @"\Сотрудники.txt");
                        _id = (int)Char.GetNumericValue(lastID.Last()[0]);
                        Writer(_id);
                    }
                    else 
                    {
                        _id = 0;
                        Writer(_id);
                    }
                    
                }
                else if (input == 2)
                {
                    if (File.Exists(path + @"\Сотрудники.txt"))
                    {
                        Reader();
                    }
                    else
                    {
                        Console.WriteLine("Файл 'Сотрудники.txt' не найден, создайте новый файл");
                    }
                }
                else
                {
                    check = false;
                }
            }  
        }
    }
}