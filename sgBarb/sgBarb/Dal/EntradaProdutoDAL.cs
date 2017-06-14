﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class EntradaProdutoDAL
    {
        public static void insert(Model.EntradaProduto entradaProduto)
        {
            Bll.EntradaProdutoBLL entraProdutoBLL = new Bll.EntradaProdutoBLL();
            entraProdutoBLL.insert(entradaProduto);
        }

        public static List<Model.EntradaProduto> selectCompraID(int compraID)
        {
            Bll.EntradaProdutoBLL entradaProdutBLL = new Bll.EntradaProdutoBLL();
            return entradaProdutBLL.selectCompraID(compraID);
        }
    }
}