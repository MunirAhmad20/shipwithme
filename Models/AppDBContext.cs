
using ChatApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using shipwithme.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;


namespace shipwithme.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        { }
        public AppDBContext(DbContextOptions options) : base(options)
        {

        }
        public AppDBContext (DbContextOptions<AppDBContext> options)
          : base(options)
        {
        }
        private static string ConnectionString { get; set; }


        public DbSet<Registration> Registration { get; set; }
        public DbSet<Adminlogin> Adminlogin { get; set; }
        public DbSet<createpurposal> Createpurposal { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Preference> Preference { get; set; }
        public DbSet<PurposalImage> PurposalImage { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Citylist> Citylist { get; set; }
        public DbSet<countrylist> countrylist { get; set; }
        public DbSet<Airportlist> Airportlist { get; set; }
        public DbSet<reasonlist> reasonlist { get; set; }
        public DbSet<accountlimit> accountlimit { get; set; }
        public DbSet<weight> weight { get; set; }
        public DbSet<onlineshopping> onlineshopping { get; set; }
        public static void SetConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            //});
            //services.AddDbContext<AppDBContext>(o => o.UseSqlServer(ConnectionString));
            //services.AddTransient<IAsyncPaymentsService<PaymentDetail>, PaymentService>();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
     ///options.UseSqlServer("Data Source=.;Initial Catalog=moneyfinder;Integrated Security=True");
           /// options.UseSqlServer("Data Source=A2NWPLSK14SQL-v01.shr.prod.iad2.secureserver.net;Initial Catalog=usmandb;User Id=Usman;Password =Lalamunir@20");
 ///options.UseSqlServer("Data Source=.;Initial Catalog=swm;Integrated Security=True");
   options.UseSqlServer("Data Source=SQL5079.site4now.net;Initial Catalog=db_a81f4a_swm;User Id=db_a81f4a_swm_admin;Password=Lalamunir@20");
        }

       
    }
}
