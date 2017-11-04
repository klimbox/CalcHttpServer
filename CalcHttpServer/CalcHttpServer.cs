using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpCalculator
{
    class CalcHttpServer
    {
        private HttpListener _listener;
        private double num1 = 0,
                       num2 = 0;
        private string opr  = "",
                       res  = "";
        private bool isNum  = false;
       

        public CalcHttpServer() : this("http://localhost:80/") { }
        public CalcHttpServer(string url)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(url);
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine("Working...");

            TimerCallback reqHandler = new TimerCallback(RequestHandler);
            Timer timer = new Timer(reqHandler, null, 0, 250);
        }

        private void RequestHandler(object obj)
        {
            HttpListenerContext context = _listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            if (request.HttpMethod == "POST")
            {
                string[] qParams = new StreamReader(request.InputStream).ReadToEnd().Split('=', '&');

                isNum = double.TryParse(qParams[1], out num1);
                isNum = double.TryParse(qParams[3], out num2) && isNum;
                opr = qParams[5];

            }
            else
            {
                var query = request.QueryString;

                isNum = double.TryParse(query.GetValues("num1")[0], out num1);
                isNum = double.TryParse(query.GetValues("num2")[0], out num2) && isNum;
                opr = query.GetValues("opr")[0];
            }


            if (isNum)
            {
                res = Calculate(num1, num2, opr);
            }
            else
            {
                res = "Enter correct values of num1 & num2";
            }
            byte[] buffer = Encoding.UTF8.GetBytes(res);
            response.AddHeader("Access-Control-Allow-Origin", "*");
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

          //  Console.WriteLine($"{DateTime.Now.ToLocalTime()}: {num1} {opr} {num2} = {res}");
            output.Close();
        }

        private string Calculate(double num1, double num2, string opr)
        {
            string res;
            switch (opr)
            {
                case "+":
                case "plus":
                    res = (num1 + num2).ToString();
                    break;
                case "-":
                    res = (num1 - num2).ToString();
                    break;
                case "/":
                    if (num2 != 0) { res = (num1 / num2).ToString(); }
                    else { res = "Err. Division by zero."; }
                    break;
                case "*":
                    res = (num1 * num2).ToString();
                    break;
                default:
                    res = "Err. Operation not supported";
                    break;
            }

            return res;
        }
    }
}
