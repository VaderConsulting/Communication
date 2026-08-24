using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stratatel.wcf.comms;
using System.ServiceModel;               // Required for WCF Contracts

namespace Client
{
    public partial class frmClient : Form
    {
        private Comms oComms = new Comms();  // private instance 
        
        public frmClient()
        {
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            oComms.MessageReceived += Comms_MessageReceived;  // Attach to method

            //Step 1: Create an instance of the WCF Client.
            EndpointAddress epAddress = new EndpointAddress("http://localhost:8000/Stratatel/wcf/comms");
            CommsClient client = new CommsClient(new WSHttpBinding(), epAddress);

            // Step 2: Call the service operations.
            client.SendMessage ("Hello there");

            //Step 3: Closing the client gracefully closes the connection and cleans up resources.
            client.Close();

        }

        private void Comms_MessageReceived()   // Event handler
        {
            Console.WriteLine("Received event: " + oComms.MessageIn);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //oComms.MessageOut = "Hello World";
            oComms.SendMessage("Hello World");
        }

    }
}
