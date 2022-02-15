using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Security.Cryptography;

namespace WinSqlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //getData("company");
            Console.WriteLine(EncryptPassword("admin"));
        }
        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="password">要加密的密码字符串</param>
        /// <returns></returns>
        public static string EncryptPassword(string password)
        {
            string msg = password;
            byte[] result = Encoding.Default.GetBytes(msg);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "").ToUpper();
        }

        void getData(string tbName = "tb_val")
        {
            try
            {
                string msg = "";
                msg += DateTime.Now.ToString("HH:mm:ss.fff") + "\r\n";
                msg += "-------------------------ST\r\n";
                string sqlServerConnString = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
                SqlServerDBHelper db = new SqlServerDBHelper(sqlServerConnString);
                DataTable dt = db.GetCommand("select * from " + tbName);
                foreach (DataRow dr in dt.Rows)
                {
                    msg += dr[0].ToString() + "," + dr[1].ToString() + "\r\n";
                }
                msg += "-------------------------ED\r\n";
                ShowMsg(msg);
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message, true);
            }
        }

        void ShowMsg(string msg, bool isErr = false)
        {
            this.Invoke(new EventHandler(delegate
            {
                textBox1.Text = DateTime.Now.ToString("HH:mm:ss.fff") + "\t" + (isErr ? "****" : "") + msg + "\r\n" + textBox1.Text;
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData(this.txtTBNm.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select * from " + txtTable.Text ;
            try
            {
                DataTable tb = DBHelp.ExecuteDataTable(sql);
                int cols = tb.Columns.Count;
                string msg = "共" + tb.Rows.Count + "\r\n";
                foreach (DataRow dr in tb.Rows)
                {
                    for (int ii = 0; ii < cols; ii++)
                    {
                        msg += dr[ii].ToString() + "\t";
                    }
                    msg += "\r\n";
                }
                ShowMsg(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t" + ex.StackTrace);
                ShowMsg(ex.Message, true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select count('x') as cnt from " + txtTable.Text;
            try
            {
                int cnt = DBHelp.ExecuteScalar(sql);
                ShowMsg("共[" + cnt + "]");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t" + ex.StackTrace);
                ShowMsg(ex.Message, true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int ret = DBHelp.ExecuteNonQuery("update tb_test set val='" + DateTime.Now.ToString() + "' where id=1");
                ShowMsg("update result [" + ret + "]");
                txtTable.Text = "tb_test";
                button2_Click(null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\t" + ex.StackTrace);
                ShowMsg(ex.Message, true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int stLine = 1;
            try
            {
                stLine = int.Parse(startLine.Text);
            }
            catch { }
            string fileName = this.textBoxListTxt.Text;
            Thread threadRun = new Thread(() =>
            {
                int rowIdx = 1;
                string sql = "";
                //读取文件内容
                try
                {
                    string[] lines = File.ReadAllLines(fileName);

                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line)) continue;

                        if (rowIdx < stLine)
                        {
                            rowIdx++;
                            continue;
                        }

                        sql = line;

                        int ret = DBHelp.ExecuteNonQuery(sql);
                        ShowMsg("No." + rowIdx + "---" + ret);
                        if (ret != 1)
                        {
                            break;
                        }
                        rowIdx++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\t" + ex.StackTrace);
                    Console.WriteLine(sql);
                    MessageBox.Show("[" + rowIdx + "]" + "\t" + ex.Message + "\t" + ex.StackTrace);
                }
                finally
                {

                }
            });
            threadRun.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int stLine = 1;
            try
            {
                stLine = int.Parse(startLine.Text);
            }
            catch { }

            string fileName = string.Empty; //文件名
            //打开文件
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "xls";
            dlg.Filter = "EXCEL文件(*.XLS)|*.xls";
            //dlg.Filter = "EXCEL文件(*.XLS)|*.xls|EXCEL文件(*.XLSX)|*.xlsx";
            if (dlg.ShowDialog() == DialogResult.OK)
                fileName = dlg.FileName;
            if (fileName == null || string.IsNullOrEmpty(fileName))
                return;

            this.textBoxListTxt.Text = fileName;


            button5_Click(null, null);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                DapperHelper.SetConnStr("DBConnect");
                List<tb_val> tbList = DapperHelper.ExecuteReaderReturnList<tb_val>("select * from tb_val");
                ShowMsg(tbList.Count + "," + tbList.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                DapperHelper.SetConnStr("MySqlDBConnect");
                List<tb_log> tbList = DapperHelper.ExecuteReaderReturnList<tb_log>("select * from tb_log");
                ShowMsg(tbList.Count + "," + tbList.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                DapperHelper.SetConnStr("SqliteDBConnect");
                List<record> tbList = DapperHelper.ExecuteReaderReturnList<record>("select * from record");
                ShowMsg(tbList.Count + "," + tbList.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                DapperHelper.SetConnStr("DBConnect2");
                List<tb_val> tbList = DapperHelper.ExecuteReaderReturnList<tb_val>("select * from Table_1");
                ShowMsg("cnt : " + tbList.Count + "," + tbList.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


    class tb_val
    {
        public int id;
        public string val;
    }
    class tb_log
    {
        public long logid;
        public string logtype;
        public string logcont;
        public string logtime;
    }

    class record
    {
        public long id;
        public long no;
        public long grp;
        public string barcode;
        public string epc;
        public string user;
        public string tid;
        public string updatetime;
        public string deltime;
        public string remark;
        public int del;
    }
}
