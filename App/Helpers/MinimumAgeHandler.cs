﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.Helpers
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
               return Task.CompletedTask;                

            var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);

            var userAge = DateTime.Today.Year - dateOfBirth.Year;

            //To make sure we are not in a leap year
            if(dateOfBirth > DateTime.Today.AddYears(--userAge))
            {
                userAge--;
            }

            if (userAge >= requirement.MinimumAge) context.Succeed(requirement);

            return Task.CompletedTask;            
        }
    }
}
