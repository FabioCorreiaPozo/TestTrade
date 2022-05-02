using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTrade
{
    internal class TypeValidation
    {

        public delegate bool Validate (string CallDate);

        public bool ValidadeDate(String CallDate)
        {
            DateTime dtValidation;           

            return DateTime.TryParseExact(CallDate, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                                                            DateTimeStyles.None, out dtValidation);
        }

        public bool ValidadeNumber(string UserWrite)
        {
            int intNumber;
            return Int32.TryParse(UserWrite, out intNumber);
        }

        public bool ValidadeLine(string Line)
        {
            return Line.Split(' ').Length == 3 ? true:false;
        }

        public bool ValidadeCustumerType(string CustumerType)
        {
           if(CustumerType == null) return false;

           // no mundo real, o ideal é validar os tipos listados na base de dados..usando linq etc..
           if(CustumerType == "Private" || CustumerType == "Public") return true;

           return false;
              
        }
        public bool ValidadePaymentDate(DateTime DateCall, DateTime Nextpayment)
        {
            return Nextpayment < DateCall ? false : true;
        }


    }
}
