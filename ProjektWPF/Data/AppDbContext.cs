using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using ProjektWPF.Data;


/*namespace ProjektWPF.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteText> NoteTexts { get; set; }
        public DbSet<NoteCheckList> NoteCheckLists { get; set; }
        public DbSet<NoteLongFormat> NoteLongFormats { get; set; }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<NoteKeyword> NoteKeywords { get; set; }
        public DbSet<NoteHistory> NoteHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                var connectionString = config.GetConnectionString("DefaultConnection");
               // optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasDiscriminator<string>("NoteType")
                .HasValue<NoteText>("Text")
                .HasValue<NoteCheckList>("CheckList")
                .HasValue<NoteLongFormat>("LongFormat");

            base.OnModelCreating(modelBuilder);
        }
    }
}
*/


namespace ProjektWPF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSety główne
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteText> NoteTexts { get; set; }
        public DbSet<NoteCheckList> NoteCheckLists { get; set; }
        public DbSet<NoteLongFormat> NoteLongFormats { get; set; }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<NoteKeyword> NoteKeywords { get; set; }
        public DbSet<NoteHistory> NoteHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguracja dziedziczenia TPH (Table-per-Hierarchy)
            modelBuilder.Entity<Note>()
                .HasDiscriminator<string>("NoteType")
                .HasValue<NoteText>("Text")
                .HasValue<NoteCheckList>("CheckList")
                .HasValue<NoteLongFormat>("LongFormat");

            base.OnModelCreating(modelBuilder);
        }
    }
}