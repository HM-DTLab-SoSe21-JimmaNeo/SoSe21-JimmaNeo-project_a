﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Domain {

    public class Quiz {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Question> Questions { get; set; }

    }
}
