using DsK.LINQTutorial.Db;
using DsK.LINQTutorial.Models;
using DsK.LINQTutorial.Tests;
using Microsoft.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        using var db = new LinqtutorialDbContext();

        Seed.Run();


        //Test
        //StringArray.Test();

        //Test
        //EntitySelectAll.Test(db);

        //Test
        //EntitySelectWhere.Test(db);

        //Test
        //EntitySelectWhereOrDefault.Test(db);

        //Test
        //EntityInnerJoinOneToOne.Test(db);

        //Test
        //EntityInnerJoinOneToMany.Test(db);

        //Test
        //EntityLeftJoinOneToOne.Test(db);

        //Test
        //EntityLeftJoinOneToMany.Test(db);

        //Test
        //EntityInnerJoinManyToMany.Test(db);

        //Test
        EntityLeftJoinManyToMany.Test(db);


        Console.ReadLine();
    }
}