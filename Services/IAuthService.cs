using Reciclagem.api.Models;

namespace Reciclagem.api.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string senha);
    }
}
