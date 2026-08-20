using Microsoft.EntityFrameworkCore;
using MiniBlogRoleBase.Data;
using MiniBlogRoleBase.Models;
namespace MiniBlogRoleBase.Services;

public class PostService
{

    private readonly AppDBContext _context;
    public PostService(AppDBContext context)
    {
        _context = context;
    }

    public Post? GetPostWithComments(int postId)
    {
        return _context.Posts
            .Include(p => p.User)
            .Include(p => p.Comments)
                .ThenInclude(c => c.User)
            .FirstOrDefault(p => p.Id == postId);
    }
    public List<Post> GetPosts()
    {
        return _context.Posts.ToList();
    }
    // Get posts for a SPECIFIC user
    public List<Post> GetPostsByUserId(string userId)
    {
        return _context.Posts
                       .Where(p => p.UserId == userId)
                       .ToList();
    }
    // Add New Client
    public void AddPost(Post post)
    {
        _context.Posts.Add(post);
        _context.SaveChanges();
    }
    public Post getThePost(int id)
    {

        return _context.Posts.Find(id);
    }
    // Update the existing Client
    public void UpdatePost(Post post)
    {
        _context.Update(post);
        _context.SaveChanges();
    }

    public void DeletePost(int id)
    {
        var post = _context.Posts.Find(id);
        if (post != null)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}