using Microsoft.EntityFrameworkCore;
using PracticeApiProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApiProject.Data.Context
{
    public class CompanyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=ec2-54-247-158-179.eu-west-1.compute.amazonaws.com;Database=d1a2jd6pr2484v;UID=sqnuaniqvuocwr;PWD=8b5bd935ebbe80fdea565893d5e793cdf76ddfb0969741fab7bd1184be997831;SSL Mode= Require;TrustServerCertificate=True");
        }

        DbSet<Employee> Employees { get; set; }
    }
}
