using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookshopDatabase
{
    [DataContractAttribute]
    public class UnsuccessfullLoginFault
    {
        private string report;

        public UnsuccessfullLoginFault(string message)
        {
            this.report = message;
        }

        [DataMemberAttribute]
        public string Message
        {
            get { return this.report; }
            set { this.report = value; }
        }
    }
}
