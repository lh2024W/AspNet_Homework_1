
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    string path = request.Path.ToString().ToLower();

    if (path == "/")
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("Html/index.html");
    }
    else if (path == "/form" && request.Method == "POST")
    {
        string userName = request.Form["username"];
        string userPhone = request.Form["userPhone"];
        await response.WriteAsync($"User name - {userName}{Environment.NewLine}User phone - {userPhone}");
    }
    else if (path == "/form")
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("Html/form.html");
    }
    else
    {
        response.StatusCode = 404;
        await response.WriteAsync("Not found");
    }
});

app.Run();
       
