using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnterpriseApplication.Infrastructure.Migrations
{
    public partial class Initial_SecurityModule_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Security",
                columns: table => new
                {
                    Role_ID_PK = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_ID_PK);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Security",
                columns: table => new
                {
                    User_ID_PK = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID_PK);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                schema: "Security",
                columns: table => new
                {
                    RoleClaim_ID_PK = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_ID_FK = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 50, nullable: true),
                    ClaimValue = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.RoleClaim_ID_PK);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Roles_Role_ID_FK",
                        column: x => x.Role_ID_FK,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "Role_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "Security",
                columns: table => new
                {
                    UserClaim_ID_PK = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID_FK = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 50, nullable: true),
                    ClaimValue = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.UserClaim_ID_PK);
                    table.ForeignKey(
                        name: "FK_UserClaim_Users_User_ID_FK",
                        column: x => x.User_ID_FK,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "User_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "Security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    User_ID_FK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_Users_User_ID_FK",
                        column: x => x.User_ID_FK,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "User_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Security",
                columns: table => new
                {
                    User_ID_FK = table.Column<Guid>(nullable: false),
                    Role_ID_FK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.User_ID_FK, x.Role_ID_FK });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_Role_ID_FK",
                        column: x => x.Role_ID_FK,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "Role_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_User_ID_FK",
                        column: x => x.User_ID_FK,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "User_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "Security",
                columns: table => new
                {
                    User_ID_FK = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.User_ID_FK, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_Users_User_ID_FK",
                        column: x => x.User_ID_FK,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "User_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Roles",
                columns: new[] { "Role_ID_PK", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("cca24fe8-ba46-4921-a9bb-e64eed9f8c39"), "fcb4b16b-0625-44b7-a36e-f6a92b28f676", "SuperAdmin", "superadmin" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Users",
                columns: new[] { "User_ID_PK", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0dfcf4cd-7a72-4053-9ca5-f90d9c8b02b8"), 0, "7bfb6745-357c-4171-b4f0-4d05e0e1dba8", "alisuriya89@gmail.com", true, false, null, "ALISURIYA89@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEI5WWcSSRpjm2sisQ8V99EDOL1ZmbxdopcqqDIgp7Cm0P8lAZcI0l0xW1ja6Uu2C+A==", null, false, "", false, "Adam" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "UserRole",
                columns: new[] { "User_ID_FK", "Role_ID_FK" },
                values: new object[] { new Guid("0dfcf4cd-7a72-4053-9ca5-f90d9c8b02b8"), new Guid("cca24fe8-ba46-4921-a9bb-e64eed9f8c39") });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_Role_ID_FK",
                schema: "Security",
                table: "RoleClaim",
                column: "Role_ID_FK");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_User_ID_FK",
                schema: "Security",
                table: "UserClaim",
                column: "User_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_User_ID_FK",
                schema: "Security",
                table: "UserLogin",
                column: "User_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_Role_ID_FK",
                schema: "Security",
                table: "UserRole",
                column: "Role_ID_FK");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaim",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Security");
        }
    }
}
