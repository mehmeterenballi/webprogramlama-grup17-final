// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using VeritabaniProjesi.Data;

namespace VeritabaniProjesi.Migrations
{
    [DbContext(typeof(BasicDataContext))]
    [Migration("20210119173117_BasicTablesScheme")]
    partial class BasicTablesScheme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("VeritabaniProjesi.Models.Announcement", b =>
                {
                    b.Property<string>("Title")
                        .HasColumnType("NVARCHAR2(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Content")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("SourceListString")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Title");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("VeritabaniProjesi.Models.BlackList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("PostId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Sender")
                        .HasColumnType("NVARCHAR2(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.ToTable("BlackList");
                });

            modelBuilder.Entity("VeritabaniProjesi.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("PeopleWhoLikedString")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PostTitle")
                        .HasColumnType("NVARCHAR2(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Rating")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Sender")
                        .HasColumnType("NVARCHAR2(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("VeritabaniProjesi.Models.Title", b =>
                {
                    b.Property<string>("PostTitle")
                        .HasColumnType("NVARCHAR2(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("Date")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("PostTitle");

                    b.HasIndex("QuestionId");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("VeritabaniProjesi.Models.Title", b =>
                {
                    b.HasOne("VeritabaniProjesi.Models.Post", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
