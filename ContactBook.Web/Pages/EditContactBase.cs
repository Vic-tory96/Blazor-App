
using ContactBookModels;
using ContactBook.Web.Services;
using Microsoft.AspNetCore.Components;

namespace ContactBook.Web.Pages
{
    public class EditContactBase : ComponentBase
    {
        [Inject]
        public IContactServices ContactServices { get; set; }

        public Contact Contact { get; set; } = new Contact();
        

        [Parameter]
        public string Id { get; set; }

        

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {  
                Contact = await ContactServices.GetContact(int.Parse(Id));
        }
        protected async Task HandleValidSubmit()
        {
            var result = await ContactServices.UpdateContact(Contact);

            if(result != null)
            {
                NavigationManager.NavigateTo("/");

            }
        }
        protected async Task Delete_Click()
        {
            await ContactServices.DeleteContact(Contact.ContactId);
            NavigationManager.NavigateTo("/");
        }
    }
}
