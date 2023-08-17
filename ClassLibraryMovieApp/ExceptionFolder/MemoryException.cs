using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.ExceptionFolder
{
    public class MemoryException:Exception
    {
        public MemoryException(string message):base(message){ }
    }
}
