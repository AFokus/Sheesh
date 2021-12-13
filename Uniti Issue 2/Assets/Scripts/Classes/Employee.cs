// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;

public class Employee : Human
    {
        public Employee(string surname, string name, string patronymic, BirthDay birthDay, string organization,
            int salary,
            int experience) : base(surname, name, patronymic, birthDay)
        {
            Organization = organization;
            Salary = salary;
            Experience = experience;
        }
        
        private string _organization;
        private int _salary;
        private int _experience;
        
        public string Organization
        {
            get => _organization;
            set
            {
                PropertyController.CheckString(value, "Organization");
                _organization = value;
            }
        }

        public int Salary
        {
            get => _salary;
            set
            {
                PropertyController.CheckInt(value, "Salary",0, int.MaxValue);
                _salary = value;
            }
        }

        public int Experience
        {
            get => _experience;
            set
            {
                PropertyController.CheckInt(value, "Expirience", 0, 100);
                _experience = value;
            }
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += $"I am Employee at {Organization}\n" +
                      $"My salary is {Salary} and I have {Experience} years of experience\n";
            return result;
        }

        ~Employee()
        {
        }
    }