﻿// <auto-generated />
using System;
using Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Desafio_DevWebCloudAWSPractitioner.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240822032631_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence.SchoolInfosEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<double>("MarksSecondPeriod")
                        .HasColumnType("double");

                    b.Property<double>("MarksfirstPeriod")
                        .HasColumnType("double");

                    b.Property<string>("NameTeacher")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumberClassroom")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SchoolInfos");
                });

            modelBuilder.Entity("Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence.StudentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("RA")
                        .HasColumnType("int");

                    b.Property<Guid>("SchoolInfosId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RA");

                    b.HasIndex("SchoolInfosId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence.StudentEntity", b =>
                {
                    b.HasOne("Desafio_DevWebCloudAWSPractitioner.Infrastructure.DBContext.Persistence.SchoolInfosEntity", "SchoolInfos")
                        .WithMany()
                        .HasForeignKey("SchoolInfosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
