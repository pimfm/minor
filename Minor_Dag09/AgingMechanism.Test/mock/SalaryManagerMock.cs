using AgeDemo;

public class SalaryManagerMock
{
    public bool SalaryHasChanged { get; private set; }

    public void ChangeSalary(object sender, BirthDayEventArgs arguments)
    {
        this.SalaryHasChanged = true;
    }
}