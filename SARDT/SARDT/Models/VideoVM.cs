using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class VideoVM
    {
        public List<Video> AllVideos { get; set; }
        public CurrentVideos CurrentVideos { get; set; }
    }
}