using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;


namespace SevenDTDMono.Utils
{
   

    [CreateAssetMenu(fileName = "ToggleColors", menuName = "Custom UI/Toggle Colors")]
    public class ToggleColors : ScriptableObject
    {
        public Color activeColor = Color.green;
        public Color inactiveColor = Color.red;
    }
    //public static class CustomEditorGUILayout
    //{
    //    public static bool ToggleWithColor(bool value, string label, Color activeColor, Color inactiveColor, GUILayoutOption[] options = null)
    //    {
    //        Color currentColor = value ? activeColor : inactiveColor;

    //        GUIStyle toggleStyle = new GUIStyle(EditorStyles.toggle);
    //        toggleStyle.normal.background = MakeTex(2, 2, currentColor);

    //        value = GUILayout.Toggle(value, label, toggleStyle, options);

    //        return value;
    //    }

    //    private static Texture2D MakeTex(int width, int height, Color color)
    //    {
    //        Color[] pix = new Color[width * height];
    //        for (int i = 0; i < pix.Length; i++)
    //        {
    //            pix[i] = color;
    //        }
    //        Texture2D result = new Texture2D(width, height);
    //        result.SetPixels(pix);
    //        result.Apply();
    //        return result;
    //    }
    //}
}
