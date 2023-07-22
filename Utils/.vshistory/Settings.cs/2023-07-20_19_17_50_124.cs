using UnityEngine;
using UnityEngine.UI;





namespace 7DTDMono_NS 
{ 
    public class Settings : MonoBehaviour
    {

        #region BOOLS undefined
        // Add more settings/options to your cheat!

        public static bool speed;
        public static bool aimbot;
        public static bool infiniteAmmo;
        public static bool noWeaponBob;
        public static bool magicBullet;

        public static bool cmDm;
        public static bool cm;
        public static bool drpbp, onht;
        #endregion

        #region Bools defined
        public static bool PlayerBox = false;
        public static bool PlayerName = false;

        public static bool chams = false;
        public static bool playerBox = false;
        public static bool zombieBox = false;
        public static bool crosshair = false; 
        public static bool playerCornerBox = false;
        public static bool zombieCornerBox = false;
        public static bool zombieHealth = false;
        public static bool playerHealth = false;
        public static bool zombieName = false;
        public static bool fovCircle = false;
        public static bool playerName = false;
        public static bool _trystackitems = false;
        #endregion



        #region FLoats
        public static float _dmg;
        #endregion

        #region Vars
        public static GUIStyle BgStyle, OnStyle, OffStyle, LabelStyle, BtnStyle, BtnStyle1, BtnStyle2, BtnStyle3, ToggStyle1,ToggStyle2;

        #endregion

        #region DEf
        public static string Text= "Text";
        public static Text BOOLText;
        public static Color _cON = Color.green;
        public static Color _cOFF = Color.red;
        public static Color _cidle = Color.red;





        #endregion

 
        public static void Styles()
        {

            #region Style
            if (BgStyle == null)
            {
                BgStyle = new GUIStyle();
                //BgStyle.normal.background = BackTexture;
                //BgStyle.onNormal.background = BackTexture;
                //BgStyle.active.background = BackTexture;
                //BgStyle.onActive.background = BackTexture;
                BgStyle.normal.textColor = Color.white;
                BgStyle.onNormal.textColor = Color.white;
                BgStyle.active.textColor = Color.white;
                BgStyle.onActive.textColor = Color.white;
                //BgStyle.fontSize = 18;
                //BgStyle.fontStyle = FontStyle.Normal;
                //BgStyle.alignment = TextAnchor.UpperCenter;
            }

            if (LabelStyle == null)
            {
                LabelStyle = new GUIStyle();
                LabelStyle.normal.textColor = Color.white;
                LabelStyle.onNormal.textColor = Color.white;
                LabelStyle.active.textColor = Color.white;
                LabelStyle.onActive.textColor = Color.white;
                //LabelStyle.fontSize = 18;
                //LabelStyle.fontStyle = FontStyle.Normal;
                //LabelStyle.alignment = TextAnchor.UpperCenter;
            }

            if (OffStyle == null)
            {
                OffStyle = new GUIStyle();
                //OffStyle.normal.background = OffTexture;
                //OffStyle.onNormal.background = OffTexture;
                //OffStyle.active.background = OffPressTexture;
                //OffStyle.onActive.background = OffPressTexture;
                OffStyle.normal.textColor = Color.white;
                OffStyle.onNormal.textColor = Color.white;
                OffStyle.active.textColor = Color.white;
                OffStyle.onActive.textColor = Color.white;
                //OffStyle.fontSize = 18;
                //OffStyle.fontStyle = FontStyle.Normal;
                //OffStyle.alignment = TextAnchor.MiddleCenter;
            }

            if (OnStyle == null)
            {
                OnStyle = new GUIStyle();
                //OnStyle.normal.background = OnTexture;
                //OnStyle.onNormal.background = OnTexture;
                //OnStyle.active.background = OnPressTexture;
                //OnStyle.onActive.background = OnPressTexture;
                OnStyle.normal.textColor = Color.white;
                OnStyle.onNormal.textColor = Color.white;
                OnStyle.active.textColor = Color.white;
                OnStyle.onActive.textColor = Color.white;
                //OnStyle.fontSize = 18;
                //OnStyle.fontStyle = FontStyle.Normal;
                //OnStyle.alignment = TextAnchor.MiddleCenter;
            }

            if (BtnStyle == null)
            {
                BtnStyle = new GUIStyle();
                //BtnStyle.normal.background = BtnTexture;
                //BtnStyle.onNormal.background = BtnTexture;
                //BtnStyle.active.background = BtnPressTexture;
                //BtnStyle.onActive.background = BtnPressTexture;
                BtnStyle.normal.textColor = Color.white;
                BtnStyle.onNormal.textColor = Color.white;
                BtnStyle.active.textColor = Color.white;
                BtnStyle.onActive.textColor = Color.white;
                //BtnStyle.fontSize = 18;
                //BtnStyle.fontStyle = FontStyle.Normal;
                //BtnStyle.alignment = TextAnchor.MiddleCenter;
            }

            if (BtnStyle1 == null)
            {
                BtnStyle1 = new GUIStyle();
                BtnStyle1.normal.textColor = _cOFF;
                BtnStyle1.onNormal.textColor = _cOFF;
                BtnStyle1.active.textColor = _cON;
                BtnStyle1.onActive.textColor = _cON;
                BtnStyle1.onHover.textColor = Color.yellow;
                //BtnStyle.fontSize = 18;
                //BtnStyle.fontStyle = FontStyle.Normal;
                //BtnStyle.alignment = TextAnchor.MiddleCenter;
            }
            if (ToggStyle1 == null)
            {
                ToggStyle1 = new GUIStyle();
                //ToggStyle1.normal.textColor = _cOFF;
                //ToggStyle1.onNormal.textColor = _cOFF;
                //ToggStyle1.active.textColor = _cON;
                //ToggStyle1.onActive.textColor = _cON;
                ToggStyle1.onHover.textColor = Color.yellow;
                //ToggStyle1.fontSize = 18;
                //ToggStyle1.fontStyle = FontStyle.Normal;
                ToggStyle1.alignment = TextAnchor.MiddleRight;
                //ToggStyle1.border.Add(new Rect(0,0,50,50));
                

            }



            #endregion
        }




        #region texture
        //    /// Textures
        //    // Use material colors and convert hex code to rbg https://www.materialpalette.com/colors
        //    public static Texture2D BtnTexture
        //    {
        //        get
        //        {
        //            if (btntexture == null)
        //            {
        //                btntexture = NewTexture2D;
        //                btntexture.SetPixel(0, 0, new Color32(3, 155, 229, 255));
        //                btntexture.Apply();
        //            }
        //            return btntexture;
        //        }
        //    }

        //    public static Texture2D BtnPressTexture
        //    {
        //        get
        //        {
        //            if (btnpresstexture == null)
        //            {
        //                btnpresstexture = NewTexture2D;
        //                btnpresstexture.SetPixel(0, 0, new Color32(2, 119, 189, 255));
        //                btnpresstexture.Apply();
        //            }
        //            return btnpresstexture;
        //        }
        //    }

        //    public static Texture2D OnPressTexture
        //    {
        //        get
        //        {
        //            if (onpresstexture == null)
        //            {
        //                onpresstexture = NewTexture2D;
        //                onpresstexture.SetPixel(0, 0, new Color32(56, 142, 60, 255));
        //                onpresstexture.Apply();
        //            }
        //            return onpresstexture;
        //        }
        //    }

        //    public static Texture2D OnTexture
        //    {
        //        get
        //        {
        //            if (ontexture == null)
        //            {
        //                ontexture = NewTexture2D;
        //                ontexture.SetPixel(0, 0, new Color32(76, 175, 80, 255));
        //                ontexture.Apply();
        //            }
        //            return ontexture;
        //        }
        //    }

        //    public static Texture2D OffPressTexture
        //    {
        //        get
        //        {
        //            if (offpresstexture == null)
        //            {
        //                offpresstexture = NewTexture2D;
        //                offpresstexture.SetPixel(0, 0, new Color32(211, 47, 47, 255));
        //                offpresstexture.Apply();
        //            }
        //            return offpresstexture;
        //        }
        //    }

        //    public static Texture2D OffTexture
        //    {
        //        get
        //        {
        //            if (offtexture == null)
        //            {
        //                offtexture = NewTexture2D;
        //                offtexture.SetPixel(0, 0, new Color32(244, 67, 54, 255));
        //                offtexture.Apply();
        //            }
        //            return offtexture;
        //        }
        //    }

        //    public static Texture2D BackTexture
        //    {
        //        get
        //        {
        //            if (backtexture == null)
        //            {
        //                backtexture = NewTexture2D;
        //                //ToHtmlStringRGBA  new Color(33, 150, 243, 1)
        //                backtexture.SetPixel(0, 0, new Color32(42, 42, 42, 200));
        //                backtexture.Apply();
        //            }
        //            return backtexture;
        //        }
        //    }
        //}


        #endregion


    }
}
