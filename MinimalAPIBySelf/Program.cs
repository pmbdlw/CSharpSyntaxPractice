// See https://aka.ms/new-console-template for more information

using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MinimalAPIBySelf.Db;
using Microsoft.Extensions.Configuration;
using MinimalAPIBySelf;

var builder = WebApplication.CreateBuilder(args);

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
            ValidIssuer = "ningissuer",
            ValidAudience = "wr",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfsdfsrty45634kkhxxhtdgdfss345t678xx"))
        };
    });

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("AdminOnly", policy =>
//    {
//        policy.RequireClaim("role", "admin");
//    });
//});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AdminOnly", policy =>
    {
        policy.RequireClaim("role", "admin");
    });


#endregion

#region swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "企业官网Api", Version = "v1" });

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

var app = builder.Build();
app.UseSwagger();
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

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "企业官网Api");
    c.RoutePrefix = string.Empty; // 将 Swagger UI 设置为应用程序的根路径
});

//ServiceLocator.Instance = app.Services;
//ServiceLocator.ApplicationBuilder = app;

//var db = SqlSugarHelper.Db;
//数据库初始化
//app.MapGet("/seed", async () =>
app.MapGet("/seed", () =>
{
    var db = new CmsContext();
    
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

