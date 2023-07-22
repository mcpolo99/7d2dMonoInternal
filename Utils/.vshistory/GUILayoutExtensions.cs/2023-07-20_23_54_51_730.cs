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
        public static bool Toggle(this GUILayout layout, bool value, string label, Color activeColor, Color inactiveColor)
        {
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);

            // Use the provided colors for the toggle
            toggleStyle.normal.textColor = inactiveColor;
            toggleStyle.active.textColor = activeColor;

            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }
        //public static bool ToggleC(bool value, string label, Color activeColor, Color inactiveColor)
        //{
        //    GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);

        //    // Use the provided colors for the toggle
        //    toggleStyle.normal.textColor = inactiveColor;
        //    toggleStyle.active.textColor = activeColor;

        //    value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

        //    return value;
        //}
        private static readonly Color DefaultTextColor = GUI.skin.toggle.normal.textColor;
        private static readonly Color ActiveColor = Color.cyan;
        private static readonly Color InactiveColor = Color.yellow;
        private static readonly Color HoverColor = Color.blue;


        public static bool ToggleC(bool value, string label, Color activeColor, Color inactiveColor, params GUILayoutOption[] options)
        {

            // Detect the current event type
            EventType currentEventType = Event.current.type;
           
            // Determine the text color based on the toggle value and event type
            Color textColor;
            if (currentEventType == EventType.KeyDown)
            {
                //textColor = GUI.skin.toggle.normal.textColor;
                textColor = value ? activeColor : inactiveColor;
            }
            else
            {
                textColor = value ? activeColor : inactiveColor;
            }
            activeColor = Color.blue;
            inactiveColor = Color.cyan;
            Color hover = Color.yellow;
            // Use the provided colors for the toggle
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            //toggleStyle.onFocused.textColor = activeColor;
            toggleStyle.normal.textColor = Color.red;                      //WHEN OFF 
            toggleStyle.onNormal.textColor = Color.green;                    //WHEN ON 
            toggleStyle.active.textColor = Color.green;                       //OFF TO ON When pressing/holding 
            toggleStyle.onActive.textColor = Color.red;                     // ON TO OFF
            toggleStyle.hover.textColor = Color.yellow;                     //OFF
            toggleStyle.onHover.textColor = Color.yellow;                   //ON
            //toggleStyle.focused.textColor = new Color(0.5f, 0.2f, 0.8f);    //OFF
            //toggleStyle.onFocused.textColor = Color.magenta;                //ON        

            

            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }

        public static bool ToggleC(bool value, string label, Color active, Color inactive, Color hover, params GUILayoutOption[] options)
        {

            // Detect the current event type
            EventType currentEventType = Event.current.type;

            // Determine the text color based on the toggle value and event type
            Color textColor;
            if (currentEventType == EventType.KeyDown)
            {
                //textColor = GUI.skin.toggle.normal.textColor;
                textColor = value ? active : inactive;
            }
            else
            {
                textColor = value ? active : inactive;
            }
            active = Color.green;
            inactive = Color.red;
            hover = Color.yellow;
            // Use the provided colors for the toggle
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            //toggleStyle.onFocused.textColor = activeColor;
            toggleStyle.normal.textColor = Color.red;                      //WHEN OFF 
            toggleStyle.onNormal.textColor = Color.green;                    //WHEN ON 
            toggleStyle.active.textColor = Color.green;                       //OFF TO ON When pressing/holding 
            toggleStyle.onActive.textColor = Color.red;                     // ON TO OFF
            toggleStyle.hover.textColor = Color.yellow;                     //OFF
            toggleStyle.onHover.textColor = Color.yellow;                   //ON
                                                                            //toggleStyle.focused.textColor = new Color(0.5f, 0.2f, 0.8f);    //OFF
                                                                            //toggleStyle.onFocused.textColor = Color.magenta;                //ON        



            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }

        public static bool ToggleC(bool value, string label, params GUILayoutOption[] options)
        {
            // Detect the current event type
            EventType currentEventType = Event.current.type;

            // Determine the text color based on the toggle value and event type
            //Color textColor;
            if (currentEventType == EventType.KeyDown)
            {
                //textColor = GUI.skin.toggle.normal.textColor;
                //textColor = value ? active : inactive;
            }
            else
            {
                //textColor = value ? active : inactive;
            }
            Color active = Color.green;
            Color inactive = Color.red;
            Color hover = Color.yellow;
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
