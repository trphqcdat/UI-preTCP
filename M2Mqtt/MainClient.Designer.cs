
namespace MQTTHandler
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_conn = new System.Windows.Forms.Button();
            this.button_send = new System.Windows.Forms.Button();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_choose = new System.Windows.Forms.Button();
            this.button_unlock = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.button_auto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.ListBox2 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ListBox3 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ListBox4 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ListBox5 = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_loop = new System.Windows.Forms.Button();
            this.button_req = new System.Windows.Forms.Button();
            this.button_raw = new System.Windows.Forms.Button();
            this.button_set = new System.Windows.Forms.Button();
            this.button_data = new System.Windows.Forms.Button();
            this.rawtext = new System.Windows.Forms.TextBox();
            this.button_show = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.ListBox6 = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button_reverse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_conn
            // 
            this.button_conn.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_conn.Location = new System.Drawing.Point(12, 197);
            this.button_conn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_conn.Name = "button_conn";
            this.button_conn.Size = new System.Drawing.Size(333, 46);
            this.button_conn.TabIndex = 0;
            this.button_conn.Text = "Connect to Server";
            this.button_conn.UseVisualStyleBackColor = true;
            this.button_conn.Click += new System.EventHandler(this.button_conn_Click);
            // 
            // button_send
            // 
            this.button_send.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_send.Location = new System.Drawing.Point(11, 449);
            this.button_send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(335, 46);
            this.button_send.TabIndex = 1;
            this.button_send.Text = "Send Waypoints";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // ListBox1
            // 
            this.ListBox1.AllowDrop = true;
            this.ListBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox1.Font = new System.Drawing.Font("Montserrat", 6F);
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.HorizontalScrollbar = true;
            this.ListBox1.ItemHeight = 14;
            this.ListBox1.Location = new System.Drawing.Point(683, 518);
            this.ListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(417, 170);
            this.ListBox1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 12F);
            this.label5.Location = new System.Drawing.Point(912, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 27);
            this.label5.TabIndex = 12;
            this.label5.Text = "Activities Status";
            // 
            // button_choose
            // 
            this.button_choose.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_choose.Location = new System.Drawing.Point(11, 298);
            this.button_choose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_choose.Name = "button_choose";
            this.button_choose.Size = new System.Drawing.Size(335, 46);
            this.button_choose.TabIndex = 23;
            this.button_choose.Text = "Choose Waypoint Mode";
            this.button_choose.UseVisualStyleBackColor = true;
            this.button_choose.Click += new System.EventHandler(this.button_choose_Click);
            // 
            // button_unlock
            // 
            this.button_unlock.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_unlock.Location = new System.Drawing.Point(11, 500);
            this.button_unlock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_unlock.Name = "button_unlock";
            this.button_unlock.Size = new System.Drawing.Size(167, 46);
            this.button_unlock.TabIndex = 24;
            this.button_unlock.Text = "Unlock Load";
            this.button_unlock.UseVisualStyleBackColor = true;
            this.button_unlock.Click += new System.EventHandler(this.button_unlock_Click);
            // 
            // button_del
            // 
            this.button_del.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_del.Location = new System.Drawing.Point(179, 500);
            this.button_del.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(165, 46);
            this.button_del.TabIndex = 25;
            this.button_del.Text = "Delete / Refresh";
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // button_auto
            // 
            this.button_auto.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_auto.Location = new System.Drawing.Point(11, 247);
            this.button_auto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_auto.Name = "button_auto";
            this.button_auto.Size = new System.Drawing.Size(335, 46);
            this.button_auto.TabIndex = 26;
            this.button_auto.Text = "Start Auto mode";
            this.button_auto.UseVisualStyleBackColor = true;
            this.button_auto.Click += new System.EventHandler(this.button_auto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(28, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 24);
            this.label2.TabIndex = 29;
            this.label2.Text = "HCMC University of Technology";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label3.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(89, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 24);
            this.label3.TabIndex = 30;
            this.label3.Text = "Graduation Thesis";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::uPLibrary.Networking.M2Mqtt.Properties.Resources.HCMCUT_svg;
            this.pictureBox1.Location = new System.Drawing.Point(139, 57);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.GrayScaleMode = false;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(371, 14);
            this.gmap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 20;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(728, 466);
            this.gmap.TabIndex = 32;
            this.gmap.Zoom = 19D;
            this.gmap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 27);
            this.label1.TabIndex = 33;
            this.label1.Text = "Controlling Board";
            // 
            // ListBox2
            // 
            this.ListBox2.AllowDrop = true;
            this.ListBox2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox2.Font = new System.Drawing.Font("Montserrat", 8F);
            this.ListBox2.FormattingEnabled = true;
            this.ListBox2.ItemHeight = 18;
            this.ListBox2.Location = new System.Drawing.Point(571, 575);
            this.ListBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox2.Name = "ListBox2";
            this.ListBox2.Size = new System.Drawing.Size(86, 20);
            this.ListBox2.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 8F);
            this.label4.Location = new System.Drawing.Point(421, 575);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Waypoint reached:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 8F);
            this.label6.Location = new System.Drawing.Point(403, 604);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Upcoming waypoint:";
            // 
            // ListBox3
            // 
            this.ListBox3.AllowDrop = true;
            this.ListBox3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ListBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox3.Font = new System.Drawing.Font("Montserrat", 8F);
            this.ListBox3.FormattingEnabled = true;
            this.ListBox3.ItemHeight = 18;
            this.ListBox3.Location = new System.Drawing.Point(571, 603);
            this.ListBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox3.Name = "ListBox3";
            this.ListBox3.Size = new System.Drawing.Size(86, 20);
            this.ListBox3.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 8F);
            this.label7.Location = new System.Drawing.Point(439, 546);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Vehicle velocity:";
            // 
            // ListBox4
            // 
            this.ListBox4.AllowDrop = true;
            this.ListBox4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ListBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox4.Font = new System.Drawing.Font("Montserrat", 8F);
            this.ListBox4.FormattingEnabled = true;
            this.ListBox4.ItemHeight = 18;
            this.ListBox4.Location = new System.Drawing.Point(571, 546);
            this.ListBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox4.Name = "ListBox4";
            this.ListBox4.Size = new System.Drawing.Size(86, 20);
            this.ListBox4.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 8F);
            this.label8.Location = new System.Drawing.Point(385, 519);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Heading (N-clockwise):";
            // 
            // ListBox5
            // 
            this.ListBox5.AllowDrop = true;
            this.ListBox5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ListBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox5.Font = new System.Drawing.Font("Montserrat", 8F);
            this.ListBox5.FormattingEnabled = true;
            this.ListBox5.ItemHeight = 18;
            this.ListBox5.Location = new System.Drawing.Point(571, 518);
            this.ListBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox5.Name = "ListBox5";
            this.ListBox5.Size = new System.Drawing.Size(86, 20);
            this.ListBox5.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 12F);
            this.label9.Location = new System.Drawing.Point(524, 487);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 27);
            this.label9.TabIndex = 42;
            this.label9.Text = "Cart Status";
            // 
            // button_loop
            // 
            this.button_loop.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_loop.Location = new System.Drawing.Point(12, 399);
            this.button_loop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_loop.Name = "button_loop";
            this.button_loop.Size = new System.Drawing.Size(110, 46);
            this.button_loop.TabIndex = 43;
            this.button_loop.Text = "Loop";
            this.button_loop.UseVisualStyleBackColor = true;
            this.button_loop.Click += new System.EventHandler(this.button_loop_Click);
            // 
            // button_req
            // 
            this.button_req.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_req.Location = new System.Drawing.Point(11, 348);
            this.button_req.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_req.Name = "button_req";
            this.button_req.Size = new System.Drawing.Size(167, 46);
            this.button_req.TabIndex = 44;
            this.button_req.Text = "Request Position";
            this.button_req.UseVisualStyleBackColor = true;
            this.button_req.Click += new System.EventHandler(this.button_req_Click);
            // 
            // button_raw
            // 
            this.button_raw.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_raw.Location = new System.Drawing.Point(11, 601);
            this.button_raw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_raw.Name = "button_raw";
            this.button_raw.Size = new System.Drawing.Size(335, 46);
            this.button_raw.TabIndex = 45;
            this.button_raw.Text = "Raw Data Transmission";
            this.button_raw.UseVisualStyleBackColor = true;
            this.button_raw.Click += new System.EventHandler(this.button_raw_Click);
            // 
            // button_set
            // 
            this.button_set.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_set.Location = new System.Drawing.Point(180, 348);
            this.button_set.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_set.Name = "button_set";
            this.button_set.Size = new System.Drawing.Size(165, 46);
            this.button_set.TabIndex = 47;
            this.button_set.Text = "Set as Waypoint";
            this.button_set.UseVisualStyleBackColor = true;
            this.button_set.Click += new System.EventHandler(this.button_set_Click);
            // 
            // button_data
            // 
            this.button_data.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_data.Location = new System.Drawing.Point(235, 399);
            this.button_data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_data.Name = "button_data";
            this.button_data.Size = new System.Drawing.Size(110, 46);
            this.button_data.TabIndex = 49;
            this.button_data.Text = "Data";
            this.button_data.UseVisualStyleBackColor = true;
            this.button_data.Click += new System.EventHandler(this.button_data_Click);
            // 
            // rawtext
            // 
            this.rawtext.Font = new System.Drawing.Font("Courier New", 19F);
            this.rawtext.Location = new System.Drawing.Point(12, 651);
            this.rawtext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rawtext.Name = "rawtext";
            this.rawtext.Size = new System.Drawing.Size(331, 43);
            this.rawtext.TabIndex = 50;
            // 
            // button_show
            // 
            this.button_show.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_show.Location = new System.Drawing.Point(11, 550);
            this.button_show.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(335, 46);
            this.button_show.TabIndex = 52;
            this.button_show.Text = "Show Messages Received";
            this.button_show.UseVisualStyleBackColor = true;
            this.button_show.Click += new System.EventHandler(this.button_show_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat", 12F);
            this.label10.Location = new System.Drawing.Point(439, 646);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(198, 27);
            this.label10.TabIndex = 53;
            this.label10.Text = "Connection Status";
            // 
            // ListBox6
            // 
            this.ListBox6.AllowDrop = true;
            this.ListBox6.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ListBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox6.Font = new System.Drawing.Font("Montserrat", 8F);
            this.ListBox6.FormattingEnabled = true;
            this.ListBox6.ItemHeight = 18;
            this.ListBox6.Location = new System.Drawing.Point(571, 677);
            this.ListBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox6.Name = "ListBox6";
            this.ListBox6.Size = new System.Drawing.Size(86, 20);
            this.ListBox6.TabIndex = 54;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Montserrat", 8F);
            this.label11.Location = new System.Drawing.Point(448, 679);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 20);
            this.label11.TabIndex = 55;
            this.label11.Text = "Connecting to:";
            // 
            // button_reverse
            // 
            this.button_reverse.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button_reverse.Location = new System.Drawing.Point(126, 399);
            this.button_reverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_reverse.Name = "button_reverse";
            this.button_reverse.Size = new System.Drawing.Size(105, 46);
            this.button_reverse.TabIndex = 56;
            this.button_reverse.Text = "Reverse";
            this.button_reverse.UseVisualStyleBackColor = true;
            this.button_reverse.Click += new System.EventHandler(this.button_reverse_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1112, 727);
            this.Controls.Add(this.button_reverse);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ListBox6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_show);
            this.Controls.Add(this.rawtext);
            this.Controls.Add(this.button_data);
            this.Controls.Add(this.button_set);
            this.Controls.Add(this.button_raw);
            this.Controls.Add(this.button_req);
            this.Controls.Add(this.button_loop);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ListBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ListBox4);
            this.Controls.Add(this.ListBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ListBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gmap);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_auto);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.button_unlock);
            this.Controls.Add(this.button_choose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.button_conn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Cart Management UI";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_conn;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_choose;
        private System.Windows.Forms.Button button_unlock;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Button button_auto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ListBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox ListBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox ListBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox ListBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_loop;
        private System.Windows.Forms.Button button_req;
        private System.Windows.Forms.Button button_raw;
        private System.Windows.Forms.Button button_set;
        private System.Windows.Forms.Button button_data;
        private System.Windows.Forms.TextBox rawtext;
        private System.Windows.Forms.Button button_show;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox ListBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button_reverse;
    }
}