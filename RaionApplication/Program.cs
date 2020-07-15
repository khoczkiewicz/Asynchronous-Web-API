// <copyright file="Program.cs" company="RAION SOFTWARE Sp. z o.o.">
// Copyright (c) RAION SOFTWARE Sp. z o.o.. All rights reserved.
// </copyright>

namespace RaionApplication
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
