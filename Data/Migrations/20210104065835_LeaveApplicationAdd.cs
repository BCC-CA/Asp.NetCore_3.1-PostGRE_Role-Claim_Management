using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Migrations
{
    public partial class LeaveApplicationAdd : Migration
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
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TableName = table.Column<int>(nullable: false),
                    DbEntryId = table.Column<Guid>(nullable: false),
                    FileContent = table.Column<string>(type: "text", nullable: false),
                    SignerId = table.Column<Guid>(nullable: true),
                    NextFileId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XmlFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XmlFiles_XmlFiles_NextFileId",
                        column: x => x.NextFileId,
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
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ApplicantId = table.Column<Guid>(nullable: true),
                    ApplicantName = table.Column<string>(maxLength: 32767, nullable: false),
                    Designation = table.Column<string>(maxLength: 32767, nullable: false),
                    LeaveStart = table.Column<DateTime>(nullable: false),
                    LeaveEnd = table.Column<DateTime>(nullable: false),
                    LeaveType = table.Column<int>(nullable: false),
                    PurposeOfLeave = table.Column<string>(maxLength: 32767, nullable: false),
                    AddressDuringLeave = table.Column<string>(maxLength: 32767, nullable: false),
                    PhoneNoDuringLeave = table.Column<string>(maxLength: 11, nullable: false),
                    ApplicationStatus = table.Column<int>(nullable: false),
                    SignedId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveApplications_User_ApplicantId",
                        column: x => x.ApplicantId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveApplications_XmlFiles_SignedId",
                        column: x => x.SignedId,
                        principalSchema: "public",
                        principalTable: "XmlFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("f74d04e2-bbc8-4f12-a74b-b0f3ef31c0e5"), "8fe22846-0e6b-4223-b4b4-57155f700e8a", "1/4/2021 6:58:34 AM", "Super-Admin", "SUPER-ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { new Guid("b0b50848-5788-4889-b529-5f23e04ac4de"), 0, "341299d4-0246-4f9b-9c76-da464f48ab59", "abrar@jahin.com", true, "Abrar", "Jahin", false, null, "ABRAR@JAHIN.COM", "ABRAR", "AQAAAAEAACcQAAAAELIiILKqE/aY925vXmvjP7hw0atJ45w/TzCdLZUdC9F80QcZAgaUJbBss9Te4J56pA==", null, false, null, "637453619144563102_1acc9ccc-1d63-44cb-94f6-0848a228a43d", false, "abrar", 10 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "RoleClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -6, "Claim_Create", "Claim.Create", new Guid("f74d04e2-bbc8-4f12-a74b-b0f3ef31c0e5") },
                    { -5, "Role_Delete", "Role.Delete", new Guid("f74d04e2-bbc8-4f12-a74b-b0f3ef31c0e5") },
                    { -4, "Role_Update", "Role.Update", new Guid("f74d04e2-bbc8-4f12-a74b-b0f3ef31c0e5") },
                    { -3, "Role_Read", "Role.Read", new Guid("f74d04e2-bbc8-4f12-a74b-b0f3ef31c0e5") },
                    { -2, "Role_Create", "Role.Create", new Guid("f74d04e2-bbc8-4f12-a74b-b0f3ef31c0e5") },
                    { -1, "SuperAdmin_All", "SuperAdmin.All", new Guid("f74d04e2-bbc8-4f12-a74b-b0f3ef31c0e5") }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId", "UserId1" },
                values: new object[,]
                {
                    { -6, "Claim_Create", "Claim.Create", new Guid("b0b50848-5788-4889-b529-5f23e04ac4de"), null },
                    { -5, "Role_Delete", "Role.Delete", new Guid("b0b50848-5788-4889-b529-5f23e04ac4de"), null },
                    { -4, "Role_Update", "Role.Update", new Guid("b0b50848-5788-4889-b529-5f23e04ac4de"), null },
                    { -3, "Role_Read", "Role.Read", new Guid("b0b50848-5788-4889-b529-5f23e04ac4de"), null },
                    { -2, "Role_Create", "Role.Create", new Guid("b0b50848-5788-4889-b529-5f23e04ac4de"), null },
                    { -1, "SuperAdmin_All", "SuperAdmin.All", new Guid("b0b50848-5788-4889-b529-5f23e04ac4de"), null }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId", "ReasonForAdding", "RoleId1", "UserId1" },
                values: new object[] { new Guid("b0b50848-5788-4889-b529-5f23e04ac4de"), new Guid("f74d04e2-bbc8-4f12-a74b-b0f3ef31c0e5"), "Created During Migration", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_ApplicantId",
                schema: "public",
                table: "LeaveApplications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_SignedId",
                schema: "public",
                table: "LeaveApplications",
                column: "SignedId");

            migrationBuilder.CreateIndex(
                name: "IX_XmlFiles_NextFileId",
                schema: "public",
                table: "XmlFiles",
                column: "NextFileId");

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
                keyValues: new object[] { new Guid("b0b50848-5788-4889-b529-5f23e04ac4de"), new Guid("f74d04e2-bbc8-4f12-a74b-b0f3ef31c0e5") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f74d04e2-bbc8-4f12-a74b-b0f3ef31c0e5"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b0b50848-5788-4889-b529-5f23e04ac4de"));

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
