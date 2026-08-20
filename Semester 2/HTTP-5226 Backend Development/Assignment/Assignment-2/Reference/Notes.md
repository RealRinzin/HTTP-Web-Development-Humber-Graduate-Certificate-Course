# Table Structure (what the migration actually creates)

**AspNetUsers** (from Identity, +1 column we added)
| Column | Type | Notes |
|---|---|---|
| Id | string (PK) | Identity's default key type |
| UserName | string | e.g. "User1234" |
| Email | string | |
| PasswordHash | string | managed by Identity, never store raw passwords |
| IsBanned | bit | **our addition** |

**AspNetRoles** / **AspNetUserRoles** (from Identity)
- Two roles used: `"User"`, `"Admin"`. Guest = no row at all (not authenticated).

**Posts**
| Column | Type |
|---|---|
| Id | int (PK) |
| Title | string(200) |
| Body | string |
| CreatedAt | datetime |

**Comments**
| Column | Type | Notes |
|---|---|---|
| Id | int (PK) | |
| Text | string(1000) | |
| CreatedAt | datetime | |
| Likes | int | bonus feature |
| PostId | int (FK → Posts.Id) | cascade delete |
| AuthorId | string (FK → AspNetUsers.Id) | restrict delete |

---

# Login: blocking banned users

Add this check inside your `AccountController.Login` POST action, **before**
`SignInManager.PasswordSignInAsync` succeeds is treated as final:

```csharp
var user = await _userManager.FindByNameAsync(model.UserName);
if (user != null && user.IsBanned)
{
    ModelState.AddModelError("", "You have been banned.");
    return View(model);
}
```

---

# Getting `CurrentUserId` into every view without repeating code

Rather than pulling `UserManager` into every controller, add one line to a
shared base controller (or an action filter) that all your controllers inherit
from:

```csharp
public class BaseController : Controller
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            ViewBag.CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        base.OnActionExecuted(context);
    }
}
```

Then `PostController : BaseController` instead of `PostController : Controller`.
This keeps the "who am I" lookup in **one place** — the same "centralize
authorization checks" principle from the concept guide.
