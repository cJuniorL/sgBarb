using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class ComandaCaixa
    {
        public static void insert(Model.ComandaCaixa comandaCaixa)
        {
            Bll.ComandaCaixa comandaCaixaBLL = new Bll.ComandaCaixa();
            comandaCaixaBLL.insert(comandaCaixa);
        }
    }
}