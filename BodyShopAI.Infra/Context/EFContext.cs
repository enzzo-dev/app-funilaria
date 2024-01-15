using BodyShopAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyShopAI.Infra.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> context) : base(context)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Error> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Entity Mappers

            SetColumnRelations(builder);
            SetColumnProperties(builder);

            #endregion

        }

        #region Private Methods

        private void SetColumnProperties(ModelBuilder builder)
        {
            #region Users
            builder.Entity<User>()
                .Property(p => p.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Entity<User>()
                .Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Entity<User>()
                .Property(p => p.Password)
                .IsRequired();

            #endregion

            #region Cars
            builder.Entity<Car>()
                .Property(p => p.Plate)
                .HasMaxLength(15)
                .IsRequired();

            builder.Entity<Car>()
                 .Property(p => p.Model)
                 .HasMaxLength(25)
                 .IsRequired();

            builder.Entity<Car>()
                 .Property(p => p.Brand)
                 .HasMaxLength(20)
                 .IsRequired();

            #endregion

            #region Error
            builder.Entity<Error>()
                .Property(p => p.LogError)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Entity<Error>()
                .Property(p => p.StackTrace)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Entity<Error>()
                .Property(p => p.ClassName)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Entity<Error>()
                .Property(p => p.Exception)
                .HasColumnType("varchar(max)")
                .IsRequired();
            #endregion
        }

        private void SetColumnRelations(ModelBuilder builder)
        {
            #region User & Car

            builder.Entity<User>()
                .ToTable("users")
                .HasKey(i => i.IdUser);

            builder.Entity<Car>()
                .ToTable("cars")
                .HasKey(i => i.IdCar);

            builder.Entity<Car>()
                .HasOne(p => p.User)
                .WithMany(p => p.OwnCar)
                .HasForeignKey(i => i.IdUser);

            #endregion

            #region Budget

            builder.Entity<Budget>()
                .ToTable("budgets")
                .HasKey(i => i.IdBudget);

            builder.Entity<Budget>()
                .HasOne(c => c.CarTarget)
                .WithMany(c => c.Budgets)
                .HasForeignKey(i => i.IdCar);

            #endregion

            #region Error
            builder.Entity<Error>()
                .ToTable("exceptions")
                .HasKey(i => i.IdError);
            #endregion
        }

        #endregion
    }
}
