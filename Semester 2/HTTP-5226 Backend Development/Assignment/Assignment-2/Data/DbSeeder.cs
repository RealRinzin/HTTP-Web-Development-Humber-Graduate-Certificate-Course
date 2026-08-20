using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Assignment_2.Models;

namespace Assignment_2.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // 1. Seed Roles
            string[] roles = { "Admin", "Manager", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new ApplicationRole { Name = role });
                }
            }

            // 2. Seed Admin User
            var adminEmail = "admin@example.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "System Admin",
                    Name = "Admin",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // 3. Seed 10 Categories
            if (!context.Categories.Any())
            {
                var sampleCategories = new List<Category>
                {
                    new Category { name = "Technology", slug = "technology" },
                    new Category { name = "Programming", slug = "programming" },
                    new Category { name = "Web Development", slug = "web-development" },
                    new Category { name = "Database Systems", slug = "database-systems" },
                    new Category { name = "Cloud Computing", slug = "cloud-computing" },
                    new Category { name = "Artificial Intelligence", slug = "artificial-intelligence" },
                    new Category { name = "Cybersecurity", slug = "cybersecurity" },
                    new Category { name = "Mobile Development", slug = "mobile-development" },
                    new Category { name = "DevOps", slug = "devops" },
                    new Category { name = "Software Architecture", slug = "software-architecture" }
                };

                await context.Categories.AddRangeAsync(sampleCategories);
                await context.SaveChangesAsync();
            }

            // 4. Seed Initial Post
            if (!context.Posts.Any() && adminUser != null)
            {
                var firstCategory = context.Categories.FirstOrDefault();
                if (firstCategory != null)
                {
                    var defaultPost = new Post
                    {
                        Title = "Welcome to our Blog Platform!",
                        Body = "welcome-to-our-blog-platform",
                        AuthorId = adminUser.Id
                    };

                    context.Posts.Add(defaultPost);
                    await context.SaveChangesAsync();
                }
            }

            // 5. Seed Comments
            if (!context.Comments.Any() && adminUser != null)
            {
                var firstPost = context.Posts.FirstOrDefault();

                if (firstPost != null)
                {
                    var sampleComments = new List<Comment>
                    {
                        new Comment { Text = "Great post! Looking forward to seeing more content here.", PostId = firstPost.Id, UserId = adminUser.Id },
                    };

                    await context.Comments.AddRangeAsync(sampleComments);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}