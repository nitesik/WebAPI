using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Repository;
using WebAPI.Services;

const string AllowedOrigin = "_allowedOrigin";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string JwtSigningKey = "r/b2NzaAxi7kzNTOPZTvio8o9uxVTvb0GL6Y2bzMQtc=";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters()
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = "localhost:7058",
			ValidAudience = "localhost:7058",
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSigningKey))
		};
	});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUsersRepository, UsersRepository>();
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
  
builder.Services.AddCors(options =>
{
	options.AddPolicy(AllowedOrigin, policy =>
	{
		policy.WithOrigins("*");
		policy.AllowAnyMethod();
		policy.AllowAnyHeader();
	});
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(AllowedOrigin);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();