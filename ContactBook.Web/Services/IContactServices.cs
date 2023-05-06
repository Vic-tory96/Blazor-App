using ContactBookModels;


namespace ContactBook.Web.Services
{
    public interface IContactServices
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContact(int id);
        Task<HttpResponseMessage> UpdateContact(Contact updatedContact);
        Task<List<Contact>> SearchContactByName(string Name);

        Task<Contact> CreateContact (Contact newContact);
        Task DeleteContact (int id);
    }
}
