using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.IO;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.Net.NetworkInformation;

namespace MQTTHandler
{
    public partial class MainForm : Form
    {
        delegate void SetTextCallback(string text);
        bool waystart = true;
        bool choose = false;
        bool conn = false;
        bool auto = false;

        MqttClient client = new MqttClient("broker.hivemq.com", 1883, false, null, null, MqttSslProtocols.None);
        public MainForm()
        {
            InitializeComponent();
            client.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(EventPublished);
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new GMap.NET.PointLatLng(10.77288991610691, 106.65989487779234);
        }

        double lon1;
        double lon2;
        double lat1;
        double lat2;
        private void Tracking()
        {
            List<PointLatLng> trackpoints = new List<PointLatLng>();
            GMapOverlay trackroutes = new GMapOverlay(gmap, "trackroutes");
            trackpoints.Add(new PointLatLng(lat1, lon1));
            trackpoints.Add(new PointLatLng(lat2, lon2));
            GMapRoute route = new GMapRoute(trackpoints, "Tracking");
            route.Stroke = new Pen(Color.Red, 1);
            trackroutes.Routes.Add(route);
            gmap.Overlays.Add(trackroutes);
            lat1 = lat2;
            lon1 = lon2;
        }
        private void Marking()
        {
            GMapOverlay markers = new GMapOverlay(gmap, "markers");
            GMapMarker marker = new GMapMarkerGoogleRed(new PointLatLng(waylat[waynum], waylon[waynum]));
            marker.ToolTipText = "WP" + waynum;
            marker.ToolTip.Fill = Brushes.Black;
            marker.ToolTip.Foreground = Brushes.White;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new Size(5, 5);
            markers.Markers.Add(marker);
            gmap.Overlays.Add(markers);
        }

        int arrive = 0;
        int wayarr = 0;
        int waynext = 0;
        double speed = 0;
        double angle = 0;
        private void Updating()
        {
            GMapOverlay markers = new GMapOverlay(gmap, "markers");
            GMapMarker marker = new GMapMarkerGoogleGreen(new PointLatLng(waylat[wayarr], waylon[wayarr]));
            markers.Markers.Add(marker);
            gmap.Overlays.Add(markers);
            SetText2(Convert.ToString(wayarr));
            if(waynext == 0)
            {
                SetText3("Finish");
            }
            else
            {
                SetText3(Convert.ToString(waynext));
            }
        }

        double[] waylon = new double[11];
        double[] waylat = new double[11];
        int waynum = 1;
        private void Drawing()
        {
            List<PointLatLng> drawpoints = new List<PointLatLng>();
            GMapOverlay drawroutes = new GMapOverlay(gmap, "drawroutes");
            drawpoints.Add(new PointLatLng(waylat[waynum - 2], waylon[waynum - 2]));
            drawpoints.Add(new PointLatLng(waylat[waynum - 1], waylon[waynum - 1]));
            GMapRoute route = new GMapRoute(drawpoints, "Drawing");
            route.Stroke = new Pen(Color.Green, 1);
            drawroutes.Routes.Add(route);
            gmap.Overlays.Add(drawroutes);
        }

        private void Deleting()
        {
            while(gmap.Overlays.Count > 0)
            {
                gmap.Overlays.RemoveAt(0);
            }
            gmap.Refresh();
            ListBox2.Items.Clear();
            ListBox3.Items.Clear();
            ListBox4.Items.Clear();
            ListBox5.Items.Clear();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (InvalidCastException ex)
            {
            }
        }

        private void SetText1(string text)
        {
            if (this.ListBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText1);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.ListBox1.Items.Add(text);
                int visibleItems = ListBox1.ClientSize.Height / ListBox1.ItemHeight;
                ListBox1.TopIndex = ListBox1.Items.Count - 1;
            }
        }

        private void SetText2(string text)
        {
            if (this.ListBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText2);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.ListBox2.Items.Add(text);
                int visibleItems = ListBox2.ClientSize.Height / ListBox2.ItemHeight;
                ListBox2.TopIndex = ListBox2.Items.Count - 1;
            }
        }

        private void SetText3(string text)
        {
            if (this.ListBox3.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText3);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.ListBox3.Items.Add(text);
                int visibleItems = ListBox3.ClientSize.Height / ListBox3.ItemHeight;
                ListBox3.TopIndex = ListBox3.Items.Count - 1;
            }
        }

        private void SetText4(string text)
        {
            if (this.ListBox4.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText4);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.ListBox4.Items.Add(text);
                int visibleItems = ListBox4.ClientSize.Height / ListBox4.ItemHeight;
                ListBox4.TopIndex = ListBox4.Items.Count - 1;
            }
        }
        private void SetText5(string text)
        {
            if (this.ListBox5.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText5);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.ListBox5.Items.Add(text);
                int visibleItems = ListBox5.ClientSize.Height / ListBox5.ItemHeight;
                ListBox5.TopIndex = ListBox5.Items.Count - 1;
            }
        }

        private void EventPublished(Object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            try
            {
                string payload = System.Text.UTF8Encoding.UTF8.GetString(e.Message);
                char[] charSeparators = new char[] { ',' };
                string[] message = payload.Split(charSeparators, StringSplitOptions.None);
                if (waystart == true)
                {
                    lon1 = Convert.ToDouble(message[0]);
                    lat1 = Convert.ToDouble(message[1]);
                    arrive = Convert.ToInt16(message[2]);
                    wayarr = Convert.ToInt16(message[3]);
                    waynext = Convert.ToInt16(message[4]);
                    speed = Convert.ToDouble(message[5]);
                    angle = Convert.ToDouble(message[6]);
                    SetText1("Received - topic: " + e.Topic + ". Current position:");
                    SetText1("Longitude: " + lon1 + ", Latitude: " + lat1);
                    SetText1("");
                    SetText4(Convert.ToString(speed) + " m/s");
                    SetText5(Convert.ToString(angle) + " *");
                    waystart = false;
                }
                else
                {
                    lon2 = Convert.ToDouble(message[0]);
                    lat2 = Convert.ToDouble(message[1]);
                    arrive = Convert.ToInt16(message[2]);
                    wayarr = Convert.ToInt16(message[3]);
                    waynext = Convert.ToInt16(message[4]);
                    speed = Convert.ToDouble(message[5]);
                    angle = Convert.ToDouble(message[6]);
                    SetText1("Received - topic: " + e.Topic + ". Current position:");
                    SetText1("Longitude: " + lon2 + ", Latitude: " + lat2);
                    SetText1("");
                    SetText4(Convert.ToString(speed) + " m/s");
                    SetText5(Convert.ToString(angle) + " *");
                    if (arrive == 1)
                    {
                        Updating();
                    }
                    if (wayarr == waynum)
                    {
                        client.Publish("control/auto", Encoding.UTF8.GetBytes("stop"));
                        ListBox1.Items.Add("Vehicle arrived to the final waypoint.");
                        ListBox1.Items.Add(">> Stopping the auto mode");
                        SetText1("");
                        auto = false;
                    }
                    Tracking();
                }
            }
            catch (InvalidCastException ex)
            {
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(conn == false)
                {
                    client.Connect("manager_sub");
                    ListBox1.Items.Add("Client connected.");
                    client.Subscribe(new string[] { "data/position" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                    ListBox1.Items.Add(">> Subscribing to: data/position");
                    ListBox1.Items.Add(">> Publishing to: control/auto & control/manual");
                    SetText1("");
                    conn = true;
                }
                else
                {
                    ListBox1.Items.Add("Client already connected.");
                    ListBox1.Items.Add(">> Press 'Disconnect' to disconnect client from MQTT");
                    SetText1("");
                }
            }
            catch (InvalidCastException ex)
            {
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == true)
                {
                    client.Disconnect();
                    ListBox1.Items.Add("Client disconnected.");
                    ListBox1.Items.Add(">> Unsubscribing from: data/position");
                    ListBox1.Items.Add(">> Stop publishing to: control/auto & control/manual");
                    SetText1("");
                    conn = false;
                }
                else
                {
                    ListBox1.Items.Add("Client already disconnected.");
                    ListBox1.Items.Add(">> Press 'Connect' to connect client to MQTT");
                    SetText1("");
                }
            }
            catch (InvalidCastException ex)
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(conn == true)
            {
                if (auto == false)
                {
                    client.Publish("control/auto", Encoding.UTF8.GetBytes("start"));
                    ListBox1.Items.Add("Publishing on: control/auto");
                    ListBox1.Items.Add(">> Starting the auto mode");
                    SetText1("");
                    auto = true;
                }
                else
                {
                    ListBox1.Items.Add("Auto mode already established.");
                    ListBox1.Items.Add(">> Press 'Stop Auto mode' to seize vehicle Auto mode");
                    SetText1("");
                }
            }
            else
            {
                ListBox1.Items.Add("Client is disconnected.");
                ListBox1.Items.Add(">> Press 'Connect' to connect client to MQTT first");
                SetText1("");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(conn == true)
            {
                if (auto == true)
                {
                    client.Publish("control/auto", Encoding.UTF8.GetBytes("stop"));
                    ListBox1.Items.Add("Publishing on: control/auto");
                    ListBox1.Items.Add(">> Stopping the auto mode");
                    SetText1("");
                    auto = false;
                }
                else
                {
                    ListBox1.Items.Add("Auto mode already seized.");
                    ListBox1.Items.Add(">> Press 'Start Auto mode' to reestablish vehicle Auto mode");
                    SetText1("");
                }
            }
            else
            {
                ListBox1.Items.Add("Client is disconnected.");
                ListBox1.Items.Add(">> Press 'Connect' to connect client to MQTT first");
                SetText1("");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(choose == false)
            {
                ListBox1.Items.Add("Start choosing waypoints...");
                ListBox1.Items.Add(">> Left-click on the map to choose");
                ListBox1.Items.Add(">> Press 'Send Waypoints Data' to confirm");
                SetText1("");
                choose = true;
            }
            else
            {
                ListBox1.Items.Add("Ready to choose waypoints on map.");
                ListBox1.Items.Add(">> Left-click on the map to choose");
                ListBox1.Items.Add(">> Press 'Send Waypoints Data' to confirm");
                SetText1("");
            }
        }
        private void gmap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && choose == true)
            {
                if (waynum <= 10)
                {
                    var point = gmap.FromLocalToLatLng(e.X, e.Y);
                    waylat[waynum] = point.Lat;
                    waylon[waynum] = point.Lng;
                    SetText1("Chosen waypoint " + waynum + ":");
                    SetText1(">> Longitude: " + waylon[waynum]);
                    SetText1(">> Latitude: " + waylat[waynum]);
                    SetText1("");
                    Marking();
                    waynum++;
                    if (waynum >= 3)
                    {
                        Drawing();
                    }
                }
                else
                {
                    SetText1("Maximum waypoints reached!");
                    SetText1(">> Press 'Send Waypoints Data' to confirm");
                    SetText1("");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(conn == true)
            {
                if (choose == true)
                {
                    int k = 1;
                    ListBox1.Items.Add("Sending chosen waypoints...");
                    while (k < waynum)
                    {
                        client.Publish("control/auto", Encoding.UTF8.GetBytes(waylon[k] + "," + waylat[k]));
                        SetText1(">> Waypoint" + k + ": Sent.");
                        k++;
                    }
                    SetText1("");
                    choose = false;
                }
                else
                {
                    ListBox1.Items.Add("No waypoints chosen!");
                    ListBox1.Items.Add(">> Press 'Choose Waypoint Mode' to create waypoints/route");
                    SetText1("");
                }
            }
            else
            {
                ListBox1.Items.Add("Client is disconnected.");
                ListBox1.Items.Add(">> Press 'Connect' to connect client to MQTT first");
                SetText1("");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(conn == true)
            {
                ListBox1.Items.Add("Delivery completed!");
                SetText1(">> Opening the container...");
                SetText1("");
            }    
            else
            {
                ListBox1.Items.Add("Client is disconnected.");
                ListBox1.Items.Add(">> Press 'Connect' to connect client to MQTT first");
                SetText1("");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add("Deleting selected waypoints & tracked route...");
            SetText1(">> Press 'Choose Waypoint Mode' to create new route");
            SetText1("");
            waylon = new double[11];
            waylat = new double[11];
            waynum = 1;
            waystart = true;
            Deleting();
        }
    }
}