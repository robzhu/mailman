using Mailman.Models;
using Mailman.Utils;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mailman
{
    public partial class UserDetailsPage : Page
    {
        private MailmanDBContext _context = new MailmanDBContext();
        private User Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string idFromQueryString = Request["id"];
            if (string.IsNullOrEmpty(idFromQueryString)) return;
            int id = -1;
            if (!int.TryParse(Request["id"], out id)) return;
            Model = _context.Users.FirstOrDefault(user => user.ID == id);
        }

        public User LoadModel()
        {
            return this.Model;
        }

        protected void buttonUnsubscribe_Command(object sender, CommandEventArgs e)
        {
            int listID = int.Parse(e.CommandArgument as string);
            _context.UnsubscribeUserFrom(Model, listID);
            this.RefreshSelf();
        }

        protected void buttonSubscribe_Command(object sender, CommandEventArgs e)
        {
            int listID = int.Parse(e.CommandArgument as string);
            _context.SubscribeUserToList(Model, listID);
            this.RefreshSelf();
        }

        public IQueryable<MailingList> GetUserSubscriptions()
        {
            return Model.Lists.AsQueryable();
        }

        public IQueryable<MailingList> GetAvailableSubscriptions()
        {
            return _context.GetAvailableSubscriptionsForUser(Model).AsQueryable();
        }
    }
}