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
                    stockId = new Guid("F7FBB9E6-BDAF-4066-BD46-8B334BA24843"),
                    CantidadReal = "150",
                    CantidadIdeal = "50",
                    CantidadMinima = "20",
                    CantidadAlarma = "5",
                    FechaIngreso = "2023-06-14"
                },
                new Stock
                {
                    stockId = new Guid("DE52AC42-4452-415C-BBEC-77169209EFBF"),
                    CantidadReal = "250",
                    CantidadIdeal = "100",
                    CantidadMinima = "30",
                    CantidadAlarma = "5",
                    FechaIngreso = "2023-06-15"
                },
                new Stock
                {
                    stockId = new Guid("D0AF07F8-115F-40B2-B206-459FE40416A8"),
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
