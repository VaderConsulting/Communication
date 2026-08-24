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
using System.ServiceModel.Description;   // Required for WCF Contracts

namespace Server
{
    public partial class frmServer : Form
    {
        private Comms oComms = new Comms();  // private instance 
        
        public frmServer()
        {
            InitializeComponent();
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            oComms.MessageReceived += Comms_MessageReceived;  // Attach to method

            // Step 1 of the address configuration procedure: Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/Stratatel/wcf/comms");

            // Step 2 of the hosting procedure: Create ServiceHost
            ServiceHost selfHost = new ServiceHost(typeof(Comms), baseAddress);
            try
            {

                // Step 3 of the hosting procedure: Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(IComms),new WSHttpBinding(),"Comms");

                // Step 4 of the hosting procedure: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 of the hosting procedure: Start (and then stop) the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");

            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
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
