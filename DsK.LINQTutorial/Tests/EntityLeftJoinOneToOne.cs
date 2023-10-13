using DsK.LINQTutorial.Helpers;
using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace DsK.LINQTutorial.Tests;
public static class EntityLeftJoinOneToOne
{
    public static void Test(LinqtutorialDbContext db)
    {
        "LINQ".StartSection();
        //TODO: See if this can return Users.UserAdditionalInfo filled            
        var LINQ = from u in db.Users
                   join uai in db.UserAdditionalInfos on u.Id equals uai.UserId into newuai
                   from x in newuai.DefaultIfEmpty()
                   select new { u = u, uai = x == null ? new UserAdditionalInfo() : x };

        LINQ.ToQueryString().ShowQuery();

        foreach (var user in LINQ)
            Console.WriteLine($"Username: {user.u.Name.PadRight(10)}\tEmail: {user.uai.Email} ");

        "LINQ".EndSection();



        "Lambda".StartSection();

        var LambdaQuery = db.Users.Include(x => x.UserAdditionalInfo);

        LambdaQuery.ToQueryString().ShowQuery();

        var LambdaList = LambdaQuery.ToList();

        foreach (var user in LambdaList)
            Console.WriteLine($"Username: {user.Name.PadRight(10)}\tEmail: {(user.UserAdditionalInfo == null ? "" : user.UserAdditionalInfo.Email)} ");

        "Lambda".EndSection();


        "From SQL".StartSection();

        var FromSQLQuery = db.Users.FromSql($"SELECT a.*, b.Email FROM Users a LEFT JOIN UserAdditionalInfo b ON a.Id = b.UserId");
        FromSQLQuery.ToQueryString().ShowQuery();
        var FromSQLList = FromSQLQuery.ToList();
        foreach (var user in FromSQLList)
            Console.WriteLine($"Username: {user.Name.PadRight(10)}\tEmail: {(user.UserAdditionalInfo == null ? "" : user.UserAdditionalInfo.Email)} ");

        "From SQL".EndSection();
    }
}
