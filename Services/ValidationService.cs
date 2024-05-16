using BlogApp.Entities;
using BlogApp.Services.Interfaces;
using BlogApp.Utils;

namespace BlogApp.Services
{
    public class ValidationService : IValidationService
    {        
        public bool ValidarUsuario(string tokenJwt, int idUser)
        {
            return JwtTokenReader.ExtractUserIdFromToken(tokenJwt) == idUser ? true : false;
        }
    }
}
