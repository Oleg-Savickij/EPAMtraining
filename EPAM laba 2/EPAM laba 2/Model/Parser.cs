using EPAM_laba_2.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_2.Model
{
    public class Parser
    {
        private SeparatorContainer separators = new SeparatorContainer();


        public Sentence CreateSentence(string sourse)
        {
            Sentence newSentence = new Sentence();
            WordFactory wordFactory=new WordFactory();
            PunctuationFactory punctuationFactory = new PunctuationFactory();
            var wordSeparators = separators.WordSeparators().Concat(separators.SentenceSeparators());
            bool tr = true;
            int punctuationMarkIndex = -1;
            while (tr==true)
            {
                tr = false;
                punctuationMarkIndex = -1;
                string punctuationMark = wordSeparators.FirstOrDefault(x =>
                {
                    punctuationMarkIndex = sourse.IndexOf(x);
                    return punctuationMarkIndex >= 0;
                });
                if (punctuationMark != null)
                {
                    newSentence.Items.Add(wordFactory.Create(sourse.Substring(0, punctuationMarkIndex )));
                    newSentence.Items.Add(punctuationFactory.Create(sourse.Substring(punctuationMarkIndex, 1)));
                    sourse = sourse.Remove(0, punctuationMarkIndex + 1);
                    tr = true;
                }
            }
            return newSentence;
        }

        public Text Parse(TextReader text)
        {
            Text resultText = new Text();
            var sentenceSeparators = separators.SentenceSeparators();
            var wordSeparators = separators.WordSeparators();
            StringBuilder buffer = new StringBuilder();
            buffer.Clear();
            string currentText = text.ReadToEnd();
            while(currentText!="")
            {
                int sentenceSeparatorIndex = -1;
                string firstSentenceSeparator = sentenceSeparators.FirstOrDefault(x =>
                {
                    sentenceSeparatorIndex = currentText.IndexOf(x);
                    return sentenceSeparatorIndex >= 0;
                });
                if (firstSentenceSeparator!=null)
                {
                    buffer.Append(currentText.Substring(0, sentenceSeparatorIndex + firstSentenceSeparator.Length));
                    Sentence newSentence = CreateSentence(buffer.ToString());
                    resultText.Add(newSentence);
                    buffer.Clear();
                    currentText = currentText.Remove(0, sentenceSeparatorIndex + 1);
                }               
            }
            return resultText;
            
        }
    }
}
