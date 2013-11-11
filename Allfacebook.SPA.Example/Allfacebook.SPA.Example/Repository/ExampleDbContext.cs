using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Allfacebook.SPA.Example.Repository
{
    public class ExampleDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public ExampleDbContext()
            : base("ExampleData")
        {
        }

        public static void CreateDatabase()
        {
            using (var ctx = new ExampleDbContext())
            {
                ctx.Database.Initialize(false);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configure<Message>(
                modelBuilder,
                entity =>
                    {
                        entity.ToTable("Message");
                        entity
                            .Property(e => e.Id)
                            .HasColumnName("Id")
                            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                        entity.HasKey(e => e.Id);
                        entity.Property(x => x.User);
                        entity.Property(x => x.MessageText);
                        entity.Property(x => x.ReceiveDate);
                    });
        }

        private void Configure<T>(DbModelBuilder modelBuilder, Action<EntityTypeConfiguration<T>> configureEntityMethod)
            where T : class
        {
            EntityTypeConfiguration<T> entityConfig = modelBuilder.Entity<T>();
            configureEntityMethod(entityConfig);
        }
    }
}