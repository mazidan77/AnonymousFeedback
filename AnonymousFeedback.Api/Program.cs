
using AnonymousFeedback.Application.Managers;
using AnonymousFeedback.Application.Mapper;
using AnonymousFeedback.Domian.IManagers;
using AnonymousFeedback.Domian.IRepositories;
using AnonymousFeedback.Domian.IUnitOfWork;
using AnonymousFeedback.Infrastructure;
using AnonymousFeedback.Infrastructure.Repositories;
using AnonymousFeedback.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace AnonymousFeedback.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddAutoMapper(typeof(UserMapper));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IBaseManager<>), typeof(BaseManager<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            var app = builder.Build();

           

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
