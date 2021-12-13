// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;
using UnityEngine.UI;

public class StudentWindow : ListWindow<Student>
{
    [SerializeField] public InputField Name;
    [SerializeField] public InputField Surname;
    [SerializeField] public InputField Patronymic;
    [SerializeField] public InputField Day;
    [SerializeField] public InputField Month;
    [SerializeField] public InputField Year;
    [SerializeField] public Text ErrorField;
    [SerializeField] public InputField Faculty;
    [SerializeField] public InputField Course;
    [SerializeField] public InputField Group;

    private string _name;
    private string _surname;
    private string _patronymic;
    private int _day;
    private int _month;
    private int _year;
    private string _faculty;
    private int _course;
    private string _group;

    private bool _editable;

    protected void OnEnable()
    {
        if (_editable) return;
        
        Name.text = string.Empty;
        Surname.text = string.Empty;
        Patronymic.text = string.Empty;
        Day.text = string.Empty;
        Month.text = string.Empty;
        Year.text = string.Empty;
        ErrorField.text = string.Empty;
        Faculty.text = string.Empty;
        Course.text = string.Empty;
        Group.text = string.Empty;
    }

    public override void SetData(int id, Student info)
    {
        base.SetData(id, info);
        _editable = true;
        
        Name.text = Information.Name;
        Surname.text = Information.Surname;
        Patronymic.text = Information.Patronymic;
        Day.text = Information.BirthDay.Day.ToString();
        Month.text = Information.BirthDay.Month.ToString();
        Year.text = Information.BirthDay.Year.ToString();
        ErrorField.text = string.Empty;
        Faculty.text = Information.Faculty;
        Course.text = Information.Course.ToString();
        Group.text = Information.Group;    
      
        TakeName();
        TakeSurname();
        TakePatronymic();
        TakeDay();
        TakeMonth();
        TakeYear();
        TakeFaculty();
        TakeCourse();
        TakeGroup();
    }

    public void TakeName() => _name = InputControll.ReadWord(Name);

    public void TakeSurname() => _surname = InputControll.ReadExpression(Surname);

    public void TakePatronymic() => _patronymic = InputControll.ReadWord(Patronymic);

    public void TakeDay()
    {
        if (!InputControll.ReadInt(Day, ref _day))
            Day.text = string.Empty;
    }
    
    public void TakeMonth()
    {
        if (!InputControll.ReadInt(Month, ref _month))
            Month.text = string.Empty;
    }
    
    public void TakeYear()
    {
        if (!InputControll.ReadInt(Year, ref _year))
            Year.text = string.Empty;
    }
    
    public void TakeFaculty() => _faculty = InputControll.ReadExpression(Faculty);

    public void TakeCourse()
    {
        if (!InputControll.ReadInt(Course, ref _course))
            Course.text = string.Empty;
    }

    public void TakeGroup() => _group = InputControll.ReadExpression(Group);


    private void ModifyListOfHumans(Human human)
    {
        if (!_editable)
            UIListManager.CreateWindow(human);
        else
            UIListManager.ModifyWindow(Id, human);
    }
    
    public void Save()
    {
        try
        {
            var human = new Student(_surname, _name, _patronymic, new BirthDay()
            {
                Day = _day,
                Month = _month,
                Year = _year
            }, _faculty, _course, _group);

           ModifyListOfHumans(human);
        }
        catch (Exception ex)
        {
            ErrorField.text = ex.Message;
            return;
        }
        
        UIManager.OpenWindow<MainMenu>();
    }

    public void Back()
    {
        UIManager.CloseWindow<StudentWindow>();

        _editable = false;
    }
}
