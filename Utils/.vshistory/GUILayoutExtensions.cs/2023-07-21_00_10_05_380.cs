using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using InControl;

namespace SevenDTDMono.Utils
{
    public static class CGUILayout
    {
        //public static bool Toggle(this GUILayout layout, bool value, string label, Color activeColor, Color inactiveColor)
        //{
        //    GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);

        //    // Use the provided colors for the toggle
        //    toggleStyle.normal.textColor = inactiveColor;
        //    toggleStyle.active.textColor = activeColor;

        //    value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

        //    return value;
        //}

        private static readonly Color DefaultTextColor = GUI.skin.toggle.normal.textColor;
        //private static readonly Color ActiveColor = Color.cyan;
        //private static readonly Color InactiveColor = Color.yellow;
        //private static readonly Color HoverColor = Color.blue;

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


        public static bool Button(string label, Color normal, Color hover, Color active, params GUILayoutOption[] options)
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = normal;
            buttonStyle.onNormal.textColor = normal;
            buttonStyle.hover.textColor = hover;
            buttonStyle.onHover.textColor = hover;
            buttonStyle.active.textColor = active;
            buttonStyle.active.textColor = active;

            bool isClicked = GUILayout.Button(label, buttonStyle, options);
            return isClicked;
        }

        public static bool Button(string label, params GUILayoutOption[] options)
        {
            Color active = Color.green;
            Color inactive = Color.red;
            Color hover = Color.cyan;
            // Use the provided colors for the toggle
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.normal.textColor = inactive;                      //WHEN OFF 
            buttonStyle.onNormal.textColor = active;                    //WHEN ON 
            buttonStyle.active.textColor = active;                       //OFF TO ON When pressing/holding 
            buttonStyle.onActive.textColor = inactive;                     // ON TO OFF
            buttonStyle.hover.textColor = hover;                     //OFF
            buttonStyle.onHover.textColor = hover;                   //ON
            bool isClicked = GUILayout.Button(label, buttonStyle, options);
            return isClicked;
        }













    }
    public static class GUILayoutExtensions1
    {
        public static bool ToggleWithColor1(bool value, string label, Color activeColor, Color inactiveColor)
        {
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);

            // Use the provided colors for the toggle
            toggleStyle.normal.textColor = inactiveColor;
            toggleStyle.active.textColor = activeColor;

            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }

        public static class GUILayoutExtensions
        {
           
        }




    }
}
