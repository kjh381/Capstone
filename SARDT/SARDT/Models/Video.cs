﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARDT.Models
{
    public class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }


        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Video video = obj as Video;
            if ((System.Object)video == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ID == video.ID) && (Title == video.Title);
        }

        public bool Equals(Video video)
        {
            // If parameter is null return false:
            if ((object)video == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (ID == video.ID) && (Title == video.Title);
        }
    }
}