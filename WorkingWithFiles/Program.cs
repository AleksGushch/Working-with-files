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
                DateTime parseOfBirth = DateTime.Parse(dateOfBirth, DateTimeFormatInfo.CurrentInfo);
                Console.Write("Введите место рождения сотрудника: ");
                string placeOfBirth = Console.ReadLine();
                sw.WriteLine($"{id++}#{age}#{height}#{parseOfBirth}#{placeOfBirth}#{date}#{time}");
            }
        }
        static void Reader() 
        {
            using (StreamReader sr = new StreamReader("Сотрудники.txt",Encoding.Unicode)) 
            {
                string infoAboutEmployee;
                while ((infoAboutEmployee = sr.ReadLine()) != null) 
                {
                    const string V = "#";
                    string[] dataAboutEmployee = infoAboutEmployee.Split(Convert.ToChar(V));
                    foreach (string word in dataAboutEmployee) 
                    {
                        Console.Write(" "+ word);
                        Console.WriteLine();
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            bool check=true;
            while(check)
            {
                Console.Write("Хотите внести данные(1) или посмотреть данные(2) или выйти (любая клавиша)?: ");
                byte input = Convert.ToByte(Console.ReadLine());
                if (input == 1)
                {
                    Writer();
                }
                else if (input == 2)
                {
                    Reader();
                }
                else 
                {
                    check=false;
                }
            }  
        }
    }
}