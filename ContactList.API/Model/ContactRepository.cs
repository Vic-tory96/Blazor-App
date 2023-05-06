using ContactBookModels;
using Microsoft.EntityFrameworkCore;

namespace ContactList.API.Model
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _appDbContext;

        public ContactRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            var result =await _appDbContext.Contacts.AddAsync(contact);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Contact> DeleteContact(int contactId)
        {
           var result = await _appDbContext.Contacts
                .FirstOrDefaultAsync(c => c.ContactId == contactId);
            if(result != null)
            {
                _appDbContext.Contacts.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Contact> GetContact(int contactId)
        {
            return await _appDbContext.Contacts
                .FirstOrDefaultAsync(c => c.ContactId == contactId);

        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _appDbContext.Contacts.ToListAsync();
        }

        public IEnumerable<Contact> Paginate(List<Contact> contacts, int perpage, int page)
        {
            // return contacts.Skip(page - 1 * pageSize).Take(pageSize);
            page = page < 1 ? 1 : page; perpage = page < 1 ? 5 : perpage; if(contacts.Count > 0)
            {
                var paginated = contacts.Skip(page - 1).Take(perpage).ToList();
                return paginated;
            }
            return new List<Contact>();
        }

        public async Task<IEnumerable<Contact>> Search(string name)//Gender? gender)
        {
            IQueryable<Contact> query = _appDbContext.Contacts;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.FirstName.Contains(name) || c.LastName.Contains(name));
            }

            //if (gender != null)
            //{
            //    query = query.Where(c => c.Gender == gender);
            //}

            return await query.ToListAsync();
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            var result = await _appDbContext.Contacts.FirstOrDefaultAsync(c => c.ContactId == contact.ContactId);

            if(result != null)
            {
                result.FirstName = contact.FirstName;
                result.LastName = contact.LastName;
                result.Email = contact.Email;
                result.Occupation = contact.Occupation;
                result.DateOfBirth = contact.DateOfBirth;
                result.Gender = contact.Gender;
                result.Address = contact.Address;
                result.PhoneNumber = contact.PhoneNumber;
                result.PhotoPath = contact.PhotoPath;

                await _appDbContext.SaveChangesAsync();

                return result;

            }
            return null;
        }

    }
}
