using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace restUtil
{
    public class RestUtil
    {
        private string baseUri = "";
        /* http://ist.rit.edu/api */
        public RestUtil(string uri)
        {
            this.baseUri = uri;
        }

        public string GET(string otherUri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUri + otherUri);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader =
                        new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader =
                        new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    return reader.ReadToEnd();
                    //log the errors...

                }
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Error";
            }
        }
    }
}
