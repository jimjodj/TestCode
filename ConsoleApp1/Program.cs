using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //parseXML();
            string sMsg = setMsg();
            string[,] arr = ParseEdiFactMessage(sMsg);
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {


                Console.WriteLine(arr[i, 0].ToString());
                Console.WriteLine(arr[i, 1].ToString());

            }
        }
        static void parseXML()
        {
         string xmlfile = "C:\\Users\\Jimmy\\Documents\\Career\\Tests\\XMLTest.XML";
            XElement xElements = XElement.Load(xmlfile);
            
            IEnumerable < XElement > refs = from e in xElements.Descendants("Reference")
                                            where (string)e.Attribute("RefCode") == "MWB"
                                || (string)e.Attribute("RefCode") == "TRV"
                                || (string)e.Attribute("RefCode") == "CAR"
                                            select e;
        
            
            foreach (XElement data in refs)
            {
                Console.WriteLine(data.Attribute("RefCode").ToString() + " ," 
                    + data.Element("RefText").ToString().Replace("<RefText>", "RefText = ").Replace("</RefText>","").ToString());
            }
            
        }
        public static string[,] ParseEdiFactMessage(string EdiMessage)
        {
            string Seperator = "LOC";
            string SegSeparator = "+";
            IList<string> SegList = EdiMessage.Split("'").Where(n=>n.Contains(Seperator)).ToList();
            
            var SegSplitArray = from s in SegList
                                select s.Split(SegSeparator);
            
            var FinalList = (from l in SegSplitArray
                        select new string[] { l[1], l[2] }).ToList<string[]>();
 

            string[,] FinalArray = new string[FinalList.Count,2];
            int row = 0;
            foreach (string[] line in FinalList)
            {
                FinalArray[row, 0] = line[0];
                FinalArray[row, 1] = line[1];
                row++;
            }
          



            return FinalArray;
        }
    static string setMsg()
    {
        string sMsg = "UNA:+.? ' " +
"UNB + UNOC:3 + 2021000969 + 4441963198 + 180525:1225 + 3VAL2MJV6EH9IX + KMSV7HMD + CUSDECU - IE++1++1'" +
"UNH + EDIFACT + CUSDEC:D: 96B: UN: 145050'" +
"BGM + ZEM:::EX + 09SEE7JPUV5HC06IC6 + Z'" +
"LOC + 17 + IT044100'" +
"LOC + 18 + SOL'" +
"LOC + 35 + SE'" +
"LOC + 36 + TZ'" +
"LOC + 116 + SE003033'" +
"DTM + 9:20090527:102'" +
"DTM + 268:20090626:102'" +
"DTM + 182:20090527:102'";
        return sMsg;
    }
    }

}
