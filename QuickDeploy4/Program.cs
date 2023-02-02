using QuickDeploy4.Data;
using QuickDeploy4.UI.Windows;

namespace QuickDeploy4
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
            ApplicationConfiguration.Initialize();


            WorkingDialog.Instance.Show();
            WorkingDialog.Instance.Hide();

            //init thread 
            new Thread(() => {
            
                // * Wait for the QDMainForm instance to be created, and a handle generated, before we continue. This will ensure that the "QD4 is working" dialog can show properly
                // We show this dialog ontop of the main one to remove any speculation of a supposed crash whilst we load everything.
                while (true)
                {
                    if (QDMainForm.Instance == null || !QDMainForm.Instance.IsHandleCreated)
                    {
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        break;
                    }
                }
                
                // Ensure the database exists,
                // Create the database file if it doesn't,
                // Ensure all tables exist, create them if not
                Database.Instance.EnsureDeploymentTable();

                // Load all deployments from existing database tables
                DeploymentDataManager.Instance.LoadDeployments();

            }) {  Name = "QD WORKER THREAD" } .Start();

            // Run the main UI form 
            Application.Run(new QDMainForm());
        }
    }
}