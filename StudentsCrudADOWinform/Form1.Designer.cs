namespace ADO1
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.insertButton = new System.Windows.Forms.Button();
			this.idTxtBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.firstNameTxtBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lastNameTxtBox = new System.Windows.Forms.TextBox();
			this.deleteBtn = new System.Windows.Forms.Button();
			this.updateBtn = new System.Windows.Forms.Button();
			this.searchBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(384, 14);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(503, 479);
			this.dataGridView1.TabIndex = 0;
			// 
			// insertButton
			// 
			this.insertButton.Location = new System.Drawing.Point(30, 147);
			this.insertButton.Name = "insertButton";
			this.insertButton.Size = new System.Drawing.Size(136, 40);
			this.insertButton.TabIndex = 1;
			this.insertButton.Text = "Insert";
			this.insertButton.UseVisualStyleBackColor = true;
			this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
			// 
			// idTxtBox
			// 
			this.idTxtBox.Location = new System.Drawing.Point(118, 18);
			this.idTxtBox.Name = "idTxtBox";
			this.idTxtBox.Size = new System.Drawing.Size(112, 24);
			this.idTxtBox.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(84, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(23, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "Id:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 18);
			this.label2.TabIndex = 5;
			this.label2.Text = "First Name:";
			// 
			// firstNameTxtBox
			// 
			this.firstNameTxtBox.Location = new System.Drawing.Point(118, 49);
			this.firstNameTxtBox.Name = "firstNameTxtBox";
			this.firstNameTxtBox.Size = new System.Drawing.Size(208, 24);
			this.firstNameTxtBox.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 18);
			this.label3.TabIndex = 7;
			this.label3.Text = "LastName:";
			// 
			// lastNameTxtBox
			// 
			this.lastNameTxtBox.Location = new System.Drawing.Point(118, 81);
			this.lastNameTxtBox.Name = "lastNameTxtBox";
			this.lastNameTxtBox.Size = new System.Drawing.Size(208, 24);
			this.lastNameTxtBox.TabIndex = 6;
			// 
			// deleteBtn
			// 
			this.deleteBtn.Location = new System.Drawing.Point(181, 147);
			this.deleteBtn.Name = "deleteBtn";
			this.deleteBtn.Size = new System.Drawing.Size(136, 40);
			this.deleteBtn.TabIndex = 8;
			this.deleteBtn.Text = "Delete";
			this.deleteBtn.UseVisualStyleBackColor = true;
			this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
			// 
			// updateBtn
			// 
			this.updateBtn.Location = new System.Drawing.Point(30, 193);
			this.updateBtn.Name = "updateBtn";
			this.updateBtn.Size = new System.Drawing.Size(136, 40);
			this.updateBtn.TabIndex = 9;
			this.updateBtn.Text = "Update";
			this.updateBtn.UseVisualStyleBackColor = true;
			this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
			// 
			// searchBtn
			// 
			this.searchBtn.Location = new System.Drawing.Point(181, 193);
			this.searchBtn.Name = "searchBtn";
			this.searchBtn.Size = new System.Drawing.Size(136, 40);
			this.searchBtn.TabIndex = 10;
			this.searchBtn.Text = "Search";
			this.searchBtn.UseVisualStyleBackColor = true;
			this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 506);
			this.Controls.Add(this.searchBtn);
			this.Controls.Add(this.updateBtn);
			this.Controls.Add(this.deleteBtn);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lastNameTxtBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.firstNameTxtBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.idTxtBox);
			this.Controls.Add(this.insertButton);
			this.Controls.Add(this.dataGridView1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button insertButton;
		private System.Windows.Forms.TextBox idTxtBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox firstNameTxtBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox lastNameTxtBox;
		private System.Windows.Forms.Button deleteBtn;
		private System.Windows.Forms.Button updateBtn;
		private System.Windows.Forms.Button searchBtn;
	}
}

