﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalAPIDemoWithCrudDbContext;

#nullable disable

namespace MinimalAPIDemoWithCrudDbContext.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220404162218_initial_04_04_22")]
    partial class initial_04_04_22
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MinimalAPIDemoWithCrudModels.StoreInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RINId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SINId")
                        .HasColumnType("int");

                    b.Property<int>("StoreNumber")
                        .HasColumnType("int");

                    b.Property<int>("VINId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StoreInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
