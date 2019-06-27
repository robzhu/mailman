using System;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Linq;
using Mailman.Models;
using System.Web.UI.WebControls;

namespace Mailman
{
    public partial class MailingListDetailsPage : Page
    {
        private MailmanDBContext _context = new MailmanDBContext();
        private MailingList Model { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            string idFromQueryString = Request["id"];
            if (string.IsNullOrEmpty(idFromQueryString)) return;
            int id = -1;
            if (!int.TryParse(Request["id"], out id)) return;
            Model = _context.MailingLists.FirstOrDefault(list => list.MailingListID == id);
        }

        public MailingList LoadModel()
        {
            return this.Model;
        }

        public IQueryable<User> GetListMembers([QueryString("id")] int? id)
        {
            return this.Model.Subscribers.AsQueryable();
        }

        protected void buttonUnsubscribe_Command(object sender, CommandEventArgs e)
        {
            int userID = int.Parse(e.CommandArgument as string);
            var matchingUser = Model.Subscribers.FirstOrDefault(user => user.UserID == userID);
            if (matchingUser == null) throw new Exception("No matching user found");

            Model.Subscribers.Remove(matchingUser);
            _context.SaveChanges();
            Response.Redirect("~" + Request.Url.PathAndQuery, false);
        }
    }
}