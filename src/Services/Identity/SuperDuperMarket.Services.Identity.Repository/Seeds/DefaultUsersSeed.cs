﻿using Microsoft.AspNetCore.Identity;
using SuperDuperMarket.Core;
using SuperDuperMarket.Core.EntityFrameworkCore.Abstractions;
using SuperDuperMarket.Services.Identity.Domains;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using IdentityModel;
using Serilog;

namespace SuperDuperMarket.Services.Identity.Repository.Seeds
{
    public class DefaultUsersSeed(IServiceScopeFactory serviceScopeFactory) : ISeedingService
    {
        protected readonly IServiceScopeFactory serviceScopeFactory = Throw.IfNull(serviceScopeFactory);

        public Task SeedAsync(CancellationToken cancellationToken = default)
        {
            using var scope = serviceScopeFactory.CreateScope();

            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var alice = userMgr.FindByNameAsync("alice").Result;
            if (alice == null)
            {
                alice = new User
                {
                    UserName = "alice",
                    Email = "AliceSmith@email.com",
                    EmailConfirmed = true,
                };
                var result = userMgr.CreateAsync(alice, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(alice, [
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Alice"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                ]).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("alice created");
            }
            else
            {
                Log.Debug("alice already exists");
            }

            var bob = userMgr.FindByNameAsync("bob").Result;
            if (bob == null)
            {
                bob = new User
                {
                    UserName = "bob",
                    Email = "BobSmith@email.com",
                    EmailConfirmed = true
                };
                var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(bob, [
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Bob"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                    new Claim("location", "somewhere")
                        ]).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("bob created");
            }
            else
            {
                Log.Debug("bob already exists");
            }

            return Task.CompletedTask;
        }
    }
}