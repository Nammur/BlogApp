using BlogApp.Entities;
using BlogApp.Services.Interfaces;
using BlogApp.Utils;

namespace BlogApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> RegisterAsync(string username, string password)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }

            var newUser = new User { Username = username, PasswordHash = BCrypt.Net.BCrypt.HashPassword(password) };
            await _userRepository.AddUserAsync(newUser);


            var token = JwtTokenGenerator.GenerateToken(newUser, "UmaChaveMuitoGrandeEEAleatoria#123456789012345678901234567890", 60);

            return token;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                var token = JwtTokenGenerator.GenerateToken(user, "UmaChaveMuitoGrandeEEAleatoria#123456789012345678901234567890", 60);
                return token;
            }
            return null;
        }
    }
}
