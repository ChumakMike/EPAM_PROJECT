using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions {
    public class NoSuchEntityFoundException : Exception {

        public NoSuchEntityFoundException() : base() { }
        public NoSuchEntityFoundException(string msg) : base(msg) { }

    }
}
