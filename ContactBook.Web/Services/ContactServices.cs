using ContactBookModels;
using System.Net.Http;

namespace ContactBook.Web.Services
{
    public class ContactServices : IContactServices
    {
        private readonly HttpClient _httpClient;
        public ContactServices(HttpClient httpClient)
        {
            _httpClient = httpClient; 
        }

        public async Task<Contact> CreateContact(Contact newContact)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/Contact", newContact);
            response.EnsureSuccessStatusCode();
            Contact createdContact = await response.Content.ReadFromJsonAsync<Contact>();
            return createdContact;
        }

        public async Task DeleteContact(int id)
        {
            await _httpClient.DeleteAsync($"/api/Contact/{id}");
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _httpClient.GetFromJsonAsync<Contact>($"/api/Contact/{id}");
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _httpClient.GetFromJsonAsync<Contact[]>("/api/Contact");
        }

        public async Task<List<Contact>> SearchContactByName(string Name)
        {
            return await _httpClient.GetFromJsonAsync<List<Contact>>($"api/Contact/search?name={Name}");
        }

        async Task<HttpResponseMessage> IContactServices.UpdateContact(Contact updatedContact)
         {
            return await _httpClient.PutAsJsonAsync("/api/Contact", updatedContact);
         }

    } 
}
