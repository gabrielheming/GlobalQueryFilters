using GlobalQueryFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<GlobalQueryFiltersDbContext>();

var app = builder.Build();

// using(var scope = app.Services.CreateScope())
// {
//     var scopedServices = scope.ServiceProvider;
//     var dbContext = scopedServices.GetRequiredService<GlobalQueryFiltersDbContext>();
//     dbContext.Database.EnsureCreated();
// }

app.MapGet("/", async (GlobalQueryFiltersDbContext dbContext, CancellationToken cancellationToken) => dbContext.Posts.Count());

app.Run();