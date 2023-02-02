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
                

                Database.Instance.EnsureDeploymentTable();

                DeploymentDataManager.Instance.LoadDeployments();

            }).Start();


            Application.Run(new QDMainForm());

            new Thread(() => 
            {
                MessageBox.Show("hello world");
                WorkingDialog.Instance.TaskUpdate("Hello world!");


            })
            {
                IsBackground = true,
                Name = "QD Worker Thread"
            }.Start();
        }
    }
}