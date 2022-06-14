//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
//using System.Collections.Generic;
//using System;

//namespace SevenDTD_mono
//{
//    //When you add the code to dnSpy you can give the class another name, example MyModMenu
//    public class PCModMenu : MonoBehaviour
//    {
//        /// fields
//        public static GUIStyle BgStyle, OnStyle, OffStyle, LabelStyle, BtnStyle, BtnStyle1, BtnStyle2, BtnStyle3;
//        public static string nameOfStr, lastInput = string.Empty, chtAc = "<color=#8bc34aff>Cheat activated: </color>", chtDe = "<color=#e57373>Cheat deactivated: </color>";
//        public static float delay = 0, widthSize = 300; //Change size here
//        public static bool ShowHide = true, ShowNotifi = false, ifDragged = false, buttonPressed = false, isStart;

//        // Texture
//        public static Texture2D ontexture, onpresstexture, offtexture, offpresstexture, backtexture, btntexture, btnpresstexture;
//        public static Texture2D NewTexture2D { get { return new Texture2D(1, 1); } }

//        // Toggles to enable/disable hack
//        public static bool toggle1, toggle2, toggle3, toggle4, toggle5;

//        // Position (x, y, width, height)
//        // Change only x and y
//        public static Rect posRect = new Rect(0, 150, 0, 0);

//        // Damage multiplier
//        public static int dmgMulti = 1, dmg = 0;

//        // Remember Y position
//        public static int btnY, mulY;

//        private bool drawMenu = true;
//        private int windowID;
//        private Rect windowRect;
//        private Rect guiRect;
//        public int _group = 0;
//        string[] CheatsString = { "Mymenu", "Men2", "Men3" };

//        private void Start()
//        {
//            windowID = new System.Random(Environment.TickCount).Next(1000, 65535);
//            windowRect = new Rect(10f, 10f, 300f, 300f);
//            guiRect = new Rect(0, 0, 300, 300);



//            if (BgStyle == null)
//            {
//                BgStyle = new GUIStyle();
//                BgStyle.normal.background = BackTexture;
//                BgStyle.onNormal.background = BackTexture;
//                BgStyle.active.background = BackTexture;
//                BgStyle.onActive.background = BackTexture;
//                BgStyle.normal.textColor = Color.white;
//                BgStyle.onNormal.textColor = Color.white;
//                BgStyle.active.textColor = Color.white;
//                BgStyle.onActive.textColor = Color.white;
//                BgStyle.fontSize = 18;
//                BgStyle.fontStyle = FontStyle.Normal;
//                BgStyle.alignment = TextAnchor.UpperCenter;
//            }

//            if (LabelStyle == null)
//            {
//                LabelStyle = new GUIStyle();
//                LabelStyle.normal.textColor = Color.yellow;
//                LabelStyle.onNormal.textColor = Color.red;
//                LabelStyle.active.textColor = Color.blue;
//                LabelStyle.onActive.textColor = Color.cyan;
//                LabelStyle.fontSize = 18;
//                LabelStyle.fontStyle = FontStyle.Normal;
//                LabelStyle.alignment = TextAnchor.UpperCenter;
//            }

//            if (OffStyle == null)
//            {
//                OffStyle = new GUIStyle();
//                OffStyle.normal.background = OffTexture;
//                OffStyle.onNormal.background = OffTexture;
//                OffStyle.active.background = OffPressTexture;
//                OffStyle.onActive.background = OffPressTexture;
//                OffStyle.normal.textColor = Color.white;
//                OffStyle.onNormal.textColor = Color.white;
//                OffStyle.active.textColor = Color.white;
//                OffStyle.onActive.textColor = Color.white;
//                OffStyle.fontSize = 18;
//                OffStyle.fontStyle = FontStyle.Normal;
//                OffStyle.alignment = TextAnchor.MiddleCenter;
//            }

//            if (OnStyle == null)
//            {
//                OnStyle = new GUIStyle();
//                OnStyle.normal.background = OnTexture;
//                OnStyle.onNormal.background = OnTexture;
//                OnStyle.active.background = OnPressTexture;
//                OnStyle.onActive.background = OnPressTexture;
//                OnStyle.normal.textColor = Color.white;
//                OnStyle.onNormal.textColor = Color.white;
//                OnStyle.active.textColor = Color.white;
//                OnStyle.onActive.textColor = Color.white;
//                OnStyle.fontSize = 18;
//                OnStyle.fontStyle = FontStyle.Normal;
//                OnStyle.alignment = TextAnchor.MiddleCenter;
//            }

//            if (BtnStyle == null)
//            {
//                BtnStyle = new GUIStyle();
//                BtnStyle.normal.background = BtnTexture;
//                BtnStyle.onNormal.background = BtnTexture;
//                BtnStyle.active.background = BtnPressTexture;
//                BtnStyle.onActive.background = BtnPressTexture;
//                BtnStyle.normal.textColor = Color.white;
//                BtnStyle.onNormal.textColor = Color.black;
//                BtnStyle.active.textColor = Color.green;
//                BtnStyle.onActive.textColor = Color.cyan;
//                BtnStyle.fontSize = 18;
//                BtnStyle.fontStyle = FontStyle.Normal;
//                BtnStyle.alignment = TextAnchor.MiddleCenter;
//            }


//        }
//        public void OnGUI()
//        {
//            // Load textured on Start one time to avoid high GPU usage.
//            if (!isStart)
//            {
//                //Start();
//                isStart = true;
//            }

//            // I created additional class (MyMenu) of GUI stuff to avoid high CPU usage
//            // and lagging on low-end devices
//            // Never make your whole GUI codes in OnGUI()
//            if (ShowHide)
//            {
//                windowRect = GUILayout.Window(windowID, windowRect, mywin, "Men1111");
//                // Unlock cursor. Remove or comment out this code if the game does not lock cursor
//                // Cursor.lockState = 0;
//                //Cursor.visible = true;
//                // if ShowHide true, call MyMenu();
//                MyMenu();
//            }
//            else
//            {
//                // Lock cursor. Remove or comment out this code if the game does not lock cursor
//                //Cursor.lockState = CursorLockMode.Locked;
//                //Cursor.visible = false;
//            }

//            // Delay time of cheat notification
//            if (delay > 0)
//                delay -= Time.deltaTime;
//            else
//                ShowNotifi = false;

//            // Show cheat notification
//            if (ShowNotifi)
//                ShowNotification();
//        }
//        private void mywin(int windowID)
//        {
//            _group = GUILayout.Toolbar(_group, CheatsString);

//            switch (_group)
//            {
//                case 0:
//                    MyMenu();
//                    break;
//                case 1:
//                    //Menu2();
//                    break;
//                case 2:
//                    //Menu3();
//                    break;

//            }
//            GUILayout.Space(10f);
//        }


//        // Unity editor: public void MyMenu()
//        // dnSpy: public static void MyMenu()
//        public static void MyMenu()
//        {
//            /// Credit
//            // (x, y, width, height)
//            GUI.Box(new Rect(posRect.x, posRect.y + 0f, widthSize + 10, 50f + 45 * mulY), "", BgStyle);
//            GUI.Label(new Rect(posRect.x, posRect.y + 5f, widthSize + 10, 95f), "Mod menu by AndnixSH#\n(your website)", LabelStyle);

//            // Note/warning. Remove or comment out to remove it
//            GUI.Box(new Rect(posRect.x, posRect.y + 65f + 45 * mulY, widthSize + 10, 50f), "", BgStyle);
//            GUI.Label(new Rect(posRect.x, posRect.y + 70f + 45 * mulY, widthSize + 10, 50f), "<color=yellow>Note: You can still use skill\nwhile cooldown</color>", LabelStyle);

//            // Button Increase/decrease. Don't touch the "btnWSize - xx". Change number of btnWSize in fields
//            if (GUI.Button(BtnRect(1, true), "DMG multplier (-/+): " + dmgMulti.ToString(), BtnStyle))
//            {

//            }
//            if (GUI.Button(new Rect(posRect.x + widthSize - 35, posRect.y + btnY, 40, 40), "-", OffStyle))
//            {
//                if (dmgMulti > 1 && dmgMulti <= 30)
//                    dmgMulti--;
//            }
//            if (GUI.Button(new Rect(posRect.x + widthSize - 80, posRect.y + btnY, 40, 40), "+", OffStyle))
//            {
//                if (dmgMulti >= 1 && dmgMulti < 30)
//                    dmgMulti++;
//            }



//            if (toggle2)
//            {
//                if(GUILayout.Button("nomosn on",OnStyle)){
//                    toggle2 = false;
//                }
//                else if (GUILayout.Button("nomosn off", OffStyle))
//                {
//                    toggle2 = true;
//                }
//            }

//            // Button toggle on/off
//            if (toggle2)
//            {
//                if (GUI.Button(BtnRect(2, false), "No monster attack (F2): ON", OnStyle))
//                {
//                    toggle2 = false;
//                }

//            }
//            else if (GUI.Button(BtnRect(2, false), "No monster attack (F2): OFF", OffStyle))
//            {
//                toggle2 = true;
//            }

//            // Button toggle on/off
//            if (toggle3) 
//            {
                
//                if (GUI.Button(BtnRect(3, false), "No cooldown (F3): ON", OnStyle))
//                {
//                    toggle3 = false;
//                }
                
//                else if (GUI.Button(BtnRect(3, false), "No cooldown (F3): OFF", OffStyle))
//                {
//                    toggle3 = true;
//                }
//            }

//            // Button click
//            if (GUI.Button(BtnRect(4, false), "Visit (your website)", BtnStyle))
//                Application.OpenURL("https://google.com");

//            GUI.DragWindow();
//        }

//        //Activate/Deactivate cheats
//        // For unity editor: public void Update()
//        // For dnSpy: public static void Update()
//        public void Update()
//        {
//            // Input always lower case
//            lastInput += Input.inputString.ToLower();

//            // limit stored input to 30 to avoid mess
//            if (lastInput.Length > 30)
//            {
//                lastInput = lastInput.Remove(0, lastInput.Length - 10);
//            }
//            if (Input.GetKeyDown(KeyCode.M) && Input.GetKeyDown(KeyCode.N))
//                ShowHide = !ShowHide;

//            //Key press with cheat code
//            if (Input.GetKeyDown(KeyCode.F2) || lastInput.EndsWith("nomonatk"))
//            {
//                toggle2 = !toggle2;
//                if (toggle2)
//                    nameOfStr = chtAc + "No monster attack";
//                else
//                    nameOfStr = chtDe + "No monster attack";
//                ShowNotifi = true;
//                delay = 5;
//                lastInput = string.Empty;
//            }

//            if (Input.GetKeyDown(KeyCode.F3) || lastInput.EndsWith("nocooldown"))
//            {
//                toggle3 = !toggle3;
//                if (toggle3)
//                    nameOfStr = chtAc + "No cooldown";
//                else
//                    nameOfStr = chtDe + "No cooldown";
//                ShowNotifi = true;
//                delay = 5;
//                lastInput = string.Empty;
//            }

//            if (Input.GetKeyDown(KeyCode.KeypadPlus))
//            {
//                if (dmgMulti >= 1 && dmgMulti < 30)
//                    dmgMulti++;
//                ShowNotifi = true;
//                delay = 5;
//                nameOfStr = "Damage multiplier: " + dmgMulti.ToString();
//                lastInput = string.Empty;
//            }

//            if (Input.GetKeyDown(KeyCode.KeypadMinus))
//            {
//                if (dmgMulti > 1 && dmgMulti <= 30)
//                    dmgMulti--;
//                ShowNotifi = true;
//                delay = 5;
//                nameOfStr = "Damage multiplier: " + dmgMulti.ToString();
//                lastInput = string.Empty;
//            }
//        }

//        // Show notification when you activate/deactivate cheats
//        public static void ShowNotification()
//        {
//            GUI.Box(new Rect(80f, 40f, 450f, 45f), "", BgStyle);
//            GUI.Label(new Rect(80f, 49f, 450f, 45f), "<size=24>" + nameOfStr + "</size>", LabelStyle);
//        }

//        /// Rect for buttons
//        // Auto position buttons. There is no need to change it 
//        public static Rect BtnRect(int y, bool multiplyBtn)
//        {
//            mulY = y;
//            if (multiplyBtn)
//            {
//                btnY = 5 + 45 * y;
//                return new Rect(posRect.x + 5, posRect.y + 5 + 45 * y, widthSize - 90, 40);
//            }
//            return new Rect(posRect.x + 5, posRect.y + 5 + 45 * y, widthSize, 40);
//        }

//        /// Textures
//        // Use material colors and convert hex code to rbg https://www.materialpalette.com/colors
//        public static Texture2D BtnTexture
//        {
//            get
//            {
//                if (btntexture == null)
//                {
//                    btntexture = NewTexture2D;
//                    btntexture.SetPixel(0, 0, new Color32(3, 155, 229, 255));
//                    btntexture.Apply();
//                }
//                return btntexture;
//            }
//        }

//        public static Texture2D BtnPressTexture
//        {
//            get
//            {
//                if (btnpresstexture == null)
//                {
//                    btnpresstexture = NewTexture2D;
//                    btnpresstexture.SetPixel(0, 0, new Color32(2, 119, 189, 255));
//                    btnpresstexture.Apply();
//                }
//                return btnpresstexture;
//            }
//        }

//        public static Texture2D OnPressTexture
//        {
//            get
//            {
//                if (onpresstexture == null)
//                {
//                    onpresstexture = NewTexture2D;
//                    onpresstexture.SetPixel(0, 0, new Color32(56, 142, 60, 255));
//                    onpresstexture.Apply();
//                }
//                return onpresstexture;
//            }
//        }

//        public static Texture2D OnTexture
//        {
//            get
//            {
//                if (ontexture == null)
//                {
//                    ontexture = NewTexture2D;
//                    ontexture.SetPixel(0, 0, new Color32(76, 175, 80, 255));
//                    ontexture.Apply();
//                }
//                return ontexture;
//            }
//        }

//        public static Texture2D OffPressTexture
//        {
//            get
//            {
//                if (offpresstexture == null)
//                {
//                    offpresstexture = NewTexture2D;
//                    offpresstexture.SetPixel(0, 0, new Color32(211, 47, 47, 255));
//                    offpresstexture.Apply();
//                }
//                return offpresstexture;
//            }
//        }

//        public static Texture2D OffTexture
//        {
//            get
//            {
//                if (offtexture == null)
//                {
//                    offtexture = NewTexture2D;
//                    offtexture.SetPixel(0, 0, new Color32(244, 67, 54, 255));
//                    offtexture.Apply();
//                }
//                return offtexture;
//            }
//        }

//        public static Texture2D BackTexture
//        {
//            get
//            {
//                if (backtexture == null)
//                {
//                    backtexture = NewTexture2D;
//                    //ToHtmlStringRGBA  new Color(33, 150, 243, 1)
//                    backtexture.SetPixel(0, 0, new Color32(42, 42, 42, 200));
//                    backtexture.Apply();
//                }
//                return backtexture;
//            }
//        }
//    }
//}