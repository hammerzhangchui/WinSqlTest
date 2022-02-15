namespace WinSqlTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTBNm = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBoxListTxt = new System.Windows.Forms.TextBox();
            this.startLine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(260, 195);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "get sqlexpress";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTBNm
            // 
            this.txtTBNm.Location = new System.Drawing.Point(12, 222);
            this.txtTBNm.Name = "txtTBNm";
            this.txtTBNm.Size = new System.Drawing.Size(100, 21);
            this.txtTBNm.TabIndex = 2;
            this.txtTBNm.Text = "tb_val";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(159, 296);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "get mysql";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(12, 305);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(100, 21);
            this.txtTable.TabIndex = 4;
            this.txtTable.Text = "tb_reader";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(278, 296);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 36);
            this.button3.TabIndex = 5;
            this.button3.Text = "get mysql(count)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(159, 338);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 36);
            this.button4.TabIndex = 6;
            this.button4.Text = "update ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(343, 407);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(113, 36);
            this.button5.TabIndex = 7;
            this.button5.Text = "批量更新";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBoxListTxt
            // 
            this.textBoxListTxt.Location = new System.Drawing.Point(12, 380);
            this.textBoxListTxt.Name = "textBoxListTxt";
            this.textBoxListTxt.Size = new System.Drawing.Size(444, 21);
            this.textBoxListTxt.TabIndex = 12;
            this.textBoxListTxt.Text = "D:\\Zhangc\\VSProject\\TCWin\\bin\\Debug\\logs\\Info.log";
            // 
            // startLine
            // 
            this.startLine.Location = new System.Drawing.Point(71, 416);
            this.startLine.Name = "startLine";
            this.startLine.Size = new System.Drawing.Size(100, 21);
            this.startLine.TabIndex = 13;
            this.startLine.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "开始行数";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(224, 407);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(113, 36);
            this.button6.TabIndex = 15;
            this.button6.Text = "选择文件批量更新";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Location = new System.Drawing.Point(343, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 269);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "dapper";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(21, 97);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(182, 23);
            this.button9.TabIndex = 2;
            this.button9.Text = "getAll(reader) sqlite";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(21, 58);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(182, 23);
            this.button8.TabIndex = 1;
            this.button8.Text = "getAll(tb_log) mysql";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(21, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(182, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "getAll(tb_val) sqlserver";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(278, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(59, 195);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(21, 140);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(182, 23);
            this.button10.TabIndex = 3;
            this.button10.Text = "Table_1) sqlserver2012";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startLine);
            this.Controls.Add(this.textBoxListTxt);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtTBNm);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTBNm;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBoxListTxt;
        private System.Windows.Forms.TextBox startLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}

