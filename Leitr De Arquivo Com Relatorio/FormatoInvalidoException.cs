using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leitr_De_Arquivo_Com_Relatorio;

internal class FormatoInvalidoException : Exception
{
    public FormatoInvalidoException(string message) : base(message)
    {
    }
}
