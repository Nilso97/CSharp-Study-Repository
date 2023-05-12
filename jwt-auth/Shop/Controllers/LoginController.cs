using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Models;
using Shop.Repositories;
using Shop.Services;

namespace Shop.Controllers
{
    [ApiController]
    [Route("v2/account")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user != null) 
            {
                var token = TokenService.GenerateToken(user);

                var refreshToken = TokenService.GenerateRefreshToken();
                TokenService.SaveRefreshToken(user.Username, refreshToken);

                user.Password = "";

                return new 
                {
                    user = user,
                    token = token,
                    refreshToken = refreshToken
                };
            }

            return NotFound(new { message = "Usuário ou senha inválidos!"});
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh(string token, string refreshToken)
        {
            var principal = TokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            var savedRefreshToken = TokenService.GetRefreshToken(username);

            if (savedRefreshToken != refreshToken)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            var newJwtToken = TokenService.GenerateToken(principal.Claims);
            var newRefreshToken = TokenService.GenerateRefreshToken();

            TokenService.DeleteRefreshToken(username, refreshToken);
            TokenService.SaveRefreshToken(username, newRefreshToken);

            return new ObjectResult(new 
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        } 
    }
}