using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CallculatorConsume
{
    class Program
    {
        private static string CalculatorUri = "https://localhost:44319/api/values/Add";
        static void Main(string[] args)
        {

            RunAsync();

            Console.ReadKey();


        }

      public static async Task RunAsync()
        {
         
              await  AsyncAdd(new Data(1, 5));
       
        }

        public static async Task<String> AsyncAdd(Data data)
        {
            using (HttpClient client=new HttpClient())
            {
                Console.WriteLine("Data " + data);
                var jsonString = JsonConvert.SerializeObject(data);
                Console.WriteLine("json string: " + jsonString);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                Console.WriteLine("content: : " + content.ToString());
                Console.WriteLine("CalculatorUri: " + CalculatorUri);

                HttpResponseMessage response = await client.PostAsync(CalculatorUri , content);
                string str = await response.Content.ReadAsStringAsync();
                //Int32 sumStr = JsonConvert.DeserializeObject<Int32>(str);
                Console.WriteLine("Result is "+str);
                return str;


            }

        }

    }
}
