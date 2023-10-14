using Dapper;
using DsK.LINQTutorial.Helpers;
using DsK.LINQTutorial.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DsK.LINQTutorial.Tests;
public static class EntityLeftJoinManyToMany
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

        //Is actually left join but foreach turns it into inner join
        foreach (var result in LambdaList)
        {
            var FirstPart = $"Username: {result.Name.PadRight(10)}\tGame: ";
            if (result.Games.Count > 0)
            {
                foreach (var game in result.Games)
                    Console.WriteLine($"{FirstPart}{game.Name}");
            }
            else
                Console.WriteLine(FirstPart);
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
            var FirstPart = $"Username: {result.Name.PadRight(10)}\tGame: ";
            if(result.Games.Count > 0)
            {
                foreach (var game in result.Games)                
                    Console.WriteLine($"{FirstPart}{game.Name}");                
            }
            else            
                Console.WriteLine(FirstPart);
        }

        "From SQL".EndSection();



        "Dapper Custom Class".StartSection();
        using (var connection = new SqlConnection(db.Database.GetConnectionString()))
        {   
            var sql = @"
                SELECT a.Name, c.Name as GameName
                FROM Users a
                LEFT JOIN UserGames b ON a.Id = b.UsersId
                LEFT JOIN Games c ON c.Id = b.GamesId
            ";

            
            var userGames = connection.Query<UserGamesModel>(sql).ToList();

            foreach(var userGame in userGames)
            {
                Console.WriteLine($"Username: {userGame.Name.PadRight(10)}\tGame: {userGame.GameName}");
            }
        }
        "Dapper Custom Class".EndSection();



        "Dapper SplitOn".StartSection();
        using (var connection = new SqlConnection(db.Database.GetConnectionString()))
        {
            var sql = @"
                SELECT a.Name, 'x' as splithere, c.Name
                FROM Users a
                LEFT JOIN UserGames b ON a.Id = b.UsersId
                LEFT JOIN Games c ON c.Id = b.GamesId
            ";

            var userGames = connection.Query<User,Game,User>(sql, (user, game) => {                
                user.Games.Add(game);
                return user;
            }, splitOn: "splithere");
        
            
            foreach (var userGame in userGames)
            {
                Console.Write($"Username: {userGame.Name.PadRight(10)}\tGame: ");

                foreach (var game in userGame.Games)
                    Console.Write($"{game.Name}");

                Console.WriteLine();
            }
        }
        "Dapper SplitOn".EndSection();

    }

}
