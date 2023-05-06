 using ContactBookModels;
using ContactBook.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.Xml;

namespace ContactBook.Web.Pages
{
    public class ContactListBase : ComponentBase
    {
        [Inject]
        public IContactServices ContactServices { get; set; }

        public bool ShowFooter { get; set; } = true;
        public IEnumerable<Contact> Contacts { get; set; }
         
        protected override async Task OnInitializedAsync()
        {   
           Contacts = (await ContactServices.GetContacts()).ToList();
             
        }

        protected async Task ContactDeleted()
        {
            Contacts = (await ContactServices.GetContacts()).ToList();
        }

        protected int SelectedContactCount { get; set; } = 0;

        protected void ContactSelectionChanged(bool isSelected)
        {
            if(isSelected)
            {
                SelectedContactCount++;
            }
            else
            {
                SelectedContactCount--;
            }
        }
    }
}
