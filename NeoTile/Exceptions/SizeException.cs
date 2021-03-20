using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoTile.Exceptions
{
    public class SizeException : Exception
    {
        public SizeException(string message) : base(message)
        {

        }
    }
}
