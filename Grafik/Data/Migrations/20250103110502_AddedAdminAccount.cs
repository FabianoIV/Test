using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grafik.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var adminId = Guid.NewGuid().ToString();
            var roleId = Guid.NewGuid().ToString();
            var passwordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin");

            // Add "Administrator" role
            migrationBuilder.Sql($@"
                INSERT INTO AspNetRoles (
                    Id,
                    Name,
                    NormalizedName,
                    ConcurrencyStamp
                )
                VALUES (
                    '{roleId}',
                    'Administrator',
                    'ADMINISTRATOR',
                    NEWID()
                )
            ");


            // Add the admin user
            migrationBuilder.Sql($@"
                INSERT INTO AspNetUsers (
                    Id,
                    UserName,
                    NormalizedUserName,
                    Email,
                    NormalizedEmail,
                    EmailConfirmed,
                    PasswordHash,
                    SecurityStamp,
                    ConcurrencyStamp,
                    PhoneNumberConfirmed,
                    TwoFactorEnabled,
                    LockoutEnabled,
                    AccessFailedCount
                )
                VALUES (
                    '{adminId}',
                    'admin',
                    'ADMIN',
                    'admin@admin.com',
                    'ADMIN@ADMIN.COM',
                    1,
                    '{passwordHash}',
                    NEWID(),
                    NEWID(),
                    0,
                    0,
                    1,
                    0
                )
            ");

            // Assign the role to the admin user
            migrationBuilder.Sql($@"
                INSERT INTO AspNetUserRoles (
                    UserId,
                    RoleId
                )
                VALUES (
                    '{adminId}',
                    '{roleId}'
                )
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the admin user
            migrationBuilder.Sql($@"
                DELETE FROM AspNetUserRoles
                WHERE UserId IN (
                    SELECT Id FROM AspNetUsers WHERE UserName = 'admin'
                )
            ");

            migrationBuilder.Sql($@"
                DELETE FROM AspNetUsers
                WHERE UserName = 'admin'
            ");

            // Remove the "Administrator" role
            migrationBuilder.Sql($@"
                DELETE FROM AspNetRoles
                WHERE Name = 'Administrator'
            ");
        }
    }
}
