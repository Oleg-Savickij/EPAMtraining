using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media
{
    public class Album:BaseMedia,ICollection<Song>
    {
        private ICollection<Song> songs=new List<Song>();

        public int Count
        {
            get
            {
                return songs.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return songs.IsReadOnly;
            }
        }

        public void Add(Song item)
        {
            songs.Add(item);
        }

        public void Clear()
        {
            songs.Clear();
        }

        public bool Contains(Song item)
        {
            return songs.Contains(item);
        }

        public void CopyTo(Song[] array, int arrayIndex)
        {
            songs.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Song> GetEnumerator()
        {
            return songs.GetEnumerator();
        }

        public bool Remove(Song item)
        {
            return songs.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return songs.GetEnumerator();
        }
    }
}
