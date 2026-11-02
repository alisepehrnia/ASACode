using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RecursiveFileList
{
	public partial class Form1 : Form
	{
		private readonly List<string> list = new List<string>();
		private readonly BackgroundWorker worker = new BackgroundWorker();

		public Form1()
		{
			InitializeComponent();
			worker.DoWork += WorkerOnDoWork;
			worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;
		}

		private string DirPath { get; set; }

		private void WorkerOnDoWork(object sender, DoWorkEventArgs e)
		{
			ListFileAndFolders(DirPath);
		}

		private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			listTextBox.Text = string.Join(Environment.NewLine, list);
			Cursor = Cursors.Default;
		}

		private void BrowseButton_Click(object sender, EventArgs e)
		{
			var folderBrowserDialog = new FolderBrowserDialog();

			if (folderBrowserDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}

			DirPath = folderBrowserDialog.SelectedPath;
			dirTextBox.Text = DirPath;
		}

		private void ListFileAndFolders(string path)
		{
			list.Clear();

			if (string.IsNullOrWhiteSpace(path))
			{
				return;
			}

			RecListFolders(path);
		}

		private void RecListFolders(string path)
		{
			var dirInfo = new DirectoryInfo(path);

			if (!dirInfo.Exists)
			{
				list.Add(path);
				return;
			}

			var fsInfos = Enumerable.Empty<FileSystemInfo>();
			try
			{
				fsInfos = dirInfo.EnumerateFileSystemInfos("*", SearchOption.TopDirectoryOnly);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			foreach (var fsInfo in fsInfos)
			{
				if ((fsInfo.Attributes & FileAttributes.Directory) != 0)
				{
					if (allRadioButton.Checked || foldersRadioButton.Checked)
					{
						list.Add(fsInfo.FullName);
					}

					RecListFolders(fsInfo.FullName);
				}
				else
				{
					if (allRadioButton.Checked || filesRadioButton.Checked)
					{
						list.Add(fsInfo.FullName);
					}
				}
			}
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			listTextBox.Text = "Please Wait...";
			Cursor = Cursors.WaitCursor;
			worker.RunWorkerAsync();
		}
	}
}