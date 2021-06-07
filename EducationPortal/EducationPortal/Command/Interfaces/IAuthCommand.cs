using System;
using System.Collections.Generic;
using System.Text;

namespace EducationPortal.Command.Interfaces
{
    public interface IAuthCommand
    {
        public int CommandNumber { get; }
        public string CommandName { get; }
        void Execute();
    }
}
