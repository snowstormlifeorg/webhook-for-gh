var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/event/{id}", async (http) => 
    { await Task.Run(() => 
        {
            var id = http.Request.RouteValues["id"];
            http.Response.StatusCode = 200;
            http.Response.ContentType = "text/plain";
            http.Response.WriteAsync($"Event {id} has been received. (Yay)");
        }); 
    });

app.Run();