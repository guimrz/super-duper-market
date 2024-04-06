﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperDuperMarket.Services.Identity.Domains;

namespace SuperDuperMarket.Services.Identity.Repository
{
    public class IdentityServiceDbContext(DbContextOptions<IdentityServiceDbContext> options) : IdentityDbContext<User>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
