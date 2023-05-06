using ContactBookModels;
using ContactBook.Web.Services;
using Microsoft.AspNetCore.Components;

namespace ContactBook.Web.Pages
{
    public class CreateContactBase : ComponentBase
    {
        [Inject]
        public IContactServices ContactServices { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public Contact Contact { get; set; } = new Contact();

        protected async Task  HandleValidSubmit ()
        {
            var UpdatedContact = await ContactServices.CreateContact(Contact);

            if (UpdatedContact != null)
            {
                NavigationManager.NavigateTo("/");


            }

        }
    }
}
