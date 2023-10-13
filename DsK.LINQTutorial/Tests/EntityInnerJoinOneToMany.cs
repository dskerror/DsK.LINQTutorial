using DsK.LINQTutorial.Helpers;
using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace DsK.LINQTutorial.Tests;
public static class EntityInnerJoinOneToMany
{
    public static void Test()
    {
        using var db = new LinqtutorialDbContext();

        "LINQ".StartSection();
        //TODO: See if this can return Users.UserAdditionalInfo filled            
        var LINQ = from u in db.Users
                   join upn in db.UserPhoneNumbers on u.Id equals upn.UserId
                   select new { u = u, upn = upn };        

        LINQ.ToQueryString().ShowQuery();

        foreach (var user in LINQ)
            Console.WriteLine($"Username: {user.u.Name.PadRight(10)}\tEmail: {user.upn.PhoneNumber} ");

        "LINQ".EndSection();



        "Lambda".StartSection();

        var LambdaQuery = db.Users.Join(db.UserPhoneNumbers, a => a.Id, b => b.UserId, (a, b) => new { A = a, B = b });        

        LambdaQuery.ToQueryString().ShowQuery();

        var LambdaList = LambdaQuery.ToList();

        foreach (var user in LambdaList)
            Console.WriteLine($"Username: {user.A.Name.PadRight(10)}\tEmail: {user.B.PhoneNumber} ");

        "Lambda".EndSection();


        "From SQL".StartSection();

        var FromSQLQuery = db.Users.FromSql(@$"
            SELECT a.Id, a.Name, b.PhoneNumber
            FROM Users a 
            INNER JOIN UserPhoneNumbers b ON a.Id = b.UserId");
        //Error if id not in select
        FromSQLQuery.ToQueryString().ShowQuery();
        var FromSQLList = FromSQLQuery.Include(x=>x.UserPhoneNumbers).ToList();
        //If I don't user Include, PhoneNumbers is null
        foreach (var user in FromSQLList)
        {
            foreach (var userPhoneNumber in user.UserPhoneNumbers)
            {
                Console.WriteLine($"Username: {user.Name.PadRight(10)}\tEmail: {userPhoneNumber.PhoneNumber} ");
            }
        }

        "From SQL".EndSection();
    }
}
