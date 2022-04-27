using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTrade
{
    internal class Trade
    {
        public double Value { get; set; } //indicates the transaction amount in dollars
        public string ClientSector { get; set; } //indicates the client´s sector which can be "Public" or "Private"
        public DateTime NextPaymentDate { get; set; } //indicates when the next payment from the client to the bank is expected

         
    }
}
