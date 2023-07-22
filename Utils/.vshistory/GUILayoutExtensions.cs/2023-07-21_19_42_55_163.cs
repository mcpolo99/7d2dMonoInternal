﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using InControl;
using XInputDotNetPure;
using InControl.UnityDeviceProfiles;

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
        public static int Toolbar1(int selected, string[] texts, GUIStyle style, params GUILayoutOption[] options)
        {
            Color activeColor = Color.green;
            Color inactiveColor = Color.red;
            Color hoverColor = Color.cyan;

            for (int i = 0; i < texts.Length; i++)
            {
                // Check if the current button is selected
                if (i == selected)
                {
                    style.normal.textColor = activeColor;
                    style.hover.textColor = activeColor;
                    style.active.textColor = activeColor;
                }
                else
                {
                    style.normal.textColor = inactiveColor;
                    style.hover.textColor = hoverColor;
                    style.active.textColor = inactiveColor;
                }

                if (GUILayout.Button(texts[i], style, options))
                {
                    // Button clicked, update the selected index
                    selected = i;
                }
            }

            // If the selected button has changed, return the new selected index
            return selected;

        }

        public static int Toolbar2(int selected, string[] texts, GUIStyle style,  params GUILayoutOption[] options)
        {
            Color activeColor = Color.green;
            Color inactiveColor = Color.red;
            Color hoverColor = Color.cyan;

            int newSelected = selected;

            for (int i = 0; i < texts.Length; i++)
            {
                bool isButtonActive = (i == selected);

                // Determine the color based on whether the button is active or not
                Color buttonColor = isButtonActive ? activeColor : inactiveColor;

                // Update the button style's color
                style.normal.textColor = buttonColor;
                style.hover.textColor = hoverColor;

                // Check if the button is clicked
                if (GUILayout.Button(texts[i], style, options))
                {
                    // Button clicked, update the selected index
                    newSelected = i;
                }
            }

            // If the selected button has changed, return the new selected index
            if (newSelected != selected)
            {
                return newSelected;
            }

            // Otherwise, return the original selected index
            return selected;
        }

        public static int CustomToolbar(int selected, string[] texts, GUIStyle style, params GUILayoutOption[] options)
        {
            Color activeColor = Color.green;
            Color inactiveColor = Color.red;
            Color hoverColor = Color.cyan;
            int newSelected = selected;
            int buttonCount = texts.Length;

            for (int i = 0; i < buttonCount; i++)
            {
                Rect rect = GUILayoutUtility.GetRect(new GUIContent(texts[i]), style, options);

                bool isButtonActive = (i == selected);
                Color buttonColor = isButtonActive ? activeColor : inactiveColor;
                style.normal.textColor = buttonColor;
                style.hover.textColor = hoverColor;

                if (GUI.Button(rect, texts[i], style))
                {
                    newSelected = i;
                }
            }

            if (newSelected != selected)
            {
                return newSelected;
            }

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
        public static bool FoldableMenuHorizontal(bool display, string label, System.Action content, float width , params GUILayoutOption[] options)
        {
            GUIStyle headerStyle = new GUIStyle(GUI.skin.box);
            headerStyle.alignment = TextAnchor.MiddleCenter;
            headerStyle.fontSize = 10;
            if (display?true:false) 
            {
                headerStyle.fontStyle = FontStyle.Bold;
                headerStyle.normal.textColor = Color.green;
            }
            else
            {
                headerStyle.fontStyle = FontStyle.Italic;
                headerStyle.normal.textColor = Color.yellow;
            }
            Rect headerRect = GUILayoutUtility.GetRect(width, 20f, headerStyle); // Pass the width value here
            Rect toggleRect = new Rect(headerRect.y, headerRect.x, 10f, 10f);
            GUI.Box(headerRect, label, headerStyle);
            Event e = Event.current;
            if (e.type == EventType.Repaint)
            {
                //DrawFoldoutHorizontal1(toggleRect, display);
            }

            if (e.type == EventType.MouseDown && headerRect.Contains(e.mousePosition))
            {
                display = !display;
                e.Use();
            }

            if (display)
            {
                content?.Invoke();
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
        private static void DrawFoldoutHorizontal1(Rect position, bool display)
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
