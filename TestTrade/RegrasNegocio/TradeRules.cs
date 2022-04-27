using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace TestTrade
{
    public class TradeRules
    {
        TypeValidation oTypeValidation;
        Trade objtrade;

        public string TradeRulesMain(string Line, string Data = null) 
        {
            
                DateTime dateCall;
                oTypeValidation = new TypeValidation();
                if (string.IsNullOrEmpty(Line))
                {
                    return "Linha sem registros";
                }

                if (Line.Length == 10)
                {
                    if (oTypeValidation.ValidadeDate(Line))
                    {
                        dateCall = DateTime.Parse(Line, new CultureInfo("en-US"));
                        return dateCall.Date.ToString();
                    }
                    else
                    {
                        return "Data de Referencia Invalida";
                    }
                }
                else if (Line.Length > 10)
                {
                    if (oTypeValidation.ValidadeLine(Line))
                    {
                        objtrade = new Trade();
                        var DadosObjeto = Line.Split(' ');
                        objtrade.Value = Convert.ToDouble(DadosObjeto[0]);
                        objtrade.ClientSector = Convert.ToString(DadosObjeto[1]);
                        objtrade.NextPaymentDate = DateTime.Parse(DadosObjeto[2], new CultureInfo("en-US"));
                        dateCall = DateTime.Parse(Data, new CultureInfo("en-US"));

                    //verificar expirado

                    if (!ExpiredVerification(dateCall, objtrade.NextPaymentDate))
                    {
                        return "EXPIRED";
                    }
                    // verificar risco
                    return RiskVerify(objtrade.ClientSector, objtrade.Value);
                }
                else
                {
                     return "Linha de Dados de trade Invalida";
                }

                }
            
            return "";
        }

        public bool ExpiredVerification(DateTime DateCall, DateTime Nextpayment) 
        {
           return DateCall.Subtract(Nextpayment).Days > 30 ?  false:true; 
        }

        public string RiskVerify(string CustumerType, double Trade)
        {

            if (Trade <= 1000000)  return "MEDIUMRISK";

            return CustumerType.Equals("Public") ? "MEDIUMRISK" : "HIGHRISK";

        }
    }
}
