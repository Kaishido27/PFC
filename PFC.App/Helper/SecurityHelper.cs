using System.Windows.Forms;
using PFC.App.Forms;

namespace PFC.App.Helpers
{
    public static class SecurityHelper
    {
        public static bool IsAuthorized()
        {
            using (var auth = new AuthForm())
            {
                return auth.ShowDialog() == DialogResult.OK;
            }
        }
    }
}