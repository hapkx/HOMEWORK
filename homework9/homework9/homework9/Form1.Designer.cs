
namespace homework9
{
    partial class Form1
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
            this.URLText = new System.Windows.Forms.TextBox();
            this.startbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.resultGrid = new System.Windows.Forms.DataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // URLText
            // 
            this.URLText.Location = new System.Drawing.Point(127, 28);
            this.URLText.Name = "URLText";
            this.URLText.Size = new System.Drawing.Size(535, 25);
            this.URLText.TabIndex = 0;
            // 
            // startbtn
            // 
            this.startbtn.Location = new System.Drawing.Point(686, 30);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(75, 23);
            this.startbtn.TabIndex = 1;
            this.startbtn.Text = "开始爬行";
            this.startbtn.UseVisualStyleBackColor = true;
            this.startbtn.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "输入网址：";
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(27, 65);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 15);
            this.info.TabIndex = 3;
            // 
            // resultGrid
            // 
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.URL,
            this.状态});
            this.resultGrid.Location = new System.Drawing.Point(30, 83);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.RowHeadersWidth = 51;
            this.resultGrid.RowTemplate.Height = 27;
            this.resultGrid.Size = new System.Drawing.Size(870, 335);
            this.resultGrid.TabIndex = 4;
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "Index";
            this.序号.HeaderText = "序号";
            this.序号.MinimumWidth = 6;
            this.序号.Name = "序号";
            this.序号.Width = 125;
            // 
            // URL
            // 
            this.URL.DataPropertyName = "URL";
            this.URL.HeaderText = "URL";
            this.URL.MinimumWidth = 6;
            this.URL.Name = "URL";
            this.URL.Width = 500;
            // 
            // 状态
            // 
            this.状态.DataPropertyName = "Status";
            this.状态.HeaderText = "状态";
            this.状态.MinimumWidth = 6;
            this.状态.Name = "状态";
            this.状态.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 450);
            this.Controls.Add(this.resultGrid);
            this.Controls.Add(this.info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startbtn);
            this.Controls.Add(this.URLText);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URLText;
        private System.Windows.Forms.Button startbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.DataGridView resultGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
    }
}