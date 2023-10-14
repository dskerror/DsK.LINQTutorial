using Dapper;
using DsK.LINQTutorial.Helpers;
using DsK.LINQTutorial.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DsK.LINQTutorial.Tests;
public static class EntitySelectAll
{
    public static void Test(LinqtutorialDbContext db)
    {
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

        var FromSQLQuery = db.Users.FromSql($"SELECT * FROM Users");
        FromSQLQuery.ToQueryString().ShowQuery();
        var FromSQLList = FromSQLQuery.ToList();
        foreach (var user in FromSQLList)
            Console.WriteLine(user.Name);

        "From SQL".EndSection();



        "Dapper".StartSection();
        using (var connection = new SqlConnection(db.Database.GetConnectionString()))
        {
            var sql = "SELECT * FROM Users";
            sql.ShowQuery();
            var dapperList = connection.Query<User>(sql).ToList();
            foreach (var user in dapperList)            
                Console.WriteLine(user.Name);            
        }
        "Dapper".EndSection();
    }
}
