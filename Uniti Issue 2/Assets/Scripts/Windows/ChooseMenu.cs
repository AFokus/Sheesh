// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

public class ChooseMenu : Window
{
    public void OnStudentClick() => UIManager.OpenWindow<StudentWindow>();

    public void OnEmployeeClick() => UIManager.OpenWindow<EmployeeWindow>();

    public void OnDriverClick() => UIManager.OpenWindow<DriverWindow>();

    public void Back() => UIManager.CloseWindow<ChooseMenu>();
}