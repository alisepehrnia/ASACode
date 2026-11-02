using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADO1
{
	public partial class Form1 : Form
	{
		private const string ConnString =
			"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Test;Data Source=.";

		private static readonly SqlConnection DbConn = new SqlConnection(ConnString);
		private static readonly DataTable Dt = new DataTable();

		public Form1()
		{
			InitializeComponent();
		}

		private static DataTable GetList()
		{
			var dataAdapter = new SqlDataAdapter("GetStudents", DbConn);
			Dt.Clear();
			dataAdapter.Fill(Dt);
			return Dt;
		}

		private static bool Insert(int id, string firstName, string lastName)
		{
			var cmd = new SqlCommand("InsertStudent", DbConn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@StudentId", SqlDbType.Int).Value = id;
			cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = firstName;
			cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = lastName;
			cmd.Parameters.Add("@R", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

			DbConn.Open();
			cmd.ExecuteNonQuery();
			DbConn.Close();

			return cmd.Parameters["@R"].Value.ToString() == "1";
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = GetList();
		}

		private void insertButton_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(idTxtBox.Text) || firstNameTxtBox.Text == null ||
			    lastNameTxtBox.Text == null)
			{
				MessageBox.Show("Fill All Text Boxes!");
				return;
			}

			if (!int.TryParse(idTxtBox.Text, out var id))
			{
				MessageBox.Show("Enter Correct Id!");
				return;
			}

			if (Exists(id))
			{
				MessageBox.Show("Student With Same Id Already Exists!");
				return;
			}

			if (Insert(id, firstNameTxtBox.Text, lastNameTxtBox.Text))
			{
				dataGridView1.DataSource = GetList();
			}
		}

		private static bool Exists(int id)
		{
			var adapter =
				new SqlDataAdapter($"select StudentId from dbo.Students where StudentId = {id}",
					DbConn);
			var dt = new DataTable();
			adapter.Fill(dt);

			return dt.Rows.Count > 0;
		}

		private static bool Delete(int id)
		{
			var cmd = new SqlCommand("DeleteStudent", DbConn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@StudentId", SqlDbType.Int).Value = id;

			DbConn.Open();
			var result = cmd.ExecuteNonQuery();
			DbConn.Close();

			return result == 1;
		}

		private void deleteBtn_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(idTxtBox.Text))
			{
				MessageBox.Show("Fill Id Text Box!");
				return;
			}

			if (!int.TryParse(idTxtBox.Text, out var id))
			{
				MessageBox.Show("Enter Correct Id!");
				return;
			}

			if (!Exists(id))
			{
				MessageBox.Show("Student With Provided Id Not Exists!");
				return;
			}

			if (Delete(id))
			{
				dataGridView1.DataSource = GetList();
			}
		}

		private static void Update(int id, string firstName, string lastName)
		{
			var cmd = new SqlCommand(
				$"update dbo.Students set FirstName='{firstName}', LastName='{lastName}' where StudentId = {id}",
				DbConn);

			DbConn.Open();
			cmd.ExecuteNonQuery();
			DbConn.Close();
		}

		private void updateBtn_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(idTxtBox.Text) || firstNameTxtBox.Text == null ||
			    lastNameTxtBox.Text == null)
			{
				MessageBox.Show("Fill All Text Boxes!");
				return;
			}

			if (!int.TryParse(idTxtBox.Text, out var id))
			{
				MessageBox.Show("Enter Correct Id!");
				return;
			}

			if (!Exists(id))
			{
				MessageBox.Show("Student With Provided Id Not Exists!");
				return;
			}

			Update(id, firstNameTxtBox.Text, lastNameTxtBox.Text);

			dataGridView1.DataSource = GetList();
		}

		private void searchBtn_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(idTxtBox.Text))
			{
				MessageBox.Show("Fill Id Text Box!");
				return;
			}

			if (!int.TryParse(idTxtBox.Text, out var id))
			{
				MessageBox.Show("Enter Correct Id!");
				return;
			}

			if (!Search(id, out var firstName, out var lastName))
			{
				MessageBox.Show("Student With Provided Id Not Exists!");
				return;
			}

			firstNameTxtBox.Text = firstName;
			lastNameTxtBox.Text = lastName;
		}

		private static bool Search(int id, out string firstName, out string lastName)
		{
			firstName = null;
			lastName = null;

			var adapter = new SqlDataAdapter($"select * from dbo.Students where StudentId = {id}",
				DbConn);

			var dt = new DataTable();
			adapter.Fill(dt);

			if (dt.Rows.Count <= 0) return false;

			firstName = dt.Rows[0][1].ToString();
			lastName = dt.Rows[0][2].ToString();
			return true;
		}
	}
}