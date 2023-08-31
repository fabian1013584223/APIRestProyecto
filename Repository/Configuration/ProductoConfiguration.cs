using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasData(
                new Producto
                {
                    Id = 1,
                    Nombre = "Computador Samsung 2018",
                    Cantidad = "1",
                    Precio = "2600000",
                    Estado = "Activo",
                    Lugar = "Estante 2"
                },
                new Producto
                {
                    Id = 2,
                    Nombre = "Audifonos inalambricos",
                    Cantidad = "1",
                    Precio = "250000",
                    Estado = "Activo",
                    Lugar = "Estante 1"
                },
                new Producto
                {
                    Id = 3,
                    Nombre = "Mouse inalambrico",
                    Cantidad = "1",
                    Precio = "50000",
                    Estado = "Activo",
                    Lugar = "Estante 3"
                }
            );
        }
    }
}
