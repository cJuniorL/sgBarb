using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class AgendaDAL
    {
        public static void insert(Model.Agenda agenda)
        {
            Bll.Agenda bllAgenda = new Bll.Agenda();
            bllAgenda.insert(agenda);
        }
    }
}