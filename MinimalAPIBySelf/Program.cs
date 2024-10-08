﻿// > See https://aka.ms/new-console-template for more information
// > This excise refers to [用最清爽的方式开发dotNet](https://www.cnblogs.com/ncellit/p/17881779.html)
//  

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MinimalAPIBySelf.Db;
using MinimalAPIBySelf;
using MinimalAPIBySelf.Api;
using MinimalAPIBySelf.Db.Models;

// Creating application builder
var builder = WebApplication.CreateBuilder(args);

#region Registering Servcies[Configuration operating, Inject modules or servcies, etc.]

#region 基本设置

builder.Services.AddMemoryCache();
builder.Services.AddControllers();

builder.Services.Configure<FormOptions>(options =>
{
    // 设置上传大小限制256MB
    options.MultipartBodyLengthLimit = 268435456;
});
var appSettings = new AppSettings();
var config = builder.Configuration;
config.GetSection("AppSettings").Bind(appSettings);
AppConfig.Settings = appSettings;
//builder.Services.AddSingleton<SqlSugarMemoryCacheService>();

#endregion

#region 授权鉴权

builder.Services.AddDbContext<CmsContext>(
    builder=>builder.UseSqlServer(appSettings.DbConnectionStrings))
    .AddDbContext<CmsContext>();
// 添加身份验证和授权中间件
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "testissuer",
            ValidAudience = "testaudience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfig.Settings.JwtSecurityKey))
        };
    });

//builder.Services.AddAuthorization(options =>00
//{
//    options.AddPolicy("AdminOnly", policy =>
//    {
//        policy.RequireClaim("role", "admin");
//    });
//});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AdminOnly", policy => { policy.RequireClaim(ClaimTypes.Role, "admin"); });

#endregion

#region Inject Swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CMS API", Version = "v1" });

    // 添加身份验证
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    // 添加授权要求
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    // 设置 XML 注释文件的路径
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

#endregion

#endregion
var app = builder.Build();

#region Use swagger

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CMS API");
    c.RoutePrefix = string.Empty; // 将 Swagger UI 设置为应用程序的根路径
});

#endregion

app.UseStaticFiles();
// 启用身份验证和授权中间件
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers(); // 这里配置了使用控制器的路由
//});

app.UseEndpoints(configure: endpoints =>
{
    _ = endpoints.MapControllers(); // 这里配置了使用控制器的路由
});

//ServiceLocator.Instance = app.Services;
//ServiceLocator.ApplicationBuilder = app;

//var db = SqlSugarHelper.Db;
//数据库初始化,只初始化数据
//app.MapGet("/seed", async () =>

app.MapGet("/seed", async (string uname, string passwd) =>
{
    using (var context = app.Services.GetService<CmsContext>()) //options=>options.UseMySql(AppConfig.Settings.DbConnectionStrings)))
    {
        var database = context.Database;

        string name = uname;
        string password = new BaseApi(context).Encrypt(passwd);
        var loginResult = await context?.SysUser.AnyAsync(e => e.UserName == name && e.UsePwd == password);
        if (!loginResult)
        {
            await context.SysUser.AddAsync(new SysUserEntity()
            {
                UserName = name,
                UsePwd = password,
                Email = "admin@i-gpt5.com"
            });
            await context.SaveChangesAsync();
            //await db.Insertable<SysUserEntity>(new SysUserEntity { IsBan = false, UsePwd = pwd, UserName = name }).ExecuteCommandAsync();
        }
    }

    //db.CodeFirst.InitTables<SysUserEntity>();

    //string name = "op";
    //string pwd = "op";
    //var loginResult = await db.Queryable<SysUserEntity>().Where(a => !a.IsBan && a.UsePwd == pwd && a.UserName == name).AnyAsync();
    //if (!loginResult)
    //{
    //    await db.Insertable<SysUserEntity>(new SysUserEntity { IsBan = false, UsePwd = pwd, UserName = name }).ExecuteCommandAsync();
    //}

    //db.CodeFirst.InitTables<FileSourceEntity>();
    //db.CodeFirst.InitTables<ArticleEntity>();
});

app.MapGet("/health", () => "1024");

app.Run();