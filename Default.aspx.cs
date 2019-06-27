using Mailman.Models;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mailman
{
    public partial class _Default : Page
    {
        private MailmanDBContext _context = new MailmanDBContext();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<MailingList> GetMailingLists()
        {
            var dbContext = new MailmanDBContext();
            IQueryable<MailingList> lists = dbContext.MailingLists;
            return lists;
        }

        protected void listEdit_Click(object sender, CommandEventArgs e)
        {
            string arg = e.CommandArgument as string;
        }

        protected void listDelete_Click(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument as string);
            var matchingList = _context.MailingLists.FirstOrDefault(ml => ml.MailingListID == id);
            if (matchingList == null) throw new Exception("Could not find a list with that ID");
            _context.MailingLists.Remove(matchingList);
            _context.SaveChanges();
            Response.Redirect("~/Default", false);
        }

        protected void NewList_Create_Click(object sender, EventArgs e)
        {
            string name = NewList_Name.Text;
            string description = NewList_Description.Text;

            // TODO: better validation
            if (string.IsNullOrEmpty(name)) throw new Exception("name cannot be empty");
            if (string.IsNullOrEmpty(description)) throw new Exception("description cannot be empty");

            _context.MailingLists.Add(new MailingList()
            {
                Name = name,
                Description = description,
            });
            _context.SaveChanges();
            Response.Redirect("~/Default", false);
        }
    }
}