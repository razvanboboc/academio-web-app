﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Academio.DTOs.DTOs
{
    public class CommunityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Guidelines { get; set; }
        public string Wiki { get; set; }
        public DateTime DateCreated { get; set; }
        public UserDto User { get; set; }
    }
}
