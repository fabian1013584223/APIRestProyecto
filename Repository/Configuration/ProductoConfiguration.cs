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
                    productoId = new Guid("F4CE3B0A-653F-408A-B964-8A32B15A054A"),
                    Nombre = "Computador Samsung 2018",
                    Cantidad = "1",
                    Precio = "2600000",
                    Estado = "Activo",
                    Lugar = "Estante 2"
                },
                new Producto
                {
                    productoId = new Guid("454EAA62-3FCD-4EAC-A435-C9523BB2B821"),
                    Nombre = "Audifonos inalambricos",
                    Cantidad = "1",
                    Precio = "250000",
                    Estado = "Activo",
                    Lugar = "Estante 1"
                },
                new Producto
                {
                    productoId = new Guid("46F4B7F0-E68B-4492-BE98-7E0FFC81A06D"),
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
