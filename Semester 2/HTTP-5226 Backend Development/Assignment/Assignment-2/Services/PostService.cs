using Assignment_2.Data;
using Assignment_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2.Services;

public class PostService
{
    private readonly ApplicationDbContext _db;
    public PostService(ApplicationDbContext db) => _db = db;

    public Task<List<Post>> GetAllAsync() =>
        _db.Posts.Include(p => p.Author).OrderByDescending(p => p.CreatedAt).ToListAsync();

    public Task<Post?> GetByIdAsync(int id) =>
        _db.Posts.Include(p => p.Author)
            .Include(p => p.Comments).ThenInclude(c => c.User)
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Post> CreateAsync(string title, string body, string authorId)
    {
        var post = new Post { Title = title, Body = body, AuthorId = authorId };
        _db.Posts.Add(post);
        await _db.SaveChangesAsync();
        return post;
    }
}