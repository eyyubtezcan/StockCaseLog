// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockCaseProject.Repository;

#nullable disable

namespace StockCaseProject.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221215102351_a")]
    partial class a
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StockCaseProject.Domain.Entities.ChangeLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateChanged")
                        .HasColumnType("datetime2");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NewValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrimaryKeyValue")
                        .HasColumnType("int");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChangeLogs");
                });

            modelBuilder.Entity("StockCaseProject.Domain.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantiy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VariantCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9748),
                            IsActive = true,
                            ProductCode = "001AD",
                            Quantiy = 120,
                            UpdatedDate = new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9748),
                            VariantCode = "454CAS"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9751),
                            IsActive = true,
                            ProductCode = "321AD",
                            Quantiy = 220,
                            UpdatedDate = new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9750),
                            VariantCode = "DFD545S"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9753),
                            IsActive = true,
                            ProductCode = "00FF1AD",
                            Quantiy = 67,
                            UpdatedDate = new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9752),
                            VariantCode = "3234FSF"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9755),
                            IsActive = true,
                            ProductCode = "ASDFBV443",
                            Quantiy = 6,
                            UpdatedDate = new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9754),
                            VariantCode = "GFHGFX4363"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
