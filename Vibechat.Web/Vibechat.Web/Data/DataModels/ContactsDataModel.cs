﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VibeChat.Web;

namespace Vibechat.Web.Data.DataModels
{
    public class ContactsDataModel
    {
        [Key]
        public int ContactId { get; set; }

        public UserInApplication User { get; set; }

        public UserInApplication Contact { get; set; }
    }
}
