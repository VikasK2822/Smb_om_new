﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
  public  interface INotificationUrl
    {
        public NotificationUrl GetNotificationUrl(string ordernumber);
    }
}
