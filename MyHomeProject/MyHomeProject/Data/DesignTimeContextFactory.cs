using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyHomeProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeProject.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyHomeProjectContext>
    {
        MyHomeProjectContext IDesignTimeDbContextFactory<MyHomeProjectContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MyHomeProjectContext>();
            var connectionString = configuration.GetConnectionString("MyHomeProjectContext");
            builder.UseSqlServer(connectionString);
     
            return new MyHomeProjectContext(builder.Options);
        }
    }
}
