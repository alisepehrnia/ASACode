namespace RecursiveFileList
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
			this.dirTextBox = new System.Windows.Forms.TextBox();
			this.listTextBox = new System.Windows.Forms.TextBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.searchButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.allRadioButton = new System.Windows.Forms.RadioButton();
			this.foldersRadioButton = new System.Windows.Forms.RadioButton();
			this.filesRadioButton = new System.Windows.Forms.RadioButton();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dirTextBox
			// 
			this.dirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dirTextBox.Location = new System.Drawing.Point(109, 9);
			this.dirTextBox.Margin = new System.Windows.Forms.Padding(9);
			this.dirTextBox.Name = "dirTextBox";
			this.dirTextBox.ReadOnly = true;
			this.dirTextBox.Size = new System.Drawing.Size(544, 26);
			this.dirTextBox.TabIndex = 0;
			// 
			// listTextBox
			// 
			this.listTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listTextBox.Location = new System.Drawing.Point(109, 104);
			this.listTextBox.Margin = new System.Windows.Forms.Padding(9);
			this.listTextBox.MaxLength = 999999999;
			this.listTextBox.Multiline = true;
			this.listTextBox.Name = "listTextBox";
			this.listTextBox.ReadOnly = true;
			this.listTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.listTextBox.Size = new System.Drawing.Size(544, 420);
			this.listTextBox.TabIndex = 1;
			// 
			// browseButton
			// 
			this.browseButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.browseButton.Location = new System.Drawing.Point(671, 9);
			this.browseButton.Margin = new System.Windows.Forms.Padding(9);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(82, 27);
			this.browseButton.TabIndex = 2;
			this.browseButton.Text = "Browse";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Margin = new System.Windows.Forms.Padding(9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 27);
			this.label1.TabIndex = 3;
			this.label1.Text = "Directory:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 104);
			this.label2.Margin = new System.Windows.Forms.Padding(9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 20);
			this.label2.TabIndex = 4;
			this.label2.Text = "List:";
			// 
			// searchButton
			// 
			this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.searchButton.BackColor = System.Drawing.Color.LightSteelBlue;
			this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.searchButton.Location = new System.Drawing.Point(671, 54);
			this.searchButton.Margin = new System.Windows.Forms.Padding(9);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(82, 26);
			this.searchButton.TabIndex = 5;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = false;
			this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.dirTextBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.browseButton, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.listTextBox, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.searchButton, 2, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(762, 533);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 54);
			this.label3.Margin = new System.Windows.Forms.Padding(9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Options:";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.allRadioButton);
			this.flowLayoutPanel1.Controls.Add(this.foldersRadioButton);
			this.flowLayoutPanel1.Controls.Add(this.filesRadioButton);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(110, 55);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(542, 30);
			this.flowLayoutPanel1.TabIndex = 10;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// allRadioButton
			// 
			this.allRadioButton.AutoSize = true;
			this.allRadioButton.Checked = true;
			this.allRadioButton.Location = new System.Drawing.Point(0, 0);
			this.allRadioButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.allRadioButton.Name = "allRadioButton";
			this.allRadioButton.Size = new System.Drawing.Size(49, 24);
			this.allRadioButton.TabIndex = 9;
			this.allRadioButton.TabStop = true;
			this.allRadioButton.Text = "All";
			this.allRadioButton.UseVisualStyleBackColor = true;
			// 
			// foldersRadioButton
			// 
			this.foldersRadioButton.AutoSize = true;
			this.foldersRadioButton.Location = new System.Drawing.Point(69, 0);
			this.foldersRadioButton.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.foldersRadioButton.Name = "foldersRadioButton";
			this.foldersRadioButton.Size = new System.Drawing.Size(86, 24);
			this.foldersRadioButton.TabIndex = 10;
			this.foldersRadioButton.Text = "Folders";
			this.foldersRadioButton.UseVisualStyleBackColor = true;
			// 
			// filesRadioButton
			// 
			this.filesRadioButton.AutoSize = true;
			this.filesRadioButton.Location = new System.Drawing.Point(175, 0);
			this.filesRadioButton.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.filesRadioButton.Name = "filesRadioButton";
			this.filesRadioButton.Size = new System.Drawing.Size(66, 24);
			this.filesRadioButton.TabIndex = 11;
			this.filesRadioButton.Text = "Files";
			this.filesRadioButton.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(782, 553);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "Form1";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox dirTextBox;
		private System.Windows.Forms.TextBox listTextBox;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.RadioButton allRadioButton;
		private System.Windows.Forms.RadioButton foldersRadioButton;
		private System.Windows.Forms.RadioButton filesRadioButton;
	}
}

