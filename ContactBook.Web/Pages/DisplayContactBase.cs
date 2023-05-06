using ContactBookModels;
using ContactBook.Web.Services;
using Microsoft.AspNetCore.Components;

namespace ContactBook.Web.Pages
{
    public class DisplayContactBase : ComponentBase
    {
        [Parameter]
        public Contact Contact { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<bool> OnContactSelection { get; set; }

        [Parameter]
        public EventCallback<int> OnContactDeleted { get; set; }

        [Inject]
        public IContactServices ContactServices { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected ContactsComponent.ConfirmBase DeleteConfirmation { get; set; }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await ContactServices.DeleteContact(Contact.ContactId);
                    await OnContactDeleted.InvokeAsync(Contact.ContactId);
            }
        }
        protected async Task CheckBoxChanged (ChangeEventArgs e)
        {
          await  OnContactSelection.InvokeAsync((bool)e.Value);
        }

       
    }
}
