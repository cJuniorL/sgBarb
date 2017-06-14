using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class ServicoComanda
    {
        public static void insert(Model.ServicoComanda servicoComanda)
        {
            Bll.ServicoComandaBLL servicoComandaBLL = new Bll.ServicoComandaBLL();
            servicoComandaBLL.insert(servicoComanda);
        }

        public static List<Model.ServicoComanda> selectByIdComanda(int idComanda)
        {
            Bll.ServicoComandaBLL servicoComandaBLL = new Bll.ServicoComandaBLL();
            return servicoComandaBLL.selectByIdComanda(idComanda);
        }

        public static void delete(int idComanda)
        {
            Bll.ServicoComandaBLL servicoComandaBLL = new Bll.ServicoComandaBLL();
            servicoComandaBLL.delete(idComanda);
        }

        public static Model.ServicoComanda selectById(int idComanda)
        {
            Bll.ServicoComandaBLL servicoCOmandaBLL = new Bll.ServicoComandaBLL();
            return servicoCOmandaBLL.selectById(idComanda);
        }

        public static void update(Model.ServicoComanda servicoComanda)
        {
            Bll.ServicoComandaBLL servicoCOmandaBLL = new Bll.ServicoComandaBLL();
            servicoCOmandaBLL.update(servicoComanda);
        }
    }
}