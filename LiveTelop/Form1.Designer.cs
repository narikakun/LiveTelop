namespace LiveTelop
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.telop_panel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.category_sub_label = new System.Windows.Forms.Label();
            this.telop_text = new System.Windows.Forms.Label();
            this.telop_scroll = new System.Windows.Forms.Timer(this.components);
            this.telop_category = new System.Windows.Forms.Label();
            this.telop_timer = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.clock_level_kirikae = new System.Windows.Forms.Timer(this.components);
            this.eew_checktimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.title_timer = new System.Windows.Forms.Timer(this.components);
            this.title_main = new System.Windows.Forms.Label();
            this.eew_form_timer = new System.Windows.Forms.Timer(this.components);
            this.telop_panel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // telop_panel
            // 
            this.telop_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.telop_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.telop_panel.ContextMenuStrip = this.contextMenuStrip1;
            this.telop_panel.Controls.Add(this.category_sub_label);
            this.telop_panel.Controls.Add(this.telop_text);
            this.telop_panel.Location = new System.Drawing.Point(0, 34);
            this.telop_panel.Name = "telop_panel";
            this.telop_panel.Size = new System.Drawing.Size(1282, 37);
            this.telop_panel.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.設定ToolStripMenuItem.Text = "設定";
            this.設定ToolStripMenuItem.Click += new System.EventHandler(this.設定ToolStripMenuItem_Click);
            // 
            // category_sub_label
            // 
            this.category_sub_label.AutoSize = true;
            this.category_sub_label.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.category_sub_label.Location = new System.Drawing.Point(-2, 2);
            this.category_sub_label.Name = "category_sub_label";
            this.category_sub_label.Size = new System.Drawing.Size(216, 29);
            this.category_sub_label.TabIndex = 1;
            this.category_sub_label.Text = "テロップサブカテ";
            // 
            // telop_text
            // 
            this.telop_text.AutoSize = true;
            this.telop_text.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.telop_text.Location = new System.Drawing.Point(210, 3);
            this.telop_text.Name = "telop_text";
            this.telop_text.Size = new System.Drawing.Size(210, 29);
            this.telop_text.TabIndex = 0;
            this.telop_text.Text = "テロップテキスト";
            // 
            // telop_scroll
            // 
            this.telop_scroll.Tick += new System.EventHandler(this.telop_scroll_Tick);
            // 
            // telop_category
            // 
            this.telop_category.AutoSize = true;
            this.telop_category.BackColor = System.Drawing.Color.Transparent;
            this.telop_category.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.telop_category.Location = new System.Drawing.Point(12, 4);
            this.telop_category.Name = "telop_category";
            this.telop_category.Size = new System.Drawing.Size(237, 29);
            this.telop_category.TabIndex = 1;
            this.telop_category.Text = "テロップカテゴリー";
            // 
            // telop_timer
            // 
            this.telop_timer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.telop_timer.AutoSize = true;
            this.telop_timer.BackColor = System.Drawing.Color.Transparent;
            this.telop_timer.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.telop_timer.Location = new System.Drawing.Point(1007, 4);
            this.telop_timer.Name = "telop_timer";
            this.telop_timer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.telop_timer.Size = new System.Drawing.Size(211, 29);
            this.telop_timer.TabIndex = 2;
            this.telop_timer.Text = "テロップタイマー";
            // 
            // clock
            // 
            this.clock.Tick += new System.EventHandler(this.clock_Tick);
            // 
            // clock_level_kirikae
            // 
            this.clock_level_kirikae.Tick += new System.EventHandler(this.clock_level_kirikae_Tick);
            // 
            // eew_checktimer
            // 
            this.eew_checktimer.Tick += new System.EventHandler(this.eew_checktimer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(807, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "テストボタン（ベータモード以外非表示）";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notify
            // 
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "LiveTelop";
            this.notify.Visible = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(0, 76);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // title_timer
            // 
            this.title_timer.Interval = 1;
            this.title_timer.Tick += new System.EventHandler(this.title_timer_Tick);
            // 
            // title_main
            // 
            this.title_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title_main.AutoSize = true;
            this.title_main.BackColor = System.Drawing.Color.Transparent;
            this.title_main.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.title_main.Location = new System.Drawing.Point(511, 20);
            this.title_main.Name = "title_main";
            this.title_main.Size = new System.Drawing.Size(177, 29);
            this.title_main.TabIndex = 5;
            this.title_main.Text = "タイトルメイン";
            // 
            // eew_form_timer
            // 
            this.eew_form_timer.Tick += new System.EventHandler(this.eew_form_timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1266, 75);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.title_main);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.telop_timer);
            this.Controls.Add(this.telop_panel);
            this.Controls.Add(this.telop_category);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(16, 114);
            this.Name = "Form1";
            this.Text = "LiveTelop Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.telop_panel.ResumeLayout(false);
            this.telop_panel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel telop_panel;
        private System.Windows.Forms.Label telop_text;
        private System.Windows.Forms.Timer telop_scroll;
        private System.Windows.Forms.Label telop_category;
        private System.Windows.Forms.Label telop_timer;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.Timer clock_level_kirikae;
        private System.Windows.Forms.Timer eew_checktimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.Label category_sub_label;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer title_timer;
        private System.Windows.Forms.Label title_main;
        public System.Windows.Forms.Timer eew_form_timer;
    }
}

