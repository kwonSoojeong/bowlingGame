namespace Assets.Scripts.Console
{
    public interface IUnityConsoleAPI
    {
        bool IsOpen { get; }
        void Open();
        void Close();
        void Write(string message);
        string ReadLineOrNull();
        void Clear();
    }
}