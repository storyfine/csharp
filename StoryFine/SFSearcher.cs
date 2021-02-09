using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryFine
{
    class SFSearcher : ISFLogical
    {
        private string id;
        public string Id { get { return id; } }
        public delegate bool LogicSearcher(SFSearcher searcher, ISFEpisode episode);
        private LogicSearcher ls;
        private ISFEpisode e;
        public SFSearcher(string id, LogicSearcher ls)
        {
            this.id = id;
            this.ls = ls;
        }
        public bool Value { get { return ls(this, e); } }
    }
}
