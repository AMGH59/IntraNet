﻿// <auto-generated />
using System;
using IntraNetAPI.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IntraNetAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220113083026_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("CollaboratorMission", b =>
                {
                    b.Property<int>("CollaboratorsId")
                        .HasColumnType("int");

                    b.Property<int>("MissionsId")
                        .HasColumnType("int");

                    b.HasKey("CollaboratorsId", "MissionsId");

                    b.HasIndex("MissionsId");

                    b.ToTable("CollaboratorMission");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CollaboratorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CollaboratorId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Collaborator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<int>("HalfDayBreak")
                        .HasColumnType("int");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsChief")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Collaborators");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CollaboratorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("StartOnMorning")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Validation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CollaboratorId");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .HasColumnType("longtext");

                    b.Property<int?>("CollaboratorId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CollaboratorId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Infos");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Proof", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PdfUrl")
                        .HasColumnType("longtext");

                    b.Property<int?>("SpentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpentId");

                    b.ToTable("Proof");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Spent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AdvanceCash")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("BillId")
                        .HasColumnType("int");

                    b.Property<string>("Commentary")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsExactAmount")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("MissionId")
                        .HasColumnType("int");

                    b.Property<int>("Validate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("MissionId");

                    b.ToTable("Spents");
                });

            modelBuilder.Entity("CollaboratorMission", b =>
                {
                    b.HasOne("IntraNetAPI.Models.Collaborator", null)
                        .WithMany()
                        .HasForeignKey("CollaboratorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntraNetAPI.Models.Mission", null)
                        .WithMany()
                        .HasForeignKey("MissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IntraNetAPI.Models.Bill", b =>
                {
                    b.HasOne("IntraNetAPI.Models.Collaborator", "Collaborator")
                        .WithMany("Bills")
                        .HasForeignKey("CollaboratorId");

                    b.Navigation("Collaborator");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Collaborator", b =>
                {
                    b.HasOne("IntraNetAPI.Models.Department", "Department")
                        .WithMany("Collaborators")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Holiday", b =>
                {
                    b.HasOne("IntraNetAPI.Models.Collaborator", "Collaborator")
                        .WithMany("Holidays")
                        .HasForeignKey("CollaboratorId");

                    b.Navigation("Collaborator");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Info", b =>
                {
                    b.HasOne("IntraNetAPI.Models.Collaborator", "Collaborator")
                        .WithMany()
                        .HasForeignKey("CollaboratorId");

                    b.HasOne("IntraNetAPI.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Collaborator");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Mission", b =>
                {
                    b.HasOne("IntraNetAPI.Models.Department", "Department")
                        .WithMany("Missions")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Proof", b =>
                {
                    b.HasOne("IntraNetAPI.Models.Spent", null)
                        .WithMany("Proofs")
                        .HasForeignKey("SpentId");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Spent", b =>
                {
                    b.HasOne("IntraNetAPI.Models.Bill", null)
                        .WithMany("Spents")
                        .HasForeignKey("BillId");

                    b.HasOne("IntraNetAPI.Models.Mission", "Mission")
                        .WithMany()
                        .HasForeignKey("MissionId");

                    b.Navigation("Mission");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Bill", b =>
                {
                    b.Navigation("Spents");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Collaborator", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Holidays");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Department", b =>
                {
                    b.Navigation("Collaborators");

                    b.Navigation("Missions");
                });

            modelBuilder.Entity("IntraNetAPI.Models.Spent", b =>
                {
                    b.Navigation("Proofs");
                });
#pragma warning restore 612, 618
        }
    }
}
