using System.Collections.Generic;


namespace Assets.Scripts
{
    public interface IBowlingPrintAPI
    {
        void StartMessage(string message);
        void EndMessage(string message);
        void PrintScroeBoard(List<Frame> frames);
        void PrintError(string error);
        void PrintMessage(string message);
        void LeftPins(int count);
    }
}
