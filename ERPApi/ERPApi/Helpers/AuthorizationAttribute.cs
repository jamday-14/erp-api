using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace ERPApi.Helpers
{
    public class AuthorizationAttribute : IAuthorizationFilter
    {
        private IRepositoryWrapper _repo;

        public AuthorizationAttribute(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (IsAnonymousFilter(context))
                return;

            if (!IsUserAuthenticated(context))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var claims = context.HttpContext.User.Claims;
            var userName = claims.FirstOrDefault(c => c.Type.ToLower() == "username").Value;
        }

        private bool IsAnonymousFilter(AuthorizationFilterContext context)
        {
            return context.Filters.Any(item => item is IAllowAnonymousFilter);
        }

        private bool IsUserAuthenticated(AuthorizationFilterContext context)
        {
            return context.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
