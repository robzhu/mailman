using Mailman.Models;
using Mailman.Utils;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mailman
{
    public partial class _Default : Page
    {
        private MailmanDBContext _context = new MailmanDBContext();
        protected void Page_Load(object sender, EventArgs e) { }

        public IQueryable<MailingList> GetMailingLists()
        {
            var dbContext = new MailmanDBContext();
            IQueryable<MailingList> lists = dbContext.MailingLists;
            return lists;
        }

        protected void listDetails_Click(object sender, CommandEventArgs e)
        {
            string arg = e.CommandArgument as string;
        }

        protected void listDelete_Click(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument as string);
            _context.DeleteList(id);
            this.RefreshSelf();
        }

        protected void NewList_Create_Click(object sender, EventArgs e)
        {
            string name = NewList_Name.Text;
            string description = NewList_Description.Text;

            _context.CreateList(name, description);
            this.RefreshSelf();
        }
    }
}