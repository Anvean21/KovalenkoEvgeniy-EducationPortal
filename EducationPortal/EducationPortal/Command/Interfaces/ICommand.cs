using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Command
{
    public interface ICommand
    {
        public int CommandNumber { get; }
        public string CommandName { get; }
        void Execute();
    }
}
