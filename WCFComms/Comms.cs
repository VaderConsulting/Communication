using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stratatel.wcf.comms
{
    public class Comms : IComms
    {
        string m_MessageIn = "";
        string m_MessageOut = "";
        
        public delegate void MessageReceivedDelegate();  // The delegate
        public MessageReceivedDelegate MessageReceived;  // An instance of the delegate

        public Comms()  // Default constructor
        {
            this.MessageReceived = new MessageReceivedDelegate(ReceiveMessage);
        }

        public string MessageIn
        {
            get { return m_MessageIn; }
        } 

        public string MessageOut
        {
            get { return m_MessageOut; }
            set { m_MessageOut = value; }
        }

        //private string ReceiveMessage()
        //{
        //    Console.WriteLine("I got a message: " + m_MessageIn);
        //    //MessageReceived();
        //}

        //private string SendMessage()
        //{
        //    Console.WriteLine("I would like to send a message: " + m_MessageOut);

        //    // Now wrap it around...
        //    m_MessageIn = m_MessageOut;
        //    MessageReceived();
        //}

        #region IComms Members

        public void SendMessage(string MessageOut)
        {
            m_MessageOut = MessageOut;
            Console.WriteLine("I would like to send a message: " + m_MessageOut);

            // Now wrap it around...
            //m_MessageIn = m_MessageOut;
            //MessageReceived();
        }

        public void ReceiveMessage()
        {
            Console.WriteLine("I got a message: " + m_MessageIn);
            //return m_MessageIn;
        }

        #endregion
    }
}
