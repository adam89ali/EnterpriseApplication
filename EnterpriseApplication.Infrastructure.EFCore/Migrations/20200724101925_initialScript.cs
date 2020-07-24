using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnterpriseApplication.Infrastructure.EFCore.Migrations
{
    public partial class initialScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
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
                schema: "Identity",
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
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Role_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "User_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "User_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Role_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_User_ID_FK",
                        column: x => x.User_ID_FK,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "User_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "User_ID_PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Role_ID_PK", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("6fd606bc-943e-43d1-8843-5edca674f8c2"), "1f34e08a-1e0a-4d7c-95e5-b4247ab15008", "SuperAdmin", "superadmin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "User_ID_PK", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("dc167304-8663-402b-8237-110a56de28b2"), 0, "9bab6078-3403-4cf5-8678-622dadccf6bb", "test@gmail.com", true, false, null, "TEST@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEAI2/krFHc018K/hFZUSjbFR617kbdfapgcM1lyuE3D5NGXWZVGFt325WAoZ8JoRSA==", null, false, "", false, "superAdmin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRole",
                columns: new[] { "User_ID_FK", "Role_ID_FK" },
                values: new object[] { new Guid("dc167304-8663-402b-8237-110a56de28b2"), new Guid("6fd606bc-943e-43d1-8843-5edca674f8c2") });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_Role_ID_FK",
                schema: "Identity",
                table: "RoleClaim",
                column: "Role_ID_FK");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_User_ID_FK",
                schema: "Identity",
                table: "UserClaim",
                column: "User_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_User_ID_FK",
                schema: "Identity",
                table: "UserLogin",
                column: "User_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_Role_ID_FK",
                schema: "Identity",
                table: "UserRole",
                column: "Role_ID_FK");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaim",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");
        }
    }
}
