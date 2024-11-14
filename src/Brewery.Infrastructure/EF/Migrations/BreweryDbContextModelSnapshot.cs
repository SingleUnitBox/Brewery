﻿// <auto-generated />
using System;
using Brewery.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Brewery.Infrastructure.EF.Migrations
{
    [DbContext(typeof(BreweryDbContext))]
    partial class BreweryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("brewery")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Brewery.Domain.Entities.Beer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BrewerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("BrewerId");

                    b.ToTable("Beers", "brewery");
                });

            modelBuilder.Entity("Brewery.Domain.Entities.Brewer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BreweryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BreweryId");

                    b.ToTable("Brewers", "brewery");
                });

            modelBuilder.Entity("Brewery.Domain.Entities.Brewery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Breweries", "brewery");
                });

            modelBuilder.Entity("Brewery.Domain.Entities.Beer", b =>
                {
                    b.HasOne("Brewery.Domain.Entities.Brewer", null)
                        .WithMany("Beers")
                        .HasForeignKey("BrewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Brewery.Domain.Entities.Brewer", b =>
                {
                    b.HasOne("Brewery.Domain.Entities.Brewery", null)
                        .WithMany("Brewers")
                        .HasForeignKey("BreweryId");
                });

            modelBuilder.Entity("Brewery.Domain.Entities.Brewer", b =>
                {
                    b.Navigation("Beers");
                });

            modelBuilder.Entity("Brewery.Domain.Entities.Brewery", b =>
                {
                    b.Navigation("Brewers");
                });
#pragma warning restore 612, 618
        }
    }
}
