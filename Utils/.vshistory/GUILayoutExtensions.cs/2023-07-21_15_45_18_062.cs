using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using InControl;
using XInputDotNetPure;

namespace SevenDTDMono.Utils
{
    public static class CGUILayout
    {
        //private static GUIStyle CfoldoutStyle;
        //private static void Awake()
        //{
        //    CfoldoutStyle = new GUIStyle(GUI.skin.label);
        //    CfoldoutStyle.fontStyle = FontStyle.Bold;
        //    CfoldoutStyle.normal.textColor = Color.black;
        //    CfoldoutStyle.onHover.textColor = Color.blue;
        //}
            //toggles with colorchange
        public static bool Toggle(bool value, string label, params GUILayoutOption[] options)
        {
            Color active = Color.green;
            Color inactive = Color.red;
            Color hover = Color.cyan;
            // Use the provided colors for the toggle
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            toggleStyle.normal.textColor = inactive;                      //WHEN OFF 
            toggleStyle.onNormal.textColor = active;                    //WHEN ON 
            toggleStyle.active.textColor = active;                       //OFF TO ON When pressing/holding 
            toggleStyle.onActive.textColor = inactive;                     // ON TO OFF
            toggleStyle.hover.textColor = hover;                     //OFF
            toggleStyle.onHover.textColor = hover;                   //ON
            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }
        public static bool Toggle(bool value, string label, Color active, Color inactive, params GUILayoutOption[] options)
        {

            Color hover = Color.cyan;
            // Use the provided colors for the toggle
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            toggleStyle.normal.textColor = inactive;                      //WHEN OFF 
            toggleStyle.onNormal.textColor = active;                    //WHEN ON 
            toggleStyle.active.textColor = active;                       //OFF TO ON When pressing/holding 
            toggleStyle.onActive.textColor = inactive;                     // ON TO OFF
            toggleStyle.hover.textColor = hover;                     //OFF
            toggleStyle.onHover.textColor = hover;                   //ON    
            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }
        public static bool Toggle(bool value, string label, Color active, Color inactive, Color hover, params GUILayoutOption[] options)
        {
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            //toggleStyle.onFocused.textColor = activeColor;
            toggleStyle.normal.textColor = inactive;                      //WHEN OFF 
            toggleStyle.onNormal.textColor = active;                    //WHEN ON 
            toggleStyle.active.textColor = active;                       //OFF TO ON When pressing/holding 
            toggleStyle.onActive.textColor = inactive;                     // ON TO OFF
            toggleStyle.hover.textColor = hover;                     //OFF
            toggleStyle.onHover.textColor = hover;                   //ON
            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }
        public static bool Toggle(bool value, string label, Color hover, params GUILayoutOption[] options)
        {
            Color inactive = Color.red;
            Color active = Color.green;
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            //toggleStyle.onFocused.textColor = activeColor;
            toggleStyle.normal.textColor = inactive;                      //WHEN OFF 
            toggleStyle.onNormal.textColor = active;                    //WHEN ON 
            toggleStyle.active.textColor = active;                       //OFF TO ON When pressing/holding 
            toggleStyle.onActive.textColor = inactive;                     // ON TO OFF
            toggleStyle.hover.textColor = hover;                     //OFF
            toggleStyle.onHover.textColor = hover;                   //ON
            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }
        //buttons with colorchange
        public static bool Button(ref bool buttonState, string label, Color active, Color inactive, Color hover, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);

            // Check if the button is currently active or inactive
            Color textColor = buttonState ? active : inactive;
            buttonStyle.normal.textColor = textColor;
            buttonStyle.hover.textColor = hover;
            buttonStyle.active.textColor = textColor;

            // Detect if the button is clicked
            bool isClicked = GUILayout.Button(label, buttonStyle, options);

            // Toggle the button state on each click
            if (isClicked)
            {
                buttonState = !buttonState;
            }

            return isClicked;
        }
        public static bool Button(ref bool buttonState, string label, Color active, Color inactive, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            Color hover = Color.cyan;
            // Check if the button is currently active or inactive
            Color textColor = buttonState ? active : inactive;
            buttonStyle.normal.textColor = textColor;
            buttonStyle.hover.textColor = hover;
            buttonStyle.active.textColor = textColor;

            // Detect if the button is clicked
            bool isClicked = GUILayout.Button(label, buttonStyle, options);

            // Toggle the button state on each click
            if (isClicked)
            {
                buttonState = !buttonState;
            }

            return isClicked;
        }
        public static bool Button(ref bool buttonState, string label, Color hover, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            Color active = Color.green;
            Color inactive = Color.red;
            // Check if the button is currently active or inactive
            Color textColor = buttonState ? active : inactive;
            buttonStyle.normal.textColor = textColor;
            buttonStyle.hover.textColor = hover;
            buttonStyle.active.textColor = textColor;

            // Detect if the button is clicked
            bool isClicked = GUILayout.Button(label, buttonStyle, options);

            // Toggle the button state on each click
            if (isClicked)
            {
                buttonState = !buttonState;
            }

            return isClicked;
        }
        public static bool Button(ref bool buttonState, string label, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            Color active = Color.green;
            Color inactive = Color.red;
            Color hover = Color.cyan;
            // Check if the button is currently active or inactive
            Color textColor = buttonState ? active : inactive;
            buttonStyle.normal.textColor = textColor;
            buttonStyle.hover.textColor = hover;
            buttonStyle.active.textColor = textColor;

            // Detect if the button is clicked
            bool isClicked = GUILayout.Button(label, buttonStyle, options);

            // Toggle the button state on each click
            if (isClicked)
            {
                buttonState = !buttonState;
            }

            return isClicked;
        }

        //button as a trigger button, no toggle color just live  color
        public static bool Button(string label, Color inactive, Color active, Color hover, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = inactive;
            buttonStyle.active.textColor = active;
            buttonStyle.hover.textColor = hover;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);
            return isClicked;
        }
        public static bool Button(string label, Color inactive, Color active, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            Color hover = Color.cyan;
            buttonStyle.normal.textColor = inactive;
            buttonStyle.active.textColor = active;
            buttonStyle.hover.textColor = hover;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);
            return isClicked;
        }
        public static bool Button(string label, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            Color active = Color.green;
            Color inactive = Color.red;
            Color hover = Color.cyan;
            buttonStyle.normal.textColor = inactive;
            buttonStyle.active.textColor = active;
            buttonStyle.hover.textColor = hover;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);
            return isClicked;
        }

        //public static bool Button(string label, params GUILayoutOption[] options)
        //{
        //    Color active = Color.green;
        //    Color inactive = Color.red;
        //    Color hover = Color.cyan;
        //    // Use the provided colors for the toggle
        //    GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        //    buttonStyle.normal.textColor = inactive;                      //WHEN OFF 
        //    buttonStyle.onNormal.textColor = active;                    //WHEN ON 
        //    buttonStyle.active.textColor = active;                       //OFF TO ON When pressing/holding 
        //    buttonStyle.onActive.textColor = inactive;                     // ON TO OFF
        //    buttonStyle.hover.textColor = hover;                     //OFF
        //    buttonStyle.onHover.textColor = hover;                   //ON
        //    bool isClicked = GUILayout.Button(label, buttonStyle, options);
        //    return isClicked;
        //}


        public static int Toolbar(int selected, string[] texts, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            Color active = Color.green;
            Color inactive = Color.red;
            Color hover = Color.cyan;

            // Apply custom text colors
            buttonStyle.normal.textColor = inactive;
            buttonStyle.active.textColor = active;
            buttonStyle.hover.textColor = hover;

            // Draw the toolbar using GUILayout.Toolbar
            int newSelected = GUILayout.Toolbar(selected, texts, buttonStyle, options);

            // If the selected button has changed, return the new selected index
            if (newSelected != selected)
            {
                return newSelected;
            }

            // Otherwise, return the original selected index
            return selected;
        }

        public static int Toolbar(int selected, string[] texts, GUIStyle style, params GUILayoutOption[] options)
        {
            Color active = Color.green;
            Color inactive = Color.red;
            Color hover = Color.cyan;

            style.normal.textColor = inactive;
            style.active.textColor = active;
            style.hover.textColor = hover;

            int newSelected = GUILayout.Toolbar(selected, texts, style, options);

            // If the selected button has changed, return the new selected index
            if (newSelected != selected)
            {
                return newSelected;
            }

            // Otherwise, return the original selected index
            return selected;
        }

        public static bool FoldableMenuVertical(bool display, string label, System.Action content, params GUILayoutOption[] options)
        {
            Color headerColor = display ? Color.green : Color.red;
            Color hoverColor = Color.cyan;

            GUIStyle headerStyle = new GUIStyle(GUI.skin.box);
            headerStyle.fontStyle = FontStyle.Bold;
            headerStyle.fontSize = 12;
            headerStyle.normal.textColor = headerColor;
            headerStyle.hover.textColor = hoverColor;

            Rect rect = GUILayoutUtility.GetRect(16f, 22f, headerStyle);
            GUI.Box(rect, label, headerStyle);

            Event e = Event.current;

            Rect toggleRect = new Rect(rect.x + 4f, rect.y + 2f, 13f, 13f);
            if (e.type == EventType.Repaint)
            {
                DrawFoldoutHorizontal(toggleRect, display);
            }

            if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
            {
                display = !display;
                e.Use();
            }

            if (display)
            {
                GUILayout.BeginVertical(GUI.skin.box);
                content?.Invoke();
                GUILayout.EndVertical();
            }

            return display;
        }
        public static bool FoldableMenuHorizontal(bool display, string label, System.Action content, params GUILayoutOption[] options)
        {
            Color headerColor = display ? Color.yellow : Color.red;
            Color hoverColor = Color.cyan;

            GUIStyle headerStyle = new GUIStyle(GUI.skin.box);
            headerStyle.fontStyle = FontStyle.Italic;
            headerStyle.fontSize = 20;
            headerStyle.normal.textColor = headerColor;
            headerStyle.onHover.textColor = hoverColor;

            Rect rect = GUILayoutUtility.GetRect(50f, 50f, headerStyle);
            GUI.Box(rect, label, headerStyle);

            Event e = Event.current;

            Rect toggleRect = new Rect(rect.x, rect.y, 10f, 10f);
            if (e.type == EventType.Repaint)
            {
                DrawFoldoutHorizontal(toggleRect, display);
            }

            if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
            {
                display = !display;
                e.Use();
            }

            if (display)
            {
                GUILayout.BeginHorizontal(GUI.skin.box);
                content?.Invoke();
                GUILayout.EndHorizontal();
            }

            return display;
        }

        private static void DrawFoldoutHorizontal(Rect position, bool expanded)
        {
            GUIStyle foldoutStyle = new GUIStyle();
            foldoutStyle.fontStyle = FontStyle.Bold;
            foldoutStyle.fontSize = 12;
            foldoutStyle.normal.textColor = expanded ? Color.green : Color.red;

            GUIContent content = new GUIContent(expanded ? "\u25BC" : "\u25BA", "Click to expand/collapse");
            GUI.Label(position, content, foldoutStyle);

            // Draw a horizontal line to separate the header from the content
            Vector2 lineStart = new Vector2(position.x + 15f, position.y + position.height);
            Vector2 lineEnd = new Vector2(lineStart.x + position.width - 15f, lineStart.y);
            DrawHorizontalLine(lineStart, lineEnd, Color.gray);
        }
        private static void DrawFoldout1(Rect position, bool display)
        {
            // Draw a simple foldout arrow on the header
            Texture2D foldoutTex = display ? Texture2D.whiteTexture : Texture2D.blackTexture;
            GUI.DrawTexture(position, foldoutTex);
        }
        private static void DrawHorizontalLine(Vector2 start, Vector2 end, Color color)
        {
            Texture2D lineTex = new Texture2D(1, 1);
            lineTex.SetPixel(0, 0, color);
            lineTex.Apply();

            Matrix4x4 matrixBackup = GUI.matrix;
            float angle = Mathf.Atan2(end.y - start.y, end.x - start.x) * 180 / Mathf.PI;
            GUIUtility.RotateAroundPivot(angle, start);
            GUI.DrawTexture(new Rect(start.x, start.y, (end - start).magnitude, 1), lineTex);
            GUI.matrix = matrixBackup;
        }

    }
}
