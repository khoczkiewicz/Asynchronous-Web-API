// <copyright file="RaionApplicationContext.cs" company="RAION SOFTWARE Sp. z o.o.">
// Copyright (c) RAION SOFTWARE Sp. z o.o.. All rights reserved.
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
