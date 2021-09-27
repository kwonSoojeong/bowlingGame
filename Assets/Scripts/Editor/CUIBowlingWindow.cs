
using Assets.Scripts.Console;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
#if UNITY_EDITOR
    class CUIBowlingWindow : EditorWindow
    {
        private BowlingGame bowlingGame;

        [MenuItem("Window/Start Bowling")]
        static void Init()
        {
            GetWindow<CUIBowlingWindow>(typeof(CUIBowlingWindow));
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField("아래의 버튼을 클릭하여 콘솔볼링게임을 시작하세요");

            if (GUILayout.Button("Start Game"))
            {
                if (!UnityConsole.IsOpen)
                {
                    UnityConsole.Open();
                    bowlingGame = new BowlingGame(new CUIBowlingPrintAPI());
                }
            }
        }
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
                        bowlingGame.KnockedDownPins(count);
                    }
                    catch (FormatException)
                    {
                        UnityConsole.WriteLine("<!> only enter to number");
                    }
                }
            }

        }
        private void OnDestroy()
        {
            if (UnityConsole.IsOpen)
            {
                UnityConsole.Close();
            }
        }

    }
#endif
}
