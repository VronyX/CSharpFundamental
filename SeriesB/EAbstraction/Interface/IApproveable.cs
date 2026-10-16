namespace SeriesB.EAbstraction.Interface;

public interface IApproveable
{
    public string Status { get; }

    public void Approve();

}
