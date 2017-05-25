using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class ClienteDAL
    {
        public static void insert(Model.Cliente cliente)
        {
            Bll.ClienteBLL clienteBLL = new Bll.ClienteBLL();
            clienteBLL.insert(cliente);
        }

        public static List<Model.Cliente> select()
        {
            Bll.ClienteBLL clienteBLL = new Bll.ClienteBLL();
            return clienteBLL.select();
        }

        public static List<Model.Cliente> selectIdNome()
        {
            Bll.ClienteBLL clienteBll = new Bll.ClienteBLL();
            return clienteBll.selectIdNome();
        }

        public static Model.Cliente selectById(int clienteID)
        {
            Bll.ClienteBLL clienteBLL = new Bll.ClienteBLL();
            return clienteBLL.selectById(clienteID); 
        }

        public static void uptade(Model.Cliente cliente)
        {
            Bll.ClienteBLL clienteBLL = new Bll.ClienteBLL();
            clienteBLL.update(cliente);
        }

        public static void delete(int clienteID)
        {
            Bll.ClienteBLL clienteBLL = new Bll.ClienteBLL();
            clienteBLL.delete(clienteID);
        }
    }
}