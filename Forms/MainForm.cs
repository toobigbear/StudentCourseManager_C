using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StudentCourseManager.Models;

namespace StudentCourseManager.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "学生课程管理系统";
            SetupStudentGrid();   // 配置表格列
            LoadStudents();       // 加载数据
        }

        // ========== 表格配置 ==========

        private void SetupStudentGrid()
        {
            // 禁止自动生成列，手动配置
            dataGridViewStudents.AutoGenerateColumns = false;
            dataGridViewStudents.Columns.Clear();

            dataGridViewStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "学号",
                Width = 120
            });

            dataGridViewStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "姓名",
                Width = 150
            });

            dataGridViewStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Age",
                HeaderText = "年龄",
                Width = 100
            });

            dataGridViewStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Major",
                HeaderText = "专业",
                Width = 200
            });

            // 样式
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.MultiSelect = false;
        }

        // ========== 数据加载 ==========

        private void LoadStudents()
        {
            try
            {
                List<Student> students = DBHelper.GetStudents();
                dataGridViewStudents.DataSource = null;
                dataGridViewStudents.DataSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败：" + ex.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== 表格行点击：填充文本框 ==========

        // 在设计器里选中 dataGridViewStudents → 属性 → 事件 → CellClick → 双击
        private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewStudents.Rows[e.RowIndex];
            txtStudentId.Text = row.Cells[0].Value?.ToString();      // 学号
            txtStudentName.Text = row.Cells[1].Value?.ToString();    // 姓名
            txtStudentAge.Text = row.Cells[2].Value?.ToString();     // 年龄
            txtStudentMajor.Text = row.Cells[3].Value?.ToString();   // 专业
        }

        // ========== 添加按钮 ==========

        // 双击按钮自动生成
        private void btnStudentAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string error))
            {
                MessageBox.Show(error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = new Student
            {
                Id = int.Parse(txtStudentId.Text.Trim()),
                Name = txtStudentName.Text.Trim(),
                Age = int.Parse(txtStudentAge.Text.Trim()),
                Major = txtStudentMajor.Text.Trim()
            };

            try
            {
                if (DBHelper.AddStudent(student))
                {
                    MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadStudents();
                }
                else
                {
                    MessageBox.Show("添加失败，学号可能已存在。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== 修改按钮 ==========

        private void btnStudentUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentId.Text))
            {
                MessageBox.Show("请先选择要修改的学生！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(out string error))
            {
                MessageBox.Show(error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = new Student
            {
                Id = int.Parse(txtStudentId.Text.Trim()),
                Name = txtStudentName.Text.Trim(),
                Age = int.Parse(txtStudentAge.Text.Trim()),
                Major = txtStudentMajor.Text.Trim()
            };

            try
            {
                if (DBHelper.UpdateStudent(student))
                {
                    MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadStudents();
                }
                else
                {
                    MessageBox.Show("修改失败。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== 删除按钮 ==========

        private void btnStudentDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentId.Text))
            {
                MessageBox.Show("请先选择要删除的学生！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtStudentId.Text.Trim());
            string name = txtStudentName.Text.Trim();

            var result = MessageBox.Show($"确定删除 [{name}] 吗？", "确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                if (DBHelper.DeleteStudent(id))
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadStudents();
                }
                else
                {
                    MessageBox.Show("删除失败。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== 刷新按钮 ==========

        private void btnStudentRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadStudents();
        }

        // ========== 辅助方法 ==========

        private bool ValidateInput(out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(txtStudentId.Text) || !int.TryParse(txtStudentId.Text.Trim(), out _))
            {
                error = "学号不能为空且必须为数字！";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStudentName.Text))
            {
                error = "姓名不能为空！";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStudentAge.Text) || !int.TryParse(txtStudentAge.Text.Trim(), out int age) || age < 0 || age > 150)
            {
                error = "年龄必须是 0~150 之间的数字！";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStudentMajor.Text))
            {
                error = "专业不能为空！";
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            txtStudentId.Clear();
            txtStudentName.Clear();
            txtStudentAge.Clear();
            txtStudentMajor.Clear();
            dataGridViewStudents.ClearSelection();
        }
    }
}