using BlogApp.Entities;

namespace BlogApp.Services.Interfaces
{
    public interface IValidationService
    {
        bool ValidarUsuario(string tokenJwt, int idUser);
    }
}
