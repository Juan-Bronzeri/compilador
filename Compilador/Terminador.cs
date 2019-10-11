using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    static class Terminador
    {
        static private string terminador;  // the name field

        static public string GetTerminador()
        {
            return terminador;
        }
        static public void SetTerminador(string value)
        {
            terminador = value;
        }
    }
}
