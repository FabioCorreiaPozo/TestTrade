using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTrade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserMessages obUserMessages = new UserMessages();
                obUserMessages.RetornaMensagem("Digite a data base");
                int linei = 0;
                string line;
                string Data = string.Empty;

                StringBuilder Retorno = new StringBuilder();
                TradeRules objTr;
                while (!String.IsNullOrWhiteSpace(line = Console.ReadLine()))
                {
                    objTr =new TradeRules();

                    if (linei == 0)
                    {
                         Data = objTr.TradeRulesMain(line);
                    }
                    else if (linei == 1)
                    {
                      //  Console.WriteLine("linhas analisadas {0}", line);
                    }
                    else 
                    {
                      Retorno.Append(objTr.TradeRulesMain(line, Data) + "\n");
                    }
                    linei++;
                }
                Console.WriteLine(Retorno);
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ops....We have an error details : {0}" , ex.Message);
            }
            
            
        }
    }
}
