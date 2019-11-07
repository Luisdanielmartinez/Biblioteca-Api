using Biblioteca.Mappers;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.ViewModel;

namespace Biblioteca.DbContextAplication
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AuthorMap(modelBuilder.Entity<Author>());
            new BookMap(modelBuilder.Entity<Book>());
        }
        public DbSet<Biblioteca.ViewModel.AuthorListingViewModel> AuthorListingViewModel { get; set; }
        public DbSet<Biblioteca.ViewModel.AuthorBookViewModel> AuthorViewModel { get; set; }
    }
}
