using System;

namespace Assets.Scripts.Console
{
    /// <summary>
    /// Ŀ���� �ܼ� API�Դϴ�.
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
        /// �ܼ�â�� ���ϴ�.
        /// </summary>
        public static void Open()
        {
            api.Open();
        }

        /// <summary>
        /// �ܼ�â�� �ݽ��ϴ�.
        /// </summary>
        public static void Close()
        {
            api.Close();
        }

        /// <summary>
        /// ���ڿ��� �ֿܼ� ǥ���մϴ�. ���� ǥ�� ���뿡 �״�� Concat�ϴ� ������ �۵��մϴ�.
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
        /// ���ڿ��� �ֿܼ� ǥ���ϰ� �߰��� �����մϴ�.
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
        /// �Է��� ���ڿ� �� ���� �ֱٿ� �Է��߰� ���� ���� �� ���� ���� �о ���ɴϴ�. ���� ���� �� ���� ���ڿ��� ������ null�� �����մϴ�.
        /// </summary>
        /// <returns></returns>
        public static string ReadLineOrNull()
        {
            ThrowIfNeitherInitializedNorOpen();
            return api.ReadLineOrNull();
        }

        /// <summary>
        /// �ܼ� ����� ����ϴ�.
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
                throw new InvalidOperationException("UnityConsole�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
            }

            if (!api.IsOpen)
            {
                throw new InvalidOperationException("UnityConsole�� ���� �ʾҽ��ϴ�.");
            }
        }
    }
}
