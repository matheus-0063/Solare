using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Solare.App.Data;
using Solare.Business.Interfaces;
using Solare.Data.Context;
using Solare.Data.Repository;

namespace Solare.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Guardando a connection string do arquivo appSettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Adicionando o suporte ao acesso ao DB do Identity via EF
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<SolareDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            builder.Services.AddScoped<ISimulacaoRepository, SimulacaoRepository>();
            builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IEnderecoSimulacaoRepository, EnderecoSimulacaoRepository>();

            // Adicionando a tela de erro de banco de dados (para desenvolvimento)
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Adicionando o Identity
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Adicionando o MVC
            builder.Services.AddControllersWithViews();

            //Adicionar AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // Gerando a APP
            var app = builder.Build();

            // Configuração conforme os ambientes
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
