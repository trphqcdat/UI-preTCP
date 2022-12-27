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

        bool isMQTTConnect = false;
        bool isFirstWaypoint = true;
        bool isChooseEnable = false;
        bool isAutoEnable = false;
        bool isOnRequest = false;
        bool isShowMessageEnable = false;
        bool isIconOnMap = false;
        bool isReverseWaypoint = false;

        string ClientSender;
        double Cart_Longitude_1;
        double Cart_Longitude_2;
        double Cart_Longitude_onRequest;
        double Cart_Latitude_1;
        double Cart_Latitude_2;
        double Cart_Latitude_onRequest;

        int isCartArrive = 0;
        int WaypointArrive = 0;
        int WaypointUpcoming = 0;
        double CartSpeed = 0;
        double CartAngle = 0;

        double[] Waypoint_Longitude = new double[21];
        double[] Waypoint_Latitude = new double[21];
        int WaypointCount = 1;
        readonly MqttClient client = new MqttClient("broker.hivemq.com", 1883, false, null, null, MqttSslProtocols.None);
        readonly Client TCPclient = new Client();

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
            trackpoints.Add(new PointLatLng(Cart_Latitude_1, Cart_Longitude_1));
            trackpoints.Add(new PointLatLng(Cart_Latitude_2, Cart_Longitude_2));
            GMapRoute route = new GMapRoute(trackpoints, "Tracking");
            route.Stroke = new Pen(Color.Red, 1);
            trackroutes.Routes.Add(route);
            gmap.Overlays.Add(trackroutes);
            Cart_Latitude_1 = Cart_Latitude_2;
            Cart_Longitude_1 = Cart_Longitude_2;
        }

        private void Marking()
        {
            GMapOverlay markers = new GMapOverlay(gmap, "markers");
            GMapMarker marker = new GMapMarkerGoogleRed(new PointLatLng(Waypoint_Latitude[WaypointCount], Waypoint_Longitude[WaypointCount]));
            marker.ToolTipText = "WP" + WaypointCount;
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
            GMapMarker marker = new GMapMarkerGoogleGreen(new PointLatLng(Waypoint_Latitude[WaypointArrive], Waypoint_Longitude[WaypointArrive]));
            markers.Markers.Add(marker);
            gmap.Overlays.Add(markers);
            SetText2(Convert.ToString(WaypointArrive));
            if (WaypointUpcoming == 0)
            {
                SetText3("Finish");
            }
            else
            {
                SetText3(Convert.ToString(WaypointUpcoming));
            }
        }

        private void Drawing()
        {
            List<PointLatLng> drawpoints = new List<PointLatLng>();
            GMapOverlay drawroutes = new GMapOverlay(gmap, "drawroutes");
            drawpoints.Add(new PointLatLng(Waypoint_Latitude[WaypointCount - 2], Waypoint_Longitude[WaypointCount - 2]));
            drawpoints.Add(new PointLatLng(Waypoint_Latitude[WaypointCount - 1], Waypoint_Longitude[WaypointCount - 1]));
            GMapRoute route = new GMapRoute(drawpoints, "Drawing");
            route.Stroke = new Pen(Color.Green, 1);
            drawroutes.Routes.Add(route);
            gmap.Overlays.Add(drawroutes);
        }
        
        private void Remapping()
        {
            int i = 2;
            int k = 1;
            while(i < WaypointCount)
            {
                List<PointLatLng> redrawpoints = new List<PointLatLng>();
                GMapOverlay redrawroutes = new GMapOverlay(gmap, "redrawroutes");
                redrawpoints.Add(new PointLatLng(Waypoint_Latitude[i - 1], Waypoint_Longitude[i - 1]));
                redrawpoints.Add(new PointLatLng(Waypoint_Latitude[i - 0], Waypoint_Longitude[i - 0]));
                GMapRoute route = new GMapRoute(redrawpoints, "Drawing");
                route.Stroke = new Pen(Color.Green, 1);
                redrawroutes.Routes.Add(route);
                gmap.Overlays.Add(redrawroutes);
                i++;
            }
            while(k < WaypointCount + 1)
            {
                GMapOverlay remarkers = new GMapOverlay(gmap, "remarkers");
                GMapMarker remarker = new GMapMarkerGoogleRed(new PointLatLng(Waypoint_Latitude[k - 1], Waypoint_Longitude[k - 1]));
                remarker.ToolTipText = "WP" + Convert.ToString(k - 1);
                remarker.ToolTip.Fill = Brushes.Black;
                remarker.ToolTip.Foreground = Brushes.White;
                remarker.ToolTip.Stroke = Pens.Black;
                remarker.ToolTip.TextPadding = new Size(5, 5);
                remarkers.Markers.Add(remarker);
                gmap.Overlays.Add(remarkers);
                k++;
            }
        }

        private void IconUpdate(int i)
        {
            GMapOverlay icons = new GMapOverlay(gmap, "icons");
            GMapMarker icon = new GMapMarkerCross(new PointLatLng(Cart_Latitude_2, Cart_Longitude_2));
            if (isIconOnMap)
            {
                //icons.Markers.Remove(icon);
                //gmap.Overlays.Add(icons);
                gmap.Overlays.RemoveAt(gmap.Overlays.Count - i);
                isIconOnMap = false;
            }
            if (!isIconOnMap)
            {
                icons.Markers.Add(icon);
                gmap.Overlays.Add(icons);
                isIconOnMap = true;
                return;
            }
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
            isChooseEnable = false;
            //button_choose.Text = "Choose Waypoint Mode";
            string payload = System.Text.UTF8Encoding.UTF8.GetString(e.Message);
            char[] charSeparators = new char[] { ',' };
            string[] message = payload.Split(charSeparators, StringSplitOptions.None);
            ClientSender = Convert.ToString(message[0]);
            if (ClientSender != "c") return;
            if (isOnRequest == true)
            {
                Cart_Longitude_onRequest = Convert.ToDouble(message[1]);
                Cart_Latitude_onRequest = Convert.ToDouble(message[2]);
                SetText1("Received current cart position:");
                SetText1("Longitude: " + Cart_Longitude_onRequest + ", Latitude: " + Cart_Latitude_onRequest);
                SetText1(">> Press 'Set as Waypoint' to set this as a waypoint");
                SetText1("");
                isOnRequest = false;
            }
            if (isFirstWaypoint == true)
            {
                Cart_Longitude_1 = Convert.ToDouble(message[1]);
                Cart_Latitude_1 = Convert.ToDouble(message[2]);
                isCartArrive = Convert.ToInt16(message[3]);
                WaypointArrive = Convert.ToInt16(message[4]);
                WaypointUpcoming = Convert.ToInt16(message[5]);
                CartSpeed = Convert.ToDouble(message[6]);  
                CartAngle = Convert.ToDouble(message[7]);
                SetText1("Received - topic: " + e.Topic + ". Current position:");
                SetText1("Longitude: " + Cart_Longitude_1 + ", Latitude: " + Cart_Latitude_1);
                SetText1("");
                SetText4(Convert.ToString(CartSpeed) + " m/s");
                SetText5(Convert.ToString(CartAngle) + " *");
                isFirstWaypoint = false;
                return;
        }
            else
            {
                Cart_Longitude_2 = Convert.ToDouble(message[1]);
                Cart_Latitude_2 = Convert.ToDouble(message[2]);
                isCartArrive = Convert.ToInt16(message[3]);
                WaypointArrive = Convert.ToInt16(message[4]);
                WaypointUpcoming = Convert.ToInt16(message[5]);
                CartSpeed = Convert.ToDouble(message[6]);
                CartAngle = Convert.ToDouble(message[7]);
                SetText1("Received - topic: " + e.Topic + ". Current position:");
                SetText1("Longitude: " + Cart_Longitude_2 + ", Latitude: " + Cart_Latitude_2);
                SetText1("");
                SetText4(Convert.ToString(CartSpeed) + " m/s");
                SetText5(Convert.ToString(CartAngle) + " *");
                if (isCartArrive == 1)
                {
                    Updating();
                    IconUpdate(2);
                }
                if (WaypointArrive == WaypointCount)
                {
                    client.Publish("control/auto", Encoding.UTF8.GetBytes("stop"));
                    SetText1("Vehicle arrived to the final waypoint.");
                    SetText1(">> Stopping the auto mode");
                    SetText1("");
                    isAutoEnable = false;
                }
                Tracking();
                IconUpdate(2);
            }
        }
       
        private void client_OnDataReceived(byte[] data, int bytesRead)
        {
            isChooseEnable = false;
            ASCIIEncoding encoder = new ASCIIEncoding();
            string payload = encoder.GetString(data, 0, bytesRead);
            char[] charSeparators = new char[] { ',' };
            string[] message = payload.Split(charSeparators, StringSplitOptions.None);
            //ClientSender = Convert.ToString(message[0]);
            //if (ClientSender != "c") return;
            if (isOnRequest == true)
            {
                Cart_Longitude_onRequest = Convert.ToDouble(message[1]);
                Cart_Latitude_onRequest = Convert.ToDouble(message[2]);
                SetText1("Received current cart position:");
                SetText1("Longitude: " + Cart_Longitude_onRequest + ", Latitude: " + Cart_Latitude_onRequest);
                SetText1(">> Press 'Set as Waypoint' to set this as a waypoint");
                SetText1("");
                isOnRequest = false;
            }
            if (isFirstWaypoint == true)
            {
                Cart_Longitude_1 = Convert.ToDouble(message[1]);
                Cart_Latitude_1 = Convert.ToDouble(message[2]);
                isCartArrive = Convert.ToInt16(message[3]);
                WaypointArrive = Convert.ToInt16(message[4]);
                WaypointUpcoming = Convert.ToInt16(message[5]);
                CartSpeed = Convert.ToDouble(message[6]);
                CartAngle = Convert.ToDouble(message[7]);
                isFirstWaypoint = false;
                return;
            }
            else
            {
                Cart_Longitude_2 = Convert.ToDouble(message[1]);
                Cart_Latitude_2 = Convert.ToDouble(message[2]);
                isCartArrive = Convert.ToInt16(message[3]);
                WaypointArrive = Convert.ToInt16(message[4]);
                WaypointUpcoming = Convert.ToInt16(message[5]);
                CartSpeed = Convert.ToDouble(message[6]);
                CartAngle = Convert.ToDouble(message[7]);
                if (isCartArrive == 1)
                {
                    Updating();
                    IconUpdate(2);
                }
                if (WaypointArrive == WaypointCount)
                {
                    client.Publish("control/auto", Encoding.UTF8.GetBytes("stop"));
                    SetText1("Vehicle arrived to the final waypoint.");
                    SetText1(">> Stopping the auto mode");
                    SetText1("");
                    isAutoEnable = false;
                }
                Tracking();
                IconUpdate(2);
            }
        }

        private void gmap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isChooseEnable == true)
            {
                if (WaypointCount <= 10)
                {
                    var point = gmap.FromLocalToLatLng(e.X, e.Y);
                    Waypoint_Latitude[WaypointCount] = point.Lat;
                    Waypoint_Longitude[WaypointCount] = point.Lng;
                    SetText1("Chosen waypoint " + WaypointCount + ":");
                    SetText1(">> Longitude: " + Waypoint_Longitude[WaypointCount]);
                    SetText1(">> Latitude: " + Waypoint_Latitude[WaypointCount]);
                    SetText1("");
                    Marking();
                    WaypointCount++;
                    if (WaypointCount >= 3)
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
            if (Client.isTCPConnect == false && isMQTTConnect == false)
            {
                TCPclient.OnDataReceived += new ClientHandlePacketData(client_OnDataReceived);
                TCPclient.ConnectToServer("139.162.36.251", 5050);
                if (Client.isTCPConnect == true)
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
                    isMQTTConnect = true;
                }
            }
            else if (Client.isTCPConnect == true)
            {
                ListBox1.Items.Add("Client disconnected from TCP server.");
                SetText1("");
                ASCIIEncoding encoder = new ASCIIEncoding();
                string s = "!Disconnect_3147";
                TCPclient.SendImmediate(encoder.GetBytes(s));
                button_conn.Text = "Connect to server";
                SetText6(" ");
            }
            else if (isMQTTConnect == true)
            {
                client.Disconnect();
                isMQTTConnect = false;
                ListBox1.Items.Add("Client disconnected from MQTT server.");
                SetText1("");
                button_conn.Text = "Connect to server";
                SetText6(" ");
            }
        }

        private void button_auto_Click(object sender, EventArgs e)
        {
            if (Client.isTCPConnect == false && isMQTTConnect == false)
            {
                ListBox1.Items.Add("UI client is currently offline.");
                SetText1(">> Press 'Connect to server' to establish communication.");
                SetText1("");
            }
            else
            {
                if (isAutoEnable == false)
                {
                    if (Client.isTCPConnect == true)
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
                    isAutoEnable = true;
                }
                else
                {
                    if (Client.isTCPConnect == true)
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
                    isAutoEnable = false;
                }
            }
        }

        private void button_choose_Click(object sender, EventArgs e)
        {
            if (isChooseEnable == false)
            {
                ListBox1.Items.Add("Start choosing waypoints...");
                ListBox1.Items.Add(">> Left-click on the map to choose, drag right-click to move around.");
                SetText1("");
                button_choose.Text = "Disable Choosing Waypoint";
                isChooseEnable = true;
            }
            else
            {
                ListBox1.Items.Add("Stop choosing waypoints...");
                ListBox1.Items.Add(">> Left-click on the map to interact, drag right-click to move around.");
                SetText1("");
                button_choose.Text = "Choose Waypoint Mode";
                isChooseEnable = false;
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (Client.isTCPConnect == false && isMQTTConnect == false)
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
                while (k < WaypointCount)
                {
                    if (Client.isTCPConnect == true)
                    {
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        string s = "u,data,wp_choose," + Waypoint_Longitude[k] + "," + Waypoint_Latitude[k];
                        TCPclient.SendImmediate(encoder.GetBytes(s));
                    }
                    else
                    {
                        client.Publish("control/auto", Encoding.UTF8.GetBytes(Waypoint_Latitude[k] + "," + Waypoint_Longitude[k]));
                    }
                    SetText1(">> Waypoint" + k + ": Sent.");
                    k++;
                }
                client.Publish("control/auto", Encoding.UTF8.GetBytes("EndWaypoint"));
                SetText1("");
            }
        }

        private void button_unlock_Click(object sender, EventArgs e)
        {
            if (Client.isTCPConnect == false && isMQTTConnect == false)
            {
                ListBox1.Items.Add("UI client is currently offline.");
                SetText1(">> Press 'Connect to server' to establish communication.");
                SetText1("");
            }
            else
            {
                if (Client.isTCPConnect == true)
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
            Waypoint_Longitude = new double[11];
            Waypoint_Latitude = new double[11];
            WaypointCount = 1;
            isFirstWaypoint = true;
            isIconOnMap = false;
            Deleting();
        }

        private void button_req_Click(object sender, EventArgs e)
        {
            if (Client.isTCPConnect == false && isMQTTConnect == false)
            {
                ListBox1.Items.Add("UI client is currently offline.");
                SetText1(">> Press 'Connect to server' to establish communication.");
                SetText1("");
            }
            else
            {
                if (Client.isTCPConnect == true)
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
                isOnRequest = true;
            }
        }

        private void button_set_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add("Setting requested position as a waypoint...");
            SetText1("");
            if (isChooseEnable == true)
            {
                if (WaypointCount <= 10)
                {
                    Waypoint_Latitude[WaypointCount] = Cart_Latitude_onRequest;
                    Waypoint_Longitude[WaypointCount] = Cart_Longitude_onRequest;
                    SetText1("Chosen waypoint " + WaypointCount + ":");
                    SetText1(">> Longitude: " + Waypoint_Longitude[WaypointCount]);
                    SetText1(">> Latitude: " + Waypoint_Latitude[WaypointCount]);
                    SetText1("");
                    Marking();
                    WaypointCount++;
                    if (WaypointCount >= 3)
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
            if (isChooseEnable == true)
            {
                if (WaypointCount <= 10 && WaypointCount > 2)
                {
                    Waypoint_Latitude[WaypointCount] = Waypoint_Latitude[1];
                    Waypoint_Longitude[WaypointCount] = Waypoint_Longitude[1];
                    SetText1("Chosen waypoint " + WaypointCount + ":");
                    SetText1(">> Longitude: " + Waypoint_Longitude[WaypointCount]);
                    SetText1(">> Latitude: " + Waypoint_Latitude[WaypointCount]);
                    SetText1("");
                    Marking();
                    WaypointCount++;
                    if (WaypointCount >= 3)
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
            for(int i = 1; i < WaypointCount; i++)
            {
                SetText1("Currently chosen waypoint " + i + ":");
                SetText1(">> Longitude: " + Waypoint_Longitude[i]);
                SetText1(">> Latitude: " + Waypoint_Latitude[i]);
                SetText1("");
            }
        }

        private void button_raw_Click(object sender, EventArgs e)
        {
            if (Client.isTCPConnect == false && isMQTTConnect == false)
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
                if (Client.isTCPConnect == true)
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
            if (isShowMessageEnable == false)
            {
                ListBox1.Items.Add("Show receiving messages on Activities Status");
                ListBox1.Items.Add(">> Press 'Hide Messages Received' to disable this.");
                SetText1("");
                button_show.Text = "Hide Messages Received";
                isShowMessageEnable = true;
            }
            else
            {
                ListBox1.Items.Add("Disable receiving messages on Activities Status");
                ListBox1.Items.Add(">> Press 'Show Messages Received' to enable messages log.");
                SetText1("");
                button_show.Text = "Show Messages Received";
                isShowMessageEnable = false;
            }

        }

        private void button_reverse_Click(object sender, EventArgs e)
        {
            if (!isReverseWaypoint)
            {
                int start = 0;
                int end = WaypointCount;
                while (start < end)
                {
                    double lontemp = Waypoint_Longitude[start];
                    Waypoint_Longitude[start] = Waypoint_Longitude[end];
                    Waypoint_Longitude[end] = lontemp;
                    double lattemp = Waypoint_Latitude[start];
                    Waypoint_Latitude[start] = Waypoint_Latitude[end];
                    Waypoint_Latitude[end] = lattemp;
                    start++;
                    end--;
                    isReverseWaypoint = true;
                }
                isReverseWaypoint = false;
                Deleting();
                Remapping();
            }
        }
    }
}