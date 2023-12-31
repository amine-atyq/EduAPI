using EduAPI;
using Microsoft.EntityFrameworkCore;
using EduAPI.Repositories; // Import the Repositories namespace
using EduAPI.Services;     // Import the Services namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EduAPIDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register repositories
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<InstructorRepository>();

// Register services
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<InstructorService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCorsPolicy",
        builder => builder.WithOrigins("https://localhost:7056") // Replace with the client's URL
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("DevCorsPolicy");

app.UseAuthorization();
app.MapControllers();
app.Run();
