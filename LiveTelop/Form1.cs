using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.WebSockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveTelop
{
    public partial class Form1 : Form
    {
        public int i;
        public int scrollspeed = Properties.Settings.Default.telop_scrollspeed;
        public string telop_text_content;
        public string category;
        public int category_number = 0;
        public string telop_level;
        public bool eew_status = false;
        public bool beta_status = Properties.Settings.Default.beta_status;
        public string beta_url = "";
        public bool eew_forecast = Properties.Settings.Default.eew_forecast;
        public bool eew_warning = Properties.Settings.Default.eew_warning;
        public bool eew_demo_forecast = Properties.Settings.Default.eew_demo_forecast;
        public bool eew_demo_warning = Properties.Settings.Default.eew_demo_warning;
        public int color_pattern = Properties.Settings.Default.color_pattern;
        public int layout_pattern = Properties.Settings.Default.layout_pattern;
        public bool error_report = Properties.Settings.Default.error_report;
        public bool time_second = Properties.Settings.Default.time_second;
        public bool time_digital = Properties.Settings.Default.time_digital;
        public string eew_text = Properties.Settings.Default.eew_text;
        public string telop_level_s = Properties.Settings.Default.telop_level_s;
        public bool bouyomi = Properties.Settings.Default.bouyomi;
        public int bouyomi_speed = Properties.Settings.Default.bouyomi_speed;
        public int bouyomi_pitch = Properties.Settings.Default.bouyomi_pitch;
        public int bouyomi_volume = Properties.Settings.Default.bouyomi_volume;
        public int bouyomi_type = Properties.Settings.Default.bouyomi_type;
        public string bouyomi_ip = Properties.Settings.Default.bouyomi_ip;
        public string bouyomi_port = Properties.Settings.Default.bouyomi_port;
        public bool eew_forecast_wav = Properties.Settings.Default.eew_forecast_wav;
        public bool eew_warning_wav = Properties.Settings.Default.eew_warning_wav;
        public bool eew_forms = Properties.Settings.Default.eew_form;
        public bool eew_form_show = false;
        public int eew_form_time = Properties.Settings.Default.eew_form_time;
        public string eew_m_f = Properties.Settings.Default.eew_m_f;
        public string eew_m_w = Properties.Settings.Default.eew_m_w;
        public bool bgm = Properties.Settings.Default.bgm;
        public string bgm_url = Properties.Settings.Default.bgm_url;
        eew_form ef;

        public Form1()
        {
            InitializeComponent();
            telop_text.Text = "";
            telop_scroll.Interval = 2;
            telop_scroll.Start();
            clock.Interval = 1000;
            this.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            BetaCheck();
            EEW_DemoCheck();
            ef = new eew_form(this);
            if (eew_form_time != 0)
            {
                eew_form_timer.Interval = eew_form_time * 1000;
            }
            if (Properties.Settings.Default.IsUpgrade == false)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.IsUpgrade = true;
                Properties.Settings.Default.Save();
            }
            BGMStart();
        }

        public SoundPlayer bgm_player;

        public void BGMStart()
        {
            if (eew_status)
            {
                bgm_player.Stop();
            }
            else
            {
                if (bgm)
                {
                    if (bgm_url != "")
                    {
                        bgm_player = new SoundPlayer(@"" + bgm_url);
                        bgm_player.PlayLooping();
                    }
                    else
                    {
                        bgm_player.Stop();
                    }
                }
                else
                {
                    bgm_player.Stop();
                }
            }
        }

        public void BetaCheck()
        {
            if (beta_status == true)
            {
                beta_url = ""; //ベータURL削除に伴い""にしている
                button1.Show();
            }
            else
            {
                beta_url = "";
                button1.Hide();
            }
        }
        public void EEW_DemoCheck()
        {
            if (eew_demo_forecast == true)
            {
                eew_url = "https://api.narikakun.net/eew/v1_Forecast.json";
            }
            else if (eew_demo_warning == true)
            {
                eew_url = "https://api.narikakun.net/eew/v1_Warning.json";
            }
            else
            {
                eew_url = "https://api.narikakun.net/eew/v1.json";
            }
        }
        private void telop_scroll_Tick(object sender, EventArgs e)
        {
            if (telop_text.Location.X <= (0 - telop_text.Size.Width))
            {
                i = telop_panel.Size.Width;
                telop_text.Location = new Point(i, 1);
                TelopContentSet();
            }
            else
            {
                telop_text.Location = new Point(i, 1);
                i -= scrollspeed;
            }
        }

        public void TelopContentSet()
        {
            if (eew_status == true) return;
            category_number++;
            try
            {
                WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                telop_text_content = wc.DownloadString("https://api.narikakun.net/livetelop/" + beta_url + "?category=" + category_number);
                //Console.WriteLine(telop_text_content);
                if (telopJson(telop_text_content).content == "")
                {
                    TelopContentSet();
                    return;
                }
                if (category_number > telopJson(telop_text_content).max)
                {
                    category_number = 0;
                    TelopContentSet();
                    return;
                }
                telop_text.Text = telopJson(telop_text_content).content;
                category_sub_label.Hide();
                telop_category.Text = telopJson(telop_text_content).title;
                if (layout_pattern == 2)
                {
                    category_sub_label.Show();
                    category_sub_label.Text = telopJson(telop_text_content).title;
                }
                if (telopJson(telop_text_content).title == "地震情報 (震度7)" || telopJson(telop_text_content).title == "地震情報 (震度6強)" || telopJson(telop_text_content).title == "地震情報 (震度6弱)" || telopJson(telop_text_content).title == "地震情報 (震度5強)" || telopJson(telop_text_content).title == "地震情報 (震度5弱)" || telopJson(telop_text_content).title == "地震情報 (震度4)" || telopJson(telop_text_content).title == "地震情報 (震度3)" || telopJson(telop_text_content).title == "地震情報 (震度2)" || telopJson(telop_text_content).title == "地震情報 (震度1)")
                {
                    if (layout_pattern == 1)
                    {
                        telop_category.Text = "地震情報";
                        category_sub_label.Text = telopJson(telop_text_content).title.Replace("地震情報 (", "").Replace(")", "");
                        category_sub_label.Show();
                    }
                    else if (layout_pattern == 2)
                    {
                        category_sub_label.Text = telopJson(telop_text_content).title;
                    }
                }
                var sokuho_content = telopJson(telop_text_content).sokuho;
                NHKsokuhoCheck(sokuho_content);
            }
            catch (System.Net.WebException error_content)
            {
                if (error_report)
                {
                    try { 
                        System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo( System.Reflection.Assembly.GetExecutingAssembly().Location);
                        System.OperatingSystem os = System.Environment.OSVersion;
                        WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                        NameValueCollection ps = new NameValueCollection();
                        ps.Add("os_info", "os:" + os.ToString());
                        ps.Add("error_content", "TelopContentSet " + error_content.ToString());
                        ps.Add("appname", "LiveTelop");
                        ps.Add("appinfo", ver.ToString());
                        byte[] resData = wc.UploadValues("https://api.narikakun.net/livetelop/soft_error_report.php", ps);
                        wc.Dispose();
                        string resText = System.Text.Encoding.UTF8.GetString(resData);
                        if (errorreportjson(resText).status == 200)
                        {
                            notify.BalloonTipTitle = "LiveTelop";
                            notify.BalloonTipIcon = ToolTipIcon.Info;
                            notify.BalloonTipText = "エラーが発生したため自動報告しました。";
                            notify.ShowBalloonTip(3000);
                        }
                        else
                        {
                            notify.BalloonTipTitle = "LiveTelop";
                            notify.BalloonTipIcon = ToolTipIcon.Error;
                            notify.BalloonTipText = "エラー自動報告に失敗しました。";
                            notify.ShowBalloonTip(3000);
                        }
                    }
                    catch (System.Net.WebException report_error_content)
                    {
                        notify.BalloonTipTitle = "LiveTelop";
                        notify.BalloonTipIcon = ToolTipIcon.Error;
                        notify.BalloonTipText = "エラー自動報告サーバーに接続できません。";
                        notify.ShowBalloonTip(3000);
                    }
                } else
                {
                    notify.BalloonTipTitle = "LiveTelop";
                    notify.BalloonTipIcon = ToolTipIcon.Info;
                    notify.BalloonTipText = "エラーが発生しました。自動報告が有効になっていないため、報告ができません。";
                    notify.ShowBalloonTip(3000);
                }
            }
        }

        [DataContract]
        class ErrorReportJsonContract
        {
            [DataMember]
            public int status { get; set; }
            [DataMember]
            public string message { get; set; }
        }

        static ErrorReportJsonContract errorreportjson(string text)
        {
            ErrorReportJsonContract json;
            var serializer = new DataContractJsonSerializer(typeof(ErrorReportJsonContract));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(text)))
            {
                json = (ErrorReportJsonContract)serializer.ReadObject(ms);
            }
            return json;
        }

        [DataContract]
        class TelopDataContract
        {
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public int max { get; set; }
            [DataMember]
            public string content { get; set; }
            [DataMember]
            public string sokuho { get; set; }
        }

        static TelopDataContract telopJson(string text)
        {
            TelopDataContract json;
            var serializer = new DataContractJsonSerializer(typeof(TelopDataContract));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(text)))
            {
                json = (TelopDataContract)serializer.ReadObject(ms);
            }
            return json;
        }

        private string sokuho_last = "";
        private bool start_sokuho = true;

        private void NHKsokuhoCheck(string sokuho_content)
        {
            if (sokuho_content != "NOTDATA")
            {
                if (start_sokuho == true)
                {
                    start_sokuho = false;
                }
                else
                {
                    if (sokuho_last != sokuho_content)
                    {
                        telop_text.Text = sokuho_content;
                        category_sub_label.Hide();
                        telop_category.Text = "ニュース速報";
                        if (layout_pattern == 2)
                        {
                            category_sub_label.Show();
                            category_sub_label.Text = "ニュース速報";
                        }
                        telop_text.Location = new Point(this.Width, 1);
                        sokuho_last = sokuho_content;
                    }
                }
            }
        }
        public void TelopLevelCheck()
        {
            try
            {
                WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                telop_level = wc.DownloadString("https://api.narikakun.net/livetelop/" + beta_url + "?category=レベル");
                //Console.WriteLine(telop_level);
                var telop_level_json = telop_level;
                telop_timer.Text = "テロップレベル" + telopJson(telop_level).content;
                if (telop_level_s == "")
                {
                    telop_level = telopJson(telop_level).content;
                } else
                {
                    telop_level = telop_level_s;
                }
                if (eew_status == true) return;
                if (color_pattern == 3)
                {
                    telop_timer.BackColor = TransparencyKey;
                    switch (telop_level)
                    {
                        case "1":
                            //3
                            this.BackColor = System.Drawing.Color.FromArgb(128, 255, 255);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
                            }
                            break;

                        case "2":
                            //2
                            this.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                            }
                            break;
                        case "3":
                            //5
                            this.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
                            }
                            break;

                        case "4":
                            //1
                            this.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                            }
                            break;

                        case "5":
                            //6
                            this.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
                            }
                            break;
                        case "6":
                            //4 (red)
                            this.BackColor = System.Drawing.Color.FromArgb(255, 128, 255);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 192, 255);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 192, 255);
                            }
                            break;
                        case "7":
                            //7
                            this.BackColor = System.Drawing.Color.FromArgb(192, 64, 0);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
                            }
                            break;
                        default:
                            //d
                            //3
                            this.BackColor = System.Drawing.Color.FromArgb(128, 255, 255);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                            }
                            break;
                    }
                    foreach (Label lbl in this.Controls.OfType<Label>())
                    {
                        lbl.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    }
                    foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                    {
                        lbl.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    }
                } else if (color_pattern == 2)
                {
                    switch (telop_level)
                    {
                        case "1":
                            this.BackColor = System.Drawing.Color.FromArgb(8, 39, 214);
                            telop_panel.BackColor = TransparencyKey;
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(8, 39, 214);
                            }
                            foreach (Label lbl in this.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            break;
                        case "2":
                            this.BackColor = System.Drawing.Color.FromArgb(27, 94, 32);
                            telop_panel.BackColor = TransparencyKey;
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(27, 94, 32);
                            }
                            foreach (Label lbl in this.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            break;
                        case "3":
                            this.BackColor = System.Drawing.Color.FromArgb(250, 245, 0);
                            telop_panel.BackColor = TransparencyKey;
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(250, 245, 0);
                            }
                            foreach (Label lbl in this.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(38, 50, 56);
                            }
                            foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(38, 50, 56);
                            }
                            break;
                        case "4":
                            this.BackColor = System.Drawing.Color.FromArgb(255, 109, 0);
                            telop_panel.BackColor = TransparencyKey;
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 109, 0);
                            }
                            foreach (Label lbl in this.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            break;
                        case "5":
                            this.BackColor = System.Drawing.Color.FromArgb(213, 0, 0);
                            telop_panel.BackColor = TransparencyKey;
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(213, 0, 0);
                            }
                            foreach (Label lbl in this.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            break;
                        case "6":
                            this.BackColor = System.Drawing.Color.FromArgb(255, 174, 201);
                            telop_panel.BackColor = TransparencyKey;
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 174, 201);
                            }
                            foreach (Label lbl in this.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            break;
                        case "7":
                            this.BackColor = System.Drawing.Color.FromArgb(100, 0, 0);
                            telop_panel.BackColor = TransparencyKey;
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(100, 0, 0);
                            }
                            foreach (Label lbl in this.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            break;
                        default:
                            this.BackColor = System.Drawing.Color.FromArgb(8, 39, 214);
                            telop_panel.BackColor = TransparencyKey;
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(8, 39, 214);
                            }
                            foreach (Label lbl in this.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            break;
                    }
                }
                else
                {
                    telop_timer.BackColor = TransparencyKey;
                    switch (telop_level)
                    {
                        case "1":
                            this.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                            }
                            break;
                        case "2":
                            this.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                            }
                            break;
                        case "3":
                            this.BackColor = System.Drawing.Color.FromArgb(128, 255, 255);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
                            }
                            break;
                        case "4":
                            this.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
                            }
                            break;
                        case "5":
                            this.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
                            }
                            break;
                        case "6":
                            this.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
                            }
                            break;
                        case "7":
                            this.BackColor = System.Drawing.Color.FromArgb(192, 64, 0);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
                            }
                            break;
                        default:
                            this.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                            }
                            break;
                    }
                    foreach (Label lbl in this.Controls.OfType<Label>())
                    {
                        lbl.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    }
                    foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                    {
                        lbl.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                    }
                }
            }
            catch (System.Net.WebException error_content)
            {
                if (error_report)
                {
                    try
                    {
                        System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        System.OperatingSystem os = System.Environment.OSVersion;
                        WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                        NameValueCollection ps = new NameValueCollection();
                        ps.Add("os_info", "os:" + os.ToString());
                        ps.Add("error_content", "TelopLevelCheck " + error_content.ToString());
                        ps.Add("appname", "LiveTelop");
                        ps.Add("appinfo", ver.ToString());
                        byte[] resData = wc.UploadValues("https://api.narikakun.net/livetelop/soft_error_report.php", ps);
                        wc.Dispose();
                        string resText = System.Text.Encoding.UTF8.GetString(resData);
                        if (errorreportjson(resText).status == 200)
                        {
                            notify.BalloonTipTitle = "LiveTelop";
                            notify.BalloonTipIcon = ToolTipIcon.Info;
                            notify.BalloonTipText = "エラーが発生したため自動報告しました。";
                            notify.ShowBalloonTip(3000);
                        }
                        else
                        {
                            notify.BalloonTipTitle = "LiveTelop";
                            notify.BalloonTipIcon = ToolTipIcon.Error;
                            notify.BalloonTipText = "エラー自動報告に失敗しました。";
                            notify.ShowBalloonTip(3000);
                        }
                    }
                    catch (System.Net.WebException report_error_content)
                    {
                        notify.BalloonTipTitle = "LiveTelop";
                        notify.BalloonTipIcon = ToolTipIcon.Error;
                        notify.BalloonTipText = "エラー自動報告サーバーに接続できません。";
                        notify.ShowBalloonTip(3000);
                    }
                }
                else
                {
                    notify.BalloonTipTitle = "LiveTelop";
                    notify.BalloonTipIcon = ToolTipIcon.Info;
                    notify.BalloonTipText = "エラーが発生しました。自動報告が有効になっていないため、報告ができません。";
                    notify.ShowBalloonTip(3000);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clock.Start();
            clock_level_kirikae.Interval = 20000;
            clock_level_kirikae.Start();
            eew_checktimer.Interval = 4000;
            eew_checktimer.Start();
            category_sub_label.Hide();
            title_main.Hide();
            pictureBox1.Hide();
            if (Properties.Settings.Default.F1Size.Width == 0) Properties.Settings.Default.Upgrade();
            if (Properties.Settings.Default.F1Size.Width == 0 || Properties.Settings.Default.F1Size.Height == 0)
            {

            }
            else
            {
                this.WindowState = Properties.Settings.Default.F1State;
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
                this.Location = Properties.Settings.Default.F1Location;
                this.Size = Properties.Settings.Default.F1Size;
            }
            i = 0;
            telop_text.Location = new Point(i, 1);
            LayoutCheck();
            TelopLevelLayoutCheck();
        }

        public int layout_level_timer_y = 0;
        public void LayoutCheck()
        {
            if (layout_pattern == 1)
            {
                telop_category.Show();
                telop_timer.Show();
                category_sub_label.Hide();
                telop_category.Location = new Point(12, 4);
                button1.Location = new Point(807, 4);
                telop_panel.Location = new Point(0, 34);
                layout_level_timer_y = 4;
            } else if (layout_pattern == 2)
            {
                telop_category.Hide();
                category_sub_label.Show();
                button1.Location = new Point(807, 37);
                telop_panel.Location = new Point(0, 2);
                layout_level_timer_y = 2;
            }
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            if (time_second)
            {
                if (time_digital) { 
                    telop_timer.Text = string.Format("{0:00}月{1:00}日 {2:00}:{3:00}:{4:00}", d.Month, d.Day, d.Hour, d.Minute, d.Second);
                } else
                {
                    telop_timer.Text = string.Format("{0:00}月{1:00}日 {2:00}時{3:00}分{4:00}秒", d.Month, d.Day, d.Hour, d.Minute, d.Second);
                }
            }
            else
            {
                if (time_digital)
                {
                    telop_timer.Text = string.Format("{0:00}月{1:00}日 {2:00}:{3:00}", d.Month, d.Day, d.Hour, d.Minute);
                }
                else
                {
                    telop_timer.Text = string.Format("{0:00}月{1:00}日 {2:00}時{3:00}分", d.Month, d.Day, d.Hour, d.Minute);
                }
            }
        }

        public int clock_level_kirikae_number = 1;
        private void clock_level_kirikae_Tick(object sender, EventArgs e)
        {
            clock_level_kirikae_number++;
            TelopLevelLayoutCheck();
        }

        public void TelopLevelLayoutCheck()
        {
            switch (clock_level_kirikae_number)
            {
                case 1:
                    clock.Stop();
                    TelopLevelCheck();
                    telop_timer.Location = new Point(this.Size.Width - 220, layout_level_timer_y);
                    break;
                case 2:
                    if (time_second)
                    {
                        if (time_digital)
                        {
                            telop_timer.Location = new Point(this.Size.Width - 258, layout_level_timer_y);
                        }
                        else
                        {
                            telop_timer.Location = new Point(this.Size.Width - 325, layout_level_timer_y);
                        }
                    }
                    else
                    {
                        if (time_digital)
                        {
                            telop_timer.Location = new Point(this.Size.Width - 220, layout_level_timer_y);
                        }
                        else
                        {
                            telop_timer.Location = new Point(this.Size.Width - 270, layout_level_timer_y);
                        }
                    }
                    clock.Start();
                    break;
                default:
                    clock_level_kirikae_number = 0;
                    break;
            }
        }

        [DataContract]
        class EEWDataContract
        {
            [DataMember]
            public Controls Control { get; set; }

            [DataContract]
            public class Controls
            {
                [DataMember]
                public string Message { get; set; }
            }
            [DataMember]
            public Heads Head { get; set; }

            [DataContract]
            public class Heads
            {
                [DataMember]
                public string AlertFlg { get; set; }
                [DataMember]
                public string ReportNum { get; set; }
                [DataMember]
                public string IsFinal { get; set; }
                [DataMember]
                public string RequestTime { get; set; }
                [DataMember]
                public string ReportId { get; set; }
            }
            [DataMember]
            public Bodys Body { get; set; }

            [DataContract]
            public class Bodys
            {
                [DataMember]
                public string OriginTime { get; set; }
                [DataMember]
                public string Magunitude { get; set; }
                [DataMember]
                public string Depth { get; set; }
                [DataMember]
                public string Calcintensity { get; set; }
                [DataMember]
                public string RegionName { get; set; }
            }
        }

        static EEWDataContract eewJson(string text)
        {
            EEWDataContract json;
            var serializer = new DataContractJsonSerializer(typeof(EEWDataContract));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(text)))
            {
                json = (EEWDataContract)serializer.ReadObject(ms);
            }
            return json;
        }
        public string last_requesttime;
        public string last_reportid;
        public string last_reportid_flg;
        public string eew_url = "https://api.dev.narikakun.net/eew/v1.json";
        private void eew_checktimer_Tick(object sender, EventArgs e)
        {
            try
            {
                WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                string eew_json = wc.DownloadString(eew_url);
                if (eew_json == null) return;
                //Console.WriteLine(eew_json);
                if (eewJson(eew_json).Control.Message == "")
                {
                    if (eewJson(eew_json).Head.RequestTime == last_requesttime) return;
                    telop_text.Location = new Point(telop_panel.Size.Width, 1);
                    bool eew_status_flg = false;
                    telop_timer.BackColor = TransparencyKey;
                    BGMStart();
                    if (eewJson(eew_json).Head.AlertFlg == "予報")
                    {
                        if (eew_forecast == true)
                        {
                            eew_status_flg = true;
                            this.BackColor = System.Drawing.Color.FromArgb(250, 245, 0);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
                            foreach (Label lbl in this.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(38, 50, 56);
                            }
                            foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(38, 50, 56);
                            }
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
                                telop_timer.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                            }
                            if (last_reportid_flg != eewJson(eew_json).Head.ReportId + eewJson(eew_json).Head.AlertFlg)
                            {
                                if (eew_forecast_wav)
                                {
                                    var player = new SoundPlayer();
                                    if (eew_m_f == "")
                                    {
                                        player = new SoundPlayer(Properties.Resources.eew_f);
                                    }
                                    else
                                    {
                                        player = new SoundPlayer(eew_m_f);
                                    }
                                    player.Play();
                                }
                            }
                        }
                    }
                    if (eewJson(eew_json).Head.AlertFlg == "警報")
                    {
                        if (eew_warning == true)
                        {
                            eew_status_flg = true;
                            this.BackColor = System.Drawing.Color.FromArgb(213, 0, 0);
                            telop_panel.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
                            foreach (Label lbl in this.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            foreach (Label lbl in telop_panel.Controls.OfType<Label>())
                            {
                                lbl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                            }
                            if (layout_pattern == 2)
                            {
                                telop_timer.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
                                telop_timer.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
                            }
                            if (last_reportid_flg != eewJson(eew_json).Head.ReportId + eewJson(eew_json).Head.AlertFlg)
                            {
                                if (eew_warning_wav)
                                {
                                    var player = new SoundPlayer();
                                    if (eew_m_w == "")
                                    {
                                        player = new SoundPlayer(Properties.Resources.eew_w);
                                    }
                                    else
                                    {
                                        player = new SoundPlayer(eew_m_w);
                                    }
                                    player.Play();
                                }
                            }
                        }
                    }
                    if (eew_status_flg == true)
                    {
                        telop_category.Text = "緊急地震速報";
                        category_sub_label.Text = "緊急地震速報";
                        var eew_time = DateTime.ParseExact(eewJson(eew_json).Body.OriginTime, "yyyyMMddHHmmss", null);
                        // {time:y} : 年
                        // {time:M} : 月
                        // {time:d} : 日
                        // {time:H} : 時
                        // {time:m} : 分
                        // {time:s} : 秒
                        // {alertflg} : 警報フラグ
                        // {reportnum} : 電文番号
                        // {regionname} : 震源
                        // {calcintensity} : 最大予想震度
                        // {depth} : 深さ
                        // {magunitude} : マグニチュード
                        // "■ 緊急地震速報 {alertflg}第{reportnum}報  ■ {time:d}日{time:H}時{time:m}分ごろ、{regionname}で最大震度{calcintensity}と推定される地震が発生した模様です。震源の深さは、{depth}、マグニチュードは{magunitude}と推定されます。"
                        telop_text.Text = eew_text.Replace("{time:y}", eew_time.ToString("yyyy")).Replace("{time:M}", eew_time.ToString("MM")).Replace("{time:d}", eew_time.ToString("dd")).Replace("{time:H}", eew_time.ToString("HH")).Replace("{time:m}", eew_time.ToString("mm")).Replace("{time:s}", eew_time.ToString("ss")).Replace("{alertflg}", eewJson(eew_json).Head.AlertFlg).Replace("{reportnum}", eewJson(eew_json).Head.ReportNum).Replace("{regionname}", eewJson(eew_json).Body.RegionName).Replace("{calcintensity}", eewJson(eew_json).Body.Calcintensity).Replace("{depth}", eewJson(eew_json).Body.Depth).Replace("{magunitude}", eewJson(eew_json).Body.Magunitude);
                        Bouyomi(telop_text.Text);
                        //telop_text.Text = "■ 緊急地震速報 " + eewJson(eew_json).Head.AlertFlg + "第" + eewJson(eew_json).Head.ReportNum + "報  ■ " + eew_time + "ごろ、" + eewJson(eew_json).Body.RegionName + "で最大震度" + eewJson(eew_json).Body.Calcintensity + "と推定される地震が発生した模様です。震源の深さは、" + eewJson(eew_json).Body.Depth + "、マグニチュードは" + eewJson(eew_json).Body.Magunitude + "と推定されます。";
                        eew_status = true;
                        if (eew_forms)
                        {
                            if (!eew_form_show)
                            {
                                ef.Show();
                            }
                            var cal = eewJson(eew_json).Body.Calcintensity;
                            int plus = 0;
                            if (cal == "5弱" || cal == "5強" || cal == "6弱" || cal == "6強")
                            {
                                plus = 30;
                            }
                            ef.label6.Text = eewJson(eew_json).Body.Calcintensity;
                            ef.label7.Text = eewJson(eew_json).Body.Magunitude;
                            ef.label8.Text = eewJson(eew_json).Body.RegionName;
                            ef.label3.Location = new Point(337 + plus, ef.label3.Location.Y);
                            ef.label4.Location = new Point(454 + plus, ef.label4.Location.Y);
                            ef.label5.Location = new Point(590 + (30 * ef.label8.Text.Length) + plus, ef.label5.Location.Y);
                            ef.label7.Location = new Point(372 + plus, ef.label7.Location.Y);
                            ef.label8.Location = new Point(529 + plus, ef.label8.Location.Y);
                            ef.label9.Location = new Point(ef.label5.Location.X + 148, ef.label5.Location.Y);
                            ef.label9.Text = eew_time.ToString("HH") + ":" + eew_time.ToString("mm") + "頃";
                            if (eewJson(eew_json).Body.Magunitude != "" || eewJson(eew_json).Body.Magunitude != "不明")
                            {
                                if (float.Parse(eewJson(eew_json).Body.Magunitude) >= 6.5)
                                {
                                    ef.BackColor = System.Drawing.Color.FromArgb(250, 245, 0);
                                    ef.label10.Text = "念の為海岸から離れてください";
                                }
                                else
                                {
                                    ef.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
                                    ef.label10.Text = "";
                                }
                            }
                            if (eew_form_time != 0)
                            {
                                eew_form_timer.Start();
                            }

                        }
                        last_requesttime = eewJson(eew_json).Head.RequestTime;
                        last_reportid = eewJson(eew_json).Head.ReportId;
                        last_reportid_flg = eewJson(eew_json).Head.ReportId + eewJson(eew_json).Head.AlertFlg;
                    }
                }
                else
                {
                    if (eew_status == true)
                    {
                        eew_form_show = false;
                        ef.Dispose();
                        ef = new eew_form(this);
                        eew_status = false;
                        TelopLevelCheck();
                        BGMStart();
                    }
                }
            }
            catch (System.Net.WebException error_content)
            {
                if (error_report)
                {
                    try { 
                        System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        System.OperatingSystem os = System.Environment.OSVersion;
                        WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                        NameValueCollection ps = new NameValueCollection();
                        ps.Add("os_info", "os:" + os.ToString());
                        ps.Add("error_content", "eew_checktimer_Tick " + error_content.ToString());
                        ps.Add("appname", "LiveTelop");
                        ps.Add("appinfo", ver.ToString());
                        byte[] resData = wc.UploadValues("https://api.narikakun.net/livetelop/soft_error_report.php", ps);
                        wc.Dispose();
                        string resText = System.Text.Encoding.UTF8.GetString(resData);
                        if (errorreportjson(resText).status == 200)
                        {
                            notify.BalloonTipTitle = "LiveTelop";
                            notify.BalloonTipIcon = ToolTipIcon.Info;
                            notify.BalloonTipText = "エラーが発生したため自動報告しました。";
                            notify.ShowBalloonTip(3000);
                        }
                        else
                        {
                            notify.BalloonTipTitle = "LiveTelop";
                            notify.BalloonTipIcon = ToolTipIcon.Error;
                            notify.BalloonTipText = "エラー自動報告に失敗しました。";
                            notify.ShowBalloonTip(3000);
                        }
                    }
                    catch (System.Net.WebException report_error_content)
                    {
                        notify.BalloonTipTitle = "LiveTelop";
                        notify.BalloonTipIcon = ToolTipIcon.Error;
                        notify.BalloonTipText = "エラー自動報告サーバーに接続できません。";
                        notify.ShowBalloonTip(3000);
                    }
        }
                else
                {
                    notify.BalloonTipTitle = "LiveTelop";
                    notify.BalloonTipIcon = ToolTipIcon.Info;
                    notify.BalloonTipText = "エラーが発生しました。自動報告が有効になっていないため、報告ができません。";
                    notify.ShowBalloonTip(3000);
                }
            }
        }
        public async void Bouyomi(string text)
        {
            if (bouyomi)
            {
                try
                {
                    if (Process.GetProcessesByName("BouyomiChan").Length > 0)
                    {
                        WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                        var sends = "http://" + bouyomi_ip + ":" + bouyomi_port + "/talk?text=" + text;
                        if (bouyomi_type != 0) { sends += "&voice=" + bouyomi_type; };
                        if (bouyomi_volume != -1) { sends += "&volume=" + bouyomi_volume; };
                        if (bouyomi_speed != 49) { sends += "&speed=" + bouyomi_speed; };
                        if (bouyomi_pitch != 49) { sends += "&tone=" + bouyomi_pitch; };
                        wc.DownloadString(sends);
                    }
                }
                catch (System.Net.WebException)
                {
                    MessageBox.Show("棒読みちゃん読み上げにて、エラーが発生しました。");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //eew_url = "https://api.narikakun.net/eew/warning.php?time=20200213193455";
            //ef.label6.Text = "7+";
            //NHKsokuhoCheck("テスト");
            try
            {
                System.Diagnostics.FileVersionInfo ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
                System.OperatingSystem os = System.Environment.OSVersion;
                WebClient wc = new WebClient() { Encoding = Encoding.GetEncoding("UTF-8") };
                NameValueCollection ps = new NameValueCollection();
                ps.Add("os_info", "os:" + os.ToString());
                ps.Add("error_content", "テスト");
                ps.Add("appname", "LiveTelop");
                ps.Add("appinfo", ver.ToString());
                byte[] resData = wc.UploadValues("https://api.narikakun.net/livetelop/soft_error_report.php", ps);
                wc.Dispose();
                string resText = System.Text.Encoding.UTF8.GetString(resData);
                if (errorreportjson(resText).status == 200)
                {
                    notify.BalloonTipTitle = "LiveTelop";
                    notify.BalloonTipIcon = ToolTipIcon.Info;
                    notify.BalloonTipText = "エラーが発生したため自動報告しました。";
                    notify.ShowBalloonTip(3000);
                }
                else
                {
                    notify.BalloonTipTitle = "LiveTelop";
                    notify.BalloonTipIcon = ToolTipIcon.Error;
                    notify.BalloonTipText = "エラー自動報告に失敗しました。";
                    notify.ShowBalloonTip(3000);
                }
            }
            catch (System.Net.WebException report_error_content)
            {
                notify.BalloonTipTitle = "LiveTelop";
                notify.BalloonTipIcon = ToolTipIcon.Error;
                notify.BalloonTipText = "エラー自動報告サーバーに接続できません。";
                notify.ShowBalloonTip(3000);
            }
        }

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting stng = new Setting(this);
            stng.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.F1State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.F1Location = this.Location;
                Properties.Settings.Default.F1Size = this.Size;
            }
            else
            {
                Properties.Settings.Default.F1Location = this.RestoreBounds.Location;
                Properties.Settings.Default.F1Size = this.RestoreBounds.Size;
            }

            Properties.Settings.Default.Save();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            TelopLevelLayoutCheck();
        }

        bool title_main_showhide = false;
        bool title_main_showafter = false;
        private async void title_timer_Tick(object sender, EventArgs e)
        {
            if (title_main_showhide)
            {
                if (title_main_showafter)
                {
                    title_main_showafter = false;
                    if (pictureBox1.Size.Width < this.Size.Width)
                    {
                        title_timer.Stop();
                    }
                    else
                    {
                        pictureBox1.Size = new Size(pictureBox1.Size.Width - 15, pictureBox1.Size.Height);
                    }
                }
                else
                {
                    if (pictureBox1.Size.Width > this.Size.Width)
                    {
                        title_timer.Stop();
                        await Task.Delay(1 * 1000);
                        title_main.Show();
                        title_main.Location = new Point(this.Size.Width / 2 - 100, title_main.Size.Height);
                        await Task.Delay(3 * 1000);
                        title_main.Hide();
                        title_main_showafter = true;
                        title_timer.Start();
                    }
                    else
                    {
                        pictureBox1.Size = new Size(pictureBox1.Size.Width + 15, pictureBox1.Size.Height);
                    }
                }
            } else
            {
                title_main_showhide = true;
                pictureBox1.Show();
            }
        }

        private void eew_form_timer_Tick(object sender, EventArgs e)
        {
            eew_form_timer.Stop();
            eew_form_show = false;
            ef.Dispose();
            ef = new eew_form(this);
        }
    }
}
