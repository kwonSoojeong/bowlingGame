using UnityEditor;

namespace Assets.Scripts.Console.Editor
{
    [InitializeOnLoad]
    public class EditorUnityConsoleAPI : IUnityConsoleAPI
    {
        static EditorUnityConsoleAPI()
        {
            UnityConsole.Init(new EditorUnityConsoleAPI());
        }

        public bool IsOpen => EditorUnityConsoleWindow.Instance != null;
        public void Open() => EditorUnityConsoleWindow.Open();
        public void Close() => EditorUnityConsoleWindow.Close();
        public void Write(string message) => EditorUnityConsoleWindow.Instance.AddOutput(message);
        public string ReadLineOrNull() => EditorUnityConsoleWindow.Instance.PullInputOrNull();
        public void Clear() => EditorUnityConsoleWindow.Instance.Clear();
    }
}
