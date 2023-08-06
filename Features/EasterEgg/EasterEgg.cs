//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class EasterEgg
//{
//    public string Code { get; private set; }
//    public Action Action { get; private set; }

//    public EasterEgg(string code, Action action)
//    {
//        Code = code.ToLower();
//        Action = action;
//    }
//}

//public class EasterEggManager : MonoBehaviour
//{
//    private List<EasterEgg> _easterEggs = new List<EasterEgg>();
//    private string currentInput = "";
//    private void Start()
//    {
//        // Add your Easter eggs here using the EasterEgg constructor.

//    }

//    private void Update()
//    {
//        CheckAndExecuteEasterEggs();
//    }

//    private void CheckAndExecuteEasterEggs1()
//    {
//        string input = GetInputString1(); // Implement GetInputString() to get the user's input as a string.

//        // Loop through the Easter eggs to find a match.
//        foreach (EasterEgg egg in _easterEggs)
//        {
//            if (input.Contains(egg.Code))
//            {
//                egg.Action();
//                break; // Uncomment if you want to execute only one Easter egg per input.
//            }
//        }
//    }

//    // Implement this method to get the user's input as a string.
//    private string GetInputString1()
//    {
//        // You can use Input.GetKey, Input.GetKeyDown, or any other input method based on your requirements.
//        // For this example, let's assume you are listening for specific key presses.

//        // Return the user's input as a string, e.g., concatenate the keys they pressed.
//        return Input.inputString.ToLower();
//    }



//    private void CheckAndExecuteEasterEggs()
//    {
//        if (Input.anyKeyDown)
//        {
//            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
//            {
//                if (Input.GetKeyDown(keyCode))
//                {
//                    char character = GetCharFromKeyCode(keyCode);
//                    currentInput += character.ToString().ToLower();
//                    break;
//                }
//            }

//            // Check if any Easter egg matches the current input.
//            foreach (EasterEgg egg in _easterEggs)
//            {
//                if (currentInput.Contains(egg.Code))
//                {
//                    egg.Action();
//                    currentInput = ""; // Reset the input after triggering an Easter egg.
//                    break; // Uncomment if you want to execute only one Easter egg per input.
//                }
//            }
//        }
//    }

//    private char GetCharFromKeyCode(KeyCode keyCode)
//    {
//        if (keyCode >= KeyCode.A && keyCode <= KeyCode.Z)
//        {
//            return (char)('a' + (keyCode - KeyCode.A));
//        }
//        else if (keyCode >= KeyCode.Alpha0 && keyCode <= KeyCode.Alpha9)
//        {
//            return (char)('0' + (keyCode - KeyCode.Alpha0));
//        }
//        else
//        {
//            return '\0'; // Return null character for other keys.
//        }
//    }

//}