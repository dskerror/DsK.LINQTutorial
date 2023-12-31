﻿using Dapper;
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

        //Is actually left join but foreach turns it into inner join
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



        "Dapper Custom Class".StartSection();
        using (var connection = new SqlConnection(db.Database.GetConnectionString()))
        {   
            var sql = @"
                SELECT a.Name, c.Name as GameName
                FROM Users a
                INNER JOIN UserGames b ON a.Id = b.UsersId
                INNER JOIN Games c ON c.Id = b.GamesId
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
                INNER JOIN UserGames b ON a.Id = b.UsersId
                INNER JOIN Games c ON c.Id = b.GamesId
            ";

            var userGames = connection.Query<User,Game,User>(sql, (user, game) => {                
                user.Games.Add(game);
                return user;
            }, splitOn: "splithere");
        
            
            foreach (var userGame in userGames)
            {
                foreach(var game in userGame.Games)
                    Console.WriteLine($"Username: {userGame.Name.PadRight(10)}\tGame: {game.Name}");
            }
        }
        "Dapper SplitOn".EndSection();

    }

}
