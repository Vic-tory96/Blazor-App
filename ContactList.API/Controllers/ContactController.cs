using ContactBookModels;
using ContactList.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Contact>>> Search(string name)// Gender? gender)
        {
            try
            {
                var result = await _contactRepository.Search(name); //gender);

                return Ok(result);

                //if (result.Any())
                //{
                //    return Ok(result);
                //}

               // return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetContacts(int page = 1, int perpage = 5)
        {
            try
            {
               

                var result = await _contactRepository.GetContacts();


                if (result.Count() > 0)
                {
                    var pagedContacts = _contactRepository.Paginate(result.ToList(), perpage, page);

                    return Ok(pagedContacts);
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }

        }

            [HttpGet("{id:int}")]
            public async Task<ActionResult<Contact>> GetContact(int id)
            {

                try
                {
                    var result = await _contactRepository.GetContact(id);

                    if (result == null)
                    {

                        return NotFound();

                    }

                    return Ok(result);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
                }

            }
            [HttpPost]
            public async Task<ActionResult<Contact>> CreateContact(Contact contact)
            {
                try
                {
                    if (contact == null)
                    {
                        return BadRequest();
                    }
                    var createdContact = await _contactRepository.AddContact(contact);

                    return CreatedAtAction(nameof(CreateContact), new { id = createdContact.ContactId }, createdContact);

                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
                }
            }
             [HttpPut()]

        public async Task<ActionResult<Contact>> UpdateContact( Contact contact)
            {
                try
                {
                    var contactToUpdate = await _contactRepository.GetContact(contact.ContactId);

                    if (contactToUpdate == null)
                    {
                        return NotFound($"Contact with Id = {contact.ContactId} not found");
                    }
                    return await _contactRepository.UpdateContact(contact);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
                }
            }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {
            try
            {
               var contactToDelete= await _contactRepository.GetContact(id);
                if(contactToDelete == null)
                {
                    return NotFound($"Contact with Id = {id} not found");
                }

                return await _contactRepository.DeleteContact(id);
            }

            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
        
    }
}
