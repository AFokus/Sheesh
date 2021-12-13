// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;

public sealed class Driver : Employee
    {
        public Driver(string surname, string name, string patronymic, BirthDay birthDay, string organization,
            int salary,
            int experience, string brand, string model) : base(surname, name, patronymic, birthDay, organization,
            salary, experience)
        {
            Brand = brand;
            Model = model;
        }

        private string _brand;
        private string _model;
        
        public string Brand
        {
            get => _brand;
            set
            {
                PropertyController.CheckString(value, "Brand");
                _brand = value;
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                PropertyController.CheckString(value, "Model");
                _model = value;
            }
        }

        public override string ToString()
        {
            var result = base.ToString();
            result += "Saying that I am an Employee I meant that I am a Driver!\n" +
                      $"And I am driving my {Model} from {Brand}\n";
            return result;
        }

        ~Driver()
        {
        }
    }