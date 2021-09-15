using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Console;

namespace Assets.Scripts
{
    public class CUIBowlingPrintAPI :IBowlingPrintAPI
    {
        public void StartMessage(string message)
        {
            UnityConsole.WriteLine("++ " + message + " ++");
        }
        public void EndMessage(string message)
        {
            UnityConsole.WriteLine(message);
        }

        public void PrintError(string error)
        {
            UnityConsole.WriteLine("<!> " + error);
        }

        public void PrintMessage(string message)
        {
            UnityConsole.Write(message);
        }

        public void PrintScroeBoard(List<Frame> frames)
        {
            // 첫 번째 줄
            UnityConsole.Write(PrintPinsCounts(frames));
            // 두 번째 줄
            UnityConsole.WriteLine(PrintTotalScore(frames));

        }

        private string PrintPinsCounts(List<Frame> frames)
        {
            string msg = "";
            for (int index = 0; index < Const.LastFrame; index++)
            {
                if (index == Const.LastFrame -1)
                    msg += $"{index + 1}:[{frames[index].FirstTryStr},{frames[index].SecondTryStr},{frames[index].ThirdTryStr}]\n"; //ex)"10:[X,X,X]\n"
                else
                    msg += $"{index + 1}:[{frames[index].FirstTryStr},{frames[index].SecondTryStr}]{Const.Blank}"; //ex)"1:[2,/] "

            }
            return msg;
        }

        private string PrintTotalScore(List<Frame> frames)
        {
            string msg = "";
            for (int i = 0; i < Const.LastFrame; i++)
            {
                if (i < Const.LastFrame - 1)
                    msg += $"{Const.Blank}{Const.Blank}[{frames[i].ScoreStr,3}]{Const.Blank}"; //ex)"  [ 11] "
                else
                    msg += $"{Const.Blank}{Const.Blank}{Const.Blank}[{frames[i].ScoreStr,5}]\n"; //ex)"   [  111]\n"
            }
            return msg;
        }

        public void LeftPins(int count)
        {
            UnityConsole.WriteLine($"Please enter between 0 and {count}.");
        }
    }
}
