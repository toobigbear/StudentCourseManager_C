using StudentCourseManager.Forms;
using Sunny.UI;
namespace StudentCourseManager
{
    public partial class Form1 : UIForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Hide(); // 隐藏当前Form1
            mainForm.Show(); // 打开主窗体
           //this.Close(); // 关闭原来的Form1

        }
    }
}
