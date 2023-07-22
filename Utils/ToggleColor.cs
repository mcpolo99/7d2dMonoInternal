using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    //internal class ToggleColor
    //{
    //}
}
