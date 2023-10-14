using DsK.LINQTutorial.Helpers;
using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace DsK.LINQTutorial.Tests;
public static class EntitySelectWhereOrDefault
{
    public static void Test(LinqtutorialDbContext db)
    {
        "LINQ Single".StartSection();

        var LINQ = from users in db.Users
                   where users.Name.Contains("a")
                   select users;

        try
        {
            Console.WriteLine(LINQ.Single().Name);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: More than one record");
        }

        try
        {
            Console.WriteLine(LINQ.SingleOrDefault().Name);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
        }

        Console.WriteLine(LINQ.First().Name);

        "LINQ".EndSection();



        "LINQ FirstOrDefault".StartSection();

        var LINQ2 = from users in db.Users
                    where users.Name.Contains("x")
                    select users;

        
        
        try
        {
            var LINQ2Result1 = LINQ2.First();

            if (LINQ2Result1 != null)
                Console.WriteLine(LINQ2Result1.Name);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: No records");
        }

        var LINQ2Result2 = LINQ2.FirstOrDefault();
        if (LINQ2Result2 != null)        
            Console.WriteLine(LINQ2Result2.Name);
        else
            Console.WriteLine("Error: No records");

        "LINQ".EndSection();
    }
}
