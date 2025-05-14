using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Infrastracture.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            Microsoft.Extensions.Logging.ILoggerFactory logger,
            System.Text.Encodings.Web.UrlEncoder encoder,
            Microsoft.AspNetCore.Authentication.ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            return Task.FromResult(AuthenticateResult.Fail("Authorization Header Not Found"));

                try
                {
                    var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                    var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                    var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                    var username = credentials[0];
                    var password = credentials[1];

                    if (username != "meyer" || password != "Kth26*98.")
                    {
                        return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));
                    }
                        

                    var claims = new[] {
                        new Claim(ClaimTypes.NameIdentifier, username),
                        new Claim(ClaimTypes.Name, username)
                    };

                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }
                catch
                {
                    return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
                }
        }            
        
    }
}