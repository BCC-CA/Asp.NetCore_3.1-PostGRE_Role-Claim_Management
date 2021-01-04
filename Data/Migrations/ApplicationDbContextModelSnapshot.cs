﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StartupProject_Asp.NetCore_PostGRE.Data;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.LeaveApplication", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AddressDuringLeave")
                        .IsRequired()
                        .HasColumnName("AddressDuringLeave")
                        .HasColumnType("character varying(32767)")
                        .HasMaxLength(32767);

                    b.Property<Guid?>("ApplicantId")
                        .HasColumnName("ApplicantId")
                        .HasColumnType("uuid");

                    b.Property<int>("ApplicationStatus")
                        .HasColumnName("ApplicationStatus")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("DeletionTime")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnName("Designation")
                        .HasColumnType("character varying(32767)")
                        .HasMaxLength(32767);

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnName("LastUpdateTime")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<DateTime>("LeaveEnd")
                        .HasColumnName("LeaveEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LeaveStart")
                        .HasColumnName("LeaveStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LeaveType")
                        .HasColumnName("LeaveType")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("ApplicantName")
                        .HasColumnType("character varying(32767)")
                        .HasMaxLength(32767);

                    b.Property<string>("PhoneNoDuringLeave")
                        .IsRequired()
                        .HasColumnName("PhoneNoDuringLeave")
                        .HasColumnType("character varying(11)")
                        .HasMaxLength(11);

                    b.Property<string>("PurposeOfLeave")
                        .IsRequired()
                        .HasColumnName("PurposeOfLeave")
                        .HasColumnType("character varying(32767)")
                        .HasMaxLength(32767);

                    b.Property<Guid?>("SignedId")
                        .HasColumnName("SignedId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("SignedId");

                    b.ToTable("LeaveApplications");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.XmlFile", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreateTime")
                        .HasColumnName("CreateTime")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid>("DbEntryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnName("DeletionTime")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnName("LastUpdateTime")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid?>("NextFileId")
                        .HasColumnName("NextFileId")
                        .HasColumnType("uuid");

                    b.Property<string>("SignedContent")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnName("FileContent")
                        .HasColumnType("text");

                    b.Property<Guid?>("SignerId")
                        .HasColumnName("SignerId")
                        .HasColumnType("uuid");

                    b.Property<int>("TableName")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NextFileId");

                    b.HasIndex("SignerId");

                    b.ToTable("XmlFiles");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Role","Identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8a98fa0a-59be-4296-89de-7e6d93099280"),
                            ConcurrencyStamp = "144f3adc-6167-4efc-8e8b-d472c8359625",
                            Description = "1/4/2021 7:51:41 AM",
                            Name = "Super-Admin",
                            NormalizedName = "SUPER-ADMIN"
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim","Identity");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ClaimType = "SuperAdmin_All",
                            ClaimValue = "SuperAdmin.All",
                            RoleId = new Guid("8a98fa0a-59be-4296-89de-7e6d93099280")
                        },
                        new
                        {
                            Id = -2,
                            ClaimType = "Role_Create",
                            ClaimValue = "Role.Create",
                            RoleId = new Guid("8a98fa0a-59be-4296-89de-7e6d93099280")
                        },
                        new
                        {
                            Id = -3,
                            ClaimType = "Role_Read",
                            ClaimValue = "Role.Read",
                            RoleId = new Guid("8a98fa0a-59be-4296-89de-7e6d93099280")
                        },
                        new
                        {
                            Id = -4,
                            ClaimType = "Role_Update",
                            ClaimValue = "Role.Update",
                            RoleId = new Guid("8a98fa0a-59be-4296-89de-7e6d93099280")
                        },
                        new
                        {
                            Id = -5,
                            ClaimType = "Role_Delete",
                            ClaimValue = "Role.Delete",
                            RoleId = new Guid("8a98fa0a-59be-4296-89de-7e6d93099280")
                        },
                        new
                        {
                            Id = -6,
                            ClaimType = "Claim_Create",
                            ClaimValue = "Claim.Create",
                            RoleId = new Guid("8a98fa0a-59be-4296-89de-7e6d93099280")
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("bytea");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<int>("UsernameChangeLimit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("User","Identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9721b72c-128f-4fbc-a178-8e72dd64ccc1"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c96427c5-9ace-421e-9781-82560b6e6969",
                            Email = "abrar@jahin.com",
                            EmailConfirmed = true,
                            FirstName = "Abrar",
                            LastName = "Jahin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ABRAR@JAHIN.COM",
                            NormalizedUserName = "ABRAR",
                            PasswordHash = "AQAAAAEAACcQAAAAEN4V/TTuSC1F7xdJyRUh8kGh3ShMMFkXkFXCw9VA2XSKzV4ypDPhu+jBg2jSbNKrGA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "637453651012383910_ee324495-70c9-4bc4-99eb-9cf0639bfb61",
                            TwoFactorEnabled = false,
                            UserName = "abrar",
                            UsernameChangeLimit = 10
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserClaim","Identity");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ClaimType = "SuperAdmin_All",
                            ClaimValue = "SuperAdmin.All",
                            UserId = new Guid("9721b72c-128f-4fbc-a178-8e72dd64ccc1")
                        },
                        new
                        {
                            Id = -2,
                            ClaimType = "Role_Create",
                            ClaimValue = "Role.Create",
                            UserId = new Guid("9721b72c-128f-4fbc-a178-8e72dd64ccc1")
                        },
                        new
                        {
                            Id = -3,
                            ClaimType = "Role_Read",
                            ClaimValue = "Role.Read",
                            UserId = new Guid("9721b72c-128f-4fbc-a178-8e72dd64ccc1")
                        },
                        new
                        {
                            Id = -4,
                            ClaimType = "Role_Update",
                            ClaimValue = "Role.Update",
                            UserId = new Guid("9721b72c-128f-4fbc-a178-8e72dd64ccc1")
                        },
                        new
                        {
                            Id = -5,
                            ClaimType = "Role_Delete",
                            ClaimValue = "Role.Delete",
                            UserId = new Guid("9721b72c-128f-4fbc-a178-8e72dd64ccc1")
                        },
                        new
                        {
                            Id = -6,
                            ClaimType = "Claim_Create",
                            ClaimValue = "Claim.Create",
                            UserId = new Guid("9721b72c-128f-4fbc-a178-8e72dd64ccc1")
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("LoginIp")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserLogin","Identity");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("ReasonForAdding")
                        .HasColumnType("text");

                    b.Property<Guid?>("RoleId1")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.ToTable("UserRole","Identity");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("9721b72c-128f-4fbc-a178-8e72dd64ccc1"),
                            RoleId = new Guid("8a98fa0a-59be-4296-89de-7e6d93099280"),
                            ReasonForAdding = "Created During Migration"
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasIndex("UserId1");

                    b.ToTable("UserToken","Identity");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.LeaveApplication", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", "Applicant")
                        .WithMany()
                        .HasForeignKey("ApplicantId");

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.XmlFile", "SignedFile")
                        .WithMany()
                        .HasForeignKey("SignedId");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.XmlFile", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.XmlFile", "NextSignedFile")
                        .WithMany()
                        .HasForeignKey("NextFileId");

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", "Signer")
                        .WithMany()
                        .HasForeignKey("SignerId");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.RoleClaim", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.Role", "Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserClaim", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserLogin", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserRole", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.Role", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleId1");

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserToken", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
