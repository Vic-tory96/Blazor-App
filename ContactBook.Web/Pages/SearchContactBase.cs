using ContactBook.Web.Services;
using ContactBookModels;
using Microsoft.AspNetCore.Components;

namespace ContactBook.Web.Pages
{
    

        public class SearchContactBase : ComponentBase
        {
            [Inject]
            protected NavigationManager navigationManager { get; set; }
            public List<Contact> _Contacts = new List<Contact>();
            [Inject]
            public IContactServices ContactServices { get; set; }
            [Parameter]

            public string Name { get; set; }


            protected async Task SearchContactByName()
            {
                _Contacts = await ContactServices.SearchContactByName(Name);

                // navigationManager.NavigateTo("/");
            }
        }
    
}

