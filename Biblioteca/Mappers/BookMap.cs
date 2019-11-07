using Biblioteca.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Mappers
{
    public class BookMap
    {
        //esta es la clase donde me crea la relacion y los atributos en la db.
        public BookMap(EntityTypeBuilder<Book> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(t=>t.Id);
            entityTypeBuilder.Property(t => t.Name).IsRequired();
            entityTypeBuilder.Property(t => t.Publisher).IsRequired();
            entityTypeBuilder.Property(t => t.ISBN).IsRequired();
            entityTypeBuilder.HasOne(e => e.Author).WithMany(e => e.Books).HasForeignKey(e => e.AuthorId);
        }
    }
}
