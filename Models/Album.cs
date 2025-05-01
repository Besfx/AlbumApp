using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AlbumApp.Entities
{
   public class Album
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        [Range(0.0, 10.0)]
        public decimal Rating { get; set; }

        public string Song { get; set; }

        public string DisplayText
        {
            get
            {
                if (Title.Length <= 12)
                {
                    return Title;
                }
                return Title.Substring(0, 12) + "...";
            }
        }
    }
}