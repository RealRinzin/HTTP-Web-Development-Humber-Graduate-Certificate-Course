using Microsoft.EntityFrameworkCore;
using MiniBlogRoleBase.Data;
using MiniBlogRoleBase.Models;
namespace MiniBlogRoleBase.Services;

public class CommentService
{

    private readonly AppDBContext _context;
    public CommentService(AppDBContext context)
    {
        _context = context;
    }
    // Get all comments for a specific post, including author details
    public List<Comment> GetCommentsByPostId(int postId)
    {
        return _context.Comments
                       .Include(c => c.User)
                       .Where(c => c.PostId == postId)
                       .OrderByDescending(c => c.CreatedAt)
                       .ToList();
    }
    public Comment? GetCommentById(int id)
    {
        return _context.Comments.Find(id);
    }
    // Save a new comment
    public void AddComment(Comment comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
    }
    public void UpdateComment(Comment comment)
    {
        var existing = _context.Comments.Find(comment.Id);
        if (existing != null)
        {
            existing.Comments = comment.Comments;
            _context.SaveChanges();
        }
    }

    public void DeleteComment(int id)
    {
        var comment = _context.Comments.Find(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}