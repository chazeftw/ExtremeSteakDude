﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeSteakDude.Commands
{
    interface IUndoRedoCommand
    {
        void Execute();
        void Undo();
    }
}
