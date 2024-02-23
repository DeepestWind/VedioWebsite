using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using VideoWebsiteApi.Interfaces;
using VideoWebsiteApi.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//添加服务
//builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddScoped<IFileUrlService, FileUrlService>();

//配置跨源资源访问
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
    builder => builder.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod());
});

builder.Services.AddDirectoryBrowser();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//启用跨源资源访问
app.UseCors("MyPolicy");

//配置静态文件夹
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetParent(builder.Environment.ContentRootPath).FullName, "resources")),
    //此时的资源文件应该在与项目文件夹同级（不在该项目文件夹内部）的位置
    RequestPath = "/resources"
});
app.UseStaticFiles(); // 开启的是默认的资源文件 wwwroot文件夹的访问

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
