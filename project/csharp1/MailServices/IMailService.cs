﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailServices
{
    public interface IMailService
    {
        void Send(string title, string content, string to);
    }
}
