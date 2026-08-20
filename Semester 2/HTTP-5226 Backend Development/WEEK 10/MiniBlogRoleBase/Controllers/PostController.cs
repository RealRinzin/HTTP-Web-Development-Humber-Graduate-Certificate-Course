using Microsoft.AspNetCore.Mvc;
using MiniBlogRoleBase.Models;
using MiniBlogRoleBase.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims; // Add this import
namespace MiniBlogRoleBase.Controllers;

public class PostController : Controller
{
    private readonly PostService _postService;
    private readonly CommentService _commentService;
    public PostController(PostService postService, CommentService commentService)
    {
        _postService = postService;
        _commentService = commentService;
    }
    // GET: /Post/Details/5
    public IActionResult Detail(int id)
    {
        var post = _postService.getThePost(id);
        if (post == null)
        {
            return NotFound();
        }

        // Fetch comments using CommentService and pass them to View via ViewBag
        ViewBag.Comments = _commentService.GetCommentsByPostId(id);

        return View(post);
    }

    // View 
    [Authorize]
    public IActionResult Index()
    {
        // 1. Get current logged-in user's ID
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        // 2. Retrieve posts belonging only to this user
        var userPosts = _postService.GetPostsByUserId(userId);

        return View(userPosts);
    }
    [Authorize]
    public IActionResult Add()
    {
        return View();
    }
    [Authorize]
    public IActionResult Edit()
    {
        return View();
    }
    // HTTP
    [HttpPost]
    [Authorize]

    public IActionResult AddPost(Post post)
    {
        // return RedirectToAction("index");
        // 1. Get the logged-in user's ID from claims
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId != null)
        {
            post.UserId = userId;
        }

        // 2. Remove 'User' from ModelState manually if not using [ValidateNever]
        ModelState.Remove("User");
        // Check if all the fields are filled
        if (!ModelState.IsValid)
        {
            return View("Add");
        }
        // If successed then, create the record and redirect to inedex
        _postService.AddPost(post);
        return RedirectToAction("index");
    }
    // Edit the Client
    [HttpGet]
    [Authorize]
    public IActionResult Edit(int id)
    {
        // Check if all the fields are filled
        var post = _postService.getThePost(id);
        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }
    // POST: Update Post
    public IActionResult Update(Post post)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId != null)
        {
            post.UserId = userId;
        }

        ModelState.Remove("User");

        if (!ModelState.IsValid)
        {
            return View("Edit", post);
        }

        // Pass directly to service; service will handle tracking & ownership
        _postService.UpdatePost(post);

        return RedirectToAction("Index");
    }
    // POST: /Post/AddComment
    [HttpPost]
    [Authorize]
    public IActionResult AddComment(int postId, string commentText)
    {
        if (string.IsNullOrWhiteSpace(commentText))
        {
            return RedirectToAction("Details", new { id = postId });
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var comment = new Comment
        {
            PostId = postId,
            Comments = commentText,
            UserId = userId!,
            CreatedAt = DateTime.UtcNow
        };

        // Use CommentService to save the new comment
        _commentService.AddComment(comment);

        return RedirectToAction("Detail", new { id = postId });
    }

    // POST: /Post/Delete/5
    [HttpPost]
    [Authorize]
    public IActionResult Delete(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var post = _postService.getThePost(id);

        if (post == null)
        {
            return NotFound();
        }

        // Security check: ensure current user owns this post
        if (post.UserId != userId)
        {
            return Unauthorized();
        }

        _postService.DeletePost(id);

        return RedirectToAction("Index");
    }
}
