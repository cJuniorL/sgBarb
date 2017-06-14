using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class CaixaDal
    {
        public static void insert(Model.Caixa caixa)
        {
            Bll.CaixaBLL caixaBll = new Bll.CaixaBLL();
            caixaBll.insert(caixa);
        }

        public static List<Model.Caixa> select()
        {
            Bll.CaixaBLL caixaBll = new Bll.CaixaBLL();
            return caixaBll.select();
        }

        public static void update(Model.Caixa caixa)
        {
            Bll.CaixaBLL caixaBll = new Bll.CaixaBLL();
            caixaBll.update(caixa);
        }
    }
}