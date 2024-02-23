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

//��ӷ���
//builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddScoped<IFileUrlService, FileUrlService>();

//���ÿ�Դ��Դ����
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

//���ÿ�Դ��Դ����
app.UseCors("MyPolicy");

//���þ�̬�ļ���
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetParent(builder.Environment.ContentRootPath).FullName, "resources")),
    //��ʱ����Դ�ļ�Ӧ��������Ŀ�ļ���ͬ�������ڸ���Ŀ�ļ����ڲ�����λ��
    RequestPath = "/resources"
});
app.UseStaticFiles(); // ��������Ĭ�ϵ���Դ�ļ� wwwroot�ļ��еķ���

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
