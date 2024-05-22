using Ecommerce.DAL.Data.Context;
using Ecommerce.DAL;
using Ecommerce.BL;
using Microsoft.EntityFrameworkCore;
using Ecommerce.DAL.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ecommerce.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//////////////////////////////////////////////////////////////////////////////
builder.Services.AddBLServices(); // add managers

builder.Services.AddDALServices(builder.Configuration); // add context, repos, unit of work

const string AllowAllCorsPolicy = "AllowAll";
builder.Services.AddCors(options =>
{
	options.AddPolicy(AllowAllCorsPolicy, b =>
	{
		b.AllowAnyOrigin()
		 .AllowAnyMethod()
		 .AllowAnyHeader();
	});
});


#region Identity

builder.Services.AddIdentityCore<User>(options =>
{
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 3;

	options.User.RequireUniqueEmail = true;
})
	.AddEntityFrameworkStores<EcommerceContext>();

#endregion


#region Authentication

builder.Services.AddAuthentication(options =>
{
	// Configure used authentication 
	options.DefaultAuthenticateScheme = "MyDefault";
	options.DefaultChallengeScheme = "MyDefault";   // return 401 if not authenticated, 403 if authenticated but not authorized
})
	// Define the authentication scheme
	.AddJwtBearer("MyDefault", options =>
	{
		var keyFromConfig = builder.Configuration.GetValue<string>(Constants.AppSettings.SecretKey)!;
		var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
		var key = new SymmetricSecurityKey(keyInBytes);

		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			IssuerSigningKey = key
		};
	});

#endregion



//////////////////////////////////////////////////////////////////////////////




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//////////////////////////////////////////////////////////
app.UseCors(AllowAllCorsPolicy);

app.UseAuthentication();
//////////////////////////////////////////////////////////

app.UseAuthorization();

app.MapControllers();

app.Run();
