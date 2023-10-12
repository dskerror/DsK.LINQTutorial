using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DsK.LINQTutorial.Tests;
public static class EntityJoinOneToMany
{
    public static void Test()
    {
        using (var db = new LinqtutorialDbContext())
        {
            //LINQ         
            //Console.WriteLine("---LINQ---");
            //var LINQ = from u in db.Users
            //           join g in db.Games on g.
            //           select new { Name = users.Name, Email = uai.Email };
            //foreach (var user in LINQ)
            //{
            //    Console.WriteLine($"Username: {user.Name.PadRight(10)}\tEmail: {user.Email} ");
            //}

            //Lambda
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("---Lambda---");
            var Lambda = db.Users.Include(x => x.Games).ToList();
            foreach (var user in Lambda)
            {
                foreach (var game in user.Games)
                {
                    Console.WriteLine($"Username: {user.Name.PadRight(10)}\tGame: {game.Name} ");
                }
                
            }

            //Lambda short
            //Console.WriteLine(Environment.NewLine);
            //Console.WriteLine("---Lambda Short---");
            //db.Users
            //    .Include(x => x.Games)                
            //    .ForEachAsync(x=>x.Games.For;
        }
    }
}
