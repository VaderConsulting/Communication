using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;  // Required for WCF Contracts

namespace Stratatel.wcf.comms
{
    [ServiceContract(Namespace = "http://stratatel.wcf.comms")]
    public interface IComms
    {
        [OperationContract()]
        void SendMessage(string MessageOut);

        [OperationContract()]
        void ReceiveMessage();
    }
}
