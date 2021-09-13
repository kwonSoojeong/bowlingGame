using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BowlingGame
{
    /// <summary>
    /// 투구 별 넘어진 핀의 갯 수 배열
    /// </summary>
    private int arrayIndex = 0;
    private int leftPins;
    public int LeftPins { get { return leftPins; } }

    /// <summary>
    /// Frame 별 Score 계산을 위한 List
    /// </summary>
    private List<Frame> frames;
    private IBowlingPrintAPI printAPI;

    private void Init(IBowlingPrintAPI printAPI)
    {
        this.printAPI = printAPI;
    }
   
   public BowlingGame (IBowlingPrintAPI printAPI)
    {
        leftPins = 10;
        frames = new List<Frame>();
        for (int i = 0; i < 10; i++)
        {
            frames.Add(new Frame(i + 1));
        }
        Init(printAPI);

        printAPI.StartMessage("Let's Play Bowling game!");
        printAPI.StartMessage("Please enter between 0 and 10.");
    }

    public void KnockedDownPins(int count)
    {
        if (CheckGameEnd() || !ValidateCount(count)) return;

        UpdatePins(count);
        UpdateFrameArray(count);

        printAPI.PrintScroeBoard(frames);

        MoveToNextTurn(count);

        CheckGameEnd();
    }

    private bool ValidateCount(int count)
    {
        if (count < 0 || count > leftPins)
        {
            printAPI.PrintError($" Please enter between 0 and {leftPins}. Try argin.");
            return false;
        }
        return true;
    }

    private void UpdatePins(int count)
    {
        leftPins -= count;
        //마지막 턴이거나, 핀이 다 쓰러지면 새로 채운다.
        if (arrayIndex % 2 == 1 || leftPins == 0)
            leftPins = Const.Ten;
        printAPI.LeftPins(leftPins);
    }

    private bool CheckGameEnd()
    {
        if (frames[Const.LastFrame - 1].IsSpared
                    || frames[Const.LastFrame - 1].IsStrick)
        {
            if (arrayIndex > Const.MexIndex)
            {
                printAPI.EndMessage($"++ Game is done! ++");
                return true;
            }
            return false;
        }
        else
        {
            if (arrayIndex > Const.MexIndex - 1)
            {
                printAPI.EndMessage("++ Game is done! ++");
                return true;
            }
            return false;
        }
    }

    private void UpdateFrameArray(int count)
    {
        if (arrayIndex % 2 == 0)
        {     
            if (arrayIndex == Getindex(10, 3))
                frames[GetRound(arrayIndex) - 1].ThirdTry = count;
            else
                frames[GetRound(arrayIndex) - 1].FirstTry = count;   
        }
        else
        {
            frames[GetRound(arrayIndex) - 1].SecondTry = count;
        }

        //Add and Sum each Frame to total scroe.
        for (int i = 0; i < frames.Count; i++)
        {
            Frame frameScore = frames[i];
            if (i < GetRound(arrayIndex) && !frameScore.FinishToSum)
                frameScore.AddPinCount(count);

            if (!frameScore.FinishToSum && frameScore.IsReadyToSum)
            {
                frameScore.SumScore(GetScroe(i));
                frameScore.FinishToSum = true;
            }
        }
    }

    private void MoveToNextTurn(int count)
    {
        //스트라이크시 다음 투구를 건너뛰고 다음 프레임으로 넘어갑니다.
        if (count == Const.Ten && arrayIndex < Getindex(Const.LastFrame, 1))
            arrayIndex += 2;
        else
            arrayIndex++;
    }

    private int GetRound(int index)
    {
        if (index == 0) return 1;
        if (index > 9 * 2) return 10;
        return (index / 2) + 1;
    }

    private int Getindex(int round, int num)
    {
        if (round == 1)
            return 0 + (num - 1);

        return ((round - 1) * 2) + (num - 1);
    }

    private int GetScroe(int round)
    {
        if (round < 1) return 0;
        return frames[round - 1].Score;
    }
}

static class Const
{
    public const int TryNotYet = -1;
    public const int Zero = 0;
    public const int Ten = 10;
    public const int MexIndex = 20;
    public const int LastFrame = 10;
    public const string Blank = " ";
    public const string Comma = ",";
    public const string X = "X";
    public const string Slash = "/";
    public const string EmptyString = "";
}
