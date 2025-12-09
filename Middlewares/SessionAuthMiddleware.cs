using Microsoft.EntityFrameworkCore;
using ClubActivitiesSystem.Db;

public class SessionAuthMiddleware
{
    private readonly RequestDelegate _next;

    public SessionAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, DBContext db)
    {
        var path = context.Request.Path.Value?.ToLower();
        if (path == null) {
            context.Response.Redirect("/Account/Login");
            return;
        }

        // 允許匿名查看的頁面（白名單）
        var allowAnonymous = new[]
        {
            "/account/login",
            "/account/register"
        };

        // 是否白名單頁面
        bool isAllowed = allowAnonymous.Any(x => path.StartsWith(x));

        // 檢查 session token
        if (context.Request.Cookies.TryGetValue("session_token", out var token))
        {
            var session = await db.Sessions
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Token == token && x.ExpiresAt > DateTime.UtcNow);

            if (session != null)
            {
                context.Items["User"] = session.User;
                context.Items["Session"] = session;

                await _next(context);
                return;
            }
        }

        // 尚未登入但正在開 Login 或 Register
        if (isAllowed)
        {
            await _next(context);
            return;
        }

        // 導向登入頁面
        context.Response.Redirect("/Account/Login");
    }
}
