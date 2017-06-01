using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class SerivcoDAL
    {   
        public static void insert(Model.Servico servico)
        {
            Bll.ServicoBLL servicoBLL = new Bll.ServicoBLL();
            servicoBLL.insert(servico);
        }

        public static void update(Model.Servico servico)
        {
            Bll.ServicoBLL servicoBLL = new Bll.ServicoBLL();
            servicoBLL.update(servico);
        }

        public static List<Model.Servico> select()
        {
            Bll.ServicoBLL servicoBLL = new Bll.ServicoBLL();
            return servicoBLL.select();
        }

        public static Model.Servico selectByID(int idServico)
        {
            Bll.ServicoBLL servico = new Bll.ServicoBLL();
            return servico.selectByID(idServico);
        }
    }
}