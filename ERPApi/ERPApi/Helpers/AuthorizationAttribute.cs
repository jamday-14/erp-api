using Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace ERPApi.Helpers
{
    public class AuthorizationAttribute : IAuthorizationFilter
    {
        private IUserService _userService;

        public AuthorizationAttribute(IUserService userService)
        {
            _userService = userService;
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

            var username = claims.FirstOrDefault(c => c.Type.ToLower() == "username").Value;
            var userId = claims.FirstOrDefault(c => c.Type.ToLower() == "userid").Value;

            var systemKeys = _userService.GetSystemKeys(username);

            if (!string.IsNullOrWhiteSpace(((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName) &&
                !systemKeys.Contains(((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName))
            {
                context.Result = new ForbidResult();
                return;
            }

            Statics.LoggedInUser = new CurrentUser
            {
                userId = Convert.ToInt32(userId),
                userName = username,
                companyId = 1
            };
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
