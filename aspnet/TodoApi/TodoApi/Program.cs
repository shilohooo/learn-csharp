using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Converters;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // 配置日期、时间序列化格式
        options.JsonSerializerOptions.Converters.Add(new CustomJsonDateTimeOffsetConverter());
    })
    // 请求参数校验失败处理
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState.Values.SelectMany(modelState => modelState.Errors);
            var errMsgBuilder = new StringBuilder();
            foreach (var error in errors)
            {
                errMsgBuilder.AppendLine(error.ErrorMessage);
            }
            return new BadRequestObjectResult(errMsgBuilder.ToString())
            {
                ContentTypes =
                {
                    MediaTypeNames.Application.Json
                }
            };
        };
    });

builder.Services.AddDbContext<TodoContext>(optionsBuilder =>
{
    // 指定使用内存数据库，方便测试
    optionsBuilder.UseInMemoryDatabase("TodoListDb")
        .LogTo(Console.WriteLine);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 全局异常处理配置
app.UseExceptionHandler(configure =>
{
    configure.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json;charset=utf-8;";

        var error = context.Features.Get<IExceptionHandlerFeature>();
        var exception = error?.Error;
        Console.WriteLine(exception);
        await context.Response.WriteAsync(exception?.Message ?? "网络错误，请稍后再试");
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();