using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebMinimumApi1.Data;
using WebMinimumApi1.Model;
using WebMinimumApi1.Properties;

namespace WebMinimumApi1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //ע��DbContext
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteConstr")));
            //1��cd����ĿĿ¼
            //2������EF    $ dotnet tool update --global dotnet-ef
            //3������Ǩ��   $ dotnet ef migrations add initialmigration
            //4���������ݿ� $ dotnet ef database update

            builder.Services.AddAutoMapper(typeof(OrganizationProfile));
            IMapper mapper = new MapperConfiguration(mc =>
            {
                //��ӳ��Id
                mc.AddProfile<OrganizationProfile>();
                mc.ShouldMapProperty = Id => false;
            }).CreateMapper();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            //ȫ���ѯ
            app.MapGet("api/todo/query", async (AppDbContext context) =>
            {
                var items = await context.ToDos.ToListAsync();
                return Results.Ok(items);
            });

            app.MapPost("api/todo/add", async (AppDbContext context, ToDo toDo) =>
            {
                await context.ToDos.AddAsync(toDo);
                await context.SaveChangesAsync();
                return Results.Created($"toDo:{toDo.Id}", toDo);
            });

            app.MapPut("api/todo/update/{id}", async (AppDbContext context, int id, ToDo toDo) =>
            {
                var toDoDTO = await context.ToDos.FirstOrDefaultAsync(t => t.Id == id);
                if (toDoDTO == null)
                {
                    return Results.NotFound();
                }
                //toDoDTO = mapper.Map<ToDo>(toDo);
                toDoDTO.Name = toDo.Name;
                int flags = await context.SaveChangesAsync();
                return Results.Accepted(flags.ToString());
            });

            app.MapDelete("api/todo/delete/{id}", async (AppDbContext context, int id) =>
            {
                var toDoDTO = await context.ToDos.FirstOrDefaultAsync(t => t.Id == id);
                if (toDoDTO == null)
                {
                    return Results.NotFound();
                }
                context.ToDos.Remove(toDoDTO);
                await context.SaveChangesAsync();
                return Results.NoContent();
            });

            app.Run();
        }
    }
}