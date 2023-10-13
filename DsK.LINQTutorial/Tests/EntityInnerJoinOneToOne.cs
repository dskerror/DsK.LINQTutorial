using DsK.LINQTutorial.Helpers;
using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace DsK.LINQTutorial.Tests;
public static class EntityInnerJoinOneToOne
{
    public static void Test(LinqtutorialDbContext db)
    {
        "LINQ".StartSection();
        //TODO: See if this can return Users.UserAdditionalInfo filled            
        var LINQ = from u in db.Users
                   join uai in db.UserAdditionalInfos on u.Id equals uai.UserId
                   select new { u = u, uai = uai };
        //select new { Name = u.Name, Email = uai.Email };

        LINQ.ToQueryString().ShowQuery();

        foreach (var user in LINQ)
            Console.WriteLine($"Username: {user.u.Name.PadRight(10)}\tEmail: {user.uai.Email} ");

        "LINQ".EndSection();



        "Lambda".StartSection();

        var LambdaQuery = db.Users.Join(db.UserAdditionalInfos, a => a.Id, b => b.UserId, (a, b) => new { A = a, B = b });

        LambdaQuery.ToQueryString().ShowQuery();

        var LambdaList = LambdaQuery.ToList();

        foreach (var user in LambdaList)
            Console.WriteLine($"Username: {user.A.Name.PadRight(10)}\tEmail: {user.B.Email} ");

        "Lambda".EndSection();


        "From SQL".StartSection();

        var FromSQLQuery = db.Users.FromSql($"SELECT a.*, b.Email FROM Users a INNER JOIN UserAdditionalInfo b ON a.Id = b.UserId");
        FromSQLQuery.ToQueryString().ShowQuery();
        var FromSQLList = FromSQLQuery.ToList();
        foreach (var user in FromSQLList)
            Console.WriteLine($"Username: {user.Name.PadRight(10)}\tEmail: {user.UserAdditionalInfo.Email} ");

        "From SQL".EndSection();
    }
}
