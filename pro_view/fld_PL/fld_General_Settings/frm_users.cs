using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_General_Settings
{
    public partial class frm_users : Form
    {
        #region Declarations
        public pro_view.fld_PL.fld_Login.frm_main frm_main;
        pro_view.fld_BL.cls_bl.stc_General_Settings.stc_users module = new fld_BL.cls_bl.stc_General_Settings.stc_users();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        int record_index;
        #endregion

        public frm_users()
        {
            InitializeComponent();

            dgv.AutoGenerateColumns = false;
        }

        #region Form
        private void frm_G_Shown(object sender, EventArgs e)
        {
            ControlsName();
            Refresh_Data();

            com_gender.DataSource = ds.Tables[1];
            com_gender.ValueMember = "id";
            com_gender.DisplayMember = "aname";

            if (dgv.Rows.Count > 0)
            {
                Tag = "Select";
                Form_Mode("Select");
            }
            else
            {
                Tag = "Empty";
                Form_Mode("Empty");
            }

            dgv.Focus();
        }
        private void frm_G_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (txt_id.Text == "") txt_id.Text = "-1";
        }
        #endregion

        #region Pro
        void ClearForm()
        {
            foreach (Control c in gbx_Details.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedValue = -1;
                }
                else if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }
            }
        }
        void EnableForm()
        {
            foreach (Control c in gbx_Details.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).ReadOnly = false;
                }
                else
                {
                    c.Enabled = true;
                }
            }
            dgv.Enabled = false;
            txt_id.ReadOnly = true;
        }
        void DisableForm()
        {
            foreach (Control c in gbx_Details.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).ReadOnly = true;
                }
                else
                {
                    c.Enabled = false;
                }
            }
            dgv.Enabled = true;
        }
        void Form_Mode(string mode)
        {
            switch (mode)
            {
                #region New
                case "New":
                    btn_New.Visible = false;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = true;
                    btn_Delete.Visible = false;
                    btn_Cancel.Visible = true;

                    EnableForm();
                    ClearForm();

                    txt_aname.Focus();
                    break;
                #endregion

                #region Edit
                case "Edit":

                    btn_New.Visible = false;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = true;
                    btn_Delete.Visible = false;
                    btn_Cancel.Visible = true;

                    EnableForm();

                    txt_aname.Select();
                    break;
                #endregion

                #region Select
                case "Select":

                    btn_New.Visible = true;
                    btn_Edit.Visible = true;
                    btn_Save.Visible = false;
                    btn_Delete.Visible = true;
                    btn_Cancel.Visible = false;

                    DisableForm();

                    if (dgv.SelectedRows.Count == 0) dgv.CurrentCell = dgv.Rows[0].Cells[0];
                    foreach (DataRow r in dt.Rows)
                    {
                        if (r["ID"].ToString() == dgv.SelectedRows[0].Cells[0].Value.ToString())
                        {
                            txt_id.Text = r["id"].ToString();
                            txt_aname.Text = r["aname"].ToString();
                            txt_ename.Text = r["ename"].ToString();
                            txt_password.Text = r["password"].ToString();
                            com_gender.SelectedValue = r["gender"].ToString();
                            txt_jobtitle.Text = r["jobtitle"].ToString();
                            txt_mobile1.Text = r["mobile1"].ToString();
                            txt_mobile2.Text = r["mobile2"].ToString();
                            txt_phone1.Text = r["phone1"].ToString();
                            txt_phone2.Text = r["phone2"].ToString();
                            txt_email.Text = r["email"].ToString();
                            com_permission_id.Text = r["permission_id"].ToString();
                            txt_allowedcompanies_ids.Text = string.Join(",", (string[])r["allowedcompanies_ids"]);
                            txt_allowedbranches_ids.Text = string.Join(",", (string[])r["allowedbranches_ids"]);
                            txt_allowedstores_ids.Text = string.Join(",", (string[])r["allowedstores_ids"]);
                            com_defaultcompany_id.Text = r["defaultcompany_id"].ToString();
                            txt_defaultbranche_id.Text = r["defaultbranche_id"].ToString();
                            com_defaultstore_id.Text = r["defaultstore_id"].ToString();
                            chk_stop.Checked = Convert.ToBoolean(r["stop"]);
                            break;
                        }
                    }

                    break;
                #endregion

                #region Empty
                case "Empty":

                    btn_New.Visible = true;
                    btn_Edit.Visible = false;
                    btn_Save.Visible = false;
                    btn_Delete.Visible = false;
                    btn_Cancel.Visible = false;

                    DisableForm();
                    ClearForm();

                    if (dgv.CurrentRow != null) dgv.CurrentRow.Selected = false;
                    break;
                    #endregion
            }
        }
        string[] TextToArray(string t)
        {
            List<string> lst = t.Split(new[] { "," }, StringSplitOptions.None).ToList();

            string[] a = lst.ToArray();
            return a;
        }
        void Bind()
        {
            //module.id = txt_id.Text.Trim();
            //module.aname = txt_aname.Text.Trim();
            //module.ename = txt_ename.Text.Trim();
            //module.password = txt_password.Text.Trim();
            //module.gender = com_gender.SelectedValue.ToString();
            //module.jobtitle = txt_jobtitle.Text.Trim();
            //module.mobile1 = txt_mobile1.Text.Trim();
            //module.mobile2 = txt_mobile2.Text.Trim();
            //module.phone1 = txt_phone1.Text.Trim();
            //module.phone2 = txt_phone2.Text.Trim();
            //module.email = txt_email.Text.Trim();
            //module.permission_id = (com_permission_id.SelectedValue != null) ? com_permission_id.SelectedValue.ToString() : string.Empty;
            //module.allowedcompanies_ids = TextToArray(txt_allowedcompanies_ids.Text.Trim());
            //module.allowedbranches_ids = TextToArray(txt_allowedbranches_ids.Text.Trim());
            //module.allowedstores_ids = TextToArray(txt_allowedstores_ids.Text.Trim());
            //module.defaultcompany_id = (com_defaultcompany_id.SelectedValue != null) ? com_defaultcompany_id.SelectedValue.ToString() : string.Empty;
            //module.defaultbranche_id = txt_defaultbranche_id.Text.Trim();
            //module.defaultstore_id = (com_defaultstore_id.SelectedValue != null) ? com_defaultstore_id.SelectedValue.ToString() : string.Empty;
            //module.stop = chk_stop.Checked;
        }
        void Refresh_Data()
        {
            //ds = module.Select();
            dt = ds.Tables[0];
            dgv.DataSource = dt;

            //if (dgv.Rows.Count > 0)
            //{
            //    dgv.CurrentCell = dgv.Rows[0].Cells[0];
            //    Tag = "Select";
            //    Form_Mode("Select");
            //}
            //else
            //{
            //    Tag = "Empty";
            //    Form_Mode("Empty");
            //}
        }
        void ControlsName()
        {
            string s = this.Name.ToString().Substring(4);
            string tabindex = "";
            foreach (Control c in gbx_Details.Controls)
            {
                if (c is TextBox || c is ComboBox || c is CheckBox)
                {
                    tabindex = (c.TabIndex > 9) ? c.TabIndex.ToString() : "0" + c.TabIndex.ToString();
                    s += ",";
                    s += tabindex + "- " + c.Name.ToString();
                }
            }
            s += ",96- lbl_creationtime";
            s += ",97- lbl_editingtime";
            s += ",98- lbl_createuser_id";
            s += ",99- lbl_edituser_id";
            String[] a = s.Split(',');
            Array.Sort(a);
            s = string.Join(",", a);

            if (MessageBox.Show(s, "Click OK to copy", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            { Clipboard.SetText(s); }
        }
        #endregion

        #region Controls
        #region display
        private void btn_New_MouseEnter(object sender, EventArgs e)
        {
            btn_New.FlatStyle = FlatStyle.Popup;
        }
        private void btn_New_MouseLeave(object sender, EventArgs e)
        {
            btn_New.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Edit_MouseEnter(object sender, EventArgs e)
        {
            btn_Edit.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Edit_MouseLeave(object sender, EventArgs e)
        {
            btn_Edit.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Save_MouseEnter(object sender, EventArgs e)
        {
            btn_Save.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Save_MouseLeave(object sender, EventArgs e)
        {
            btn_Save.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Delete_MouseEnter(object sender, EventArgs e)
        {
            btn_Delete.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Delete_MouseLeave(object sender, EventArgs e)
        {
            btn_Delete.FlatStyle = FlatStyle.Flat;
        }
        private void btn_Cancel_MouseEnter(object sender, EventArgs e)
        {
            btn_Cancel.FlatStyle = FlatStyle.Popup;
        }
        private void btn_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btn_Cancel.FlatStyle = FlatStyle.Flat;
        }
        #endregion
        private void btn_New_Click(object sender, EventArgs e)
        {
            Tag = "New";
            Form_Mode("New");
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Tag = "Edit";
            Form_Mode("Edit");
            record_index = dgv.SelectedRows[0].Index;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Bind();
            if (Tag.ToString() == "New")
            {
                if (txt_aname.Text.Trim() == "" && txt_ename.Text.Trim() == "")
                {
                    MessageBox.Show("يجب إدخال الأسم ", "حفظ البيان", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txt_aname.Focus();
                    return;
                }
                //dt = module.Insert().Tables[0];
                dgv.DataSource = dt;
                if (dgv.RowCount > 0) dgv.CurrentCell = dgv.Rows[dgv.RowCount - 1].Cells[0];
                dgv.Focus();
            }
            else if (Tag.ToString() == "Edit")
            {
                //dt = module.Update().Tables[0];
                dgv.DataSource = dt;
                dgv.CurrentCell = dgv.Rows[record_index].Cells[0];
            }
            Tag = "Select";
            Form_Mode("Select");
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل بالفعل تريد الحذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
            {
                return;
            }

            Bind();
            //dt = module.Delete().Tables[0];
            dgv.DataSource = dt;

            Tag = "Empty";
            Form_Mode("Empty");
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (Tag.ToString() == "New")
            {
                Tag = "Empty";
                Form_Mode("Empty");
            }
            else if (Tag.ToString() == "Edit")
            {
                Tag = "Select";
                Form_Mode("Select");
            }
        }
        #endregion

        #region dgv
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (Tag == null || dgv.Focused == false) return;
            if (Tag.ToString() == "Select" || Tag.ToString() == "Empty")
            {
                Tag = "Select";
                Form_Mode("Select");
            }
        }
        #endregion
    }
}
