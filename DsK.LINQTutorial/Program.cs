using DsK.LINQTutorial.Db;
using DsK.LINQTutorial.Models;
using DsK.LINQTutorial.Tests;
internal class Program
{
    private static void Main(string[] args)
    {
        //using (var db = new LinqtutorialDbContext())
        //    Seed.Run();


        //Test
        //StringArray.Test();

        //Test
        EntitySelectAll.Test();

        //Test
        EntitySelectWhere.Test();

        //Test
        //EntityJoinOneToOne.Test();

        //Test
        //EntityJoinOneToMany.Test();

        Console.ReadLine();
    }
}