using Academio.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academio.DTOs.Models
{
    public class SessionModel
    {
        public UserDto UserDto { get; set; }
        public TokenModel Token { get; set; }
    }
}
