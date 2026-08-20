using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiniBlogRoleBase.Models;

namespace MiniBlogRoleBase.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppDBContext>();
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

                // Change the password to include a valid special character if default rules apply
                var result = await userManager.CreateAsync(adminUser, "Admin@123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    // CRUCIAL: This will print exactly why the database rejected the user creation
                    var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Identity User Seeding Failed: {errorMessages}");
                }
            }
            // 4. Seed Initial Post
            // 3. Seed 20 Initial Posts with randomized content
            if (!await context.Posts.AnyAsync() && adminUser != null)
            {
                var random = new Random();

                // Arrays of sample strings to mix and match
                var topics = new[] { "ASP.NET Core", "Entity Framework", "C# Tips", "Web Development", "Clean Architecture", "Database Design" };
                var verbs = new[] { "Mastering", "Understanding", "Deep Dive Into", "The Ultimate Guide To", "Getting Started With" };
                var buzzwords = new[] { "Like a Pro", "in 2026", "Best Practices", "For Beginners", "Simplified" };

                var postsToSeed = new List<Post>();

                for (int i = 1; i <= 20; i++)
                {
                    // Generate random combinations for titles
                    string randomTitle = $"{verbs[random.Next(verbs.Length)]} {topics[random.Next(topics.Length)]} {buzzwords[random.Next(buzzwords.Length)]} (Post #{i})";

                    var defaultPost = new Post
                    {
                        Title = randomTitle,
                        // Uses a random image ID between 1 and 500 so your posts don't all show the exact same puppy image
                        FeaturedImage = $"https://picsum.photos/id/{random.Next(1, 501)}/800/600",
                        Summary = $"This is a quick summary for post number {i}, covering essential modern development concepts.",
                        Description = $"This is the full comprehensive body content for post number {i}. It contains detailed paragraphs, code explanations, and structural guidelines written by the system administrator.",
                        UserId = adminUser.Id
                    };

                    postsToSeed.Add(defaultPost);
                }

                // Add all 20 items to the context in bulk and save once
                await context.Posts.AddRangeAsync(postsToSeed);
                await context.SaveChangesAsync();
            }
            // 5. Seed 
            if (!await context.Comments.AnyAsync() && adminUser != null)
            {
                var defaultComment = new Comment
                {
                    Comments = "Welcome to our Blog Platform!",
                    PostId = 1,
                    UserId = adminUser.Id // Directly maps to the author
                };

                context.Comments.Add(defaultComment);
                await context.SaveChangesAsync();
            }
            // 5. Seed Comments
            // if (!await context.Comments.AnyAsync() && adminUser != null)
            // {
            //     var firstPost = await context.Posts.FirstOrDefaultAsync();

            //     if (firstPost != null)
            //     {
            //         var sampleComments = new List<Comment>
            //         {
            //             new Comment 
            //             { 
            //                 Text = "Great post! Looking forward to seeing more content here.", 
            //                 PostId = firstPost.Id, 
            //                 UserId = adminUser.Id 
            //             },
            //         };

            //         await context.Comments.AddRangeAsync(sampleComments);
            //         await context.SaveChangesAsync();
            //     }
            // }
        }
    }
}
