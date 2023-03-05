using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// Creates a custom Role class to seed data into the Default AspNetRoles table
public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "Manager",
                NormalizedName = "MANAGER"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            }
        );
    }
}