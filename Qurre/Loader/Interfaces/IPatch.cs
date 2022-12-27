using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loader.Interfaces
{
    internal interface IPatch
    {
        /// <summary>
        /// Entry point for patch. Apply them here!
        /// </summary>
        void Start();
    }
}
