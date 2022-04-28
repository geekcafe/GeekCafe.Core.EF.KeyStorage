﻿#if DEBUG
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GeekCafe.Core.EF.KeyStorage.MySql
{
    /// <summary>
    /// Factory for creating a db context. Only used in dev mode
    /// when creating migrations.
    /// </summary>
    //[NoCoverage]
    public class DbFactory : IDesignTimeDbContextFactory<MySqlKeyContext>
    {

        public DbFactory (){
            Console.WriteLine("Init DbFactory");
        }
        /// <summary>
        /// Creates a new db context.
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <returns>The db context</returns>
        public MySqlKeyContext CreateDbContext(string[] args)
        {
            Console.WriteLine($"CreateDbContext");
            var connectionString = "server=localhost;port=3306;database=keystorage;uid=geekcafe;password=password";

            // if (Environment.GetEnvironmentVariable("KEYSTORAGE_CONN_STRING") != null)
            // {
            //     connectionString = Environment.GetEnvironmentVariable("KEYSTORAGE_CONN_STRING");

            // }

            var builder = new DbContextOptionsBuilder<MySqlKeyContext>();
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new MySqlKeyContext(builder.Options);
        }
    }
}

#endif