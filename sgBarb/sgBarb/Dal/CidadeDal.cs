﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class CidadeDAL
    {
        public static void insert(Model.Cidade cidade)
        {
            Bll.CidadeBLL cidadeBLL = new Bll.CidadeBLL();
            cidadeBLL.insert(cidade);
        }

        public static List<Model.Cidade> select()
        {
            Bll.CidadeBLL cidadeBLL = new Bll.CidadeBLL();
            return cidadeBLL.select();
        }
    }
}