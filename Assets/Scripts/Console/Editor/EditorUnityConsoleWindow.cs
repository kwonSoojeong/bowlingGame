using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Console.Editor
{
    public class EditorUnityConsoleWindow : EditorWindow
    {
        static readonly string ConsoleInputControlName = "ConsoleInput";
        private static Font ConsoleFont;

        private string outputBuffer;
        private string currentInput;
        private Queue<string> inputQueue = new Queue<string>();

        private float scrollPosition;
        private bool needScrollDown;
        private bool needFocusOnInput;
        
        public static EditorUnityConsoleWindow Instance { get; private set; }
        
        private static void InitializeFont()
        {
            if (ConsoleFont == null)
            {
                ConsoleFont = EditorGUIUtility.Load("D2Coding.ttf") as Font;
            }
        }

        public static void Open()
        {
            if (Instance == null)
            {
                Instance = EditorWindow.GetWindow<EditorUnityConsoleWindow>(true, "UnityConsole", true);
            }
            else
            {
                EditorWindow.FocusWindowIfItsOpen<EditorUnityConsoleWindow>();
            }
            
            Instance.needScrollDown = true;
            Instance.needFocusOnInput = true;
            InitializeFont();
        }

        public new static void Close()
        {
            if (Instance != null)
            {
                ((EditorWindow)Instance).Close();
                Instance = null;
            }
        }
        
        void OnGUI()
        {
            using (new EditorGUIFontScope(ConsoleFont))
            {
                if (needScrollDown)
                {
                    scrollPosition = Mathf.Infinity;
                    needScrollDown = false;
                }

                using (var scrollScope = new EditorGUILayout.ScrollViewScope(
                    new Vector2(0, scrollPosition), false, true, 
                    GUIStyle.none, GUI.skin.verticalScrollbar, GUI.skin.scrollView, 
                    GUILayout.ExpandHeight(true)))
                {
                    GUILayout.Label(outputBuffer);

                    scrollPosition = scrollScope.scrollPosition.y;
                }

                if (Event.current.type == EventType.KeyDown 
                    && Event.current.character == '\n' 
                    && GUI.GetNameOfFocusedControl() == ConsoleInputControlName)
                {
                    PushInput(currentInput);
                    currentInput = "";
                    needFocusOnInput = true;

                    // HACK : 이게 false로 들어와있어야 포커스 맞췄을 때 커서가 바로 들어간다.
                    // 텍스트 에디터가 1줄짜리면서 편집중(커서 들어와있는 상태)일 때 엔터 입력이 들어오면 편집 상태를 풀어버리기 때문
                    // 하드코딩된 거라 우회할 방법이 이것밖에...
                    EditorGUIUtility.editingTextField = false;
                }
            
                GUI.SetNextControlName(ConsoleInputControlName);
                currentInput = EditorGUILayout.TextField(currentInput, GUILayout.ExpandWidth(true));

                if (needFocusOnInput)
                {
                    GUI.FocusControl(ConsoleInputControlName);
                    needFocusOnInput = false;
                }
            }
        }

        public void Clear()
        {
            outputBuffer = "";
            RefreshOutput();
        }

        public void AddOutput(string text)
        {
            outputBuffer += text;
            RefreshOutput();
        }

        public string PullInputOrNull()
        {
            if (inputQueue.Count > 0)
            {
                return inputQueue.Dequeue();
            }

            return null;
        }

        void RefreshOutput()
        {
            needScrollDown = true;
            Repaint();
        }

        void PushInput(string input)
        {
            inputQueue.Enqueue(input);
        }
    }
}