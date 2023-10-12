using DsK.LINQTutorial.Helpers;
using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace DsK.LINQTutorial.Tests;
public static class EntitySelectWhere
{
    public static void Test()
    {
        using var db = new LinqtutorialDbContext();

        "LINQ".StartSection();

        var LINQ = from users in db.Users
                   where users.Name.Contains("a")
                   select users;

        LINQ.ToQueryString().ShowQuery();

        foreach (var user in LINQ)
            Console.WriteLine(user.Name);

        "LINQ".EndSection();



        "Lambda".StartSection();

        var LambdaQuery = db.Users.Where(x => x.Name.Contains("a"));

        LambdaQuery.ToQueryString().ShowQuery();

        var LambdaList = LambdaQuery.ToList();

        foreach (var user in LambdaList)
            Console.WriteLine(user.Name);

        "Lambda".EndSection();


        "Lambda Short".StartSection();

        db.Users.Where(x => x.Name.Contains("a")).ToList().ForEach(x => Console.WriteLine(x.Name));
        
        "Lambda Short".EndSection();
    }
}
