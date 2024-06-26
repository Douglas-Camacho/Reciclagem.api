namespace Reciclagem.api.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _user = new List<UserModel>
        {
            new UserModel { UserId = 1, Username = "operador", Senha = "123", Role = "operador" },
            new UserModel { UserId = 2, Username = "operador1", Senha = "123", Role = "operador" },
            new UserModel { UserId = 3, Username = "analista", Senha = "123", Role = "analista" },
            new UserModel { UserId = 1, Username = "diretor", Senha = "123", Role = "diretor" },
        };

        public UserModel Authenticate(string username, string senha)
        {
            return _user.FirstOrDefault(u => u.Username == username && u.Senha == senha);
        }
    }
}
