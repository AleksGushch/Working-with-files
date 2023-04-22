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
        static void Writer() 
        {
            using (StreamWriter sw = new StreamWriter("Сотрудники.txt", true, Encoding.Unicode))
            {
                string date = DateTime.Now.ToShortDateString();
                string time = DateTime.Now.ToShortTimeString();
                int id = 1;
                Console.WriteLine("Ввод данных о сотруднике:");
                Console.Write("Введите возраст сотрудника: ");
                byte age = Convert.ToByte(Console.ReadLine());
                Console.Write("Введите рост сотрудника: ");
                byte height = Convert.ToByte(Console.ReadLine());
                Console.Write("Введите дату рождения сотрудника(дд/мм/гггг): ");
                string dateOfBirth = Console.ReadLine();
                DateTime parseOfBirth = DateTime.Parse(dateOfBirth);
                Console.Write("Введите место рождения сотрудника: ");
                string placeOfBirth = Console.ReadLine();
                sw.WriteLine($"{id++}#{age}#{height}#{parseOfBirth.ToString("D")}#{placeOfBirth}#{date}#{time}");
            }
        }
        static void Reader() 
        {
            using (StreamReader sr = new StreamReader("Сотрудники.txt", Encoding.Unicode)) 
            {
                string infoAboutEmployee;
                Console.WriteLine($"" +
                    $"{"Таб.номер",10}|" +
                    $"{"Возраст",8}|" +
                    $"{"Рост",5}|" +
                    $"{"Дата рождения",18}|" +
                    $"{"Место рождения",20}|" +
                    $"{"Дата внесения в систему",24}|" +
                    $"{"Время внесения в систему",25}|");
                while ((infoAboutEmployee = sr.ReadLine()) != null) 
                {
                    string[] dataAboutEmployee = infoAboutEmployee.Split(Convert.ToChar("#"));
                    Console.WriteLine($"" +
                        $"{dataAboutEmployee[0],10}|" +
                        $"{dataAboutEmployee[1],8}|" +
                        $"{dataAboutEmployee[2],5}|" +
                        $"{dataAboutEmployee[3],18}|" +
                        $"{dataAboutEmployee[4],20}|" +
                        $"{dataAboutEmployee[5],24}|" +
                        $"{dataAboutEmployee[6],25}|");
                }
            }
        }
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            bool check=true;
            while(check)
            {
                Console.Write("Хотите внести данные(1) или посмотреть данные(2) или выйти (0)?: ");
                byte input = Convert.ToByte(Console.ReadLine());
                if (input == 1)
                {
                    Writer();
                }
                else if (input == 2)
                {
                    if (File.Exists(path+@"\Сотрудники.txt"))
                    {
                        Reader();
                    }
                    else 
                    {
                        Console.WriteLine("Файл 'Сотрудники.txt' не найден, создайте новый файл");
                        Writer();
                    }
                }
                else 
                {
                    check=false;
                }
            }  
        }
    }
}