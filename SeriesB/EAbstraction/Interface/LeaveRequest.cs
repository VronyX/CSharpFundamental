namespace SeriesB.EAbstraction.Interface;

public class LeaveRequest : IApproveable, ICancelable
{
    private string name;
    private int days;

    public string Status { get; private set; } = "Pending";

    public LeaveRequest(string name, int days)
    {
        this.name = name;
        this.days = days;
    }

    public void Approve()
    {
        Console.WriteLine();
        Status = "Approved";
        Console.WriteLine($"{name} has been approved, with {days} days");
    }

    public void Cancel()
    {
        Console.WriteLine();
        Status = "Canceled";
        Console.WriteLine($"{name} has been cancelled");
    }
}
