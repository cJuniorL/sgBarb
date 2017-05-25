using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class FuncionarioDAL
    {
        public static void insert(Model.Funcionario funcionario)
        {
            Bll.FuncionarioBLL funcionarioBLL = new Bll.FuncionarioBLL();
            funcionarioBLL.insert(funcionario);
        }

        public static List<Model.Funcionario> select()
        {
            Bll.FuncionarioBLL funcionarioBLL = new Bll.FuncionarioBLL();
            return funcionarioBLL.select();
        }

        public static List<Model.Funcionario> selectIdNome()
        {
            Bll.FuncionarioBLL funcionarioBll = new Bll.FuncionarioBLL();
            return funcionarioBll.selectIdNome();
        }

        public static void delete(int funcionarioID)
        {
            Bll.FuncionarioBLL funcionaroBLL = new Bll.FuncionarioBLL();
            funcionaroBLL.delete(funcionarioID);
        }

        public static Model.Funcionario selectById(int funcionarioID)
        {
            Bll.FuncionarioBLL funcionarioBLL = new Bll.FuncionarioBLL();
            return funcionarioBLL.selectById(funcionarioID);
        }

        public static void update(Model.Funcionario funcionario)
        {
            Bll.FuncionarioBLL funcionarioBLL = new Bll.FuncionarioBLL();
            funcionarioBLL.update(funcionario);
        }
    }
}