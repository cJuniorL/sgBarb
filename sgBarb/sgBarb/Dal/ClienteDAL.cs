﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class ClienteDAL
    {
        public static void insert(Model.Cliente cliente)
        {
            Bll.ClienteBLL clienteBLL = new Bll.ClienteBLL();
            clienteBLL.insert(cliente);
        }
    }
}