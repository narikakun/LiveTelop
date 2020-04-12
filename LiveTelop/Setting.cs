using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveTelop
{
    public partial class Setting : Form
    {
        Form1 f1;
        public Setting(Form1 f)
        {
            InitializeComponent();
            f1 = f;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            CheckBoxLoad();
            System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            label12.Text = "ver:" + ver.ProductVersion.ToString();
        }

        private void CheckBoxLoad()
        {
            checkBox1.Checked = Properties.Settings.Default.beta_status;
            checkBox2.Checked = Properties.Settings.Default.eew_forecast;
            checkBox3.Checked = Properties.Settings.Default.eew_warning;
            checkBox4.Checked = Properties.Settings.Default.eew_demo_forecast;
            checkBox5.Checked = Properties.Settings.Default.eew_demo_warning;
            trackBar1.Value = Properties.Settings.Default.telop_scrollspeed;
            trackBar2.Value = Properties.Settings.Default.color_pattern;
            textBox1.Text = Convert.ToString(Properties.Settings.Default.telop_scrollspeed);
            textBox2.Text = Convert.ToString(Properties.Settings.Default.color_pattern);
            trackBar3.Value = Properties.Settings.Default.layout_pattern;
            textBox3.Text = Convert.ToString(Properties.Settings.Default.layout_pattern);
            textBox4.Text = Convert.ToString(Properties.Settings.Default.eew_text);
            checkBox8.Checked = Properties.Settings.Default.error_report;
            checkBox9.Checked = Properties.Settings.Default.time_second;
            checkBox10.Checked = Properties.Settings.Default.time_digital;
            checkBox11.Checked = Properties.Settings.Default.bouyomi;
            textBox5.Text = Convert.ToString(Properties.Settings.Default.telop_level_s);
            trackBar4.Value = Properties.Settings.Default.bouyomi_speed;
            if (Properties.Settings.Default.bouyomi_speed == 49)
            {
                label9.Text = "速度(無効)";
            } else
            {
                label9.Text = "速度(" + Properties.Settings.Default.bouyomi_speed + ")";
            }
            trackBar5.Value = Properties.Settings.Default.bouyomi_pitch;
            if (Properties.Settings.Default.bouyomi_pitch == 49)
            {
                label10.Text = "ピッチ(無効)";
            }
            else
            {
                label10.Text = "ピッチ(" + Properties.Settings.Default.bouyomi_pitch + ")";
            }
            trackBar6.Value = Properties.Settings.Default.bouyomi_volume;
            if (Properties.Settings.Default.bouyomi_volume == -1)
            {
                label11.Text = "ボリューム(無効)";
            }
            else
            {
                label11.Text = "ボリューム(" + Properties.Settings.Default.bouyomi_volume + ")";
            }
            textBox6.Text = Convert.ToString(Properties.Settings.Default.bouyomi_ip);
            textBox7.Text = Convert.ToString(Properties.Settings.Default.bouyomi_port);
            checkBox12.Checked = Properties.Settings.Default.eew_forecast_wav;
            checkBox13.Checked = Properties.Settings.Default.eew_warning_wav;
            textBox8.Text = Convert.ToString(Properties.Settings.Default.bouyomi_type);
            checkBox14.Checked = Properties.Settings.Default.eew_form;
            trackBar7.Value = Properties.Settings.Default.eew_form_time;
            if (trackBar7.Value == 0)
            {
                label16.Text = "表示画面表示秒数（無効）";
            }
            else
            {
                label16.Text = "表示画面表示秒数（" + trackBar7.Value + "秒）";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                f1.beta_status = true;
            } else
            {
                f1.beta_status = false;
            }
            f1.BetaCheck();
            f1.LayoutCheck();
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.beta_status = checkBox1.Checked;
            Properties.Settings.Default.eew_forecast = checkBox2.Checked;
            Properties.Settings.Default.eew_warning = checkBox3.Checked;
            Properties.Settings.Default.eew_demo_forecast = checkBox4.Checked;
            Properties.Settings.Default.eew_demo_warning = checkBox5.Checked;
            Properties.Settings.Default.telop_scrollspeed = trackBar1.Value;
            Properties.Settings.Default.color_pattern = trackBar2.Value;
            Properties.Settings.Default.layout_pattern = trackBar3.Value;
            Properties.Settings.Default.eew_text = textBox4.Text;
            Properties.Settings.Default.error_report = checkBox8.Checked;
            Properties.Settings.Default.time_second = checkBox9.Checked;
            Properties.Settings.Default.time_digital = checkBox10.Checked;
            Properties.Settings.Default.telop_level_s = textBox5.Text;
            Properties.Settings.Default.bouyomi = checkBox11.Checked;
            Properties.Settings.Default.bouyomi_speed = trackBar4.Value;
            Properties.Settings.Default.bouyomi_pitch = trackBar5.Value;
            Properties.Settings.Default.bouyomi_volume = trackBar6.Value;
            Properties.Settings.Default.bouyomi_ip = textBox6.Text;
            Properties.Settings.Default.bouyomi_port = textBox7.Text;
            Properties.Settings.Default.eew_forecast_wav = checkBox12.Checked;
            Properties.Settings.Default.eew_warning_wav = checkBox13.Checked;
            Properties.Settings.Default.bouyomi_type = Convert.ToInt32(textBox8.Text);
            Properties.Settings.Default.eew_form = checkBox14.Checked;
            Properties.Settings.Default.eew_form_time = trackBar7.Value;
            Properties.Settings.Default.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                f1.eew_forecast = true;
            }
            else
            {
                f1.eew_forecast = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                f1.eew_warning = true;
            }
            else
            {
                f1.eew_warning = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                f1.eew_demo_forecast = true;
            }
            else
            {
                f1.eew_demo_forecast = false;
            }
            f1.EEW_DemoCheck();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                f1.eew_demo_warning = true;
            }
            else
            {
                f1.eew_demo_warning = false;
            }
            f1.EEW_DemoCheck();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            f1.Size = Properties.Settings.Default.F1Size;
            CheckBoxLoad();
            checkBox6.Checked = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "2";
            }
            if (Convert.ToInt32(textBox1.Text) > 10)
            {
                textBox1.Text = "10";
            }
            trackBar1.Value = Convert.ToInt32(textBox1.Text);
            f1.scrollspeed = trackBar1.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(trackBar1.Value);
            f1.scrollspeed = trackBar1.Value;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "2";
            trackBar1.Value = 2;
            f1.scrollspeed = 2;
            checkBox7.Checked = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(trackBar2.Value);
            f1.color_pattern = trackBar2.Value;
            f1.TelopLevelCheck();
            f1.LayoutCheck();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "1";
            }
            if (Convert.ToInt32(textBox2.Text) > 3)
            {
                textBox2.Text = "3";
            }
            trackBar2.Value = Convert.ToInt32(textBox2.Text);
            f1.color_pattern = trackBar2.Value;
            f1.TelopLevelCheck();
            f1.LayoutCheck();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(trackBar3.Value);
            f1.layout_pattern = trackBar3.Value;
            f1.TelopLevelCheck();
            f1.LayoutCheck();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "1";
            }
            if (Convert.ToInt32(textBox3.Text) > 2)
            {
                textBox3.Text = "2";
            }
            trackBar3.Value = Convert.ToInt32(textBox3.Text);
            f1.layout_pattern = trackBar3.Value;
            f1.TelopLevelCheck();
            f1.LayoutCheck();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1.TelopContentSet();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                f1.error_report = true;
            }
            else
            {
                f1.error_report = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                f1.time_second = true;
            }
            else
            {
                f1.time_second = false;
            }
            f1.TelopLevelLayoutCheck();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                f1.time_digital = true;
            }
            else
            {
                f1.time_digital = false;
            }
            f1.TelopLevelLayoutCheck();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            f1.eew_text = textBox4.Text;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            var textbox5 = textBox5.Text;
            if (textbox5 == "1" || textbox5 == "2" || textbox5 == "3" || textbox5 == "4" || textbox5 == "5" || textbox5 == "6" || textbox5 == "7" || textbox5 == "")
            {
                f1.telop_level_s = textBox5.Text;
                f1.TelopLevelCheck();
            } else
            {
                MessageBox.Show("有効な数字を入れてください。");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                f1.bouyomi = true;
                checkBox11.Text = "読み上げる";
            }
            else
            {
                f1.bouyomi = false;
                checkBox11.Text = "読み上げない";
            }
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            if (trackBar4.Value == 49)
            {
                label9.Text = "速度(無効)";
                f1.bouyomi_speed = 49;
            }
            else
            {
                label9.Text = "速度(" + trackBar4.Value.ToString() + ")";
                f1.bouyomi_speed = trackBar4.Value;
            }
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            if (trackBar5.Value == 49)
            {
                label10.Text = "ピッチ(無効)";
                f1.bouyomi_pitch = 49;
            }
            else
            {
                label10.Text = "ピッチ(" + trackBar5.Value.ToString() + ")";
                f1.bouyomi_pitch = trackBar5.Value;
            }
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            if (trackBar6.Value == -1)
            {
                label11.Text = "ボリューム(無効)";
                f1.bouyomi_volume = -1;
            }
            else
            {
                label11.Text = "ボリューム(" + trackBar6.Value.ToString() + ")";
                f1.bouyomi_volume = trackBar6.Value;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            f1.bouyomi_ip = textBox6.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "50080";
            }
            if (textBox7.Text == "-")
            {
                textBox7.Text = "0";
            }
            if (Convert.ToInt32(textBox7.Text) < 0)
            {
                textBox7.Text = "0";
            }
            if (Convert.ToInt32(textBox7.Text) > 65535)
            {
                textBox7.Text = "65535";
            }
            f1.bouyomi_port = textBox7.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.Bouyomi("これはテスト読み上げです。");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("BouyomiChan").Length > 0)
                {
                    WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                    var sends = "http://" + f1.bouyomi_ip + ":" + f1.bouyomi_port + "/pause";
                    wc.DownloadString(sends);
                }
                else
                {
                    MessageBox.Show("棒読みちゃんが起動していません。");
                }
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("棒読みちゃん読み上げにて、エラーが発生しました。");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("BouyomiChan").Length > 0)
                {
                    WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                    var sends = "http://" + f1.bouyomi_ip + ":" + f1.bouyomi_port + "/resume";
                    wc.DownloadString(sends);
                }
                else
                {
                    MessageBox.Show("棒読みちゃんが起動していません。");
                }
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("棒読みちゃん読み上げにて、エラーが発生しました。");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("BouyomiChan").Length > 0)
                {
                    WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                    var sends = "http://" + f1.bouyomi_ip + ":" + f1.bouyomi_port + "/skip";
                    wc.DownloadString(sends);
                }
                else
                {
                    MessageBox.Show("棒読みちゃんが起動していません。");
                }
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("棒読みちゃん読み上げにて、エラーが発生しました。");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("BouyomiChan").Length > 0)
                {
                    WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                    var sends = "http://" + f1.bouyomi_ip + ":" + f1.bouyomi_port + "/clear";
                    wc.DownloadString(sends);
                } else
                {
                    MessageBox.Show("棒読みちゃんが起動していません。");
                }
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("棒読みちゃん読み上げにて、エラーが発生しました。");
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                f1.eew_forecast_wav = true;
            }
            else
            {
                f1.eew_forecast_wav = false;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                f1.eew_warning_wav = true;
            }
            else
            {
                f1.eew_warning_wav = false;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            f1.bouyomi_type = Convert.ToInt32(textBox8.Text);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                f1.eew_forms = true;
            }
            else
            {
                f1.eew_forms = false;
            }
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            if (trackBar7.Value == 0)
            {
                label16.Text = "表示画面表示秒数（無効）";
            }
            else
            {
                label16.Text = "表示画面表示秒数（" + trackBar7.Value + "秒）";
                f1.eew_form_timer.Interval = trackBar7.Value * 1000;
            }
            f1.eew_form_time = trackBar7.Value;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
