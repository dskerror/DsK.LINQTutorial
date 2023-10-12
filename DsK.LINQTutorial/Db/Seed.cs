using DsK.LINQTutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DsK.LINQTutorial.Db;
public static class Seed
{
    public static void Run()
    {
        using (var db = new LinqtutorialDbContext())
        {
            db.Database.ExecuteSql($"TRUNCATE Table UserGames");
            db.Database.ExecuteSql($"TRUNCATE Table UserAdditionalInfo");
            db.Database.ExecuteSql($"DELETE FROM Users");
            db.Database.ExecuteSql($"DBCC CHECKIDENT('LINQTutorialDB.dbo.Users', RESEED, 0)");
            db.Database.ExecuteSql($"DELETE FROM Games");
            db.Database.ExecuteSql($"DBCC CHECKIDENT('LINQTutorialDB.dbo.Games', RESEED, 0)");

            db.Database.EnsureCreated();

            var game1 = new Game { Name = "Overwatch" };
            var game2 = new Game { Name = "Call Of Duty" };
            var game3 = new Game { Name = "Spide Man 2" };
            var game4 = new Game { Name = "Fortnite" };
            var game5 = new Game { Name = "Counter Strike 2" };
            db.Games.Add(game1);
            db.Games.Add(game2);
            db.Games.Add(game3);
            db.Games.Add(game4);
            db.Games.Add(game5);
            db.SaveChanges();


            var user1 = new User { Name = "Ruben" };
            var user2 = new User { Name = "Rafael" };
            var user3 = new User { Name = "Natcel" };
            var user4 = new User { Name = "Edwin" };
            var user5 = new User { Name = "Carlos" };
            db.Users.Add(user1);
            db.Users.Add(user2);
            db.Users.Add(user3);
            db.Users.Add(user4);
            db.Users.Add(user5);
            db.SaveChanges();

            user1.Games.Add(game1);
            user1.Games.Add(game2);
            user2.Games.Add(game1);
            user2.Games.Add(game3);
            user3.Games.Add(game1);
            user3.Games.Add(game4);
            user4.Games.Add(game1);
            user4.Games.Add(game5);
            user5.Games.Add(game2);
            user5.Games.Add(game4);
            db.SaveChanges();



            var useraddinfo1 = new UserAdditionalInfo { Email = "ruben.negron@optimapr.com", UserId = user1.Id };
            var useraddinfo2 = new UserAdditionalInfo { Email = "rafael.ramirez@optimapr.com", UserId = user2.Id };
            var useraddinfo3 = new UserAdditionalInfo { Email = "natcel.nieves@optimapr.com", UserId = user3.Id };
            var useraddinfo4 = new UserAdditionalInfo { Email = "edwin.gonzalez@optimapr.com", UserId = user4.Id };
            var useraddinfo5 = new UserAdditionalInfo { Email = "carlos.negron@optimapr.com", UserId = user5.Id };
            db.UserAdditionalInfos.Add(useraddinfo1);
            db.UserAdditionalInfos.Add(useraddinfo2);
            db.UserAdditionalInfos.Add(useraddinfo3);
            db.UserAdditionalInfos.Add(useraddinfo4);
            db.UserAdditionalInfos.Add(useraddinfo5);
            db.SaveChanges();
        }
    }
}
