using Npgsql;
using System.Data;

namespace pro_view.fld_BL
{
    class cls_bl
    {
        public struct stc_Login
        {
            public struct main
            {
                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    return dal.ExecuteAndRetriveDataSet(
                          "select * from tbl_companies order by sequ;"
                        + "select * from tbl_branches order by sequ;"
                        + "select * from tbl_users order by sequ;");
                }
            }
        }
        public struct stc_Accounting
        {
 
        }
        public struct stc_General_Settings
        {
            public struct stc_companies
            {
                #region properties
                public string id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public string notes { get; set; }
                public bool stop { get; set; }
                public string user_id { get; set; }
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    return dal.ExecuteAndRetriveDataSet("Select * From tbl_companies order by sequ");
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[6];


                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[3].Value = notes;
                    param[4] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[4].Value = stop;
                    param[5] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[5].Value = user_id;
                    return dal.ExecuteAndRetriveDataSet("fnc_companies_insert", param); ;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[6];

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[3].Value = notes;
                    param[4] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[4].Value = stop;
                    param[5] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[5].Value = user_id;

                    return dal.ExecuteAndRetriveDataSet("fnc_companies_update", param);
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[2];

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 2);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[1].Value = user_id;

                    return dal.ExecuteAndRetriveDataSet("fnc_companies_delete", param);
                }
            }
            public struct stc_branches
            {

            }
            public struct stc_stores
            {

            }
            public struct stc_fyears
            {

            }
            public struct stc_currencies
            {

            }
            public struct stc_users
            {

            }
        }
    }
}
