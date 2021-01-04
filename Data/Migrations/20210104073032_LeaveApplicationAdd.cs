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
                    LastUpdateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
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
                    LastUpdateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
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
                values: new object[] { new Guid("72e4466b-faa7-40a1-a284-87009f225118"), "eb95e909-021d-42c9-afbb-e104ac3a51c7", "1/4/2021 7:30:31 AM", "Super-Admin", "SUPER-ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName", "UsernameChangeLimit" },
                values: new object[] { new Guid("3534192b-8234-4db8-b390-8e1d39262895"), 0, "941f3a5c-4fd7-4c82-b88e-db8601f4cc9c", "abrar@jahin.com", true, "Abrar", "Jahin", false, null, "ABRAR@JAHIN.COM", "ABRAR", "AQAAAAEAACcQAAAAEHiXKMq9gskv/m/0hQ0HZ8csUdkUFrIFu9isQ8N7I5vE+4TkLVOxUshybzFitZXhrA==", null, false, null, "637453638315110134_a8863b8c-62e3-4c61-9e62-e44d38a2170c", false, "abrar", 10 });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "RoleClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { -6, "Claim_Create", "Claim.Create", new Guid("72e4466b-faa7-40a1-a284-87009f225118") },
                    { -5, "Role_Delete", "Role.Delete", new Guid("72e4466b-faa7-40a1-a284-87009f225118") },
                    { -4, "Role_Update", "Role.Update", new Guid("72e4466b-faa7-40a1-a284-87009f225118") },
                    { -3, "Role_Read", "Role.Read", new Guid("72e4466b-faa7-40a1-a284-87009f225118") },
                    { -2, "Role_Create", "Role.Create", new Guid("72e4466b-faa7-40a1-a284-87009f225118") },
                    { -1, "SuperAdmin_All", "SuperAdmin.All", new Guid("72e4466b-faa7-40a1-a284-87009f225118") }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId", "UserId1" },
                values: new object[,]
                {
                    { -6, "Claim_Create", "Claim.Create", new Guid("3534192b-8234-4db8-b390-8e1d39262895"), null },
                    { -5, "Role_Delete", "Role.Delete", new Guid("3534192b-8234-4db8-b390-8e1d39262895"), null },
                    { -4, "Role_Update", "Role.Update", new Guid("3534192b-8234-4db8-b390-8e1d39262895"), null },
                    { -3, "Role_Read", "Role.Read", new Guid("3534192b-8234-4db8-b390-8e1d39262895"), null },
                    { -2, "Role_Create", "Role.Create", new Guid("3534192b-8234-4db8-b390-8e1d39262895"), null },
                    { -1, "SuperAdmin_All", "SuperAdmin.All", new Guid("3534192b-8234-4db8-b390-8e1d39262895"), null }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId", "ReasonForAdding", "RoleId1", "UserId1" },
                values: new object[] { new Guid("3534192b-8234-4db8-b390-8e1d39262895"), new Guid("72e4466b-faa7-40a1-a284-87009f225118"), "Created During Migration", null, null });

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
                keyValues: new object[] { new Guid("3534192b-8234-4db8-b390-8e1d39262895"), new Guid("72e4466b-faa7-40a1-a284-87009f225118") });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("72e4466b-faa7-40a1-a284-87009f225118"));

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3534192b-8234-4db8-b390-8e1d39262895"));

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
