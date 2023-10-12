using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DsK.LINQTutorial.Tests;
public static class EntityJoinOneToOne
{
    public static void Test()
    {
        using (var db = new LinqtutorialDbContext())
        {
            //LINQ
            //TODO: See if this can return Users.UserAdditionalInfo filled
            Console.WriteLine("---LINQ---");
            var LINQ = from users in db.Users
                       join uai in db.UserAdditionalInfos on users.Id equals uai.UserId                       
                       select new { Name = users.Name, Email = uai.Email };
            foreach (var user in LINQ)
            {
                Console.WriteLine($"Username: {user.Name.PadRight(10)}\tEmail: {user.Email} ");
            }

            //Lambda
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("---Lambda---");
            var Lambda = db.Users.Include(x => x.UserAdditionalInfo).ToList();
            foreach (var user in Lambda)
            {
                Console.WriteLine($"Username: {user.Name.PadRight(10)}\tEmail: {user.UserAdditionalInfo.Email} ");
            }

            //Lambda short
            //note : doesnt need include because the query above already has it.
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("---Lambda Short---");
            db.Users
            .ToList()
                .ForEach(x => Console.WriteLine($"Username: {x.Name.PadRight(10)}\tEmail: {x.UserAdditionalInfo.Email} "));
        }
    }
}
