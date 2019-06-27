using Mailman.Models;
using System;
using System.Linq;
using System.Web.UI;

namespace Mailman
{
    public partial class ManageUsers : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<User> GetAllUsers()
        {
            var db = new MailmanDBContext();
            return db.Users.AsQueryable();
        }
    }
}