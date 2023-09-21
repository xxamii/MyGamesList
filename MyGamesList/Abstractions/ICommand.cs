using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGamesList.Abstractions
{
    public interface ICommand
    {
        public string CommandName { get; }
        void Execute();
    }
}
