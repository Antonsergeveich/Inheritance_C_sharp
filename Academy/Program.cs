﻿//#define INHERITANCE_1
//#define INHERITANCE_2
//#define WRITE_TO_FILE
#define READ_TO_FILE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if INHERITANCE_1
            Human human = new Human("Vercetty", "Tommy", 30);
            Console.WriteLine(human);

            Student student = new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 96);
            Console.WriteLine(student);

            Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
            Console.WriteLine(teacher); 
#endif
#if INHERITANCE_2
            Human tommy = new Human("Vercetty", "Tommy", 30);
            Console.WriteLine(tommy);

            Student student_tommy = new Student(tommy, "Theft", "Vice", 95, 98);
            Console.WriteLine(student_tommy);

            Graduate graduate_tommy = new Graduate(student_tommy, "Working in a printing_house");
            Console.WriteLine(graduate_tommy);

            Human ricardo = new Human("Diaz", "Ricardo", 50);
            Console.WriteLine(ricardo);

            Teacher teacher_ricardo = new Teacher(ricardo, "Weapons distribution", 20);
            Console.WriteLine(teacher_ricardo);

            Human lance = new Human("Vance", "Lance", 30);
            Console.WriteLine(tommy);

            Student student_lance = new Student(lance, "Helicopter driving", "Vice City", 55, 93);
            Console.WriteLine(student_tommy);

            Graduate graduate_lance = new Graduate(lance, "Helicopter_driving", "Vice_City", 95, 98, "Money");
            Console.WriteLine(graduate_lance);

            Graduate graduat_lance = new Graduate("Vance", "Lance", 30, "Helicopter_driving", "Vice_City", 95, 98, "Money");
            Console.WriteLine(graduat_lance);

            Graduate bachelor_lance = new Graduate(student_lance, "Money");
            Console.WriteLine(bachelor_lance);

#endif
#if WRITE_TO_FILE
            Human[] group = new Human[]
               {
            student_tommy, teacher_ricardo, graduate_lance,
            new Teacher("Cortez", "Juan García", 50, "Military_education", 50),
            new Graduate(student_tommy, "The_leader_of_his_own_gang"),
            new Human ( "Vance", "Victor", 40)
               };
            //Print(group);
            Save(group, "group.csv");
            //CSV - Comma Separated Values
            //(Значение разделенные запятыми).
            //CSV - это общепринятый фармат файлов для хранения таблиц в текстовых файлах;
            //https://ru.wikipedia.org/wiki/CSV  
#endif
            Human[] group = Load("group.csv");
            Print(group);
        }
        public static void Print(Human[] group)
        {
            //for (int i = 0; i < group.Length; i++)
            //{
            //    Console.WriteLine($"{group[i]};");
            //}
            foreach (Human i in group) // DownCast - преобразование от базового типа к дочернему
            {
                Console.WriteLine(i);
            }
        }
        static void Save(Human[] group, string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach (Human i in group)
            {
                sw.WriteLine(i.ToFileString()); // DownCast - преобразование от базового типа к дочернему
            }
            sw.Close();
            Process.Start("excel", filename);
        }
        static Human[] Load(string filename)
        {
            List<Human> list = new List<Human>();
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                string buffer = sr.ReadLine();
                //Console.WriteLine(buffer);
                string[] values = buffer.Split(',');
                //Human human = HumanFactory(values[0]);
                //human.Init(values);
                //list.Add(human);
                list.Add(HumanFactory(values[0]).Init(values));
            }
            sr.Close();
            return list.ToArray();
        }

        //Фабрика - это патерн проектирования
        //который позволяет создавать типовые объекты если у них общий родитель;
        static Human HumanFactory(string type) // UpCast - преобразование дочернего типа к базовому.
        {
            Human human = null;
            switch (type)
            {
                case "Human":     human = new Human("", "", 0);                      break;
                case "Teacher":   human = new Teacher("", "", 0, "", 0);             break;
                case "Student":   human = new Student("", "", 0, "", "", 0, 0);      break;
                case "Graduate":  human = new Graduate("", "", 0, "", "", 0, 0, ""); break;
            }
            return human;
        }
    }
}
