using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Console;
using System;
using Assets.Scripts;

public class GameManager : MonoBehaviour
{
    private BowlingGame bowlingGame;
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        Debug.Log("start");

        //BowlingGame set CUI, GUI, 
        // CUI => console input, output system.
        // Gui => intput : Button handle, output Ui table board, <= input Array, score


        if (Application.isPlaying)
        {
            //isPlayMode ¸é start console button ¼û±ä´Ù
            GameObject.Find("CUI").SetActive(false);

            GUIBowlingPrintAPI gUIBowlingPrintAPI = GameObject.Find("ScoreBoard").GetComponent<GUIBowlingPrintAPI>();
            StartGuiMode(gUIBowlingPrintAPI);
        }
      
    }

    
    // Update is called once per frame
    void Update()
    {
        if (UnityConsole.IsOpen)
        {
            string input = UnityConsole.ReadLineOrNull();
            
            if (input != null)
            {
                UnityConsole.WriteLine(input);
                try
                {
                    int count = int.Parse(input);
                    InputPins(count);
                }
                catch (FormatException)
                {
                    UnityConsole.WriteLine("<!> only enter to number");
                }
            }
        }
    }
    public void StartConsoleMode()
    {
        Debug.Log("Test, start console.");
        UnityConsole.Open();
        StartBowlingGame(new CUIBowlingPrintAPI());
    }

    private void StartGuiMode(GUIBowlingPrintAPI printApi)
    {
        Debug.Log("Test, start GUI.");
        StartBowlingGame(printApi);
    }


    private void StartBowlingGame(IBowlingPrintAPI printAPI)
    {
        bowlingGame = new BowlingGame(printAPI);
        Debug.Log("Test, new Bowling Game");
    }

    public void InputPins(int count)
    {
        Debug.Log("Test, InputPins" + count);
        bowlingGame.KnockedDownPins(count);
    }
}
