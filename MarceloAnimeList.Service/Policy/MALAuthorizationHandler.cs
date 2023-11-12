using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace MarceloAnimeList.Service.Policy
{
    public class MALAuthorizationHandler : AuthorizationHandler<MALAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            MALAuthorizationRequirement requirement)
        {
            // Check if the user is authenticated
            if (!context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // Retrieve the JWT token from the current user's claims
            var jwtTokenClaim = context.User.FindFirst(c => c.Type == JwtRegisteredClaimNames.Jti);

            if (jwtTokenClaim == null || string.IsNullOrEmpty(jwtTokenClaim.Value))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // Validate the JWT token
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var token = tokenHandler.ReadToken(jwtTokenClaim.Value) as JwtSecurityToken;

                // You can add custom validation logic here if needed.
                // For example, you can check the token's expiration, issuer, audience, etc.

                // If the token is valid, succeed the authorization requirement.
                context.Succeed(requirement);
            }
            catch
            {
                // Token validation failed, so fail the authorization requirement.
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
