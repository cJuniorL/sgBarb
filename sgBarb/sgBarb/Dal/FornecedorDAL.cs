using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class FornecedorDAL
    {
        public static void insert(Model.Fornecedor fornecedor)
        {
            Bll.FornecedorBLL fornecedorBLL = new Bll.FornecedorBLL();
            fornecedorBLL.insert(fornecedor);
        }

        public static List<Model.Fornecedor> select()
        {
            Bll.FornecedorBLL fornecedorBLL = new Bll.FornecedorBLL();
            return fornecedorBLL.select();
        }

        public static void delete(int fornecedorID)
        {
            Bll.FornecedorBLL fornecedorBLL = new Bll.FornecedorBLL();
            fornecedorBLL.delete(fornecedorID);
        }

        public static Model.Fornecedor selectByID(int fornecedorID)
        {
            Bll.FornecedorBLL fornecedorBLL = new Bll.FornecedorBLL();
            return fornecedorBLL.selectByID(fornecedorID);
        }

        public static void update(Model.Fornecedor fornecedor)
        {
            Bll.FornecedorBLL fornecedorBLL = new Bll.FornecedorBLL();
            fornecedorBLL.update(fornecedor);
        }

        public static List<Model.Fornecedor> selectIdEmpresa()
        {
            Bll.FornecedorBLL fornecedorBLL = new Bll.FornecedorBLL();
            return fornecedorBLL.selectIdEmpresa();
        }
    }
}