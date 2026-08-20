using Microsoft.AspNetCore.Identity;
using MiniReddit.Models;

namespace MiniReddit.Data
{
    // Call SeedData.InitializeAsync(app.Services) once from Program.cs on startup.
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var db = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            // --- Roles ---
            foreach (var role in new[] { "User", "Admin" })
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // --- Users ---
            var admin = await userManager.FindByNameAsync("theAdminXX");
            if (admin == null)
            {
                admin = new ApplicationUser { UserName = "theAdminXX", Email = "admin@example.com" };
                await userManager.CreateAsync(admin, "Admin@12345");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            var user1 = await userManager.FindByNameAsync("User1234");
            if (user1 == null)
            {
                user1 = new ApplicationUser { UserName = "User1234", Email = "user1234@example.com" };
                await userManager.CreateAsync(user1, "User@12345");
                await userManager.AddToRoleAsync(user1, "User");
            }

            var user2 = await userManager.FindByNameAsync("Gamer101");
            if (user2 == null)
            {
                user2 = new ApplicationUser { UserName = "Gamer101", Email = "gamer101@example.com" };
                await userManager.CreateAsync(user2, "User@12345");
                await userManager.AddToRoleAsync(user2, "User");
            }

            // --- Post ---
            if (!db.Posts.Any())
            {
                var post = new Post
                {
                    Title = "Am I wrong in this situation?",
                    Body = "Today I went to the doctor and there was this person who " +
                           "constantly tried to get in first despite the line. So I was " +
                           "a little bit frustrated and hungry and basically called him " +
                           "some name. BUT I explained to the cops..."
                };
                db.Posts.Add(post);
                db.SaveChanges();

                // --- Sample comments ---
                db.Comments.AddRange(
                    new Comment { PostId = post.Id, AuthorId = user1.Id, Text = "Yeah you are totally in the wrong, cant believe you said that", Likes = 2 },
                    new Comment { PostId = post.Id, AuthorId = user2.Id, Text = "im dead lmao", Likes = 5 }
                );
                db.SaveChanges();
            }
        }
    }
}
