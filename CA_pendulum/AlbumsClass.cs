using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_pendulum
{
    internal class AlbumsClass
    {
        public string id { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public string release { get; set; }

        public AlbumsClass(string sor)
        {
            var v = sor.Split(';');
            this.id = v[0];
            this.artist = v[1];
            this.title = v[2];
            this.release = v[3];
        }
    }
}
