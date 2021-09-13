using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    /// <summary>
    /// 각 Frame 별 Scroe를 관리하기 위한 FrameScore Class
    /// </summary>
    public class Frame
    {
        public readonly int FrameNumber;

        public int FirstTry { get; set; }
        public int SecondTry { get; set; }
        public int ThirdTry { get; set; }

        public string FirstTryStr { 
            get
            {
                if (FirstTry == Const.TryNotYet)
                    return Const.Blank;
                else if (FirstTry == Const.Ten && FrameNumber == Const.LastFrame) //10 Frame 
                    return Const.X;
                else if (FirstTry == Const.Ten)
                    return Const.X;

                return FirstTry.ToString();
            } 
        }

        public string SecondTryStr
        {
            get
            {
                if (SecondTry == Const.TryNotYet)
                    return Const.Blank;

                else if (FirstTry == Const.Ten
                    && SecondTry == Const.Ten && FrameNumber == Const.LastFrame) //10 Frame
                    return Const.X;

                else if (FirstTry != Const.Ten
                    && SecondTry + FirstTry == Const.Ten)
                    return Const.Slash;

                return SecondTry.ToString();
            }
        }

        public string ThirdTryStr
        {
            get
            {
                if (FrameNumber == Const.LastFrame)
                {
                    if (ThirdTry == Const.TryNotYet)
                        return Const.Blank;
                    
                    if (ThirdTry == Const.Ten)
                        return Const.X;
                    return ThirdTry.ToString();
                }
                return Const.Blank;
            }
        }
        public bool IsSpared {
            get
            {
                if (FirstTry != Const.Ten
                && SecondTry + FirstTry == Const.Ten)
                    return true;
                return false;
            }
        }

        public bool IsStrick
        {
            get
            {
                if (FirstTry == Const.Ten) return true;
                return false;
            }
        }
        public bool FinishToSum { get; set; }

        private bool isReadyToSum;
        public bool IsReadyToSum { get { return isReadyToSum; } }
        
        private List<int> sumList = new List<int>();

        private int score = Const.TryNotYet;
        public int Score { get { return score; } }
        public string ScoreStr
        {
            get
            {
                if (score == Const.TryNotYet) return Const.EmptyString;
                return score.ToString();
            }
        }

        public Frame(int frameNumber)
        {
            this.FrameNumber = frameNumber;
            this.FinishToSum = false;
            this.FirstTry = Const.TryNotYet;
            this.SecondTry = Const.TryNotYet;
            this.ThirdTry = Const.TryNotYet;
        }

        public void AddPinCount(int pins)
        {
            sumList.Add(pins);
            Check();
        }

        private void Check()
        {
            if (IsStrick || IsSpared)
            {
                if (sumList.Count == 3)
                    isReadyToSum = true;
            }
            else
            {
                if (sumList.Count == 2)
                    isReadyToSum = true;
            }
        }

        public void SumScore(int number)
        {
            foreach (int i in sumList)
                number += i;
            this.score = number;
        }
    }
}
