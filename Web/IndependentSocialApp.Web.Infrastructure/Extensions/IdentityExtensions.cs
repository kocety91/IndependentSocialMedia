﻿namespace IndependentSocialApp.Web.Infrastructure.Extensions
{
    using System.Linq;
    using System.Security.Claims;

    public static class IdentityExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
        {
            return user
                .Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                ?.Value;
        }
    }
}
