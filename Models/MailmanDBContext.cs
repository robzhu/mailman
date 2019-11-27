using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Mailman.Models
{
    public class MailmanDBContext : DbContext
    {
        public MailmanDBContext() : base(DBConfig.GetConnectionString()) { }

        public DbSet<User> Users { get; set; }
        public DbSet<MailingList> MailingLists { get; set; }

        public bool DeleteList(int id)
        {
            var matchingList = MailingLists.FirstOrDefault(ml => ml.ID == id);
            if (matchingList == null) return false;
            MailingLists.Remove(matchingList);
            SaveChanges();
            return true;
        }

        public User AddNewUser(string firstName, string lastName, string email)
        {
            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = email,
            };
            Users.Add(user);
            SaveChanges();
            return user;
        }

        public MailingList CreateList(string name, string description)
        {
            // TODO: better validation
            if (string.IsNullOrEmpty(name)) throw new Exception("name cannot be empty");
            if (string.IsNullOrEmpty(description)) throw new Exception("description cannot be empty");

            var list = new MailingList()
            {
                Name = name,
                Description = description,
            };
            MailingLists.Add(list);
            SaveChanges();
            return list;
        }

        public void UnsubscribeUserFrom(User user, int listID)
        {
            var matchingList = MailingLists.FirstOrDefault(list => list.ID == listID);
            if (matchingList == null) return;
            user.Lists.Remove(matchingList);
            SaveChanges();
        }

        internal IEnumerable<MailingList> GetAvailableSubscriptionsForUser(User model)
        {
            foreach(var list in MailingLists)
            {
                if(!model.Lists.Contains(list))
                {
                    yield return list;
                }
            }
        }

        public void SubscribeUserToList(User user, int listID)
        {
            var matchingList = MailingLists.FirstOrDefault(list => list.ID == listID);
            if (matchingList == null) throw new Exception("List does not exist");
            user.Lists.Add(matchingList);
            SaveChangesAsync();
        }
    }
}