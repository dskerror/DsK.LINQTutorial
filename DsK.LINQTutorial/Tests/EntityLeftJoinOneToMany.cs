using DsK.LINQTutorial.Helpers;
using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace DsK.LINQTutorial.Tests;
public static class EntityLeftJoinOneToMany
{
    public static void Test(LinqtutorialDbContext db)
    {
        "LINQ".StartSection();
        //TODO: See if this can return Users.UserAdditionalInfo filled            
        var LINQ = from u in db.Users
                   join upn in db.UserPhoneNumbers on u.Id equals upn.UserId into newuai
                   from x in newuai.DefaultIfEmpty()
                   select new { u = u, upn = x == null ? new UserPhoneNumber() : x };

        LINQ.ToQueryString().ShowQuery();

        foreach (var user in LINQ)
            Console.WriteLine($"Username: {user.u.Name.PadRight(10)}\tPhone: {user.upn.PhoneNumber} ");

        "LINQ".EndSection();



        "Lambda".StartSection();

        var LambdaQuery = db.Users.Include(x => x.UserPhoneNumbers);

        LambdaQuery.ToQueryString().ShowQuery();

        var LambdaList = LambdaQuery.ToList();

        foreach (var user in LambdaList)
        {
            var FirstPart = $"Username: {user.Name.PadRight(10)}\tPhone: ";
            if (user.UserPhoneNumbers.Count > 0)
            {
                foreach (var phoneNumber in user.UserPhoneNumbers)
                {
                    Console.Write(FirstPart);
                    Console.WriteLine($"{(phoneNumber.PhoneNumber)} ");
                }
            }
            else
            {
                Console.WriteLine(FirstPart);
            }

            //Console.Write($"Username: {user.Name.PadRight(10)}\tPhone: ");
            //if (user.UserPhoneNumbers.Count > 0)
            //{
            //    foreach (var phoneNumber in user.UserPhoneNumbers)
            //        Console.Write($"{(phoneNumber.PhoneNumber)} ");
            //}
            //Console.WriteLine();
        }

        "Lambda".EndSection();


        "From SQL".StartSection();

        //var FromSQLQuery = db.Users.FromSql($"SELECT a.Id, a.Name, b.PhoneNumber, b.UserId FROM Users a LEFT JOIN UserPhoneNumbers b ON a.Id = b.UserId");
        //Error : Produces undesired results

        var FromSQLQuery = db.Users.FromSql($"SELECT * FROM Users a").Include(x=>x.UserPhoneNumbers);

        FromSQLQuery.ToQueryString().ShowQuery();
        var FromSQLList = FromSQLQuery.ToList();
        foreach (var user in FromSQLList)
        {
            var FirstPart = $"Username: {user.Name.PadRight(10)}\tPhone: ";

            if (user.UserPhoneNumbers.Count > 0)
            {
                foreach (var phoneNumber in user.UserPhoneNumbers)
                {
                    Console.Write(FirstPart);
                    Console.WriteLine($"{(phoneNumber.PhoneNumber)} ");
                }
            }
            else
            {
                Console.WriteLine(FirstPart);
            }
        }

        "From SQL".EndSection();
    }
}
