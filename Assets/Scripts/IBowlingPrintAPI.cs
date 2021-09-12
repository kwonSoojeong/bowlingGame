using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface IBowlingPrintAPI
    {
        void StartMessage(string message);
        void EndMessage(string message);
        void PrintScroeBoard(List<Frame> frames);
        void PrintError(string error);
        void PrintMessage(string message);
    }
}
