using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.IO;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.Net.NetworkInformation;
using System.Threading;
using GraphicsToolkit.Networking;


namespace MQTTHandler
{
    public partial class MainForm : Form
    {
        delegate void SetTextCallback(string text);

        string path = @"E:\New folder\BK\HK221\Luan_van_tot_nghiep\Temporary\data\test2.txt";

        bool conn_MQTT = false;
        bool waystart = true;
        bool choose = false;
        bool auto = false;
        bool request = false;
        bool show = false;

        string sender;
        double lon1;
        double lon2;
        double lonreq;
        double lat1;
        double lat2;
        double latreq;

        int arrive = 0;
        int wayarr = 0;
        int waynext = 0;
        double speed = 0;
        double angle = 0;

        double[] waylon = new double[11];
        double[] waylat = new double[11];
        int waynum = 1;
        readonly MqttClient client = new MqttClient("broker.hivemq.com", 1883, false, null, null, MqttSslProtocols.None);
        readonly Client TCPclient = new Client();
        //TextWriter tw = new StreamWriter(@"E:\New folder\BK\HK221\Luan_van_tot_nghiep\Temporary\data\test2.txt", true);

        public MainForm()
        {
            InitializeComponent();
            //TCPclient.OnDataReceived += new ClientHandlePacketData(client_OnDataReceived);
            client.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(EventPublished);
            gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new GMap.NET.PointLatLng(10.77288991610691, 106.65989487779234);
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
        private void SetText6(string text)
        {
            if (this.ListBox6.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText6);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.ListBox6.Items.Add(text);
                int visibleItems = ListBox6.ClientSize.Height / ListBox6.ItemHeight;
                ListBox6.TopIndex = ListBox6.Items.Count - 1;
            }
        }

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

        private void Updating()
        {
            GMapOverlay markers = new GMapOverlay(gmap, "markers");
            GMapMarker marker = new GMapMarkerGoogleGreen(new PointLatLng(waylat[wayarr], waylon[wayarr]));
            markers.Markers.Add(marker);
            gmap.Overlays.Add(markers);
            SetText2(Convert.ToString(wayarr));
            if (waynext == 0)
            {
                SetText3("Finish");
            }
            else
            {
                SetText3(Convert.ToString(waynext));
            }
        }

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
            while (gmap.Overlays.Count > 0)
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

        private void EventPublished(Object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            try
            {
                string payload = System.Text.UTF8Encoding.UTF8.GetString(e.Message);
                char[] charSeparators = new char[] { ',' };
                string[] message = payload.Split(charSeparators, StringSplitOptions.None);
                if (request == true)
                {
                    lonreq = Convert.ToDouble(message[0]);
                    latreq = Convert.ToDouble(message[1]);
                    SetText1("Received current cart position:");
                    SetText1("Longitude: " + lonreq + ", Latitude: " + latreq);
                    SetText1(">> Press 'Set as Waypoint' to set this as a waypoint");
                    SetText1("");
                    request = false;
                }
                else if (waystart == true)
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
                        //tw.WriteLine("REACHED WAYPOINT");
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
                    //File.WriteAllText(path, lat2.ToString() + "," + lon2.ToString() + Environment.NewLine);
                    //tw.WriteLine(lat2.ToString() + "," + lon2.ToString());
                    Tracking();
                }
            }
            catch (InvalidCastException ex)
            {
            }
        }
       
        private void client_OnDataReceived(byte[] data, int bytesRead)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            string payload = encoder.GetString(data, 0, bytesRead);
            char[] charSeparators = new char[] { ',' };
            string[] message = payload.Split(charSeparators, StringSplitOptions.None);
            sender = Convert.ToString(message[0]);
            if (sender != "c") return;
            if (request == true)
            {
                lonreq = Convert.ToDouble(message[1]);
                latreq = Convert.ToDouble(message[2]);
                SetText1("Received current cart position:");
                SetText1("Longitude: " + lonreq + ", Latitude: " + latreq);
                SetText1(">> Press 'Set as Waypoint' to set this as a waypoint");
                SetText1("");
                request = false;
            }
            if (waystart == true)
            {
                lon1 = Convert.ToDouble(message[1]);
                lat1 = Convert.ToDouble(message[2]);
                arrive = Convert.ToInt16(message[3]);
                wayarr = Convert.ToInt16(message[4]);
                waynext = Convert.ToInt16(message[5]);
                speed = Convert.ToDouble(message[6]);
                angle = Convert.ToDouble(message[7]);
                SetText1("Current position:");
                SetText1("Longitude: " + lon1 + ", Latitude: " + lat1);
                SetText1("");
                SetText4(Convert.ToString(speed) + " m/s");
                SetText5(Convert.ToString(angle) + " *");
                waystart = false;
            }
            else
            {
                lon2 = Convert.ToDouble(message[1]);
                lat2 = Convert.ToDouble(message[2]);
                arrive = Convert.ToInt16(message[3]);
                wayarr = Convert.ToInt16(message[4]);
                waynext = Convert.ToInt16(message[5]);
                speed = Convert.ToDouble(message[6]);
                angle = Convert.ToDouble(message[7]);
                SetText1("Current position:");
                SetText1("Longitude: " + lon2 + ", Latitude: " + lat2);
                SetText1("");
                SetText4(Convert.ToString(speed) + " m/s");
                SetText5(Convert.ToString(angle) + " *");
                if (arrive == 1)
                {
                    Updating();
                    //tw.WriteLine("REACHED WAYPOINT");
                }
                if (wayarr == waynum-1)
                {
                    client.Publish("control/auto", Encoding.UTF8.GetBytes("stop"));
                    this.Invoke(new MethodInvoker(delegate () 
                    { ListBox1.Items.Add("Vehicle arrived to the final waypoint.");
                      ListBox1.Items.Add(">> Stopping the auto mode");
                      SetText1("");
                    }));
                }
                //File.WriteAllText(path, lat2.ToString() + "," + lon2.ToString() + Environment.NewLine);
                //tw.WriteLine(lat2.ToString() + "," + lon2.ToString());
                Tracking();
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

        private void button_conn_Click(object sender, EventArgs e)
        {
            if (Client.conn_TCP == false && conn_MQTT == false)
            {
               //TCPclient.OnDataReceived += new ClientHandlePacketData(client_OnDataReceived);
                //TCPclient.ConnectToServer("139.162.36.251", 5050);
                if (Client.conn_TCP == true)
                {
                    ListBox1.Items.Add("Client connected to TCP server.");
                    button_conn.Text = "Disconnect from TCP server";
                    SetText6("TCP");
                    //ASCIIEncoding encoder = new ASCIIEncoding();
                    //string s = "ui_conn";
                    //TCPclient.SendImmediate(encoder.GetBytes(s));
                }
                else
                {
                    ListBox1.Items.Add("Client unable to connect to TCP server, proceed to use MQTT...");
                    client.Connect("manager_sub");
                    button_conn.Text = "Disconnect from MQTT server";
                    ListBox1.Items.Add("MQTT client connected.");
                    client.Subscribe(new string[] { "data/position" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
                    ListBox1.Items.Add(">> Subscribing to: data/position");
                    ListBox1.Items.Add(">> Publishing to: control/auto & control/manual");
                    SetText1("");
                    SetText6("MQTT");
                    conn_MQTT = true;
                }
            }
            else if (Client.conn_TCP == true)
            {
                ListBox1.Items.Add("Client disconnected from TCP server.");
                SetText1("");
                ASCIIEncoding encoder = new ASCIIEncoding();
                string s = "!Disconnect_3147";
                TCPclient.SendImmediate(encoder.GetBytes(s));
                button_conn.Text = "Connect to server";
                SetText6(" ");
            }
            else if (conn_MQTT == true)
            {
                client.Disconnect();
                conn_MQTT = false;
                ListBox1.Items.Add("Client disconnected from MQTT server.");
                SetText1("");
                button_conn.Text = "Connect to server";
                SetText6(" ");
            }
        }

        private void button_auto_Click(object sender, EventArgs e)
        {
            if (Client.conn_TCP == false && conn_MQTT == false)
            {
                ListBox1.Items.Add("UI client is currently offline.");
                SetText1(">> Press 'Connect to server' to establish communication.");
                SetText1("");
            }
            else
            {
                if (auto == false)
                {
                    if (Client.conn_TCP == true)
                    {
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        string s = "u,data,auto_start";
                        TCPclient.SendImmediate(encoder.GetBytes(s));
                        ListBox1.Items.Add("Sending auto signal to server.");
                        SetText1("");
                    }
                    else
                    {
                        client.Publish("control/auto", Encoding.UTF8.GetBytes("start"));
                        ListBox1.Items.Add("Publishing on: control/auto");
                    }
                    ListBox1.Items.Add(">> Starting the auto mode");
                    SetText1("");
                    button_auto.Text = "Stop Auto mode";
                    auto = true;
                }
                else
                {
                    if (Client.conn_TCP == true)
                    {
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        string s = "u,auto_stop";
                        TCPclient.SendImmediate(encoder.GetBytes(s));
                    }
                    else
                    {
                        client.Publish("control/auto", Encoding.UTF8.GetBytes("stop"));
                    }
                    ListBox1.Items.Add("Publishing on: control/auto");
                    ListBox1.Items.Add(">> Stopping the auto mode");
                    SetText1("");
                    button_auto.Text = "Start Auto mode";
                    auto = false;
                }
            }
        }

        private void button_choose_Click(object sender, EventArgs e)
        {
            if (choose == false)
            {
                ListBox1.Items.Add("Start choosing waypoints...");
                ListBox1.Items.Add(">> Left-click on the map to choose, drag right-click to move around.");
                SetText1("");
                button_choose.Text = "Disable Choosing Waypoint";
                choose = true;
            }
            else
            {
                ListBox1.Items.Add("Stop choosing waypoints...");
                ListBox1.Items.Add(">> Left-click on the map to interact, drag right-click to move around.");
                SetText1("");
                button_choose.Text = "Choose Waypoint Mode";
                choose = false;
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (Client.conn_TCP == false && conn_MQTT == false)
            {
                ListBox1.Items.Add("UI client is currently offline.");
                SetText1(">> Press 'Connect to server' to establish communication.");
                SetText1("");
            }
            else
            {
                int k = 1;
                ListBox1.Items.Add("Sending chosen waypoints...");
                client.Publish("control/auto", Encoding.UTF8.GetBytes("StartWaypoint"));
                //File.WriteAllText(path, "Waypoints" + Environment.NewLine);
                //tw.WriteLine("Waypoints");
                while (k < waynum)
                {
                    if (Client.conn_TCP == true)
                    {
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        string s = "u,data,wp_choose," + waylon[k] + "," + waylat[k];
                        TCPclient.SendImmediate(encoder.GetBytes(s));
                    }
                    else
                    {
                        client.Publish("control/auto", Encoding.UTF8.GetBytes(waylat[k] + "," + waylon[k]));
                    }
                    //File.WriteAllText(path, waylat[k].ToString() + "," + waylon[k].ToString() + Environment.NewLine);
                    //tw.WriteLine(waylat[k].ToString() + "," + waylon[k].ToString());
                    SetText1(">> Waypoint" + k + ": Sent.");
                    k++;
                }
                client.Publish("control/auto", Encoding.UTF8.GetBytes("EndWaypoint"));
                //File.WriteAllText(path, Environment.NewLine + "Positions" + Environment.NewLine);
                //tw.WriteLine("Positions");
                SetText1("");
            }
        }

        private void button_unlock_Click(object sender, EventArgs e)
        {
            if (Client.conn_TCP == false && conn_MQTT == false)
            {
                ListBox1.Items.Add("UI client is currently offline.");
                SetText1(">> Press 'Connect to server' to establish communication.");
                SetText1("");
            }
            else
            {
                if (Client.conn_TCP == true)
                {
                    ASCIIEncoding encoder = new ASCIIEncoding();
                    string s = "u,data,open";
                    TCPclient.SendImmediate(encoder.GetBytes(s));
                }
                else
                {
                    client.Publish("control/auto", Encoding.UTF8.GetBytes("open"));
                }
                ListBox1.Items.Add("Delivery completed!");
                SetText1(">> Opening the container...");
                SetText1("");
            }
        }

        private void button_del_Click(object sender, EventArgs e)
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

        private void button_req_Click(object sender, EventArgs e)
        {
            if (Client.conn_TCP == false && conn_MQTT == false)
            {
                ListBox1.Items.Add("UI client is currently offline.");
                SetText1(">> Press 'Connect to server' to establish communication.");
                SetText1("");
            }
            else
            {
                if (Client.conn_TCP == true)
                {
                    ASCIIEncoding encoder = new ASCIIEncoding();
                    string s = "u,data,request";
                    TCPclient.SendImmediate(encoder.GetBytes(s));
                }
                else
                {
                    client.Publish("control/auto", Encoding.UTF8.GetBytes("Request"));
                }
                ListBox1.Items.Add("Requesting current cart position...");
                SetText1("");
                request = true;
            }
        }

        private void button_set_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add("Setting requested position as a waypoint...");
            SetText1("");
            if (choose == true)
            {
                if (waynum <= 10)
                {
                    waylat[waynum] = latreq;
                    waylon[waynum] = lonreq;
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
            else
            {
                SetText1("Not currently in waypoint choosing mode.");
                SetText1(">> Press 'Choose Waypoint Mode' to proceed");
                SetText1("");
            }
        }

        private void button_loop_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add("Create a waypoint loop from the recent chosen waypoint...");
            SetText1("");
            if (choose == true)
            {
                if (waynum <= 10 && waynum > 2)
                {
                    waylat[waynum] = waylat[1];
                    waylon[waynum] = waylon[1];
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
            else
            {
                SetText1("Not currently in waypoint choosing mode.");
                SetText1(">> Press 'Choose Waypoint Mode' to proceed");
                SetText1("");
            }
        }

        private void button_data_Click(object sender, EventArgs e)
        {
            for(int i = 1; i < waynum; i++)
            {
                SetText1("Currently chosen waypoint " + i + ":");
                SetText1(">> Longitude: " + waylon[i]);
                SetText1(">> Latitude: " + waylat[i]);
                SetText1("");
            }
        }

        private void button_raw_Click(object sender, EventArgs e)
        {
            if (Client.conn_TCP == false && conn_MQTT == false)
            {
                ListBox1.Items.Add("UI client is currently offline.");
                SetText1(">> Press 'Connect to server' to establish communication.");
                SetText1("");
            }
            else if (rawtext.Text == string.Empty)
            {
                ListBox1.Items.Add("Type messages needed to send into the 'MESSAGE' box.");
                ListBox1.Items.Add(">> Press 'Raw Data Transmission' again to send said message.");
                SetText1("");
            }
            else
            {
                if (Client.conn_TCP == true)
                {
                    ASCIIEncoding encoder = new ASCIIEncoding();
                    string s = "u,raw," + rawtext.Text;
                    TCPclient.SendImmediate(encoder.GetBytes(s));
                }
                else
                {
                    client.Publish("control/auto", Encoding.UTF8.GetBytes(rawtext.Text));
                }
                ListBox1.Items.Add("Message sent to server/cart: " + rawtext.Text);
            }
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            if (show == false)
            {
                ListBox1.Items.Add("Show receiving messages on Activities Status");
                ListBox1.Items.Add(">> Press 'Hide Messages Received' to disable this.");
                SetText1("");
                button_show.Text = "Hide Messages Received";
                show = true;
            }
            else
            {
                ListBox1.Items.Add("Disable receiving messages on Activities Status");
                ListBox1.Items.Add(">> Press 'Show Messages Received' to enable messages log.");
                SetText1("");
                button_show.Text = "Show Messages Received";
                show = false;
            }

        }

        private void buttonCancelService_Click(object sender, EventArgs e)
        {
            client.Publish("control/service", Encoding.UTF8.GetBytes("k-service"));
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            client.Publish("control/auto", Encoding.UTF8.GetBytes("Pause"));
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            client.Publish("control/auto", Encoding.UTF8.GetBytes("Go"));
        }
    }
}