using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Funcoes
{
    public class InputTimeBootstrap
    {

        public static string getInputDate(DateTime dt)
        {
            return (dt.Year + "-" + dt.Month.ToString("00") + "-" + dt.Day.ToString("00"));
        }
    }
}