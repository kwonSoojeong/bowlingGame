using System;

namespace Assets.Scripts.Console
{
    /// <summary>
    /// 커스텀 콘솔 API입니다.
    /// </summary>
    public static class UnityConsole
    {
        private static IUnityConsoleAPI api;

        public static bool IsOpen => api?.IsOpen ?? false;

        public static void Init(IUnityConsoleAPI api)
        {
            UnityConsole.api = api;
        }

        /// <summary>
        /// 콘솔창을 엽니다.
        /// </summary>
        public static void Open()
        {
            api.Open();
        }

        /// <summary>
        /// 콘솔창을 닫습니다.
        /// </summary>
        public static void Close()
        {
            api.Close();
        }

        /// <summary>
        /// 문자열을 콘솔에 표시합니다. 현재 표시 내용에 그대로 Concat하는 식으로 작동합니다.
        /// </summary>
        /// <param name="message"></param>
        public static void Write(string message)
        {
            ThrowIfNeitherInitializedNorOpen();
            api.Write(message);
        }

        public static void Write(string format, params object[] args)
        {
            Write(string.Format(format, args));
        }

        /// <summary>
        /// 문자열을 콘솔에 표시하고 추가로 개행합니다.
        /// </summary>
        /// <param name="message"></param>
        public static void WriteLine(string message)
        {
            Write(message + "\n");
        }

        public static void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(format, args));
        }

        /// <summary>
        /// 입력한 문자열 중 제일 최근에 입력했고 아직 읽은 적 없는 것을 읽어서 얻어옵니다. 만약 읽은 적 없는 문자열이 없으면 null를 리턴합니다.
        /// </summary>
        /// <returns></returns>
        public static string ReadLineOrNull()
        {
            ThrowIfNeitherInitializedNorOpen();
            return api.ReadLineOrNull();
        }

        /// <summary>
        /// 콘솔 출력을 지웁니다.
        /// </summary>
        public static void Clear()
        {
            ThrowIfNeitherInitializedNorOpen();
            api.Clear();
        }

        static void ThrowIfNeitherInitializedNorOpen()
        {
            if (api == null)
            {
                throw new InvalidOperationException("UnityConsole를 초기화하지 않았습니다.");
            }

            if (!api.IsOpen)
            {
                throw new InvalidOperationException("UnityConsole를 열지 않았습니다.");
            }
        }
    }
}
