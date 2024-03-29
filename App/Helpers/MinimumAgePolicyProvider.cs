﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace App.Helpers
{
    public class MinimumAgePolicyProvider : IAuthorizationPolicyProvider
    {
        const string POLICY_PREFIX = "MinimumAge";
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {            
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser();
            return Task.FromResult(policy.Build());
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            //Parsing the age from policy name
            //Create a new AuthorizationPolicy
            //Adding Requirements

            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase)
                && int.TryParse(policyName.Substring(POLICY_PREFIX.Length), out var age))
            {

                var policy = new AuthorizationPolicyBuilder();
                policy.AddRequirements(new MinimumAgeRequirement(age));
                return Task.FromResult(policy.Build());
            }
            return Task.FromResult<AuthorizationPolicy>(null);
        }
    }
}
