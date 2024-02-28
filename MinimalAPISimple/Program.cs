using MinimalAPISimple;

var builder = WebApplication.CreateBuilder(args); //.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});
// builder.Services.AddRazorPages().AddMvcOptions(options => options.EnableEndpointRouting = false);
builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
// if (builder.Environment.IsDevelopment())
// {
//     builder.Services.AddRazorRuntimeCompilation();
// }
var app = builder.Build();
app.UseMvcWithDefaultRoute();
var sampleTodos = new Todo[] {
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom",null, true),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
};

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.Run();

