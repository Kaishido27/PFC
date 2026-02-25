using PFC.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace PFC.App
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjGyl/VkR+XU9Ff1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3hTdERiWHZacHVXRWNUWU91XQ==");
            ApplicationConfiguration.Initialize();

            try
            {
                using (var context = new AppDbContext())
                {

                    context.Database.Migrate();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Database Setup has failed: {ex.Message}", "Start up Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new Main());
        }
    }
}