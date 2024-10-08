﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    internal class Student:Human
    {
        static readonly int SPECIALITY_WIDTH = 24;
        static readonly int GROUP_WIDTH = 9;
        static readonly int RATING_WIDTH = 8;
        static readonly int ATTENDANCE_WIDTH = 5;
        public string Speciality {  get; set; }
        public string Group { get; set; }
        public double Rating { get; set; }
        public double Attendance {  get; set; }
        public Student
            (
            string lastName, string firstName, uint age,
            string speciality, string group, double rating, double attendance
            ):base(lastName, firstName, age)
        {
            Speciality = speciality;
            Group = group;
            Rating = rating;
            Attendance = attendance;
            Console.WriteLine($"SConstructor:\t{GetHashCode()}");
        }
        public Student(Human human, string speciality, string group, double rating, double attendance):base(human)
        {
            Speciality=speciality;
            Group = group;
            Rating = rating;
            Attendance = attendance;
            Console.WriteLine($"SConstructor:\t{GetHashCode()}");
        }

        public Student(Student other) : base(other) 
            //UpCast - приведение дочернего типа к базовому типу 
            //DownCast - преобразование от базового типа к дочернему
        {
            this.Speciality = other.Speciality;
            this.Group = other.Group;
            this.Rating = other.Rating;
            this.Attendance = other.Attendance;
            Console.WriteLine($"SCopyConstryctor:\t{GetHashCode()}");
        }

        ~Student() 
        {
            Console.WriteLine($"SDestructor:\t{GetHashCode()}");
        }
        public override string ToString()
        {
            return base.ToString() + $" {Speciality.PadRight(SPECIALITY_WIDTH)}" +
                $" {Group.PadRight(GROUP_WIDTH)} {Rating.ToString().PadLeft(RATING_WIDTH)}" +
                $" {Attendance.ToString().PadLeft(ATTENDANCE_WIDTH)}";
        }
        public override string ToFileString()
        {
            return base.ToFileString()+$",{Speciality},{Group},{Rating},{Attendance}";
        }
        public override Human Init(string[] values)
        {
            base.Init(values);
            Speciality = values[4];
            Group = values[5];
            Rating = Convert.ToDouble(values[6]);
            Attendance = Convert.ToDouble(values[7]);
            return this;
        }
    }
}
