using Auction.Api.Entities;
using Auction.Api.Interfaces;
using Auction.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auction.Api.Services
{

    public class LoggedUser : ILoggedUser
    {
        private readonly IUserRepositories _repositories;
        private readonly IHttpContextAccessor _httpContext;
        public LoggedUser(IUserRepositories repositories, IHttpContextAccessor httpContext)
        {
            _repositories = repositories;
            _httpContext = httpContext;
        }
        public async Task<User> User()
        {
            var token = TokenOnRequest();
            var email = FromBase64String(token);
            var userLogged = await _repositories.GetUserLogged(email);
            return userLogged;
        }
        private string TokenOnRequest()
        {
            var authentication = _httpContext.HttpContext!.Request.Headers.Authorization.ToString();

            return authentication["Bearer ".Length..];
            //return authentication.Substring(7, authentication.Length);
        }

        private string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }

}
