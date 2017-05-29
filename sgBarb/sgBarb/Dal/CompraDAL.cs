using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class CompraDAL
    {
        public static int insert(Model.Compra compra)
        {
            Bll.CompraBll compraBLL = new Bll.CompraBll();
            return compraBLL.insert(compra);
        }
    }
}