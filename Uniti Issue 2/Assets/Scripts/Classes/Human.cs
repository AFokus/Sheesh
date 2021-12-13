// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;

public struct BirthDay
    {
        private int _day;
        private int _month;
        private int _year;
        public int Day
        {
            get => _day;
            set
            {
                PropertyController.CheckInt(value, "Birth Day", 1, 31);
                _day = value;
            }
        }
        public int Month
        {
            get => _month;
            set
            {
                PropertyController.CheckInt(value, "Birth Month", 1, 12);
                _month = value;
            }
        }
        public int Year
        {
            get => _year;
            set
            {
                PropertyController.CheckInt(value, "Birth Year", 1900, DateTime.Today.Year);
                _year = value;
            }
        }
    }

    public abstract class Human
    {
        protected Human(string surname, string name, string patronymic, BirthDay birthDay)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            BirthDay = birthDay;
        }

        private string _surname;
        private string _name;
        private string _patronymic;
        
        public string Surname
        {
            get => _surname;
            set
            {
                PropertyController.CheckString(value, "Surname");
                _surname = value;
            }
        }
        
        public string Name
        {
            get => _name;
            set
            {
                PropertyController.CheckString(value, "Name");
                _name = value;
            }
        }
        
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                PropertyController.CheckString(value, "Patronymic");
                _patronymic = value;
            }
        }
        
        public BirthDay BirthDay { get; set; }
        
        public int Age
        {
            get
            {
                var age = DateTime.Today.Year - BirthDay.Year;

                if (DateTime.Today.Month < BirthDay.Month)
                    age--;
                else if (DateTime.Today.Month == BirthDay.Month && DateTime.Today.Day < BirthDay.Day)
                    age--;

                return age;
            }
        }

        public override string ToString()
        {
            var result = $"I am {Surname} {Name} {Patronymic}\n" +
                         $"at the age of {Age}. Well, my birthday is at {BirthDay.Day}.{BirthDay.Month}.{BirthDay.Year}\n";
            return result;
        }

        ~Human()
        {
        }
    }