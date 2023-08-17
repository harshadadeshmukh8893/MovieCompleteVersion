using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    public class LengthException:Exception
    {
        public LengthException(string message):base(message) { }
    }
}
