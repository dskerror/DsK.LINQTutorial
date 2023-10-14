using Dapper;
using DsK.LINQTutorial.Helpers;
using DsK.LINQTutorial.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DsK.LINQTutorial.Tests;
public static class EntityInnerJoinManyToMany
{
    public static void Test(LinqtutorialDbContext db)
    {
        //"LINQ".StartSection();
        // Couldnt find example
        //"LINQ".EndSection();



        "Lambda".StartSection();
        var LambdaQuery = db.Users.Include(x => x.Games);
        LambdaQuery.ToQueryString().ShowQuery();
        var LambdaList = LambdaQuery.ToList();

        foreach (var result in LambdaList)
        {
            foreach (var game in result.Games)
            {
                Console.WriteLine($"Username: {result.Name.PadRight(10)}\tGame: {game.Name}");
            }
        }

        "Lambda".EndSection();


        "From SQL".StartSection();

        var FromSQLQuery = db.Users.FromSql($"SELECT * FROM Users a");

        //var FromSQLQuery = db.Users.FromSql(@$"
        //    SELECT a.Id, a.Name, c.Name as GameName
        //    FROM Users a
        //    INNER JOIN UserGames b ON a.Id = b.UsersId
        //    INNER JOIN Games c ON c.Id = b.GamesId
        //    ");

        FromSQLQuery.ToQueryString().ShowQuery();
        var FromSQLList = FromSQLQuery.Include(x => x.Games).ToList();

        foreach (var result in FromSQLList)
        {
            foreach (var game in result.Games)
            {
                Console.WriteLine($"Username: {result.Name.PadRight(10)}\tGame: {game.Name}");
            }
        }

        "From SQL".EndSection();

        "Dapper".StartSection();
        using (var connection = new SqlConnection("Server=.;Database=LINQTutorialDB;Trusted_Connection=True;Trust Server Certificate=true"))
        {   
            var sql = @"
                SELECT a.Name, c.Name as GameName
                FROM Users a
                INNER JOIN UserGames b ON a.Id = b.UsersId
                INNER JOIN Games c ON c.Id = b.GamesId
            ";
            
            var userGames = connection.Query<UserGames>(sql).ToList();

            foreach(var userGame in userGames)
            {
                Console.WriteLine($"Username: {userGame.Name.PadRight(10)}\tGame: {userGame.GameName}");
            }
        }
        "Dapper".EndSection();

    }

}

public class UserGames
{
    public string Name { get; set; }
    public string GameName { get; set; }
}
