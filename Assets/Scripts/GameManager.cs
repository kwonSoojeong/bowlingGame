using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Console;
using System;
using Assets.Scripts;

public class GameManager : MonoBehaviour
{
    private BowlingGame bowlingGame;


    void Start()
    {
        Debug.Log("start");

        //BowlingGame set CUI, GUI, 
        // CUI => console input, output system.
        // Gui => intput : Button handle, output Ui table board, <= input Array, score
        

        //isPlayMode ¸é start console button ¼û±ä´Ù
      
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityConsole.IsOpen)
        {
            Debug.Log("key return");

            string input = UnityConsole.ReadLineOrNull();
            
            if (input != null)
            {
                UnityConsole.WriteLine(input);
                try
                {
                    int count = int.Parse(input);
                    bowlingGame.KnockedDownPins(count);
                }
                catch(FormatException ex)
                {
                    UnityConsole.WriteLine("only enter to number");
                }

            }
            
        }
    }
    public void StartConsoleMode()
    {
        
        Debug.Log("Test, start console.");
        UnityConsole.Open();
        UnityConsole.WriteLine("Let's play bowling!");

        StartBowlingGame(new CUIBowlingPrintAPI());
    }
    public void StartBowlingGame(IBowlingPrintAPI printAPI)
    {
        bowlingGame = new BowlingGame(printAPI);
        bowlingGame.KnockedDownPins(5);
    }
}
