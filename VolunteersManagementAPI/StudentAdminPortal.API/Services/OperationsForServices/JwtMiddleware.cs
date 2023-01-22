using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using VolunteersManagement.API.Services.UserService;

namespace VolunteersManagement.API.Services.OperationsForServices
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate nextRequestDelegate;

        public JwtMiddleware(RequestDelegate nextRequestDelegate)
        {
            this.nextRequestDelegate = nextRequestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService, IJwtUtils jwtUtils)
        {
            
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault();
            var userId = jwtUtils.ValidateJwtToken(token);
       
            //user was validated
            if (userId!= Guid.Empty)
            {
                httpContext.Items["User"]=userService.GetbyID(userId).Result;
                
            }
            await nextRequestDelegate(httpContext);

        }
        
        
        }
    }

 