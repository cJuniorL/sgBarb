using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class FotoDal
    {
        public static void insert(Model.Foto foto)
        {
            Bll.FotoBLL fotoBLL = new Bll.FotoBLL();
            fotoBLL.insert(foto);
        }

        public static List<Model.Foto> select()
        {
            Bll.FotoBLL fotoBll = new Bll.FotoBLL();
            return fotoBll.select();
        }
    }
}