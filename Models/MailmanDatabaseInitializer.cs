using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Mailman.Models
{
    public class MailmanDatabaseInitializer: DropCreateDatabaseIfModelChanges<MailmanDBContext> {
        protected override void Seed(MailmanDBContext context) {
            context.Users.AddRange(SeedUsers());
            context.MailingLists.AddRange(SeedMailingLists());
        }

        private static User User_Annie = new User
        {
            ID = 1,
            FirstName = "Annie",
            LastName = "Adams",
            EmailAddress = "aa@mail.com"
        };

        private static User User_Bob = new User
        {
            ID = 2,
            FirstName = "Bob",
            LastName = "Barker",
            EmailAddress = "bb@mail.com"
        };

        private static User User_Chris = new User
        {
            ID = 3,
            FirstName = "Christopher",
            LastName = "Colombus",
            EmailAddress = "cc@mail.com"
        };

        private static User User_Danny = new User
        {
            ID = 4,
            FirstName = "Danny",
            LastName = "DeVito",
            EmailAddress = "dd@mail.com"
        };

        private static IEnumerable<User> SeedUsers() {
            yield return User_Annie;
            yield return User_Bob;
            yield return User_Chris;
            yield return User_Danny;
        }

        private static IEnumerable<MailingList> SeedMailingLists()
        {
            yield return new MailingList
            {
                ID = 1,
                Name = "Cat Facts",
                Description = "Every day, we send an interesting fact about cats",
                Subscribers = new List<User>(SeedUsers().Take(3))
            };
            yield return new MailingList
            {
                ID = 2,
                Name = "Emacs vs. Vim Debate Club",
                Description = "Let's get ready to rumble!",
                Subscribers = new List<User>(SeedUsers().Skip(2))
            };
        }
    }
}