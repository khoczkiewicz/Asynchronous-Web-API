// <copyright file="RaionApplicationContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RaionApplication.Models
{
    using Microsoft.EntityFrameworkCore;

    public class RaionApplicationContext : DbContext
    {
        public RaionApplicationContext(DbContextOptions<RaionApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<RaionApplication.Models.Item> Item { get; set; }
    }
}
