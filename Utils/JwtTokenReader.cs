using System.IdentityModel.Tokens.Jwt;

namespace BlogApp.Utils
{
    public static class JwtTokenReader
    {
        public static int ExtractUserIdFromToken(string token)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadToken(token) as JwtSecurityToken;
            var userId = int.Parse(jwtToken.Claims.FirstOrDefault(claim => claim.Type == "userId")?.Value);

            return userId;
        }
    }
}