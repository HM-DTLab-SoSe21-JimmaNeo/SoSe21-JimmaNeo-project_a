using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Shared
{
    public class Answer
    {
        [Required]
        public string Text { get; set; }

        public bool Selected { get; set; }
    }
}
