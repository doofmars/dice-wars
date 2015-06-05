using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Hexagonal
{
    public class RandomGenerator
    {
        private static RandomGenerator instance;
        private static readonly Random RANDOM = new Random();

        public static RandomGenerator getInstance()
        {
            if (instance == null)
            {
                instance = new RandomGenerator(); 
            }
            return instance;
        }

        public void initialize()
        {
            //call "rollTheDice" because the first call takes a quite long time
            rollTheDice(3);
        }

        public int rollTheDice(int dices)
        {
            try
            {
                int[] numbers = GetRandomInts(1, 6, dices);
                int result = 0;
                foreach (int element in numbers)
                {
                    result += element;
                }
                return result;
            }
            catch (Exception e)
            {
                return rollTheDiceOffline(dices);
            }
        }

        private int rollTheDiceOffline(int dices)
        {
            if (dices > 0)
            {
                return rollTheDiceOffline(dices - 1) + RANDOM.Next(1, 7);
            }
            else
            {
                return 0;
            }
        }


        //Returns an array of random integers between two numbers, both inclusive        
        private int[] GetRandomInts(int min, int max, int count)
        {
            //Build the url string to www.random.org
            string url = "http://www.random.org/integers/?num=" + count.ToString();

            url += "&min=" + min.ToString();
            url += "&max=" + max.ToString();
            url += "&col=1&base=10&format=html&rnd=new";

            string data = DownloadData(url);

            if (data != string.Empty)
            {
                //Parse the data
                string startMarker = "<pre class=" + '"' + "data" + '"' + ">"; //<pre class="data">
                int j = data.IndexOf(startMarker);
                if (j != -1)
                {
                    int k = data.IndexOf("</pre>", j);
                    if (k != -1)
                    {
                        string intString = data.Substring(j + startMarker.Length, k - j - startMarker.Length);
                        intString = intString.Trim();

                        //Read each line
                        List<int> integers = new List<int>();
                        StringReader readLines = new StringReader(intString);

                        while (readLines.Peek() != -1)
                        {
                            integers.Add(int.Parse(readLines.ReadLine()));
                        }

                        return integers.ToArray();
                    }
                }
            }

            throw new Exception("No internet connection!");
        }


        //Connects to URL to download data
        private string DownloadData(string url)
        {
            try
            {
                //Get a data stream from the url
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();

                //Download in chuncks
                byte[] buffer = new byte[1024];

                //Get Total Size
                int dataLength = (int)response.ContentLength;

                //Download to memory
                //Note: adjust the streams here to download directly to the hard drive
                MemoryStream memStream = new MemoryStream();
                while (true)
                {
                    //Try to read the data
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                        break;
                    else
                        memStream.Write(buffer, 0, bytesRead);
                }

                //Convert the downloaded stream to a byte array
                string downloadedData = System.Text.ASCIIEncoding.ASCII.GetString(memStream.ToArray());

                //Clean up
                stream.Close();
                memStream.Close();

                return downloadedData;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
