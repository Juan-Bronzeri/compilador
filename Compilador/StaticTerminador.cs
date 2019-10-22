using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    static class StaticTerminador
    {
        static private char terminador;  // the name field

        static public char GetTerminador()
        {
            return terminador;
        }
        static public void SetTerminador(char value)
        {
            terminador = value;
        }
    }
}
