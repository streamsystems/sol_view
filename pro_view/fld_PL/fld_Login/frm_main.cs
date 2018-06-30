using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_Login
{
    public partial class frm_main : Form
    {
        #region Declarations
        pro_view.fld_BL.cls_bl.stc_Login.main module = new fld_BL.cls_bl.stc_Login.main();
        DataSet ds = new DataSet();
        #endregion

        public frm_main()
        {
            InitializeComponent();
        }

        #region Form
        private void frm_main_Shown(object sender, EventArgs e)
        {
            btn_Database.Image = imageList32.Images["DataBase_32.png"];
            btn_Branche.Image = imageList32.Images["Branche_32.png"];
            btn_User.Image = imageList32.Images["User_32.png"];

            ds = module.Select();

            com_companies.DataSource = ds.Tables[0];
            com_companies.ValueMember = "id";
            com_companies.DisplayMember = "aname";

            com_branches.DataSource = ds.Tables[1];
            com_branches.ValueMember = "id";
            com_branches.DisplayMember = "aname";

            com_users.DataSource = ds.Tables[2];
            com_users.ValueMember = "id";
            com_users.DisplayMember = "aname";
        }
        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("هل تريد حفظ نسخة إحتياطية من البيانات ؟ ...  يجب حفظ نسخ أخرى من البيانات على قرص آخر حتى لا يتم فقدان البيانات نهائياً في حالة عطل القرص الصلب ", "حفظ نسخة احتياطية", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            if (result == DialogResult.Yes)
            {
                //g.BackupDatabase(AppDomain.CurrentDomain.BaseDirectory + "BACKUP");
                Environment.Exit(1);
            }
            else if (result == DialogResult.No)
            {
                //Application.Exit();
                //Environment.Exit(1);
                Application.ExitThread();

                Environment.Exit(10);
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void frm_main_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        #endregion

        private void com_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_User.Text = com_users.Text;
        }

        private void الشركاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_General_Settings.frm_companies f = new fld_General_Settings.frm_companies();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "الشركات";

            f.Show();
        }

        private void المستخدمونToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_General_Settings.frm_users f = new fld_General_Settings.frm_users();
            f.btn_New.Image = imageList_48.Images["New_48.png"];
            f.btn_Edit.Image = imageList_48.Images["Edit_48.png"];
            f.btn_Save.Image = imageList_48.Images["Save_48.png"];
            f.btn_Cancel.Image = imageList_48.Images["Cancel_48.png"];
            f.btn_Delete.Image = imageList_48.Images["Delete_48.png"];
            f.frm_main = this;
            f.Text = "المستخدمون";

            f.Show();
        }
    }
}
