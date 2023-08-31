using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Configuration
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasData(
                new Stock
                {
                    Id = 1,
                    CantidadReal = "150",
                    CantidadIdeal = "50",
                    CantidadMinima = "20",
                    CantidadAlarma = "5",
                    FechaIngreso = "2023-06-14"
                },
                new Stock
                {
                    Id = 2,
                    CantidadReal = "250",
                    CantidadIdeal = "100",
                    CantidadMinima = "30",
                    CantidadAlarma = "5",
                    FechaIngreso = "2023-06-15"
                },
                new Stock
                {
                    Id = 3,
                    CantidadReal = "80",
                    CantidadIdeal = "40",
                    CantidadMinima = "10",
                    CantidadAlarma = "5",
                    FechaIngreso = "2023-06-16"
                }
            );
        }
    }
}
