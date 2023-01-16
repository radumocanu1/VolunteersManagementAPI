using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using VolunteersManagement.API.Models;
using VolunteersManagement.API.Models.Enums;

namespace VolunteersManagement.API.Services.OperationsForServices
{
    public class Authorization : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Roles> roles;

        public Authorization(params Roles[] roles)
        {
            this.roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusObject = new JsonResult(new {Message="Nu ai permisiune pentru aceassta operatie" }){ StatusCode = StatusCodes.Status401Unauthorized};
            if (roles == null) 
            {
                context.Result = unauthorizedStatusObject;
            }
            var user = (User)context.HttpContext.Items["User"];
            if (user == null || !roles.Contains(user.role)) 
            {
                context.Result = unauthorizedStatusObject;

            }
        }
    }
}
