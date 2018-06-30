using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using Npgsql;

namespace pro_view.fld_PL.fld_Login
{
    public partial class frm_serverinfo : Form
    {
        NpgsqlConnection con;
        Thread thread;
        string lbl;

        public frm_serverinfo()
        {
            InitializeComponent();

            textBox_Server.Text = Properties.Settings.Default.Server;
            txt_Port.Text = Properties.Settings.Default.Port;
            textBox_ID.Text = Properties.Settings.Default.PostgresUser;
            textBox_Password.Text = Properties.Settings.Default.PostgresPassword;
            textBox_DataBase.Text = Properties.Settings.Default.Database;
        }

        #region Pro
        void SaveSettings()
        {
            Properties.Settings.Default.Server = textBox_Server.Text.Trim();
            Properties.Settings.Default.Port = txt_Port.Text.Trim();
            Properties.Settings.Default.PostgresUser = textBox_ID.Text;
            Properties.Settings.Default.PostgresPassword = textBox_Password.Text;
            Properties.Settings.Default.Database = textBox_DataBase.Text;

            Properties.Settings.Default.Save();
        }

        void RestoreDatabase(string path)
        {
            con = new NpgsqlConnection(@"Server= " + Properties.Settings.Default.Server +
                                       ";Port=" + Properties.Settings.Default.Port +
                                       ";user id= " + Properties.Settings.Default.PostgresUser +
                                       "; Password= " + Properties.Settings.Default.PostgresPassword +
                                       ";Database= " + Properties.Settings.Default.Database);

            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                string s = "USE MASTER RESTORE DATABASE [Farm] FROM DISK='" + path + "'WITH REPLACE;";
                NpgsqlCommand cmd = new NpgsqlCommand(s, con);

                lbl = "جارٍ اضافة قاعدة البيانات ...";
                Start_Waiting();
                cmd.ExecuteNonQuery();
                con.Close();
                Abort_Waiting();

                MessageBox.Show("تم اضافة قاعدة البيانات بنجاح", "اضافة قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                con.Close();
                Abort_Waiting();
                MessageBox.Show(ex.ToString());
            }
        }
        void Start_Waiting()
        {
            thread = new Thread(Waiting);
            thread.IsBackground = true;
            thread.Start();
        }
        void Waiting()
        {
            //PL.G.frm_Waiting w = new PL.G.frm_Waiting();
            //w.lbl.Text = lbl;

            //w.ShowDialog();
        }
        void Abort_Waiting()
        {
            thread.Abort();
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void button_OK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }
        private void lbl_Database_DoubleClick(object sender, EventArgs e)
        {
            SaveSettings();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RestoreDatabase(ofd.FileName);
            }
        }
    }
}
