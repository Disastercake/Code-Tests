using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonScripts
{
    public class NameGenerator
    {
        private static readonly string[] NAME_LIST = new string[]
        {
            "Mike", "Cory", "Todd", "Tiffany", "Zuggy", "Tuttle", "Lomlom", "Zoomy", "Squawkers", "Trashman",
            "Jingle", "Lovebug", "Zahra", "Uppy", "Vegan", "Yuffie", "Sora", "Shiro", "Kuro", "Franky"
        };

        private List<string> NAME_POOL = new List<string>(NAME_LIST) { };

        /// <summary>
        /// Resets the list of names.
        /// </summary>
        public void Reset()
        {
            NAME_POOL.Clear();
            NAME_POOL.AddRange(NAME_LIST);
        }

        /// <summary>
        /// Gets a name from a pool of names, then removes that name permanently from the pool.
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            string name = string.Empty;

            if (NAME_POOL.Count > 0)
            {
                int i = UnityEngine.Random.Range(0, NAME_POOL.Count);
                name = NAME_POOL[i];
                NAME_POOL.RemoveAt(i);
            }

            if (string.IsNullOrEmpty(name))
                name = string.Format("{0} No-Name", UnityEngine.Random.value > 0.5f ? "Mr." : "Ms.");

            return name;
        }

        /// <summary>
        /// The number of unique names remaining.
        /// </summary>
        public int NamesRemaining
        {
            get { return NAME_POOL.Count; }
        }
    }
}
