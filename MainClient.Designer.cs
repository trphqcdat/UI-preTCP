
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
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.Button1.Location = new System.Drawing.Point(16, 334);
            this.Button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(165, 46);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Connect";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.Button2.Location = new System.Drawing.Point(16, 484);
            this.Button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(333, 46);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "Send Waypoints Data";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.Button3.Location = new System.Drawing.Point(184, 334);
            this.Button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(165, 46);
            this.Button3.TabIndex = 2;
            this.Button3.Text = "Disconnect";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
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
            this.ListBox1.Location = new System.Drawing.Point(371, 372);
            this.ListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(386, 198);
            this.ListBox1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 12F);
            this.label5.Location = new System.Drawing.Point(475, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 27);
            this.label5.TabIndex = 12;
            this.label5.Text = "Activities Status";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(16, 434);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(333, 46);
            this.button4.TabIndex = 23;
            this.button4.Text = "Choose Waypoint Mode";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button5.Location = new System.Drawing.Point(16, 534);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 46);
            this.button5.TabIndex = 24;
            this.button5.Text = "Unlock Container";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button6.Location = new System.Drawing.Point(184, 534);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(165, 46);
            this.button6.TabIndex = 25;
            this.button6.Text = "Delete / Refresh";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button7.Location = new System.Drawing.Point(16, 384);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(165, 46);
            this.button7.TabIndex = 26;
            this.button7.Text = "Start Auto mode";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold);
            this.button8.Location = new System.Drawing.Point(184, 384);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(165, 46);
            this.button8.TabIndex = 27;
            this.button8.Text = "Stop Auto mode";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
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
            this.pictureBox1.Location = new System.Drawing.Point(144, 57);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 62);
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
            this.gmap.Size = new System.Drawing.Size(387, 319);
            this.gmap.TabIndex = 32;
            this.gmap.Zoom = 19D;
            this.gmap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 305);
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
            this.ListBox2.HorizontalScrollbar = true;
            this.ListBox2.ItemHeight = 18;
            this.ListBox2.Location = new System.Drawing.Point(261, 244);
            this.ListBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox2.Name = "ListBox2";
            this.ListBox2.Size = new System.Drawing.Size(86, 20);
            this.ListBox2.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 8F);
            this.label4.Location = new System.Drawing.Point(113, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Waypoint reached:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 8F);
            this.label6.Location = new System.Drawing.Point(165, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Upcoming:";
            // 
            // ListBox3
            // 
            this.ListBox3.AllowDrop = true;
            this.ListBox3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ListBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox3.Font = new System.Drawing.Font("Montserrat", 8F);
            this.ListBox3.FormattingEnabled = true;
            this.ListBox3.HorizontalScrollbar = true;
            this.ListBox3.ItemHeight = 18;
            this.ListBox3.Location = new System.Drawing.Point(261, 273);
            this.ListBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox3.Name = "ListBox3";
            this.ListBox3.Size = new System.Drawing.Size(86, 20);
            this.ListBox3.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 8F);
            this.label7.Location = new System.Drawing.Point(131, 214);
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
            this.ListBox4.HorizontalScrollbar = true;
            this.ListBox4.ItemHeight = 18;
            this.ListBox4.Location = new System.Drawing.Point(261, 214);
            this.ListBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox4.Name = "ListBox4";
            this.ListBox4.Size = new System.Drawing.Size(86, 20);
            this.ListBox4.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 8F);
            this.label8.Location = new System.Drawing.Point(77, 185);
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
            this.ListBox5.HorizontalScrollbar = true;
            this.ListBox5.ItemHeight = 18;
            this.ListBox5.Location = new System.Drawing.Point(261, 185);
            this.ListBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox5.Name = "ListBox5";
            this.ListBox5.Size = new System.Drawing.Size(86, 20);
            this.ListBox5.TabIndex = 40;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(775, 590);
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
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainClient";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button3;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
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
    }
}