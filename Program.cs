using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GDELT_GKG_PARSE
{
    class Program
    {

        static void Main(string[] args)
        {
            DoData();
            Console.ReadLine();
        }


        private static void DoData()
        {
            var asm = typeof(Program).Assembly;
            var resourceStream = asm.GetManifestResourceStream("GDELT_GKG_PARSE.AppData.20161216041500.gkg.csv");
            if (resourceStream == null)
            {
                Console.WriteLine("the data are not found, cancel order!");
                return;
            }
            string line;
            short counter = 0;
            var regex = new Regex(@"(\w+(?:-\w+)+)");
            using (var reader = new StreamReader(resourceStream, System.Text.Encoding.UTF8))
            {
                while ((line = reader.ReadLine()) != null && ++counter < 100)
                {
                    var fields = line.Split('\t');
                    //Console.WriteLine("id: {0}", fields[0]);
                    //Console.WriteLine("date time : {0}", fields[1]);
                    //Console.WriteLine("source name : {0}", fields[3]);
                    Console.WriteLine(fields[4]);
                    Match match = regex.Match(fields[4]);
                    if (match.Success)
                    {
                        var title = match.Groups[0].Value.Replace("-", " ");
                        Console.WriteLine(title);
                    }
                    else
                    {
                        Console.WriteLine("this URL is not SEO friendly!");
                    }
                    //Console.WriteLine("counts1 : {0}", fields[5]);
                    //Console.WriteLine("counts2 : {0}", fields[6]);
                    //Console.WriteLine("themes : {0}", fields[7]);
                    //Console.WriteLine("enh themes : {0}", fields[8]);
                    //Console.WriteLine("locations : {0}", fields[9]);
                    //Console.WriteLine("enh locations : {0}", fields[10]);
                    //Console.WriteLine("persons : {0}", fields[11]);
                    //Console.WriteLine("enh persons : {0}", fields[12]);
                    //Console.WriteLine("organizations : {0}", fields[13]);
                    //Console.WriteLine("enh organizations : {0}", fields[14]);
                    //Console.WriteLine("tone : {0}", fields[15]);
                    //Console.WriteLine("enh dates : {0}", fields[16]);
                    //Console.WriteLine("gcam : {0}", fields[17]);
                    //Console.WriteLine("sharing img : {0}", fields[18]);
                    //Console.WriteLine("related img : {0}", fields[19]);
                    //Console.WriteLine("embed img : {0}", fields[20]);
                    //Console.WriteLine("embed videos : {0}", fields[21]);
                    //Console.WriteLine("quotations : {0}", fields[22]);
                    //Console.WriteLine("all names : {0}", fields[23]);
                    //Console.WriteLine("amounts : {0}", fields[24]);
                }
            }
        }
    }
}
