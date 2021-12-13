// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;

public class Student : Human
    {

        public Student(string surname, string name, string patronymic, BirthDay birthDay, string faculty, int course,
            string group) : base(surname, name, patronymic, birthDay)
        {
            Faculty = faculty;
            Course = course;
            Group = group;
        }
        
        private string _faculty;
        private int _course;
        private string _group;

        public string Faculty
        {
            get => _faculty;
            set
            {
                PropertyController.CheckString(value, "Faculty");
                _faculty = value;
            }
        }
        
        public int Course
        {
            get => _course;
            set
            {
                PropertyController.CheckInt(value, "Course", 1, 6);
                _course = value;
            }
        }

        public string Group
        {
            get => _group;
            set
            {
                PropertyController.CheckString(value, "Group");
                _group = value;
            }
        }
        
        public override string ToString()
        {
            var result = base.ToString();
            result += $"I am Student at {Faculty} faculty\n" +
                      $"Now i studying at {Course} course in my {Group} group\n";
            return result;
        }

        ~Student()
        {
        }
    }