using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamove
{
    public interface ILog
    {
        void Save(string message);
        void PrintLogger();
        void Write();
    }
}
