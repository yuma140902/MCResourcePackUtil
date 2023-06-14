namespace MCResourcePackUtil.Forms
{
	partial class FilterForm
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
			if (disposing && (components != null)) {
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
			this.selectionBtn = new System.Windows.Forms.Button();
			this.pathBox = new System.Windows.Forms.TextBox();
			this.runBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.label2 = new System.Windows.Forms.Label();
			this.outputPathBox = new System.Windows.Forms.TextBox();
			this.outputSelectBtn = new System.Windows.Forms.Button();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.filterTypeBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// selectionBtn
			// 
			this.selectionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.selectionBtn.Location = new System.Drawing.Point(343, 12);
			this.selectionBtn.Name = "selectionBtn";
			this.selectionBtn.Size = new System.Drawing.Size(22, 19);
			this.selectionBtn.TabIndex = 0;
			this.selectionBtn.Text = "…";
			this.selectionBtn.UseVisualStyleBackColor = true;
			this.selectionBtn.Click += new System.EventHandler(this.selectionBtn_Click);
			// 
			// pathBox
			// 
			this.pathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pathBox.Location = new System.Drawing.Point(53, 12);
			this.pathBox.Name = "pathBox";
			this.pathBox.ReadOnly = true;
			this.pathBox.Size = new System.Drawing.Size(284, 19);
			this.pathBox.TabIndex = 1;
			// 
			// runBtn
			// 
			this.runBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.runBtn.Location = new System.Drawing.Point(290, 233);
			this.runBtn.Name = "runBtn";
			this.runBtn.Size = new System.Drawing.Size(75, 23);
			this.runBtn.TabIndex = 2;
			this.runBtn.Text = "実行(&R)";
			this.runBtn.UseVisualStyleBackColor = true;
			this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "入力: ";
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(12, 233);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(272, 23);
			this.progressBar.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "出力: ";
			// 
			// outputPathBox
			// 
			this.outputPathBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.outputPathBox.Location = new System.Drawing.Point(53, 37);
			this.outputPathBox.Name = "outputPathBox";
			this.outputPathBox.ReadOnly = true;
			this.outputPathBox.Size = new System.Drawing.Size(284, 19);
			this.outputPathBox.TabIndex = 6;
			// 
			// outputSelectBtn
			// 
			this.outputSelectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.outputSelectBtn.Location = new System.Drawing.Point(343, 37);
			this.outputSelectBtn.Name = "outputSelectBtn";
			this.outputSelectBtn.Size = new System.Drawing.Size(22, 19);
			this.outputSelectBtn.TabIndex = 7;
			this.outputSelectBtn.Text = "…";
			this.outputSelectBtn.UseVisualStyleBackColor = true;
			this.outputSelectBtn.Click += new System.EventHandler(this.outputSelectBtn_Click);
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.checkedListBox1.Enabled = false;
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Items.AddRange(new object[] {
            "Blocks",
            "Items",
            "Entities",
            "Gui",
            "その他(assets内)",
            "その他(assets外)"});
			this.checkedListBox1.Location = new System.Drawing.Point(6, 18);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(120, 88);
			this.checkedListBox1.TabIndex = 8;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Enabled = false;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "短辺16px以下",
            "短辺32px以下",
            "短辺64px以下",
            "正方形のみ",
            "すべて"});
			this.comboBox1.Location = new System.Drawing.Point(132, 18);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(215, 20);
			this.comboBox1.TabIndex = 9;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.checkedListBox1);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Enabled = false;
			this.groupBox1.Location = new System.Drawing.Point(12, 99);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(353, 128);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "処理対象のテクスチャ";
			// 
			// filterTypeBox
			// 
			this.filterTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.filterTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.filterTypeBox.FormattingEnabled = true;
			this.filterTypeBox.Items.AddRange(new object[] {
            "TraditionalBeauty",
            "TraditionalBeauty MoreBold"});
			this.filterTypeBox.Location = new System.Drawing.Point(72, 62);
			this.filterTypeBox.Name = "filterTypeBox";
			this.filterTypeBox.Size = new System.Drawing.Size(293, 20);
			this.filterTypeBox.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 12);
			this.label3.TabIndex = 12;
			this.label3.Text = "フィルター: ";
			// 
			// FilterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(377, 268);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.filterTypeBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.outputSelectBtn);
			this.Controls.Add(this.outputPathBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.runBtn);
			this.Controls.Add(this.pathBox);
			this.Controls.Add(this.selectionBtn);
			this.Name = "FilterForm";
			this.Text = "フィルター - MCResourcePackUtil";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button selectionBtn;
		private System.Windows.Forms.TextBox pathBox;
		private System.Windows.Forms.Button runBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox outputPathBox;
		private System.Windows.Forms.Button outputSelectBtn;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox filterTypeBox;
		private System.Windows.Forms.Label label3;
	}
}