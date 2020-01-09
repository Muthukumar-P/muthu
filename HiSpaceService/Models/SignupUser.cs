using HiSpaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceService.Models
{
    public class SignupUser
    {
        public string Username { set; get; }
        public string Password { set; get; }   
        public bool IsClient  { set; get; }
    }
}
