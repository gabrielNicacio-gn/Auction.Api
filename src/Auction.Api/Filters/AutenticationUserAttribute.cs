using Auction.Api.Interfaces;
using Auction.Api.Repositories;
using Auction.Api.Repositories.Data_Access;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Auction.Api.Filters
{
    public class AutenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IUserRepositories _repositories;
        public AutenticationUserAttribute(IUserRepositories repositories)
        {
            _repositories = repositories; 
        }
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context.HttpContext);
                var email = FromBase64String(token);

                var exist = await _repositories.ExistUserWithEmail(email);

                if (!exist)
                {
                    context.Result = new UnauthorizedObjectResult("Email not exist");
                }
            }
            catch (Exception ex)

            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }
        }

        private string TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();
            if (string.IsNullOrEmpty(authentication))
            {
                throw new InvalidOperationException("Token is missing");
            }
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
