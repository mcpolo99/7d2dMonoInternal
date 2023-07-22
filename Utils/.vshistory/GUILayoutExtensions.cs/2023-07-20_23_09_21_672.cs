using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;


namespace SevenDTDMono.Utils
{
    public static class GUILayoutExtensions
    {
        public static bool Toggle(this GUILayout layout, bool value, string label, Color activeColor, Color inactiveColor)
        {
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);

            // Use the provided colors for the toggle
            toggleStyle.normal.textColor = inactiveColor;
            toggleStyle.active.textColor = activeColor;

            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }
    }
    public static class GUILayoutExtensions1
    {
        public static bool ToggleWithColor(bool value, string label, Color activeColor, Color inactiveColor)
        {
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);

            // Use the provided colors for the toggle
            toggleStyle.normal.textColor = inactiveColor;
            toggleStyle.active.textColor = activeColor;

            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }




        // Helper method to create a texture with a specific color
        private static Texture2D MakeTex(int width, int height, Color color)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; i++)
            {
                pix[i] = color;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }
    }
}
