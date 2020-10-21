using System.Collections.Generic;
using System;

namespace DROrdenes.BLL
{

    public class Utilidades
    {

        public static int ToInt(string valor)
        {
            int retorno = 0;



            int.TryParse(valor, out retorno);



            return retorno;
        }

    }

}