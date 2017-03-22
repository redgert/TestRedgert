using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLLibrary;

namespace ovning30
{
    public partial class index : System.Web.UI.Page
    {
        List<Contact> contacts = new List<Contact>();
        public void RefreshListbox()
        {
            ListBoxContacts.Items.Clear();

            contacts = SQL.GetAllContacts();

            foreach (var contact in contacts)
            {
                ListBoxContacts.Items.Add($"{contact.Firstname} {contact.Lastname}");
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            contacts = SQL.GetAllContacts();

            if (!IsPostBack)
            {
                foreach (var contact in contacts)
                {
                    ListBoxContacts.Items.Add($"{contact.Firstname} {contact.Lastname}");
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            string firstName = TextBoxFirstname.Text.Trim();
            string lastName = TextBoxLastname.Text.Trim();

            if (firstName.Length > 0 && lastName.Length > 0)
            {
                Contact newContact = new Contact(0, firstName, lastName);

                SQL.AddContact(lastName, firstName);

                contacts = SQL.GetAllContacts();

                ListBoxContacts.Items.Clear();

                foreach (var contact in contacts)
                {
                    ListBoxContacts.Items.Add($"{contact.Firstname} {contact.Lastname}");
                }

                TextBoxFirstname.Text = "";
                TextBoxLastname.Text = "";
                RefreshListbox();
                Session["myContact"] = newContact.Firstname;
                Response.Redirect("nagotKul.aspx");
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string firstName = TextBoxFirstname.Text.Trim();
            string lastName = TextBoxLastname.Text.Trim();

            if (firstName.Length > 0 && lastName.Length > 0)
            {
                int index = ListBoxContacts.SelectedIndex;

                if (index > 0)
                {
                    int ID = contacts.ElementAt(index).ID;
                    SQL.UpdateContact(ID, lastName, firstName);

                    TextBoxFirstname.Text = "";
                    TextBoxLastname.Text = "";
                    contacts = SQL.GetAllContacts();
                    ListBoxContacts.Items.Clear();

                    foreach (var contact in contacts)
                    {
                        ListBoxContacts.Items.Add($"{contact.Firstname} {contact.Lastname}");
                    }
                    RefreshListbox();
                }
            }
        }

        protected void ButtonRemove_Click(object sender, EventArgs e)
        {
            string firstName = TextBoxFirstname.Text.Trim();
            string lastName = TextBoxLastname.Text.Trim();

            if (firstName.Length > 0 && lastName.Length > 0)
            {
                int index = ListBoxContacts.SelectedIndex;
                
                if (index > 0)
                {
                    int ID = contacts.ElementAt(index).ID;
                    SQL.RemoveContact(ID, lastName, firstName);

                    TextBoxFirstname.Text = "";
                    TextBoxLastname.Text = "";
                    contacts = SQL.GetAllContacts();
                    ListBoxContacts.ClearSelection();
                    RefreshListbox();
                }
            }
        }

        protected void ListBoxContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            contacts = SQL.GetAllContacts();
            TextBoxFirstname.Text = contacts[ListBoxContacts.SelectedIndex].Firstname;
            TextBoxLastname.Text = contacts[ListBoxContacts.SelectedIndex].Lastname;
        }
    }
}