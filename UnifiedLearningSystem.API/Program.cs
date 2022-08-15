using UnifiedLearningSystem.API.Middleware;
using UnifiedLearningSystem.Application;
using UnifiedLearningSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.InjectApplicationLayer();
builder.Services.InjectInfrastructureLayer(builder.Configuration);
builder.Services.AddResponseCaching();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
                  p => p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseResponseCaching();
app.UseStaticFiles();
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionCustomMiddleware>();
app.UseMiddleware<LoggerCustomMiddleware>();
app.MapControllers();

app.Run();


