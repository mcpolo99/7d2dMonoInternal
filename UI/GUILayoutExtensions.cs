using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using InControl;
using XInputDotNetPure;
using InControl.UnityDeviceProfiles;
using static PassiveEffect;
using JetBrains.Annotations;
using static Setting;

namespace SevenDTDMono.Utils
{
   
    public static class CGUILayout
    {
        private static Color Active = Color.green;
        private static Color Inactive = Color.yellow;
        private static Color Hover = Color.cyan;
        private static bool isResizing = false;
        private static Vector2 mouseStartPos;
        private static Rect originalWinRect;

        #region BeginHorizontal
        public static void BeginHorizontal(GUIContent content, GUIStyle style, System.Action contentActions, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(content, style, options);
            contentActions?.Invoke();
            GUILayout.EndHorizontal();
        }
        public static void BeginHorizontal(string _string, GUIStyle style, System.Action contentActions, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(_string, style, options);
            contentActions?.Invoke();
            GUILayout.EndHorizontal();
        }
        public static void BeginHorizontal(GUIStyle style, System.Action contentActions, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(style, options);
            contentActions?.Invoke();
            GUILayout.EndHorizontal();
        }
        public static void BeginHorizontal(System.Action contentActions, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(options);
            contentActions?.Invoke();
            GUILayout.EndHorizontal();
        }
        public static void BeginHorizontal(GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginHorizontal(style, options);
            //contentActions?.Invoke();
            GUILayout.EndHorizontal();
        }
        #endregion

        #region BeginVertical
        public static void BeginVertical(GUIContent content, GUIStyle style, System.Action contentActions, params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(content, style, options);
            contentActions?.Invoke();
            GUILayout.EndVertical();
        }
        public static void BeginVertical(string _string, GUIStyle style, System.Action contentActions, params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(_string, style, options);
            contentActions?.Invoke();
            GUILayout.EndVertical();
        }
        public static void BeginVertical(GUIStyle style, System.Action contentActions, params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(style, options);
            contentActions?.Invoke();
            GUILayout.EndVertical();
        }
        public static void BeginVertical(System.Action contentActions, params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(options);
            contentActions?.Invoke();
            GUILayout.EndVertical();
        }
        public static void BeginVertical(GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.BeginVertical(style, options);
            //contentActions?.Invoke();
            GUILayout.EndVertical();
        }
        #endregion

        public static Dictionary<string, bool> SBu = new Dictionary<string, bool>();
        public static Dictionary<string, bool> RBu = new Dictionary<string, bool>();


        //public static void BeginHorizontal(System.Action content, params GUILayoutOption[] options)
        //{
        //    GUILayout.BeginHorizontal(options);
        //    content?.Invoke();
        //    GUILayout.EndHorizontal();
        //}
        public static void BeginVertical(System.Action content)
        {
            GUILayout.BeginVertical();
            content?.Invoke();
            GUILayout.EndVertical();
        }






        public static bool Toggle(bool value, string label, params GUILayoutOption[] options)
        {
            // Use the provided colors for the toggle
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            toggleStyle.normal.textColor = Inactive;                      //WHEN OFF 
            toggleStyle.onNormal.textColor = Active;                    //WHEN ON 
            toggleStyle.active.textColor = Active;                       //OFF TO ON When pressing/holding 
            toggleStyle.onActive.textColor = Inactive;                     // ON TO OFF
            toggleStyle.hover.textColor = Hover;                     //OFF on offstate
            toggleStyle.onHover.textColor = Hover;                   //ON  on onState
            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }
        public static bool Toggle(bool value, string label, Color active, Color inactive, params GUILayoutOption[] options)
        {
            // Use the provided colors for the toggle
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            toggleStyle.normal.textColor = inactive;                      //WHEN OFF 
            toggleStyle.onNormal.textColor = active;                    //WHEN ON 
            toggleStyle.active.textColor = active;                       //OFF TO ON When pressing/holding 
            toggleStyle.onActive.textColor = inactive;                     // ON TO OFF
            toggleStyle.hover.textColor = Hover;                     //OFF
            toggleStyle.onHover.textColor = Hover;                   //ON    
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

            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            //toggleStyle.onFocused.textColor = activeColor;
            toggleStyle.normal.textColor = Inactive;                      //WHEN OFF 
            toggleStyle.onNormal.textColor = Active;                    //WHEN ON 
            toggleStyle.active.textColor = Active;                       //OFF TO ON When pressing/holding 
            toggleStyle.onActive.textColor = Inactive;                     // ON TO OFF
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

            // Toggle the button state on each click // the buttonstate kan be used to toogle a bool on/off
            if (isClicked)
            {
                buttonState = !buttonState;
            }

            return isClicked;
        }
        public static bool Button(ref bool buttonState, string label, Color active, Color inactive, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            // Check if the button is currently active or inactive
            Color textColor = buttonState ? active : inactive;
            buttonStyle.normal.textColor = textColor;
            buttonStyle.hover.textColor = Hover;
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
            // Check if the button is currently active or inactive
            Color textColor = buttonState ? Active : Inactive;
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
            // Check if the button is currently active or inactive
            Color textColor = buttonState ? Active : Inactive;
            buttonStyle.normal.textColor = textColor;
            buttonStyle.hover.textColor = Hover;
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
            buttonStyle.normal.textColor = inactive;
            buttonStyle.active.textColor = active;
            buttonStyle.hover.textColor = Hover;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);
            return isClicked;
        }
        public static bool Button(string label, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = Inactive;
            buttonStyle.active.textColor = Active;
            buttonStyle.hover.textColor = Hover;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);
            return isClicked;
        }

        public static bool Button(string label, Action onClickAction, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = Inactive;
            buttonStyle.active.textColor = Active;
            buttonStyle.hover.textColor = Hover;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);

            if (isClicked && onClickAction != null)
            {
                onClickAction.Invoke();
            }

            return isClicked;
        }
        public static bool Button(string label, Action onClickAction, ref bool toggle, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = toggle ? Active : Inactive;
            buttonStyle.active.textColor = Active;
            buttonStyle.hover.textColor = Hover;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);

            if (isClicked && onClickAction != null)
            {
                onClickAction.Invoke();
                toggle = !toggle; // Toggle the bool value when the button is clicked
            }

            return isClicked;
        }
        public static bool Button(string label, ref bool toggle, Action onClickAction = null, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = toggle ? Active : Inactive;
            buttonStyle.active.textColor = Active;
            buttonStyle.hover.textColor = Hover;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);

            if (isClicked)
            {
                toggle = !toggle; // Toggle the bool value when the button is clicked

                if (onClickAction != null)
                {
                    onClickAction.Invoke();
                }
            }

            return isClicked;
        }
        public static bool Button(string label, bool toggle, Action onClickAction = null, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = toggle ? Active : Inactive;
            buttonStyle.active.textColor = Active;
            buttonStyle.hover.textColor = Hover;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);

            if (isClicked)
            {
                toggle = !toggle; // Toggle the bool value when the button is clicked

                if (onClickAction != null)
                {
                    onClickAction.Invoke();
                }
            }

            return isClicked;
        }

        public static bool SButton(string label, string boolKey, Action onClickAction = null, params GUILayoutOption[] options)
        {
            if (!SB.ContainsKey(boolKey))
            {
                SB[boolKey] = false;
            }
            bool toggle = SB.ContainsKey(boolKey) ? SB[boolKey] : false;
            bool isClicked = CGUILayout.Button(label, SB[boolKey], onClickAction, options);
            if (isClicked)
            {
                SB[boolKey] = !toggle; // Toggle the bool value when the button is clicked
            }
            return SB[boolKey];
        }
        public static bool RButton(string label, string boolKey, Action onClickAction = null, params GUILayoutOption[] options)
        {
            bool toggle = RB.ContainsKey(boolKey) ? RB[boolKey] : false;
            bool isClicked = CGUILayout.Button(label, RB[boolKey], onClickAction, options);
            if (isClicked)
            {
                RB[boolKey] = !toggle; // Toggle the bool value when the button is clicked
            }
            return RB[boolKey];
        }

        public static bool Button(string label, Dictionary<string, bool> boolDictionary, string key, Action onClickAction = null, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = boolDictionary[key] ? Active : Inactive;
            buttonStyle.active.textColor = Active;
            buttonStyle.hover.textColor = Hover;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);

            if (isClicked)
            {
                boolDictionary[key] = !boolDictionary[key]; // Toggle the bool value when the button is clicked

                if (onClickAction != null)
                {
                    onClickAction.Invoke();
                }
            }

            return isClicked;
        }

        public static bool Button(string label, ref int currentIndex, params GUILayoutOption[] buttonOptions)//Cycle enumlist item
        {
            // Display the button with the label and the current enum value as buttonText.
            bool buttonPressed = GUILayout.Button(label + " " + ((Enum)System.Enum.ToObject(typeof(ValueModifierTypes), currentIndex)).ToString(), buttonOptions);

            // If the button is pressed, increment the index and loop back to the beginning if needed.
            if (buttonPressed)
            {
                currentIndex = (currentIndex + 1) % System.Enum.GetValues(typeof(ValueModifierTypes)).Length;
            }

            // Return the buttonPressed state.
            return buttonPressed;
        }
        public static void Button(ref Dictionary<string, bool> buttonStates, string label, System.Action onClickAction = null, params GUILayoutOption[] options)
        {
            // Check if the button label exists in the dictionary, and if not, add it with the default value.
            if (!buttonStates.ContainsKey(label))
            {
                buttonStates[label] = false; // Set the default value for the new button.
            }

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = buttonStates[label] ? Color.green : Color.red; // Set different colors for the toggle state
            buttonStyle.active.textColor = Color.green;
            buttonStyle.hover.textColor = Color.green;

            bool isClicked = GUILayout.Button(label, buttonStyle,options);

            if (isClicked)
            {
                buttonStates[label] = !buttonStates[label]; // Toggle the bool value when the button is clicked

                if (onClickAction != null)
                {
                    onClickAction.Invoke();
                }
            }
        }




        public static bool Button1(string label, Action[] onClickActions, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = Inactive;
            buttonStyle.active.textColor = Active;
            buttonStyle.hover.textColor = Hover;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);

            if (isClicked && onClickActions != null)
            {
                foreach (var onClickAction in onClickActions)
                {
                    onClickAction?.Invoke();
                }
            }

            return isClicked;
        }



        public static float HorizontalScrollbarWithLabel(string label, ref float Modifier, float rightMaxValue)
        {
            GUIStyle Labelstyle = new GUIStyle(GUI.skin.label);
            Labelstyle.alignment = TextAnchor.LowerCenter;
            Labelstyle.fontSize = 13;
            Labelstyle.padding = new RectOffset(0, 0, -4, 0);

            GUILayout.BeginHorizontal();
            GUILayout.Label(label, Labelstyle, GUILayout.MaxWidth(100));
            //GUILayout.Label("Attacks/minute", Labelstyle, GUILayout.MaxWidth(60));
            Modifier = GUILayout.HorizontalScrollbar(Modifier, 0f, 0f, rightMaxValue);
            GUILayout.Label(Modifier.ToString("F1"), Labelstyle, GUILayout.MaxWidth(40));
            GUILayout.EndHorizontal();

            return Modifier;
        }















        public static int Toolbar4(int selected, string[] texts, GUIStyle style, params GUILayoutOption[] options)
        {
            int newSelected = selected;
            int buttonCount = texts.Length;

            GUILayout.BeginHorizontal();
            {
                for (int i = 0; i < buttonCount; i++)
                {
                    Rect rect = GUILayoutUtility.GetRect(new GUIContent(texts[i]), style, options);

                    bool isButtonActive = (i == selected);
                    Color buttonColor = isButtonActive ? Active : Inactive;
                    style.normal.textColor = buttonColor;
                    style.hover.textColor = Hover;

                    if (GUI.Button(rect, texts[i], style))
                    {
                        newSelected = i;
                    }
                }
            }
            GUILayout.EndHorizontal();
            if (newSelected != selected)
            {
                return newSelected;
            }

            return selected;
        }
        public static bool FoldableMenuHorizontal(bool display, string label, System.Action content, float width, params GUILayoutOption[] options)
        {
            GUIStyle headerStyle = new GUIStyle(GUI.skin.box);
            headerStyle.alignment = TextAnchor.MiddleCenter;
            headerStyle.fontSize = 15;
            if (display ? true : false)
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
            Rect toggleRect = new Rect(headerRect.y, headerRect.x, 10f, 20f);

            float lineHeight = 10f;
            Rect lineRect = new Rect(headerRect.x, headerRect.y + (headerRect.height - lineHeight) * 0.5f, 30, lineHeight);
            DrawLine(lineRect, display ? Color.green : Color.yellow);

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
        public static void DropDownForMethods(string label, System.Action content, ref bool toggle, params GUILayoutOption[] options)
        {

            GUIStyle headerStyle = new GUIStyle(GUI.skin.button);
            //GUIStyle headerStyle = new GUIStyle(GUI.skin.box);
            headerStyle.alignment = TextAnchor.MiddleRight;
            headerStyle.fontSize = 15;

            if (!toggle)
            {
                headerStyle.fontStyle = FontStyle.Bold;
                //headerStyle.normal.textColor = Color.green;
            }
            else
            {
                headerStyle.fontStyle = FontStyle.BoldAndItalic;
                //headerStyle.normal.textColor = Color.yellow;
            }
            // GUIContent content1 = new GUIContent(toggle ? "\u25BC" : "\u25BA", "Click to expand/collapse");

            Rect headerRect = GUILayoutUtility.GetRect(300, 30f, headerStyle); // Pass the width value here

            //Rect headerRect = GUILayoutUtility.GetRect(content1, headerStyle); // Pass the width value here
            //Rect headerRect1 = GUILayoutUtility.GetRect(100, 10); // Pass the width value here
            float lineHeight = 10f;
            Rect lineRect = new Rect(headerRect.x, headerRect.y + (headerRect.height - lineHeight) * 0.5f, 30, lineHeight);
            DrawLine(lineRect, toggle ? Color.green : Color.yellow);
            GUI.Box(headerRect, label, headerStyle);
            if (Event.current.type == EventType.MouseDown && headerRect.Contains(Event.current.mousePosition))
            {
                toggle = !toggle;
                Event.current.Use();
            }

            if (toggle)
            {

                CGUILayout.BeginVertical(GUI.skin.box, () =>
                {

                    content?.Invoke();

                });



            }
        }


















        public static bool CustomDropDown(string label, System.Action content, float width, params GUILayoutOption[] options)
        {
            //for every press toggle on and off for the customdrop down
            bool toggle = false;
            GUIStyle headerStyle = new GUIStyle(GUI.skin.box);
            headerStyle.alignment = TextAnchor.MiddleCenter;
            headerStyle.fontSize = 15;
            if (toggle ? true : false)
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
            Rect toggleRect = new Rect(headerRect.y, headerRect.x, 10f, 20f);
            GUI.Box(headerRect, label, headerStyle);
            Event e = Event.current;
            if (e.type == EventType.Repaint)
            {
                //DrawFoldoutHorizontal1(toggleRect, display);
            }

            if (e.type == EventType.MouseDown && headerRect.Contains(e.mousePosition))
            {
                toggle = !toggle;
                e.Use();
            }

            if (toggle)
            {
                content?.Invoke();
            }

            return toggle;
        }

        public static bool CustomDropDown(bool toggle, string label, System.Action content, params GUILayoutOption[] options)
        {
            //for every press toggle on and off for the customdrop down

            GUIStyle headerStyle = new GUIStyle(GUI.skin.box);
            headerStyle.alignment = TextAnchor.MiddleCenter;
            headerStyle.fontSize = 15;
            if (toggle ? true : false)
            {
                headerStyle.fontStyle = FontStyle.Bold;
                headerStyle.normal.textColor = Color.green;
            }
            else
            {
                headerStyle.fontStyle = FontStyle.Italic;
                headerStyle.normal.textColor = Color.yellow;
            }
            Rect headerRect = GUILayoutUtility.GetRect(30, 20f, headerStyle); // Pass the width value here
            Rect toggleRect = new Rect(headerRect.y, headerRect.x, 10f, 20f);
            GUI.Box(headerRect, label, headerStyle);
            Event e = Event.current;
            if (e.type == EventType.Repaint)
            {
                //DrawFoldoutHorizontal1(toggleRect, display);
            }

            if (e.type == EventType.MouseDown && headerRect.Contains(e.mousePosition))
            {
                toggle = !toggle;
                e.Use();
            }

            if (toggle)
            {
                content?.Invoke();
            }

            return toggle;
        }


        public static void CustomDropDown(string label, System.Action content, ref bool toggle, params GUILayoutOption[] options)
        {
            GUIStyle headerStyle = new GUIStyle(GUI.skin.box);
            headerStyle.alignment = TextAnchor.MiddleCenter;
            headerStyle.fontSize = 15;

            if (toggle)
            {
                headerStyle.fontStyle = FontStyle.Bold;
                headerStyle.normal.textColor = Color.green;
            }
            else
            {
                headerStyle.fontStyle = FontStyle.Italic;
                headerStyle.normal.textColor = Color.yellow;
            }

            Rect headerRect = GUILayoutUtility.GetRect(30, 20f, headerStyle); // Pass the width value here
            GUI.Box(headerRect, label, headerStyle);

            if (Event.current.type == EventType.MouseDown && headerRect.Contains(Event.current.mousePosition))
            {
                toggle = !toggle;
                Event.current.Use();
            }

            if (toggle)
            {
                content?.Invoke();
            }
        }


        public static void BeginScrollView(Vector2 vector2, System.Action content, params GUILayoutOption[] options)
        {
            
            vector2 = GUILayout.BeginScrollView(vector2,options);
            {
                content?.Invoke();
            }
            GUILayout.EndScrollView();
        }


        public static void DrawLine(Rect rect, Color color)
        {
            GUI.color = color;
            GUI.DrawTexture(rect, Texture2D.whiteTexture);
            GUI.color = Color.white;
        }









        //public static Rect Window(int windowID, Rect windowRect, GUI.WindowFunction drawWindowContents, string title)
        //{
        //    GUILayout.BeginArea(windowRect, title, GUI.skin.window);
        //    drawWindowContents(windowID);

        //    // Add a resizing handle at the bottom-right corner
        //    Rect handleRect = new Rect(windowRect.width - 20, windowRect.height - 20, 20, 20);
        //    GUI.DrawTexture(handleRect, Texture2D.whiteTexture);

        //    // Check if the mouse is over the handle and handle resizing logic
        //    Event e = Event.current;
        //    if (e.type == EventType.MouseDown && handleRect.Contains(e.mousePosition))
        //    {
        //        isResizing = true;
        //        mouseStartPos = e.mousePosition;
        //        originalWinRect = windowRect;
        //        e.Use();
        //    }
        //    else if (e.type == EventType.MouseDrag && isResizing)
        //    {
        //        Vector2 offset = e.mousePosition - mouseStartPos;
        //        windowRect.width = Mathf.Max(originalWinRect.width + offset.x, 100);
        //        windowRect.height = Mathf.Max(originalWinRect.height + offset.y, 100);
        //        e.Use();
        //    }
        //    else if (e.type == EventType.MouseUp && isResizing)
        //    {
        //        isResizing = false;
        //        e.Use();
        //    }

        //    GUILayout.EndArea();
        //    return windowRect;
        //}


        //public static bool FoldableMenuVertical(bool display, string label, System.Action content, params GUILayoutOption[] options)
        //{
        //    Color headerColor = display ? Active : Inactive;
        //    Color hoverColor = Hover;

        //    GUIStyle headerStyle = new GUIStyle(GUI.skin.box);
        //    headerStyle.fontStyle = FontStyle.Bold;
        //    headerStyle.fontSize = 12;
        //    headerStyle.normal.textColor = headerColor;
        //    headerStyle.hover.textColor = hoverColor;

        //    Rect rect = GUILayoutUtility.GetRect(16f, 22f, headerStyle);
        //    GUI.Box(rect, label, headerStyle);

        //    Event e = Event.current;

        //    Rect toggleRect = new Rect(rect.x + 4f, rect.y + 2f, 13f, 13f);
        //    if (e.type == EventType.Repaint)
        //    {
        //        DrawFoldoutHorizontal(toggleRect, display);
        //    }

        //    if (e.type == EventType.MouseDown && rect.Contains(e.mousePosition))
        //    {
        //        display = !display;
        //        e.Use();
        //    }

        //    if (display)
        //    {
        //        GUILayout.BeginVertical(GUI.skin.box);
        //        content?.Invoke();
        //        GUILayout.EndVertical();
        //    }

        //    return display;
        //}



        //public static int Toolbar(int selected, string[] texts, params GUILayoutOption[] options)
        //{
        //    GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
        //    // Apply custom text colors
        //    buttonStyle.normal.textColor = Inactive;
        //    buttonStyle.active.textColor = Active;
        //    buttonStyle.hover.textColor = Hover;

        //    // Draw the toolbar using GUILayout.Toolbar
        //    int newSelected = GUILayout.Toolbar(selected, texts, buttonStyle, options);

        //    // If the selected button has changed, return the new selected index
        //    if (newSelected != selected)
        //    {
        //        return newSelected;
        //    }

        //    // Otherwise, return the original selected index
        //    return selected;
        //}

        //public static int Toolbar(int selected, string[] texts, GUIStyle style, params GUILayoutOption[] options)
        //{
        //    style.active.textColor = Active;
        //    style.hover.textColor = Hover;

        //    int newSelected = GUILayout.Toolbar(selected, texts, style, options);

        //    // If the selected button has changed, return the new selected index
        //    if (newSelected != selected)
        //    {
        //        return newSelected;
        //    }

        //    // Otherwise, return the original selected index
        //    return selected;
        //}
        //public static int Toolbar1(int selected, string[] texts, GUIStyle style, params GUILayoutOption[] options)
        //{
        //    //Color activeColor = Color.green;
        //    //Color inactiveColor = Color.red;
        //    //Color hoverColor = Color.cyan;

        //    for (int i = 0; i < texts.Length; i++)
        //    {
        //        // Check if the current button is selected
        //        if (i == selected)
        //        {
        //            style.normal.textColor = Active;
        //            style.hover.textColor = Active;
        //            style.active.textColor = Active;
        //        }
        //        else
        //        {
        //            style.normal.textColor = Inactive;
        //            style.hover.textColor = Hover;
        //            style.active.textColor = Inactive;
        //        }

        //        if (GUILayout.Button(texts[i], style, options))
        //        {
        //            // Button clicked, update the selected index
        //            selected = i;
        //        }
        //    }

        //    // If the selected button has changed, return the new selected index
        //    return selected;

        //}

        //public static int Toolbar2(int selected, string[] texts, GUIStyle style, params GUILayoutOption[] options)
        //{
        //    int newSelected = selected;

        //    for (int i = 0; i < texts.Length; i++)
        //    {
        //        bool isButtonActive = (i == selected);

        //        // Determine the color based on whether the button is active or not
        //        Color buttonColor = isButtonActive ? Active : Inactive;

        //        // Update the button style's color
        //        style.normal.textColor = buttonColor;
        //        style.hover.textColor = Hover;

        //        // Check if the button is clicked
        //        if (GUILayout.Button(texts[i], style, options))
        //        {
        //            // Button clicked, update the selected index
        //            newSelected = i;
        //        }
        //    }

        //    // If the selected button has changed, return the new selected index
        //    if (newSelected != selected)
        //    {
        //        return newSelected;
        //    }

        //    // Otherwise, return the original selected index
        //    return selected;
        //}
        //private static void DrawFoldoutHorizontal(Rect position, bool expanded)
        //{
        //    GUIStyle foldoutStyle = new GUIStyle();
        //    foldoutStyle.fontStyle = FontStyle.Bold;
        //    foldoutStyle.fontSize = 12;
        //    foldoutStyle.normal.textColor = expanded ? Active : Inactive;

        //    GUIContent content = new GUIContent(expanded ? "\u25BC" : "\u25BA", "Click to expand/collapse");
        //    GUI.Label(position, content, foldoutStyle);

        //    // Draw a horizontal line to separate the header from the content
        //    Vector2 lineStart = new Vector2(position.x + 15f, position.y + position.height);
        //    Vector2 lineEnd = new Vector2(lineStart.x + position.width - 15f, lineStart.y);
        //    DrawHorizontalLine(lineStart, lineEnd, Color.gray);
        //}
        //private static void DrawFoldoutHorizontal1(Rect position, bool display)
        //{
        //    // Draw a simple foldout arrow on the header
        //    Texture2D foldoutTex = display ? Texture2D.whiteTexture : Texture2D.blackTexture;
        //    GUI.DrawTexture(position, foldoutTex);
        //}
        //private static void DrawHorizontalLine(Vector2 start, Vector2 end, Color color)
        //{
        //    Texture2D lineTex = new Texture2D(1, 1);
        //    lineTex.SetPixel(0, 0, color);
        //    lineTex.Apply();

        //    Matrix4x4 matrixBackup = GUI.matrix;
        //    float angle = Mathf.Atan2(end.y - start.y, end.x - start.x) * 180 / Mathf.PI;
        //    GUIUtility.RotateAroundPivot(angle, start);
        //    GUI.DrawTexture(new Rect(start.x, start.y, (end - start).magnitude, 1), lineTex);
        //    GUI.matrix = matrixBackup;
        //}

    }
}
