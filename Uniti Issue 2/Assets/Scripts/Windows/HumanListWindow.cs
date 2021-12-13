// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

public class HumanListWindow : ListWindow<Human>
{
    [SerializeField] private Text _order;
    [SerializeField] private Text _type;
    [SerializeField] private Text _name;
    [SerializeField] private Text _age;

    private void UpdateInfo()
    {
        _order.text = Id.ToString();
        _type.text = Information.GetType().ToString();
        _name.text = Information.Name + " " + Information.Surname;
        _age.text = Information.Age.ToString();
    }
    
    protected void Awake() => UpdateInfo();

    protected void OnEnable() => UpdateInfo();

    public void View() => UIManager.OpenListWindow<ViewWindow, Human>(Id, Information);

    public void Edit()
    {
        switch (Information)
        {
            case Student student:
            {
                UIManager.OpenListWindow<StudentWindow, Student>(Id, student);
                break;
            }

            case Driver driver:
            {
                UIManager.OpenListWindow<DriverWindow, Driver>(Id, driver);
                break;
            }
            
            case Employee employee:
            {
                UIManager.OpenListWindow<EmployeeWindow, Employee>(Id, employee);
                break;
            }
        }
    }
    public void Destroy() => UIListManager.DestroyWindow(Id);
}
