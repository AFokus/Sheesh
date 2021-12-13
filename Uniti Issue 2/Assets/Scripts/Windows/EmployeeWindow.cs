// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeWindow : ListWindow<Employee>
{
    [SerializeField] public InputField Name;
    [SerializeField] public InputField Surname;
    [SerializeField] public InputField Patronymic;
    [SerializeField] public InputField Day;
    [SerializeField] public InputField Month;
    [SerializeField] public InputField Year;
    [SerializeField] public Text ErrorField;
    [SerializeField] public InputField Organization;
    [SerializeField] public InputField Experience;
    [SerializeField] public InputField Salary;

    private string _name;
    private string _surname;
    private string _patronymic;
    private int _day;
    private int _month;
    private int _year;
    private string _organization;
    private int _experience;
    private int _salary;

    private bool _editable = false;
    
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
        Organization.text = string.Empty;
        Salary.text = string.Empty;
        Experience.text = string.Empty;
    }
    
    public override void SetData(int id, Employee info)
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
        Organization.text = Information.Organization;
        Salary.text = Information.Salary.ToString();
        Experience.text = Information.Experience.ToString();

        TakeName();
        TakeSurname();
        TakePatronymic();
        TakeDay();
        TakeMonth();
        TakeYear();
        TakeOrganization();
        TakeSalary();
        TakeExperience();
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
    
    public void TakeOrganization() => _organization = InputControll.ReadExpression(Organization);

    public void TakeExperience()
    {
        if (!InputControll.ReadInt(Experience, ref _experience))
            Experience.text = string.Empty;
    }
    
    public void TakeSalary()
    {
        if (!InputControll.ReadInt(Salary, ref _salary))
            Salary.text = string.Empty;
    }

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
            var human = new Employee(_surname, _name, _patronymic, new BirthDay()
            {
                Day = _day,
                Month = _month,
                Year = _year
            }, _organization, _salary, _experience);

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
        UIManager.CloseWindow<EmployeeWindow>();
        
        _editable = false;
    }
}
