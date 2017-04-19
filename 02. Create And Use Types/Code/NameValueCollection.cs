using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
    public class NameValueCollection : List<NameValuePair>
    {
        public new void Add(NameValuePair pair)
        {
            if (this.GetByName(pair.Name) != null)
            {
                throw new ArgumentException("An item with this name already exists.");
            }

            base.Add(pair);
        }

        public new void Add(params NameValuePair[] pairs)
        {
            foreach (var pair in pairs)
            {
                this.Add(pair);
            }
        }

        public NameValuePair GetByName(string name)
        {
            return this.FirstOrDefault(x => x.Name == name);
        }

        public List<NameValuePair> FindBySubstring(string key)
        {
            return this.Where(x => x.Name.IndexOf(key) != -1).ToList();
        }
    }
}
