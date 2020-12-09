﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Migrations
{
    public partial class ApplicationTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"), new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"));

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "XmlFiles",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    FileContent = table.Column<string>(type: "text", nullable: false),
                    FileRealName = table.Column<string>(maxLength: 32767, nullable: false),
                    TableName = table.Column<int>(nullable: false),
                    DbEntryId = table.Column<long>(nullable: false),
                    IsAlreadyUsed = table.Column<bool>(nullable: false),
                    SignerId = table.Column<Guid>(nullable: true),
                    PreviousFileId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XmlFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XmlFiles_XmlFiles_PreviousFileId",
                        column: x => x.PreviousFileId,
                        principalSchema: "public",
                        principalTable: "XmlFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_XmlFiles_User_SignerId",
                        column: x => x.SignerId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveApplications",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ApplicantId = table.Column<long>(nullable: false),
                    ApplicantName = table.Column<string>(maxLength: 32767, nullable: false),
                    Designation = table.Column<string>(maxLength: 32767, nullable: false),
                    LeaveStart = table.Column<DateTime>(nullable: false),
                    LeaveEnd = table.Column<DateTime>(nullable: false),
                    LeaveType = table.Column<int>(nullable: false),
                    PurposeOfLeave = table.Column<string>(maxLength: 32767, nullable: false),
                    AddressDuringLeave = table.Column<string>(maxLength: 32767, nullable: false),
                    PhoneNoDuringLeave = table.Column<string>(maxLength: 11, nullable: false),
                    ApplicationStatus = table.Column<int>(nullable: false),
                    LastSignedId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveApplications_XmlFiles_LastSignedId",
                        column: x => x.LastSignedId,
                        principalSchema: "public",
                        principalTable: "XmlFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("31bb77f3-53a2-438e-b29e-e8f12cf49d73"), "f93a5c24-7fc8-43a9-b938-491d15e5ec28", "12/9/2020 8:39:36 AM", "Super-Admin", "SUPER-ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { new Guid("f91c2202-827c-4be1-8230-abbc89038091"), 0, "ab6a5f97-cbc6-49d7-9ea5-9d1724be8851", "abrar@jahin.com", true, "Abrar", "Jahin", false, null, "ABRAR@JAHIN.COM", "ABRAR", "AQAAAAEAACcQAAAAEPWNQ5lIOfTuhjl3JOFIHpX72sUCr9g4xiRHhxsqoQ+G+QS6pNuctkxOsxvFmJfJbQ==", null, false, null, "637431215769660673_f9910b91-a4f2-4d3a-8287-761ed02adc22", false, "abrar", 10 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "RoleClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -6, "Claim_Create", "Claim.Create", new Guid("31bb77f3-53a2-438e-b29e-e8f12cf49d73") },
                    { -5, "Role_Delete", "Role.Delete", new Guid("31bb77f3-53a2-438e-b29e-e8f12cf49d73") },
                    { -4, "Role_Update", "Role.Update", new Guid("31bb77f3-53a2-438e-b29e-e8f12cf49d73") },
                    { -3, "Role_Read", "Role.Read", new Guid("31bb77f3-53a2-438e-b29e-e8f12cf49d73") },
                    { -2, "Role_Create", "Role.Create", new Guid("31bb77f3-53a2-438e-b29e-e8f12cf49d73") },
                    { -1, "SuperAdmin_All", "SuperAdmin.All", new Guid("31bb77f3-53a2-438e-b29e-e8f12cf49d73") }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId", "UserId1" },
                values: new object[,]
                {
                    { -6, "Claim_Create", "Claim.Create", new Guid("f91c2202-827c-4be1-8230-abbc89038091"), null },
                    { -5, "Role_Delete", "Role.Delete", new Guid("f91c2202-827c-4be1-8230-abbc89038091"), null },
                    { -4, "Role_Update", "Role.Update", new Guid("f91c2202-827c-4be1-8230-abbc89038091"), null },
                    { -3, "Role_Read", "Role.Read", new Guid("f91c2202-827c-4be1-8230-abbc89038091"), null },
                    { -2, "Role_Create", "Role.Create", new Guid("f91c2202-827c-4be1-8230-abbc89038091"), null },
                    { -1, "SuperAdmin_All", "SuperAdmin.All", new Guid("f91c2202-827c-4be1-8230-abbc89038091"), null }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId", "ReasonForAdding", "RoleId1", "UserId1" },
                values: new object[] { new Guid("f91c2202-827c-4be1-8230-abbc89038091"), new Guid("31bb77f3-53a2-438e-b29e-e8f12cf49d73"), "Created During Migration", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_LastSignedId",
                schema: "public",
                table: "LeaveApplications",
                column: "LastSignedId");

            migrationBuilder.CreateIndex(
                name: "IX_XmlFiles_PreviousFileId",
                schema: "public",
                table: "XmlFiles",
                column: "PreviousFileId");

            migrationBuilder.CreateIndex(
                name: "IX_XmlFiles_SignerId",
                schema: "public",
                table: "XmlFiles",
                column: "SignerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveApplications",
                schema: "public");

            migrationBuilder.DropTable(
                name: "XmlFiles",
                schema: "public");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaim",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRole",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("f91c2202-827c-4be1-8230-abbc89038091"), new Guid("31bb77f3-53a2-438e-b29e-e8f12cf49d73") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("31bb77f3-53a2-438e-b29e-e8f12cf49d73"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f91c2202-827c-4be1-8230-abbc89038091"));

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934"), "9d3a576f-a9c0-44c7-9f48-788680e06377", "12/8/2020 9:27:07 AM", "Super-Admin", "SUPER-ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"), 0, "66d8c20a-b7ad-4c25-8bae-afe301f3a72d", "abrar@jahin.com", true, "Abrar", "Jahin", false, null, "ABRAR@JAHIN.COM", "ABRAR", "AQAAAAEAACcQAAAAEIvZj1REJRr5G9ehJD0eYPfa4BxlVngQ6ZcUsitZ4PMBTwpKDeR2T6Rv2rITpwLzEg==", null, false, null, "637430380275976571_dbf7cdff-e9a1-411b-93a5-d88d5bfc65e8", false, "abrar", 10 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "RoleClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -6, "Claim_Create", "Claim.Create", new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934") },
                    { -5, "Role_Delete", "Role.Delete", new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934") },
                    { -4, "Role_Update", "Role.Update", new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934") },
                    { -3, "Role_Read", "Role.Read", new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934") },
                    { -2, "Role_Create", "Role.Create", new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934") },
                    { -1, "SuperAdmin_All", "SuperAdmin.All", new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934") }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId", "UserId1" },
                values: new object[,]
                {
                    { -6, "Claim_Create", "Claim.Create", new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"), null },
                    { -5, "Role_Delete", "Role.Delete", new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"), null },
                    { -4, "Role_Update", "Role.Update", new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"), null },
                    { -3, "Role_Read", "Role.Read", new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"), null },
                    { -2, "Role_Create", "Role.Create", new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"), null },
                    { -1, "SuperAdmin_All", "SuperAdmin.All", new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"), null }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId", "ReasonForAdding", "RoleId1", "UserId1" },
                values: new object[] { new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"), new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934"), "Created During Migration", null, null });
        }
    }
}
