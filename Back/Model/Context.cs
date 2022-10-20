using System;
using Microsoft.EntityFrameworkCore;

namespace Model;

public class Context : DbContext
{
    public DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Data Source=" + Environment.MachineName + ";Initial Catalog=Birl; Integrated Security=True");
        optionsBuilder.UseSqlServer("Data Source=SNCCH01LABF104\\SQLEXPRESS;Initial Catalog=Birl; Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>{
            entity.HasKey(u => u.id);
            entity.Property(u => u.nome).IsRequired();
            entity.Property(u => u.login).IsRequired();
            entity.Property(u => u.senha).IsRequired();
        });
    }
}