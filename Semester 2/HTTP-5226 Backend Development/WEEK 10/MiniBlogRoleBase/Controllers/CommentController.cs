using Microsoft.AspNetCore.Mvc;
using MiniBlogRoleBase.Models;
using MiniBlogRoleBase.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MiniBlogRoleBase.Controllers;

public class CommentController : Controller
{
    private readonly CommentService _commentService;
    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }
    // POST: /Comment/Add
    [HttpPost]
    [Authorize]
    public IActionResult Add(int postId, string commentText,int rating)
    {
        if (string.IsNullOrWhiteSpace(commentText))
        {
            return RedirectToAction("Detail", "Comment", new { id = postId });
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        // Clamp rating between 1 and 5
        rating = Math.Clamp(rating, 1, 5);
        var comment = new Comment
        {
            PostId = postId,
            Comments = commentText,
            Rating = rating,
            UserId = userId!,
            CreatedAt = DateTime.UtcNow
        };

        _commentService.AddComment(comment);

        return RedirectToAction("Detail", "Post", new { id = postId });
    }

    // GET: /Comment/Edit/5
    [HttpGet]
    [Authorize]
    public IActionResult Edit(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var comment = _commentService.GetCommentById(id);

        if (comment == null) return NotFound();

        // Security: Ensure user owns the comment
        if (comment.UserId != userId) return Unauthorized();

        return View(comment);
    }

    // POST: /Comment/Edit
    [HttpPost]
    [Authorize]
    public IActionResult Edit(Comment comment)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var existingComment = _commentService.GetCommentById(comment.Id);

        if (existingComment == null) return NotFound();
        if (existingComment.UserId != userId) return Unauthorized();

        ModelState.Remove("User");
        ModelState.Remove("Post");

        if (!ModelState.IsValid)
        {
            return View(comment);
        }

        _commentService.UpdateComment(comment);

        // Redirect back to the post's detail page
        return RedirectToAction("Detail", "Post", new { id = comment.PostId });
    }

    // POST: /Comment/Delete
    [HttpPost]
    [Authorize]
    public IActionResult Delete(int commentId, int postId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var comment = _commentService.GetCommentById(commentId);

        if (comment == null) return NotFound();
        if (comment.UserId != userId) return Unauthorized();

        _commentService.DeleteComment(commentId);

        return RedirectToAction("Detail", "Post", new { id = postId });
    }
}
