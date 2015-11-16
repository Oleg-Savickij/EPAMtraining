using EPAM_laba_2.Model;
using EPAM_laba_2.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Text commonText = new Text();
            TextReader textfile = File.OpenText("C:/Users/Oleg/Source/Repos/EPAMtraining/EPAM laba 2/EPAM laba 2/test.txt");
            Parser newParser = new Parser();
            commonText = newParser.Parse(textfile);
            //Console.WriteLine(commonText.GetText());

            var sortedText = commonText.SortByLength();
            foreach (var item in sortedText)
            {
                Console.WriteLine(item.GetSentence());
            }
            var typedText = commonText.GetByType("?");
            List<ISentenceItem> words = new List<ISentenceItem>();
            foreach (var item in typedText)
            {
                words = item.GetWordsByLength(6);
            }
            foreach (var item in words)
            {
                words.Where(x => x.chars.Length == 7);
            }


            //Console.WriteLine(commonText.GetText());


            var newText = commonText.GetWordsByLength(7);

            //newText.Where(x=>x.)
            Console.WriteLine(commonText.Count);

            commonText.GetSentenceByIndex(5).ReplaceWordsByLength(5, "aaaaaaaaa");
        }
    }
}
