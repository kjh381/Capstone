using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.YouTube;

namespace SARDT.Models
{
    public class Playlist
    {
        public Playlist()
        {

        }

        public List<Video> VideoList { get; set; }
    }
}