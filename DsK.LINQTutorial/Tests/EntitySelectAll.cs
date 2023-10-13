using DsK.LINQTutorial.Helpers;
using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace DsK.LINQTutorial.Tests;
public static class EntitySelectAll
{
    public static void Test()
    {
        using var db = new LinqtutorialDbContext();

        "LINQ".StartSection();

        var LINQ = from users in db.Users
                   select users;

        LINQ.ToQueryString().ShowQuery();

        foreach (var user in LINQ)
            Console.WriteLine(user.Name);

        "LINQ".EndSection();



        "Lambda".StartSection();

        var LambdaQuery = db.Users;

        LambdaQuery.ToQueryString().ShowQuery();

        var LambdaList = LambdaQuery.ToList();

        foreach (var user in LambdaList)
            Console.WriteLine(user.Name);

        "Lambda".EndSection();



        "Lambda Short".StartSection();

        db.Users.ToList().ForEach(x => Console.WriteLine(x.Name));

        "Lambda Short".EndSection();



        "From SQL".StartSection();

        var FromSQLQuery = db.Users.FromSql($"SELECT * FROM USERS");
        FromSQLQuery.ToQueryString().ShowQuery();
        var FromSQLList = FromSQLQuery.ToList();
        foreach (var user in FromSQLList)
            Console.WriteLine(user.Name);

        "From SQL".EndSection();
    }
}
