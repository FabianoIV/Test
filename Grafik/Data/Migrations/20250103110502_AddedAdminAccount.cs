using Grafik.Data;
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
            // Hash the password for "admin"
            var passwordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin");

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
                    NEWID(),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM AspNetUsers 
                WHERE UserName = 'admin'
            ");
        }
    }
}
