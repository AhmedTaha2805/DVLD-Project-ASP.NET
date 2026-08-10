using DVLD_project.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            var services = new ServiceCollection();

            

            services.AddHttpClient<CountryClientService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7008/");
            });

            services.AddTransient<AddPersonControl>();
            services.AddTransient<PersonDetailsControl>();
            services.AddTransient<frmLoginForm>();

            ServiceProvider = services.BuildServiceProvider();

            Application.Run(ServiceProvider.GetRequiredService<frmLoginForm>());
        }
    }
}
