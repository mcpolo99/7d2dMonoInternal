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
        public static bool ToggleC(bool value, string label, Color activeColor, Color inactiveColor)
        {
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);

            // Use the provided colors for the toggle
            toggleStyle.normal.textColor = inactiveColor;
            toggleStyle.active.textColor = activeColor;

            value = GUILayout.Toggle(value, label, toggleStyle, GUILayout.Width(120));

            return value;
        }

        public static bool ToggleC(bool value, string label, Color activeColor, Color inactiveColor, params GUILayoutOption[] options)
        {
            // Detect the current event type
            EventType currentEventType = Event.current.type;

            // Determine the text color based on the toggle value and event type
            Color textColor;
            if (currentEventType == EventType.Layout)
            {
                textColor = GUI.skin.toggle.normal.textColor;
            }
            else
            {
                textColor = value ? activeColor : inactiveColor;
            }

            // Use the provided colors for the toggle
            GUIStyle toggleStyle = new GUIStyle(GUI.skin.toggle);
            toggleStyle.normal.textColor = textColor;
            toggleStyle.active.textColor = textColor;

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
