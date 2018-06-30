using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace pro_view.fld_DAL
{
    class cls_dal
    {
        NpgsqlConnection con;


        public cls_dal()
        {
            con = new NpgsqlConnection(@"Server= " + Properties.Settings.Default.Server +
                                       ";Port=" + Properties.Settings.Default.Port +
                                       ";user id= " + Properties.Settings.Default.PostgresUser +
                                       "; Password= " + Properties.Settings.Default.PostgresPassword +
                                       ";Database= " + Properties.Settings.Default.Database);
        }

        public void open()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();

                if (con.State != ConnectionState.Open)
                {
                    MessageBox.Show("Connection currently {0} when it should be open.", "Data Access Open", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        public void Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public DataSet ExecuteAndRetriveDataSet(string Function, NpgsqlParameter[] param)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();

            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Function;

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }

            foreach (IDataParameter p in cmd.Parameters)
            {
                if (p.Value == null) p.Value = DBNull.Value;
            }

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public DataSet ExecuteAndRetriveDataSet(string txt)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            DataSet ds = new DataSet();
            using (con)
            {
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = txt;
                    cmd.Connection = con;

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ExecuteAndRetriveDataSet", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            return ds;
        }
    }
}
