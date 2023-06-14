namespace MCResourcePackUtil
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.filterBtn = new System.Windows.Forms.Button();
			this.combineBtn = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.appVersionLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tableLayoutPanel1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.filterBtn, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.combineBtn, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 109);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// filterBtn
			// 
			this.filterBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.filterBtn.Location = new System.Drawing.Point(3, 3);
			this.filterBtn.Name = "filterBtn";
			this.filterBtn.Size = new System.Drawing.Size(136, 103);
			this.filterBtn.TabIndex = 0;
			this.filterBtn.Text = "フィルターをかける";
			this.filterBtn.UseVisualStyleBackColor = true;
			this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
			// 
			// combineBtn
			// 
			this.combineBtn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.combineBtn.Location = new System.Drawing.Point(145, 3);
			this.combineBtn.Name = "combineBtn";
			this.combineBtn.Size = new System.Drawing.Size(136, 103);
			this.combineBtn.TabIndex = 1;
			this.combineBtn.Text = "合成する";
			this.combineBtn.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appVersionLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 109);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(284, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// appVersionLabel
			// 
			this.appVersionLabel.Name = "appVersionLabel";
			this.appVersionLabel.Size = new System.Drawing.Size(93, 17);
			this.appVersionLabel.Text = "appVersionLabel";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 131);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.statusStrip1);
			this.Name = "Form1";
			this.Text = "MCResourcePackUtil";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button filterBtn;
		private System.Windows.Forms.Button combineBtn;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel appVersionLabel;
	}
}

