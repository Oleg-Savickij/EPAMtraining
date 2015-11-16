using EPAM_laba_2.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_laba_2.Model
{
    public class Text 
    {
        private ICollection<Sentence> _textContainer = new List<Sentence>();
        public void Add(Sentence item)
        {
            _textContainer.Add(item);
        }
        public int Count
        {
            get
            {
                return _textContainer.Count;
            }
        }
        public List<Sentence> GetSentenceByLength(int length)
        {
            var result = _textContainer.Where(x => x.Items.Count == length).ToList();
            return result;
        }

        public List<Sentence> GetAll()
        {
            return _textContainer.Select(x=> x).ToList();
        }
        
       public string GetText()
        {
            string newText = "";
            foreach (var item in _textContainer)
            {
                newText += item.GetSentence();
            }
            return newText;
        }

        public List<Sentence> SortByLength()
        {
            List<Sentence> sortedText = _textContainer.Select(x => x).ToList();
            sortedText.Sort(delegate (Sentence a, Sentence b)
            {
                return a.Length.CompareTo(b.Length);
            });
            return sortedText;
        }
        
        public List<Sentence> GetByType(string type)
        {
            var typedSentences = _textContainer.Where(x => x.TypeOfSentence() == type).ToList();
            return typedSentences;
        }

        public List<ISentenceItem> GetWordsByLength(int length)
        {
            List<ISentenceItem> words = new List<ISentenceItem>();
            foreach (var item in _textContainer)
            {
                words = (item.GetWordsByLength(length));
            }
            return words;
        }

        public Sentence GetSentenceByIndex(int index)
        {
            var sentence =_textContainer.ElementAt(index);
            return sentence;
        }
    }
}
