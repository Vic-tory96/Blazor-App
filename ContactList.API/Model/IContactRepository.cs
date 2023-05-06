using ContactBookModels;

namespace ContactList.API.Model
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> Search(string name);// Gender? gender);
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetContact(int contactId);
        Task<Contact> AddContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
        Task<Contact> DeleteContact(int contactId);
         IEnumerable<Contact> Paginate(List<Contact> contacts, int perpage, int page);
    }
}
