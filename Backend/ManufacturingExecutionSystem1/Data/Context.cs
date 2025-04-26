using ManufacturingExecutionSystem1.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem1.Data
{
  public class Context : DbContext
  {
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }
    public DbSet<ProgProfil> ProgProfils { get; set; } = default!;
    public DbSet<Caracters> Caracters { get; set; } = default!;
    public DbSet<CaractersStartOfShiftValues> CaractersStartOfShiftValues { get; set; } = default!;
    public DbSet<CaracterValues> CaracterValues { get; set; } = default!;
    public DbSet<Machine> Machine { get; set; } = default!;
    public DbSet<Process> Process { get; set; } = default!;
    public DbSet<Process_ProfilUser> Process_ProfilUsers { get; set; } = default!;
    public DbSet<Product> Product { get; set; } = default!;
    public DbSet<ProfilUser> ProfilUser { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      /* modelBuilder.Entity<Process_ProfilUser>().HasKey(p => new { p.CodeProcess, p.Id_Profil });
       modelBuilder.Entity<Process_ProfilUser>().HasOne(p => p.Process).WithMany(p => p.process_ProfilUsers).HasForeignKey(fk => fk.CodeProcess);
       modelBuilder.Entity<Process_ProfilUser>().HasOne(p => p.ProfilUser).WithMany(p => p.Process_ProfilUsers).HasForeignKey(fk => fk.Id_Profil);
       modelBuilder.Entity<Process>().HasMany(p => p.Machines).WithOne(p => p.Process).HasForeignKey(m => m.CodeProcess);
       modelBuilder.Entity<Process>().HasMany(p => p.Products).WithOne(p => p.Process).HasForeignKey(m => m.CodeProcess).OnDelete(DeleteBehavior.Cascade);
       modelBuilder.Entity<Process>().HasMany(p => p.Caracters).WithOne(p => p.Process).HasForeignKey(m => m.CodeProcess);
       modelBuilder.Entity<Process>().HasMany(p => p.process_ProfilUsers).WithOne(p => p.Process).HasForeignKey(m => m.CodeProcess);
       modelBuilder.Entity<Machine>().HasMany(m => m.CaractersStartOfShiftValues).WithOne(c => c.Machine).HasForeignKey(c => c.Machine_Code);
       modelBuilder.Entity<Caracters>().HasMany(m => m.CaracterValues).WithOne(c => c.Caracters).HasForeignKey(c => c.CodeCaracter);
      */
      modelBuilder.Entity<Product>(entity =>
      {
        entity.HasKey(e => e.ItemCode);
        entity.HasOne(p => p.Process).WithMany(e => e.Products).HasForeignKey(p => p.CodeProcess).OnDelete(DeleteBehavior.Cascade);

      });
      modelBuilder.Entity<Machine>(entity =>
      {
        entity.HasKey(e => e.Machine_Code);
        entity.HasOne(m => m.Process).WithMany(e => e.Machines).HasForeignKey(m => m.CodeProcess).OnDelete(DeleteBehavior.Cascade);

      });
      modelBuilder.Entity<Caracters>(entity =>
      {
        entity.HasKey(e => e.CodeCaracter);
        entity.HasOne(c=>c.Process).WithMany(p=>p.Caracters).HasForeignKey(c=>c.CodeProcess).OnDelete(DeleteBehavior.Cascade);
      });
      
      modelBuilder.Entity<CaractersStartOfShiftValues>(entity =>
      {
        entity.HasKey(e => e.CodeCaracterStartOFShift);
        entity.HasOne(c=>c.Machine).WithMany(m=>m.CaractersStartOfShiftValues).HasForeignKey(c=>c.Machine_Code).OnDelete(DeleteBehavior.Cascade);
      });
      modelBuilder.Entity<CaracterValues>(entity =>
      {
        entity.HasKey(e=>e.IDCaracterValues);
        entity.HasOne(c => c.Caracters).WithMany(c => c.CaracterValues).HasForeignKey(e => e.CodeCaracter).OnDelete(DeleteBehavior.Cascade);
      });
      modelBuilder.Entity<Process_ProfilUser>(entity =>
      {
        entity.HasKey(p => new { p.CodeProcess, p.Id_Profil });
        entity.HasOne(p=>p.Process).WithMany(p=>p.Process_ProfilUsers).HasPrincipalKey(p=>p.CodeProcess).OnDelete(DeleteBehavior.Cascade);
        entity.HasOne(p => p.ProfilUser).WithMany(p => p.Process_ProfilUsers).HasPrincipalKey(p => p.Id_Profil).OnDelete(DeleteBehavior.Cascade);

      });
      modelBuilder.Entity<ProgProfil>(entity =>
      {
        entity.HasKey(e=>e.IDProgProfil);
        entity.HasOne(p => p.ProfilUser).WithMany(u => u.ProgProfiles).HasForeignKey(p => p.Id_Profil).OnDelete(DeleteBehavior.Cascade);
        });
    }
  }
}
