namespace Reciclagem.api.Services
{
    public interface IEmailService
    {
        void EnviarEmail(string para, string assunto, string mensagem);
    }
}

