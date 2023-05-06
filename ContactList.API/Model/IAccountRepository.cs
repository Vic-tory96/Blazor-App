using ContactBookModels;
using Microsoft.AspNetCore.Identity;

namespace ContactList.API.Model
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(Signup signup, string role);
        Task<string> LoginAsync(Login login);
    }
}
