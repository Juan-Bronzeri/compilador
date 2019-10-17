using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    class StaticTamanhoVariavel
    {
        static private int tamanhoVariavel;

        static public int GetTamanhoVariavel()
        {
            return tamanhoVariavel;
        }
        static public void SetTamanhoVariavel(int value)
        {
            tamanhoVariavel = value;
        }
    }
}
