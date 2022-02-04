var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    return Results.Ok("Hello world");
});
app.MapGet("/{nome}", (string nome) =>
{
    return Results.Ok($"Hello {nome}");
});

app.MapPost("/", (User user) =>
{
    var response = new UserResponse();
    response.success = true;
    response.user = user;
    return Results.Ok(response);
});

app.Run();

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
}

public class AppResponse
{
    public bool success { get; set; }
    public string? message { get; set; }
}

public class UserResponse : AppResponse
{
    public User? user { get; set; }
}