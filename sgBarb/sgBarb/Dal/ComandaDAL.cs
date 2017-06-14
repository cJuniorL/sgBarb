using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class ComandaDAL
    {
        public static void insert(Model.Comanda comanda)
        {
            Bll.ComandaBLL comandaBLL = new Bll.ComandaBLL();
            comandaBLL.insert(comanda);
        }

        public static void update(Model.Comanda comanda)
        {
            Bll.ComandaBLL comandaBLL = new Bll.ComandaBLL();
            comandaBLL.update(comanda);
        }

        public static Model.Comanda selectByID(int comandaID)
        {
            Bll.ComandaBLL comandaBLL = new Bll.ComandaBLL();
            return comandaBLL.selectByID(comandaID);
        }

        public static List<Model.Comanda> select()
        {
            Bll.ComandaBLL comandaBLL = new Bll.ComandaBLL();
            return comandaBLL.select();
        }
    }
}