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

        public static List<Model.Compra> select()
        {
            Bll.CompraBll compraBLL = new Bll.CompraBll();
            return compraBLL.select();
        }

        public static Model.Compra selectByID(int compraID)
        {
            Bll.CompraBll compraBLL = new Bll.CompraBll();
            return compraBLL.selectById(compraID);
        }
    }
}