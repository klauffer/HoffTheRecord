// <auto-generated />
using Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(HoffTheRecordContext))]
    [Migration("20220612202427_AddingPersonThatWasHoffedAndImageToHoff")]
    partial class AddingPersonThatWasHoffedAndImageToHoff
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Data.Hasselhoffing.HasslehoffRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonThatCommittedTheOffense")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonThatWasHoffed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Hoffs");
                });
#pragma warning restore 612, 618
        }
    }
}
