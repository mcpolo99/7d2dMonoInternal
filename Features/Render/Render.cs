using UnityEngine;
using O = SevenDTDMono.Objects;
using SETT = SevenDTDMono.Settings;
using Eutl= SevenDTDMono.ESPUtils;

namespace SevenDTDMono
{
    internal class Render : MonoBehaviour
    {

        #region Local settings
        private Color blackCol;
        private Color entityBoxCol;
        private Color crosshairCol;

        private readonly float crosshairScale = 14f;
        private readonly float lineThickness = 1.75f;

        public static Camera mainCam;
        #endregion


        

        private void Start()
        {
            // Camera.main is a very expensive getter, so we want to do it once and cache the result.
            mainCam = Camera.main;

            blackCol = new Color(0f, 0f, 0f, 120f);
            entityBoxCol = new Color(0.42f, 0.36f, 0.90f, 1f);
            crosshairCol = new Color32(30, 144, 255, 255);
        }

        private void OnGUI()
        {


            if (Event.current.type != EventType.Repaint)
            {
                return;
            }

            if (!mainCam)
            {
                mainCam = Camera.main;
            }


            if (SETT.crosshair) //crosshair Function
             {
                // Constantly redefining these vectors so that you can change your resolution and the crosshair will still be in the middle.
                Vector2 lineHorizontalStart = new Vector2(Screen.width / 2 - crosshairScale, Screen.height / 2);
                Vector2 lineHorizontalEnd = new Vector2(Screen.width / 2 + crosshairScale, Screen.height / 2);

                Vector2 lineVerticalStart = new Vector2(Screen.width / 2, Screen.height / 2 - crosshairScale);
                Vector2 lineVerticalEnd = new Vector2(Screen.width / 2, Screen.height / 2 + crosshairScale);

                Eutl.DrawLine(lineHorizontalStart, lineHorizontalEnd, crosshairCol, lineThickness);
                Eutl.DrawLine(lineVerticalStart, lineVerticalEnd, crosshairCol, lineThickness);
            }
            if (SETT.fovCircle)
            {
                // Outline
                Eutl.DrawCircle(Color.black, new Vector2(Screen.width / 2, Screen.height / 2), 149f);
                Eutl.DrawCircle(Color.black, new Vector2(Screen.width / 2, Screen.height / 2), 151f);

                Eutl.DrawCircle(new Color32(30, 144, 255, 255), new Vector2(Screen.width / 2, Screen.height / 2), 150f);
            }




        }




    }
}
