using Sunny.UI;
using StudentCourseManager.Forms;
namespace StudentCourseManager
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 新版SunnyUI正确的蓝色主题设置方式
            UIStyles.SetStyle(UIStyle.Blue);
            //Application.Run(new Form1());
            Application.Run(new MainForm());
        }
    }
}