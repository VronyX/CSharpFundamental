using SeriesB.AClassAndObject;
//using SeriesB.BEncapsulation;
//using SeriesB.CInheritance;
//using SeriesB.DPolymorphism;
using SeriesB.EAbstraction.Abstract;
using SeriesB.EAbstraction.Interface;

namespace SeriesB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Example01 example1 = new Example01();
            //example1.ClassObjectExample();
            
            //Example02 example2 = new Example02();
            //example2.Example02Encapsulation();

            //Example03 example3 = new Example03();
            //example3.InheritanceExample();

            //Example04 example4 = new Example04();
            //example4.PolymorphismExample();

            //Employee fran = new Contract("Fran", 20, 150000);
            //fran.ShowPaysSlip();

            //Employee joko = new Permanent("Joko", 8000000, 500000);
            //joko.ShowPaysSlip();


            LeaveRequest leaveRequest = new LeaveRequest("Fran", 30);
            Console.WriteLine($"Status leave sebelum: {leaveRequest.Status}");
            leaveRequest.Approve();
            Console.WriteLine($"Status leave approved: {leaveRequest.Status}");
            leaveRequest.Cancel();
            Console.WriteLine($"Status leave cancelled: {leaveRequest.Status}");
            Console.WriteLine();
            OvertimeRequest overtimeRequest = new OvertimeRequest("Dello", 1);
            Console.WriteLine($"Status overtime sebelum: {overtimeRequest.Status}");
            overtimeRequest.Approve();
            Console.WriteLine($"Status overtime approved: {overtimeRequest.Status}");
        }
    }
}
