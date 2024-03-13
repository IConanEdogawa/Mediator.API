using Mediator.Applicition.Abstractions;
using Mediator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Infrastructure.Persisnatce
{
    public class ApplicitionDbContext : DbContext, IApplicitionDbContext
    {
        public ApplicitionDbContext(DbContextOptions<ApplicitionDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
    }
}
