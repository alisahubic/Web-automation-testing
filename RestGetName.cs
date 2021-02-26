using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Web;





namespace JOliver
{
    class RestGetName
    {

        //Create request
        string harunl12222;
        public static string CreateRequest()
        {
            string UrlRequest = "http://api.namefake.com/";
            return UrlRequest;
        }

        //Make request and get Response
        public static BasicInformation MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                            "Server error (HTTP {0}:{1})",
                            response.StatusCode,
                            response.StatusDescription
                            )
                            );
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(BasicInformation));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    BasicInformation jsonResponse
                    = objResponse as BasicInformation;
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        static public void ProcessResponse(BasicInformation basicInfo)
        {

            /*
                        string name = basicInfo.Address;
                        Console.WriteLine(name);

                        string company = basicInfo.MaidenName;
                        Console.WriteLine(company);
                        */


            string name = basicInfo.Name;
            string username = basicInfo.Username;
            string password = basicInfo.Password;
            string birthDate = basicInfo.BirthDate;
            //     Console.WriteLine(name, password, username);
            Console.WriteLine(name);
            Console.WriteLine(username);
            Console.WriteLine(password);
            Console.WriteLine(birthDate);

        }


        public static Tuple<string, string, string, string,string> ReturnBasicInformation(BasicInformation basicInfo)
        {


            string name = basicInfo.Name;
            string username = basicInfo.Username;
            string password = basicInfo.Password;
            string birthDate = basicInfo.BirthDate;
            string domain = basicInfo.Domain;

            return Tuple.Create(name, username, password, birthDate, domain);

        }


        public static string TakeName(string value, int index, char delimiter)
        {
           // return value.Split(' ')[index];
            return value.Split(delimiter)[index];
            

          //  1991-03-05
        }
    
    }
}