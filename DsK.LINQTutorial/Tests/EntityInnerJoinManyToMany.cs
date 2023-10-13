using DsK.LINQTutorial.Helpers;
using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace DsK.LINQTutorial.Tests;
public static class EntityInnerJoinManyToMany
{
    public static void Test(LinqtutorialDbContext db)
    {
        //"LINQ".StartSection();
        
        //var LINQ = from u in db.Users
        //           join upn in db.UserPhoneNumbers on u.Id equals upn.UserId
        //           select new { u = u, upn = upn };        

        //LINQ.ToQueryString().ShowQuery();

        //foreach (var user in LINQ)
        //    Console.WriteLine($"Username: {user.u.Name.PadRight(10)}\tEmail: {user.upn.PhoneNumber} ");

        //"LINQ".EndSection();



        //"Lambda".StartSection();

        //var LambdaQuery = db.Users.Include(x=>x.Games).Where(x=>x.Games != null);        

        //LambdaQuery.ToQueryString().ShowQuery();

        //var LambdaList = LambdaQuery.ToList();

        //foreach (var user in LambdaList)
        //{
        //    foreach (var game in user.Games)
        //    {
        //        Console.WriteLine($"Username: {user.Name.PadRight(10)}\tGame: {game.Name} ");
        //    }
        //}

        //"Lambda".EndSection();


        //"From SQL".StartSection();

        //var FromSQLQuery = db.Users.FromSql(@$"
        //    SELECT a.Id, a.Name, b.PhoneNumber
        //    FROM Users a 
        //    INNER JOIN UserGames b ON a.Id = b.UserId
        //    INNER JOIN Games c ON c.Id = b.GameId
        //    ");
        
        //FromSQLQuery.ToQueryString().ShowQuery();
        //var FromSQLList = FromSQLQuery.Include(x=>x.UserPhoneNumbers).ToList();
        
        //foreach (var result in FromSQLList)
        //{
        //    foreach (var userPhoneNumber in result.UserPhoneNumbers)
        //    {
        //        Console.WriteLine($"Username: {user.Name.PadRight(10)}\tGame: {userPhoneNumber.PhoneNumber} ");
        //    }
        //}

        //"From SQL".EndSection();
    }
}
