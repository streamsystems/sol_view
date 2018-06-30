using Npgsql;
using System;
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
            public struct stc_Settings
            {
                public struct stc_chart
                {
                    #region properties
                    public string id { get; set; }
                    public string aname { get; set; }
                    public string ename { get; set; }
                    public string menue_id { get; set; }
                    public string side_id { get; set; }
                    public string ccrelation_id { get; set; }
                    public string cc1_id { get; set; }
                    public string cc2_id { get; set; }
                    public string property_id { get; set; }
                    public string company_id { get; set; }
                    public string branch_id { get; set; }
                    public string notes { get; set; }
                    public bool stop { get; set; }
                    public string parent_id { get; set; }
                    public string user_id { get; set; }
                    #endregion

                    public DataSet Select()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        return dal.ExecuteAndRetriveDataSet("Select * From tbl_chart order by sequ"
                                                          + "Select * From tbl_companies order by sequ"
                                                          + "Select * From tbl_branches order by sequ");
                    }
                    public DataSet Insert()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        NpgsqlParameter[] param = new NpgsqlParameter[15];

                        param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[0].Value = id;
                        param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[1].Value = aname;
                        param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[2].Value = ename;
                        param[3] = new NpgsqlParameter("@in_menue_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[3].Value = menue_id;
                        param[4] = new NpgsqlParameter("@in_side_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[4].Value = side_id;
                        param[5] = new NpgsqlParameter("@in_ccrelation_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[5].Value = ccrelation_id;
                        param[6] = new NpgsqlParameter("@in_cc1_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[6].Value = cc1_id;
                        param[7] = new NpgsqlParameter("@in_cc2_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[7].Value = cc2_id;
                        param[8] = new NpgsqlParameter("@in_property_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[8].Value = property_id;
                        param[9] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                        param[9].Value = company_id;
                        param[10] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                        param[10].Value = branch_id;
                        param[11] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                        param[11].Value = notes;
                        param[12] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                        param[12].Value = stop;
                        param[13] = new NpgsqlParameter("@in_parent_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[13].Value = parent_id;
                        param[14] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                        param[14].Value = user_id;
                        return dal.ExecuteAndRetriveDataSet("fnc_chart_insert", param); ;
                    }
                    public DataSet Update()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        NpgsqlParameter[] param = new NpgsqlParameter[15];

                        param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[0].Value = id;
                        param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[1].Value = aname;
                        param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[2].Value = ename;
                        param[3] = new NpgsqlParameter("@in_menue_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[3].Value = menue_id;
                        param[4] = new NpgsqlParameter("@in_side_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[4].Value = side_id;
                        param[5] = new NpgsqlParameter("@in_ccrelation_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[5].Value = ccrelation_id;
                        param[6] = new NpgsqlParameter("@in_cc1_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[6].Value = cc1_id;
                        param[7] = new NpgsqlParameter("@in_cc2_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[7].Value = cc2_id;
                        param[8] = new NpgsqlParameter("@in_property_id", NpgsqlTypes.NpgsqlDbType.Varchar, (1));
                        param[8].Value = property_id;
                        param[9] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                        param[9].Value = company_id;
                        param[10] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                        param[10].Value = branch_id;
                        param[11] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                        param[11].Value = notes;
                        param[12] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                        param[12].Value = stop;
                        param[13] = new NpgsqlParameter("@in_parent_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                        param[13].Value = parent_id;
                        param[14] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                        param[14].Value = user_id;

                        return dal.ExecuteAndRetriveDataSet("fnc_chart_update", param);
                    }
                    public DataSet Delete()
                    {
                        pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                        NpgsqlParameter[] param = new NpgsqlParameter[2];

                        param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar,50);
                        param[0].Value = id;
                        param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                        param[1].Value = user_id;

                        return dal.ExecuteAndRetriveDataSet("fnc_chart_delete", param);
                    }
                }
            }
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
                #region properties
                public string id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public string mobile1 { get; set; }
                public string mobile2 { get; set; }
                public string phone1 { get; set; }
                public string phone2 { get; set; }
                public string email { get; set; }
                public string company_id { get; set; }
                public string notes { get; set; }
                public bool stop { get; set; }
                public string user_id { get; set; }
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet("Select * From tbl_branches order by sequ;"
                                                    + "Select * From tbl_companies order by sequ;");
                    ds.Tables[0].TableName = "tbl_branches";
                    ds.Tables[1].TableName = "tbl_companies";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[12];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = mobile1;
                    param[4] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = mobile2;
                    param[5] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = phone1;
                    param[6] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = phone2;
                    param[7] = new NpgsqlParameter("@in_email", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = email;
                    param[8] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[8].Value = company_id;
                    param[9] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[9].Value = notes;
                    param[10] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[10].Value = stop;
                    param[11] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[11].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("fnc_branches_insert", param); ;
                    ds.Tables[0].TableName = "tbl_branches";
                    //ds.Tables[1].TableName = "tbl_companies";

                    return ds;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[12];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = mobile1;
                    param[4] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = mobile2;
                    param[5] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = phone1;
                    param[6] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = phone2;
                    param[7] = new NpgsqlParameter("@in_email", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = email;
                    param[8] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[8].Value = company_id;
                    param[9] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[9].Value = notes;
                    param[10] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[10].Value = stop;
                    param[11] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[11].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("fnc_branches_update", param);
                    ds.Tables[0].TableName = "tbl_branches";
                    //ds.Tables[1].TableName = "tbl_companies";

                    return ds;
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[2];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 3);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[1].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("fnc_branches_delete", param);
                    ds.Tables[0].TableName = "tbl_branches";
                    //ds.Tables[1].TableName = "tbl_companies";

                    return ds;
                }
            }
            public struct stc_stores
            {
                #region properties
                public string id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public string responame { get; set; }
                public string mobile1 { get; set; }
                public string mobile2 { get; set; }
                public string phone1 { get; set; }
                public string phone2 { get; set; }
                public string company_id { get; set; }
                public string branch_id { get; set; }
                public string notes { get; set; }
                public bool stop { get; set; }
                public string user_id { get; set; }
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet("Select * From tbl_stores order by sequ;"
                                                    + "Select * From tbl_branches order by sequ;"
                                                    + "Select * From tbl_companies order by sequ;");
                    ds.Tables[0].TableName = "tbl_stores";
                    ds.Tables[1].TableName = "tbl_branches";
                    ds.Tables[2].TableName = "tbl_companies";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[13];
                    DataSet ds = new DataSet();


                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_responame", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = responame;
                    param[4] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = mobile1;
                    param[5] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = mobile2;
                    param[6] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = phone1;
                    param[7] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = phone2;
                    param[8] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[8].Value = company_id;
                    param[9] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[9].Value = branch_id;
                    param[10] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[10].Value = notes;
                    param[11] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[11].Value = stop;
                    param[12] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[12].Value = user_id;


                    ds = dal.ExecuteAndRetriveDataSet("fnc_stores_insert", param); ;
                    ds.Tables[0].TableName = "tbl_stores";

                    return ds;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[13];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_responame", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = responame;
                    param[4] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = mobile1;
                    param[5] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = mobile2;
                    param[6] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = phone1;
                    param[7] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = phone2;
                    param[8] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[8].Value = company_id;
                    param[9] = new NpgsqlParameter("@in_branch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[9].Value = branch_id;
                    param[10] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[10].Value = notes;
                    param[11] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[11].Value = stop;
                    param[12] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[12].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("fnc_stores_update", param);
                    ds.Tables[0].TableName = "tbl_stores";

                    return ds;
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[2];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 3);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[1].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("fnc_stores_delete", param);
                    ds.Tables[0].TableName = "tbl_stores";

                    return ds;
                }
            }
            public struct stc_fyears
            {
                #region properties
                public string id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public DateTime beigndate { get; set; }
                public DateTime enddate { get; set; }
                public string company_id { get; set; }
                public string notes { get; set; }
                public bool stop { get; set; }
                public string user_id { get; set; }
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet("Select * From tbl_fyears order by sequ;"
                                                    + "Select * From tbl_companies order by sequ;");
                    ds.Tables[0].TableName = "tbl_fyears";
                    ds.Tables[1].TableName = "tbl_companies";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[9];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_beigndate", NpgsqlTypes.NpgsqlDbType.Date);
                    param[3].Value = beigndate;
                    param[4] = new NpgsqlParameter("@in_enddate", NpgsqlTypes.NpgsqlDbType.Date);
                    param[4].Value = enddate;
                    param[5] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[5].Value = company_id;
                    param[6] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[6].Value = notes;
                    param[7] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[7].Value = stop;
                    param[8] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[8].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("fnc_fyears_insert", param); ;
                    ds.Tables[0].TableName = "tbl_fyears";

                    return ds;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[9];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_beigndate", NpgsqlTypes.NpgsqlDbType.Date);
                    param[3].Value = beigndate;
                    param[4] = new NpgsqlParameter("@in_enddate", NpgsqlTypes.NpgsqlDbType.Date);
                    param[4].Value = enddate;
                    param[5] = new NpgsqlParameter("@in_company_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[5].Value = company_id;
                    param[6] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[6].Value = notes;
                    param[7] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[7].Value = stop;
                    param[8] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[8].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("fnc_fyears_update", param);
                    ds.Tables[0].TableName = "tbl_fyears";

                    return ds;
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[2];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 2);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[1].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("fnc_fyears_delete", param);
                    ds.Tables[0].TableName = "tbl_fyears";

                    return ds;
                }
            }
            public struct stc_currencies
            {
                #region properties
                public string id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public string asymbol { get; set; }
                public string esymbol { get; set; }
                public decimal price { get; set; }
                public string notes { get; set; }
                public bool stop { get; set; }
                public string user_id { get; set; }
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();

                    ds = dal.ExecuteAndRetriveDataSet("Select * From tbl_currencies order by sequ;");

                    ds.Tables[0].TableName = "tbl_currencies";

                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[9];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_asymbol", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = asymbol;
                    param[4] = new NpgsqlParameter("@in_esymbol", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = esymbol;
                    param[5] = new NpgsqlParameter("@in_price", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[5].Value = price;
                    param[6] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[6].Value = notes;
                    param[7] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[7].Value = stop;
                    param[8] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[8].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("fnc_currencies_insert", param); ;
                    ds.Tables[0].TableName = "tbl_currencies";

                    return ds;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[9];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_asymbol", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = asymbol;
                    param[4] = new NpgsqlParameter("@in_esymbol", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[4].Value = esymbol;
                    param[5] = new NpgsqlParameter("@in_price", NpgsqlTypes.NpgsqlDbType.Numeric);
                    param[5].Value = price;
                    param[6] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[6].Value = notes;
                    param[7] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[7].Value = stop;
                    param[8] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[8].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("fnc_currencies_update", param);
                    ds.Tables[0].TableName = "tbl_currencies";

                    return ds;
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[2];
                    DataSet ds = new DataSet();

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 2);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[1].Value = user_id;

                    ds = dal.ExecuteAndRetriveDataSet("fnc_currencies_delete", param);
                    ds.Tables[0].TableName = "tbl_currencies";

                    return ds;
                }
            }
            public struct stc_users
            {
                #region properties
                public string id { get; set; }
                public string aname { get; set; }
                public string ename { get; set; }
                public string password { get; set; }
                public int gender_id { get; set; }
                public string jobtitle { get; set; }
                public string mobile1 { get; set; }
                public string mobile2 { get; set; }
                public string phone1 { get; set; }
                public string phone2 { get; set; }
                public string email { get; set; }
                public string permission_id { get; set; }
                public string allowedcompanies_ids { get; set; }
                public string allowedbranches_ids { get; set; }
                public string allowedstores_ids { get; set; }
                public string allowedfyears_ids { get; set; }
                public string defaultcompany_id { get; set; }
                public string defaultbranch_id { get; set; }
                public string defaultstore_id { get; set; }
                public string defaultfyear_id { get; set; }
                public string notes { get; set; }
                public bool stop { get; set; }
                public string user_id { get; set; }
                #endregion

                public DataSet Select()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    DataSet ds = new DataSet();
                    
                    ds = dal.ExecuteAndRetriveDataSet("select * From tbl_users order by sequ;"
                                                      + "select * from tbl_gender order by id;"
                                                      + "select * From tbl_companies order by sequ;"
                                                      + "select * From tbl_branches order by sequ;"
                                                      + "select * From tbl_stores order by sequ;"
                                                      + "select * From tbl_fyears order by sequ;");
                    ds.Tables[0].TableName = "users";
                    ds.Tables[1].TableName = "gender";
                    ds.Tables[2].TableName = "companies";
                    ds.Tables[3].TableName = "branches";
                    ds.Tables[4].TableName = "stores";
                    ds.Tables[5].TableName = "fyears";
                    return ds;
                }
                public DataSet Insert()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[23];

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_password", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = password;
                    param[4] = new NpgsqlParameter("@in_gender_id", NpgsqlTypes.NpgsqlDbType.Smallint);
                    param[4].Value = gender_id;
                    param[5] = new NpgsqlParameter("@in_jobtitle", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = jobtitle;
                    param[6] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = mobile1;
                    param[7] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = mobile2;
                    param[8] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[8].Value = phone1;
                    param[9] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[9].Value = phone2;
                    param[10] = new NpgsqlParameter("@in_email", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[10].Value = email;
                    param[11] = new NpgsqlParameter("@in_permission_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[11].Value = permission_id;
                    param[12] = new NpgsqlParameter("@in_allowedcompanies_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[12].Value = allowedcompanies_ids;
                    param[13] = new NpgsqlParameter("@in_allowedbranches_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[13].Value = allowedbranches_ids;
                    param[14] = new NpgsqlParameter("@in_allowedstores_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[14].Value = allowedstores_ids;
                    param[15] = new NpgsqlParameter("@in_allowedfyears_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[15].Value = allowedfyears_ids;
                    param[16] = new NpgsqlParameter("@in_defaultcompany_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[16].Value = defaultcompany_id;
                    param[17] = new NpgsqlParameter("@in_defaultbranch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[17].Value = defaultbranch_id;
                    param[18] = new NpgsqlParameter("@in_defaultstore_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[18].Value = defaultstore_id;
                    param[19] = new NpgsqlParameter("@in_defaultfyear_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[19].Value = defaultfyear_id;
                    param[20] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[20].Value = notes;
                    param[21] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[21].Value = stop;
                    param[22] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[22].Value = user_id;

                    return dal.ExecuteAndRetriveDataSet("fnc_users_insert", param); ;
                }
                public DataSet Update()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[23];

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_aname", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[1].Value = aname;
                    param[2] = new NpgsqlParameter("@in_ename", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[2].Value = ename;
                    param[3] = new NpgsqlParameter("@in_password", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[3].Value = password;
                    param[4] = new NpgsqlParameter("@in_gender_id", NpgsqlTypes.NpgsqlDbType.Smallint);
                    param[4].Value = gender_id;
                    param[5] = new NpgsqlParameter("@in_jobtitle", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[5].Value = jobtitle;
                    param[6] = new NpgsqlParameter("@in_mobile1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[6].Value = mobile1;
                    param[7] = new NpgsqlParameter("@in_mobile2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[7].Value = mobile2;
                    param[8] = new NpgsqlParameter("@in_phone1", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[8].Value = phone1;
                    param[9] = new NpgsqlParameter("@in_phone2", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[9].Value = phone2;
                    param[10] = new NpgsqlParameter("@in_email", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[10].Value = email;
                    param[11] = new NpgsqlParameter("@in_permission_id", NpgsqlTypes.NpgsqlDbType.Varchar, (50));
                    param[11].Value = permission_id;
                    param[12] = new NpgsqlParameter("@in_allowedcompanies_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[12].Value = allowedcompanies_ids;
                    param[13] = new NpgsqlParameter("@in_allowedbranches_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[13].Value = allowedbranches_ids;
                    param[14] = new NpgsqlParameter("@in_allowedstores_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[14].Value = allowedstores_ids;
                    param[15] = new NpgsqlParameter("@in_allowedfyears_ids", NpgsqlTypes.NpgsqlDbType.Text);
                    param[15].Value = allowedfyears_ids;
                    param[16] = new NpgsqlParameter("@in_defaultcompany_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[16].Value = defaultcompany_id;
                    param[17] = new NpgsqlParameter("@in_defaultbranch_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[17].Value = defaultbranch_id;
                    param[18] = new NpgsqlParameter("@in_defaultstore_id", NpgsqlTypes.NpgsqlDbType.Varchar, (3));
                    param[18].Value = defaultstore_id;
                    param[19] = new NpgsqlParameter("@in_defaultfyear_id", NpgsqlTypes.NpgsqlDbType.Varchar, (2));
                    param[19].Value = defaultfyear_id;
                    param[20] = new NpgsqlParameter("@in_notes", NpgsqlTypes.NpgsqlDbType.Text);
                    param[20].Value = notes;
                    param[21] = new NpgsqlParameter("@in_stop", NpgsqlTypes.NpgsqlDbType.Boolean);
                    param[21].Value = stop;
                    param[22] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[22].Value = user_id;

                    return dal.ExecuteAndRetriveDataSet("fnc_users_update", param);
                }
                public DataSet Delete()
                {
                    pro_view.fld_DAL.cls_dal dal = new fld_DAL.cls_dal();
                    NpgsqlParameter[] param = new NpgsqlParameter[2];

                    param[0] = new NpgsqlParameter("@in_id", NpgsqlTypes.NpgsqlDbType.Varchar, 3);
                    param[0].Value = id;
                    param[1] = new NpgsqlParameter("@in_user_id", NpgsqlTypes.NpgsqlDbType.Varchar, (4));
                    param[1].Value = user_id;

                    return dal.ExecuteAndRetriveDataSet("fnc_users_delete", param);
                }
            }
        }
    }
}
