using Assets.Scripts;
using Assets.Scripts.Console;
using NUnit.Framework;


public class Test
{

    [Test]
    public void CUI_Test_Spared_1_9()
    {
        UnityConsole.Open();
        BowlingGame bowlingGame = new BowlingGame(new CUIBowlingPrintAPI());
       
        bowlingGame.KnockedDownPins(1);
        bowlingGame.KnockedDownPins(9);
        Assert.AreEqual("1", bowlingGame.Frames[0].FirstTryStr);
        Assert.AreEqual("/", bowlingGame.Frames[0].SecondTryStr);
        Assert.AreEqual(true, bowlingGame.Frames[0].IsSpared);

    }

    [Test]
    public void CUI_Check_Round2_Spated_5_5_5()
    {
        UnityConsole.Open();
        BowlingGame bowlingGame = new BowlingGame(new CUIBowlingPrintAPI());

        bowlingGame.KnockedDownPins(5);
        bowlingGame.KnockedDownPins(5);
        bowlingGame.KnockedDownPins(5);
        Assert.AreEqual("5", bowlingGame.Frames[0].FirstTryStr);
        Assert.AreEqual("/", bowlingGame.Frames[0].SecondTryStr);
        Assert.AreEqual(true, bowlingGame.Frames[0].IsSpared);
        Assert.AreEqual("15", bowlingGame.Frames[0].ScoreStr);

        Assert.AreEqual("5", bowlingGame.Frames[1].FirstTryStr);
    }


    [Test]
    public void CUI_Check_Round2_Spated_0_10_5()
    {
        UnityConsole.Open();
        BowlingGame bowlingGame = new BowlingGame(new CUIBowlingPrintAPI());

        bowlingGame.KnockedDownPins(0);
        bowlingGame.KnockedDownPins(10);
        bowlingGame.KnockedDownPins(5);
        Assert.AreEqual("0", bowlingGame.Frames[0].FirstTryStr);
        Assert.AreEqual("/", bowlingGame.Frames[0].SecondTryStr);
        Assert.AreEqual(true, bowlingGame.Frames[0].IsSpared);
        Assert.AreEqual("15", bowlingGame.Frames[0].ScoreStr);

        Assert.AreEqual("5", bowlingGame.Frames[1].FirstTryStr);
    }

    [Test]
    public void CUI_Check_Round3_Strick_10_10_10()
    {
        UnityConsole.Open();
        BowlingGame bowlingGame = new BowlingGame(new CUIBowlingPrintAPI());
        for (int i = 0; i < 3; i++)
        {
            bowlingGame.KnockedDownPins(10);
        }
        Assert.AreEqual("X", bowlingGame.Frames[0].FirstTryStr);
        Assert.AreEqual(true, bowlingGame.Frames[0].IsStrick);
        Assert.AreEqual(" ", bowlingGame.Frames[0].SecondTryStr);
        Assert.AreEqual("30", bowlingGame.Frames[0].ScoreStr);

        Assert.AreEqual("X", bowlingGame.Frames[1].FirstTryStr);
        Assert.AreEqual(true, bowlingGame.Frames[1].IsStrick);
        Assert.AreEqual(" ", bowlingGame.Frames[1].SecondTryStr);
        Assert.AreEqual("X", bowlingGame.Frames[2].FirstTryStr);
        Assert.AreEqual(true, bowlingGame.Frames[2].IsStrick);
        Assert.AreEqual(" ", bowlingGame.Frames[2].SecondTryStr);
    }

    [Test]
    public void CUI_Check_Round10_All_Strick()
    {
        UnityConsole.Open();
        BowlingGame bowlingGame = new BowlingGame(new CUIBowlingPrintAPI());
        for (int i = 0; i < 12; i++)
        {
            bowlingGame.KnockedDownPins(10);
        }
        Assert.AreEqual("X", bowlingGame.Frames[9].FirstTryStr);
        Assert.AreEqual("X", bowlingGame.Frames[9].SecondTryStr);
        Assert.AreEqual(true, bowlingGame.Frames[9].IsStrick);
        Assert.AreEqual("300", bowlingGame.Frames[9].ScoreStr);
    }

    [Test]
    public void CUI_Check_Round10_Spared()
    {
        UnityConsole.Open();
        BowlingGame bowlingGame = new BowlingGame(new CUIBowlingPrintAPI());
        for (int i = 0; i < 9; i++)
        {
            bowlingGame.KnockedDownPins(10);
        }
        bowlingGame.KnockedDownPins(1);
        bowlingGame.KnockedDownPins(9);
        bowlingGame.KnockedDownPins(5);
        Assert.AreEqual("1", bowlingGame.Frames[9].FirstTryStr);
        Assert.AreEqual("/", bowlingGame.Frames[9].SecondTryStr);
        Assert.AreEqual("5", bowlingGame.Frames[9].ThirdTryStr);
        Assert.AreEqual(true, bowlingGame.Frames[9].IsSpared);
        int score = bowlingGame.Frames[8].Score + 15;
        Assert.AreEqual(score.ToString(), bowlingGame.Frames[9].ScoreStr);
    }


    public void CUI_Check_Round10_0_0()
    {
        UnityConsole.Open();
        BowlingGame bowlingGame = new BowlingGame(new CUIBowlingPrintAPI());
        for (int i = 0; i < 9; i++)
        {
            bowlingGame.KnockedDownPins(10);
        }
        bowlingGame.KnockedDownPins(0);
        bowlingGame.KnockedDownPins(0);
        
        Assert.AreEqual("0", bowlingGame.Frames[9].FirstTryStr);
        Assert.AreEqual("0", bowlingGame.Frames[9].SecondTryStr);
        Assert.AreEqual(true, bowlingGame.Frames[9].IsSpared);
        int score = bowlingGame.Frames[8].Score + 0;
        Assert.AreEqual(score.ToString(), bowlingGame.Frames[9].ScoreStr);
    }
}