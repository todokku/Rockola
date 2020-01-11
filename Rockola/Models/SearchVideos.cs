using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rockola.Models
{
    public  class SearchVideos
    {
        public List<string> Videos { get; set; }
        public List<string> Channels { get; set; }
        public List<string> Playlist { get; set; }
    }
}