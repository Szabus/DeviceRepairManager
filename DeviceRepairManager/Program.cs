using DeviceRepairManager.Data;


namespace DeviceRepairManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            var db = new DatabaseService("repair.db");


            var conn = db.GetConnection();

            
            Application.Run(new LoginForm(conn));

            
            conn.Close();
        }
    }
}