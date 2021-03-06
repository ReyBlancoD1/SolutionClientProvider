﻿// <auto-generated />
using Customer.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Customer.Persistence.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Customer")
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Customer.Domain.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            Name = "Quhoshoquqybelydaqeba"
                        },
                        new
                        {
                            ClientId = 2,
                            Name = "Taesaewezhaeqejotuxoshira"
                        },
                        new
                        {
                            ClientId = 3,
                            Name = "Leratunashejolujypawa"
                        },
                        new
                        {
                            ClientId = 4,
                            Name = "Hebotirikuqazhezhibuwy"
                        },
                        new
                        {
                            ClientId = 5,
                            Name = "Jopasosaeliqitadotoha"
                        },
                        new
                        {
                            ClientId = 6,
                            Name = "Nusezheruwosaedomezhaexo"
                        },
                        new
                        {
                            ClientId = 7,
                            Name = "Vecitohagexykaeqaejeve"
                        },
                        new
                        {
                            ClientId = 8,
                            Name = "Kikipabodepotucaezhyfu"
                        },
                        new
                        {
                            ClientId = 9,
                            Name = "Mejakukaevuduxopajaru"
                        },
                        new
                        {
                            ClientId = 10,
                            Name = "Ritaezhytimelehaexeshisy"
                        },
                        new
                        {
                            ClientId = 11,
                            Name = "Gulaeresyqaehishariqise"
                        },
                        new
                        {
                            ClientId = 12,
                            Name = "Fuwerexyshabikuzhaeqaenu"
                        },
                        new
                        {
                            ClientId = 13,
                            Name = "Gorugyqurexudegazhoshi"
                        },
                        new
                        {
                            ClientId = 14,
                            Name = "Visugygenyxamuqomydy"
                        },
                        new
                        {
                            ClientId = 15,
                            Name = "Dikaekisyjehylomaxuxi"
                        },
                        new
                        {
                            ClientId = 16,
                            Name = "Maejishoxixaexulizhyxishe"
                        },
                        new
                        {
                            ClientId = 17,
                            Name = "Mijyzhynelalipaemaqifo"
                        },
                        new
                        {
                            ClientId = 18,
                            Name = "Diqyraehygezhaehokoxece"
                        },
                        new
                        {
                            ClientId = 19,
                            Name = "Tywaejawaefanamusotaety"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
