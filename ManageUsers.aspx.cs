using Mailman.Models;
using Mailman.Utils;
using System;
using System.Linq;
using System.Web.UI;

namespace Mailman
{
    public partial class ManageUsers : Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        public IQueryable<User> GetAllUsers()
        {
            var db = new MailmanDBContext();
            return db.Users.AsQueryable();
        }

        protected void buttonAddUser_Click(object sender, EventArgs e)
        {
            var context = new MailmanDBContext();
            context.AddNewUser(
                this.textFirstName.Text,
                this.textLastName.Text,
                this.textEmail.Text
            );
            this.RefreshSelf();
        }
    }
}