using System;
using System.Data;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace pro_view.fld_PL.fld_Login
{
    public partial class frm_login : Form
    {
        #region Declarations
        pro_view.fld_BL.cls_bl.stc_General_Settings.stc_users model = new fld_BL.cls_bl.stc_General_Settings.stc_users();
        pro_view.fld_PL.fld_Login.frm_main frm_main = new pro_view.fld_PL.fld_Login.frm_main();
        private static string Key = "dofkrfayurdedofkrfaosrdestfkrfao";
        private static string IV = "zxcvbhkdfrasdaeh";
        string user_id;
        string id;
        int CurrentDate;
        #endregion

        public frm_login()
        {
            InitializeComponent();

            txt_Name.Text = Properties.Settings.Default.LoginUser;
        }

        #region Form
        private void frm_Login_Shown(object sender, EventArgs e)
        {
            if (txt_Name.Text != "") txt_Password.Focus();
        }
        private void frm_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Pro
        int IntDate(DateTime dd)
        {
            string s = "";

            string m = dd.Month.ToString();
            if (m.Length == 1) m = "0" + m;

            string d = dd.Day.ToString();
            if (d.Length == 1) d = "0" + d;

            s = dd.Year.ToString() + m + d;

            return Convert.ToInt32(s);
        }
        public static string Decrypt(string encrypted)
        {
            byte[] encryptedbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(Key);
            aes.IV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV);
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] secret = crypto.TransformFinalBlock(encryptedbytes, 0, encryptedbytes.Length);
            crypto.Dispose();
            return System.Text.ASCIIEncoding.ASCII.GetString(secret);

        }
        string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();

            string MACAddress = String.Empty;

            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty)
                { // only return MAC Address from first card
                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }

            return MACAddress;
        }
        string UniqueMachineId()
        {
            StringBuilder builder = new StringBuilder();

            String query = "SELECT * FROM Win32_BIOS";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementClass mc = new ManagementClass("Win32_Processor");
            //  This should only find one
            foreach (ManagementObject item in searcher.Get())
            {
                Object obj = item["Manufacturer"];
                builder.Append(Convert.ToString(obj));
                builder.Append(':');
                obj = item["SerialNumber"];
                builder.Append(Convert.ToString(obj));
            }

            return builder.ToString();
        }
        string cpuID()
        {
            string cpuID = "";
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuID == "")
                {
                    //Remark gets only the first CPU ID
                    cpuID = mo.Properties["processorID"].Value.ToString();

                }
            }
            return cpuID;
        }
        string CheckAth()
        {
            string value = "";
            int ExpireDate = 0;
            id = UniqueMachineId() + GetMACAddress() + cpuID();
            CurrentDate = IntDate(DateTime.Today);
            try
            {
                value = Decrypt(Properties.Settings.Default.PreventID);
                ExpireDate = (Properties.Settings.Default.PreventDays != "") ? Convert.ToInt32(Decrypt(Properties.Settings.Default.PreventDays)) : ExpireDate;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "error";
            }

            if (id != value)
            {
                return "id";
            }
            else if (CurrentDate > ExpireDate)
            {
                return "date";
            }
            else
            {
                return "OK";
            }

        }

        #endregion

        #region Details
        private void txt_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) SendKeys.Send("{TAB}");
        }
        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btn_Login_Click(null, null);
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            //model.aname = txt_Name.Text.Trim();
            //model.ename = txt_Name.Text;
            //model.password = txt_Password.Text.Trim();

            //DataTable dt = new DataTable();
            //dt = model.Select().Tables[0];

            //foreach (DataRow r in dt.Rows)
            //{
            //    if ((r["aname"].ToString() == model.aname || r["ename"].ToString() == model.ename) && r["password"].ToString() == model.password)
            //    {
            //        Hide();
            //        string c = CheckAth();
            //        if (c == "OK")
            //        {

            //            user_id = r["id"].ToString();
            //            frm_main.UserID = user_id;
            //            frm_main.Show();
            //            Properties.Settings.Default.LoginUser = txt_Name.Text;
            //            Properties.Settings.Default.Save();
            //            return;
            //        }
            //        else
            //        {
            //            pro_view.fld_PL.fld_Login.frm_preventnu p = new frm_preventnu();
            //            p.UserID = r["id"].ToString();
            //            p.Case = c;
            //            p.frm_main = frm_main;
            //            p.ShowDialog();
            //            return;
            //        }
            //    }
            //}
            //MessageBox.Show("أسم المستخدم أو كلمة المرور غير صحيحة", "خطأ في بيانات الدخول", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void btn_Demo_Click(object sender, EventArgs e)
        {
            Hide();
            frm_main.com_users.SelectedValue = "Demo";
            frm_main.Show();
        }
        private void btn_ServerConSettings_Click(object sender, EventArgs e)
        {
            pro_view.fld_PL.fld_Login.frm_serverinfo s = new frm_serverinfo();
            s.ShowDialog();
        }
        #endregion

        private void btn_Lock_MouseEnter(object sender, EventArgs e)
        {
            btn_Lock.FlatStyle = FlatStyle.Popup;
        }

        private void btn_Lock_MouseLeave(object sender, EventArgs e)
        {
            btn_Lock.FlatStyle = FlatStyle.Flat;
        }
    }
}
