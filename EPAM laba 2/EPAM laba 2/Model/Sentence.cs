using EPAM_laba_2.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EPAM_laba_2.Model
{
    public class Sentence 
    {
       public List<ISentenceItem> Items { get; set; }
       public Sentence()
            {
                Items = new List<ISentenceItem>();
            }
       
       public string TypeOfSentence()
            {
                return Items.Last().ToString();
            }

       public int Length
        {
            get
            {         
                return Items.Count(x => x is Word);
            }
        }
       public string GetSentence()
        {
            string sentence = "";
            foreach (var item in Items)
            {
                sentence += item.chars;
            }
            return sentence;
        }

        public List<ISentenceItem> GetWordsByLength(int length)
        {
            var words = Items.Where(x => x is Word).ToList();
            return words.Where(x => x.chars.Length == length).ToList();
        }

        public void RemoveWordsByLength(int length)
        {
            Items.RemoveAll(x=> (x.chars.Length==length) && !((x as Word).IsFirstVowel));
            
        }
        
        public void ReplaceWordsByLength(int length,string newWord)
        {
            Items.Where(x => (x.chars.Length == length) && (x is Word)).Select(x => x = new Word(newWord));
        }
    }
}
