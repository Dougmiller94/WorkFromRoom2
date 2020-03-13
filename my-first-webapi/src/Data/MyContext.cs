using Microsoft.EntityFrameworkCore;
using src.Controllers;
using src.Persistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Data
{
    public class MyContext : DbContext 
    {
        public MyContext (DbContextOptions<MyContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasOne(note => note.NoteBook)
                .WithMany(notebook => notebook.Notes)
                .HasForeignKey(note => note.NotebookId);
        }


       public DbSet<Note> Note { get; set; }

        public DbSet<NoteBook> NoteBook { get; set; }
    }
}
