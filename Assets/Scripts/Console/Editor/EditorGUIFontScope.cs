using System;
using UnityEngine;

namespace Assets.Scripts.Console.Editor
{
    public struct EditorGUIFontScope : IDisposable
    {
        private readonly Font oldFont;

        public EditorGUIFontScope(Font font)
        {
            oldFont = GUI.skin.font;
            GUI.skin.font = font;
        }

        public void Dispose()
        {
            GUI.skin.font = oldFont;
        }
    }
}