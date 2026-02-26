using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PFC.App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFC.App
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            LoadDefaultControl();
        }

        private void LoadDefaultControl()
        {
            //Makes the dashboard the default view when opening the app
            DashboardView home = new DashboardView();
            home.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(home);

        }

        private void ShowView(UserControl view)
        {
            //clear the old user control
            pnlMainContent.Controls.Clear();

            // set up the new UserControl
            view.Dock = DockStyle.Fill;
            // add to the Main Panel
            pnlMainContent.Controls.Add(view);
        }

        private void DashboardTab_Click(object sender, EventArgs e)
        {
            ShowView(new DashboardView());
        }

        private void ProductTab_Click(object sender, EventArgs e)
        {
            ShowView(new ProductView());
        }

        private void Report_Click(object sender, EventArgs e)
        {
            ShowView(new ReportsView());
        }
    }


}
