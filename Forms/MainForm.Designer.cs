namespace StudentCourseManager.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tabMain = new TabControl();
            tabPageStudent = new TabPage();
            btnStudentRefresh = new Button();
            btnStudentDelete = new Button();
            btnStudentUpdate = new Button();
            btnStudentAdd = new Button();
            txtStudentMajor = new TextBox();
            txtStudentName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtStudentAge = new TextBox();
            txtStudentId = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dataGridViewStudents = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            Age = new DataGridViewTextBoxColumn();
            Major = new DataGridViewTextBoxColumn();
            labelStudents = new Label();
            tabPageCourse = new TabPage();
            tabPageSelect = new TabPage();
            tabPageScore = new TabPage();
            tabMain.SuspendLayout();
            tabPageStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabPageStudent);
            tabMain.Controls.Add(tabPageCourse);
            tabMain.Controls.Add(tabPageSelect);
            tabMain.Controls.Add(tabPageScore);
            tabMain.Location = new Point(24, 8);
            tabMain.Margin = new Padding(5);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(768, 584);
            tabMain.TabIndex = 0;
            // 
            // tabPageStudent
            // 
            tabPageStudent.Controls.Add(btnStudentRefresh);
            tabPageStudent.Controls.Add(btnStudentDelete);
            tabPageStudent.Controls.Add(btnStudentUpdate);
            tabPageStudent.Controls.Add(btnStudentAdd);
            tabPageStudent.Controls.Add(txtStudentMajor);
            tabPageStudent.Controls.Add(txtStudentName);
            tabPageStudent.Controls.Add(label4);
            tabPageStudent.Controls.Add(label3);
            tabPageStudent.Controls.Add(txtStudentAge);
            tabPageStudent.Controls.Add(txtStudentId);
            tabPageStudent.Controls.Add(label2);
            tabPageStudent.Controls.Add(label1);
            tabPageStudent.Controls.Add(dataGridViewStudents);
            tabPageStudent.Controls.Add(labelStudents);
            tabPageStudent.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            tabPageStudent.Location = new Point(4, 37);
            tabPageStudent.Margin = new Padding(5);
            tabPageStudent.Name = "tabPageStudent";
            tabPageStudent.Padding = new Padding(5);
            tabPageStudent.Size = new Size(760, 543);
            tabPageStudent.TabIndex = 0;
            tabPageStudent.Text = "学生管理";
            tabPageStudent.UseVisualStyleBackColor = true;
            // 
            // btnStudentRefresh
            // 
            btnStudentRefresh.Location = new Point(618, 484);
            btnStudentRefresh.Margin = new Padding(5);
            btnStudentRefresh.Name = "btnStudentRefresh";
            btnStudentRefresh.Size = new Size(109, 36);
            btnStudentRefresh.TabIndex = 13;
            btnStudentRefresh.Text = "刷新";
            btnStudentRefresh.UseVisualStyleBackColor = true;
            btnStudentRefresh.Click += btnStudentRefresh_Click;
            // 
            // btnStudentDelete
            // 
            btnStudentDelete.Location = new Point(431, 484);
            btnStudentDelete.Margin = new Padding(5);
            btnStudentDelete.Name = "btnStudentDelete";
            btnStudentDelete.Size = new Size(109, 36);
            btnStudentDelete.TabIndex = 12;
            btnStudentDelete.Text = "删除";
            btnStudentDelete.UseVisualStyleBackColor = true;
            btnStudentDelete.Click += btnStudentDelete_Click;
            // 
            // btnStudentUpdate
            // 
            btnStudentUpdate.Location = new Point(243, 484);
            btnStudentUpdate.Margin = new Padding(5);
            btnStudentUpdate.Name = "btnStudentUpdate";
            btnStudentUpdate.Size = new Size(109, 36);
            btnStudentUpdate.TabIndex = 11;
            btnStudentUpdate.Text = "修改";
            btnStudentUpdate.UseVisualStyleBackColor = true;
            btnStudentUpdate.Click += btnStudentUpdate_Click;
            // 
            // btnStudentAdd
            // 
            btnStudentAdd.Location = new Point(56, 484);
            btnStudentAdd.Margin = new Padding(5);
            btnStudentAdd.Name = "btnStudentAdd";
            btnStudentAdd.Size = new Size(109, 36);
            btnStudentAdd.TabIndex = 10;
            btnStudentAdd.Text = "添加";
            btnStudentAdd.UseVisualStyleBackColor = true;
            btnStudentAdd.Click += btnStudentAdd_Click;
            // 
            // txtStudentMajor
            // 
            txtStudentMajor.Location = new Point(542, 434);
            txtStudentMajor.Margin = new Padding(5);
            txtStudentMajor.Name = "txtStudentMajor";
            txtStudentMajor.Size = new Size(142, 35);
            txtStudentMajor.TabIndex = 9;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(542, 390);
            txtStudentName.Margin = new Padding(5);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(142, 35);
            txtStudentName.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(475, 434);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 7;
            label4.Text = "专业:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(475, 390);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 28);
            label3.TabIndex = 6;
            label3.Text = "姓名:";
            // 
            // txtStudentAge
            // 
            txtStudentAge.Location = new Point(134, 434);
            txtStudentAge.Margin = new Padding(5);
            txtStudentAge.Name = "txtStudentAge";
            txtStudentAge.Size = new Size(142, 35);
            txtStudentAge.TabIndex = 5;
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(134, 390);
            txtStudentId.Margin = new Padding(5);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(142, 35);
            txtStudentId.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 434);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 28);
            label2.TabIndex = 3;
            label2.Text = "年龄:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 390);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 28);
            label1.TabIndex = 2;
            label1.Text = "学号：";
            // 
            // dataGridViewStudents
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Columns.AddRange(new DataGridViewColumn[] { Id, Name, Age, Major });
            dataGridViewStudents.EnableHeadersVisualStyles = false;
            dataGridViewStudents.Location = new Point(24, 51);
            dataGridViewStudents.Margin = new Padding(5);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.RowHeadersWidth = 62;
            dataGridViewStudents.RowTemplate.Height = 30;
            dataGridViewStudents.Size = new Size(712, 323);
            dataGridViewStudents.TabIndex = 1;
            dataGridViewStudents.CellClick += dataGridViewStudents_CellClick;
            // 
            // Id
            // 
            Id.HeaderText = "学号";
            Id.MinimumWidth = 8;
            Id.Name = "Id";
            Id.Width = 150;
            // 
            // Name
            // 
            Name.HeaderText = "姓名";
            Name.MinimumWidth = 8;
            Name.Name = "Name";
            Name.Width = 150;
            // 
            // Age
            // 
            Age.HeaderText = "年龄";
            Age.MinimumWidth = 8;
            Age.Name = "Age";
            Age.Width = 150;
            // 
            // Major
            // 
            Major.HeaderText = "专业";
            Major.MinimumWidth = 8;
            Major.Name = "Major";
            Major.Width = 150;
            // 
            // labelStudents
            // 
            labelStudents.AutoSize = true;
            labelStudents.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            labelStudents.Location = new Point(30, 14);
            labelStudents.Margin = new Padding(5, 0, 5, 0);
            labelStudents.Name = "labelStudents";
            labelStudents.Size = new Size(110, 31);
            labelStudents.TabIndex = 0;
            labelStudents.Text = "学生管理";
            // 
            // tabPageCourse
            // 
            tabPageCourse.Location = new Point(4, 33);
            tabPageCourse.Margin = new Padding(5);
            tabPageCourse.Name = "tabPageCourse";
            tabPageCourse.Padding = new Padding(5);
            tabPageCourse.Size = new Size(760, 547);
            tabPageCourse.TabIndex = 1;
            tabPageCourse.Text = "课程管理";
            tabPageCourse.UseVisualStyleBackColor = true;
            // 
            // tabPageSelect
            // 
            tabPageSelect.Location = new Point(4, 33);
            tabPageSelect.Margin = new Padding(5);
            tabPageSelect.Name = "tabPageSelect";
            tabPageSelect.Padding = new Padding(5);
            tabPageSelect.Size = new Size(760, 547);
            tabPageSelect.TabIndex = 2;
            tabPageSelect.Text = "选课管理";
            tabPageSelect.UseVisualStyleBackColor = true;
            // 
            // tabPageScore
            // 
            tabPageScore.Location = new Point(4, 33);
            tabPageScore.Margin = new Padding(5);
            tabPageScore.Name = "tabPageScore";
            tabPageScore.Padding = new Padding(5);
            tabPageScore.Size = new Size(760, 547);
            tabPageScore.TabIndex = 3;
            tabPageScore.Text = "成绩查询";
            tabPageScore.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 602);
            Controls.Add(tabMain);
            Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Margin = new Padding(5);

            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            tabMain.ResumeLayout(false);
            tabPageStudent.ResumeLayout(false);
            tabPageStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageStudent;
        private System.Windows.Forms.TabPage tabPageCourse;
        private System.Windows.Forms.TabPage tabPageSelect;
        private System.Windows.Forms.TabPage tabPageScore;
        private System.Windows.Forms.Label labelStudents;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Age;
        private System.Windows.Forms.DataGridViewTextBoxColumn Major;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudentMajor;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStudentAge;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Button btnStudentRefresh;
        private System.Windows.Forms.Button btnStudentDelete;
        private System.Windows.Forms.Button btnStudentUpdate;
        private System.Windows.Forms.Button btnStudentAdd;
    }
}