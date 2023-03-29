using Domain.Entities;

namespace Infrastructure.Seeds
{
    internal static class ProfileSeed
    {
        public static List<Profile> Seed { get; set; } = new List<Profile>() {
            new Profile
            {
                Id = 1,
                Name= "Employee",
            },
            new Profile
            {
                Id = 2,
                Name= "Manager",
            },
            new Profile
            {
                Id = 3,
                Name= "Administrator",
            }
        };
    }
}
