using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_pendulum
{
    internal class TracksClass
    {
        public string title { get; set; }
        public string length { get; set; }
        public string album { get; set; }
        public string url { get; set; }

        public TracksClass(string sor)
        {
            var v = sor.Split(';');
            this.title = v[0];
            this.length = v[1];
            this.album = v[2];
            this.url = v[3];
        }
    }
}
