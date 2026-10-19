using SeriesC.AExceptionHandling;
using SeriesC.BCollection;
using SeriesC.CGeneric;
using SeriesC.DLinq;
using SeriesC.EAsynchronus;

namespace SeriesC;

internal class Program
{
    static void Main(string[] args)
    {
        //ExceptionHandling.TryCatchFinally();
        //ExceptionHandling.OtherException();
        //ExceptionHandling.ThrowKeyword();
        //Collection.ListCollection();

        //Employee<string> herul = new Employee<string>()
        //{
        //    Id = "x123",
        //    FullName = "Herul Syahwandi S",
        //    Salary = 1000,
        //    Job = "Junior Programer"
        //};

        //Employee<int> rifqi = new Employee<int>()
        //{
        //    Id = 9990,
        //    FullName = "Herul Syahwandi S",
        //    Salary = 2500,
        //    Job = "Senior Programer"
        //};

        //herul.Introduction();
        //rifqi.Introduction();

        //LinqQuery.Introduction();
        //LinqQuery.Transformation();
        //LinqQuery.Grouping();
        //LinqQuery.Joining();
        //LinqQuery.GroupAndJoin();

        //MultiThread.ThreadExample();
        //MultiThread.ConcurrencyAndParallelism();

        //Asynchronous.TaskClass();
        //Asynchronous.AsyncAwait().Wait();
        Asynchronous.Cancelation().Wait();
    }
}
