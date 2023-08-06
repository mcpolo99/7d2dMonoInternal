using System;
using System.Runtime.InteropServices;
using UnityEngine;
using SETT = SevenDTDMono.Settings;
using Eutl = SevenDTDMono.ESPUtils;
using O = SevenDTDMono.Objects;


namespace SevenDTDMono{
    public class ESP : MonoBehaviour {
        //public bool fovCircle = false;
        #region local def
        public static Camera mainCam;

        private Color blackCol;
        private Color entityBoxCol;
        private Color crosshairCol;

        private readonly float crosshairScale = 14f;
        private readonly float lineThickness = 1.75f;




        #endregion

        private void Start() {

            #region local settings start
            // Camera.main is a very expensive getter, so we want to do it once and cache the result.
            mainCam = Camera.main;

            blackCol = new Color(0f, 0f, 0f, 120f);
            entityBoxCol = new Color(0.42f, 0.36f, 0.90f, 1f);
            crosshairCol = new Color32(30, 144, 255, 255);
            #endregion
        }

        private void Update() {
            if (SETT.zombieCornerBox) 
            {
                SETT.zombieBox = false;
            } else if (SETT.zombieBox && SETT.zombieCornerBox) {
                SETT.zombieCornerBox = false;
            } //checking if Zombie box toggles stuff is enabled?

            if (SETT.playerCornerBox) {
                SETT.playerBox = false;
            } else if (SETT.playerBox && SETT.playerCornerBox) {
                SETT.playerCornerBox = false;
            } //Checking if Player box toggles stiuff is enabled?

            if (O.ELP){
                O.ELP.weaponCrossHairAlpha = SETT.crosshair ? 0f : 255f;
            }//crosshair check if crosshair toogle is enabled?
        }

        private void OnGUI() {
            // Run once per frame.
            if (Event.current.type != EventType.Repaint) {
                return;
            }

            if (!mainCam) {
                mainCam = Camera.main;
            }



            if (SETT.fovCircle) {
                // Outline
                Eutl.DrawCircle(Color.black, new Vector2(Screen.width / 2, Screen.height / 2), 149f);
                Eutl.DrawCircle(Color.black, new Vector2(Screen.width / 2, Screen.height / 2), 151f);

                Eutl.DrawCircle(new Color32(30, 144, 255, 255), new Vector2(Screen.width / 2, Screen.height / 2), 150f);
            }//if fov toggle enabled draw circle
            
            if (SETT.crosshair) {
                // Constantly redefining these vectors so that you can change your resolution and the crosshair will still be in the middle.
                Vector2 lineHorizontalStart = new Vector2(Screen.width / 2 - crosshairScale, Screen.height / 2);
                Vector2 lineHorizontalEnd = new Vector2(Screen.width / 2 + crosshairScale, Screen.height / 2);

                Vector2 lineVerticalStart = new Vector2(Screen.width / 2, Screen.height / 2 - crosshairScale);
                Vector2 lineVerticalEnd = new Vector2(Screen.width / 2, Screen.height / 2 + crosshairScale);

                ESPUtils.DrawLine(lineHorizontalStart, lineHorizontalEnd, crosshairCol, lineThickness);
                ESPUtils.DrawLine(lineVerticalStart, lineVerticalEnd, crosshairCol, lineThickness);
            }//if crosshair toggle draw crosshair

            if (O._listZombies.Count > 0 && (SETT.zombieName || SETT.zombieBox || SETT.zombieHealth)) {
                foreach (EntityZombie zombie in O._listZombies) {
                    if (!zombie || !zombie.IsAlive()) {
                        continue;
                    }

                    Vector3 w2s = mainCam.WorldToScreenPoint(zombie.transform.position);

                    if (Eutl.IsOnScreen(w2s)) {
                        Vector3 w2sHead = mainCam.WorldToScreenPoint(zombie.emodel.GetHeadTransform().position);
                        
                        float height = Mathf.Abs(w2sHead.y - w2s.y);
                        float x = w2s.x - height * 0.3f /* Shift the box to the left a bit. */;
                        float y = Screen.height - w2sHead.y;

                        if (SETT.zombieBox) {
                            ESPUtils.OutlineBox(new Vector2(x - 1f, y - 1f), new Vector2((height / 2f) + 2f, height + 2f), blackCol);
                            ESPUtils.OutlineBox(new Vector2(x, y), new Vector2(height / 2f, height), entityBoxCol);
                            ESPUtils.OutlineBox(new Vector2(x + 1f, y + 1f), new Vector2((height / 2f) - 2f, height - 2f), blackCol);
                        } else if (SETT.zombieCornerBox) {
                            ESPUtils.CornerBox(new Vector2(w2sHead.x, y ), height / 2f, height, 2f, entityBoxCol, true);
                        }

                        if (SETT.zombieName) {
                            ESPUtils.DrawString(new Vector2(w2s.x, Screen.height - w2s.y + 8f/* Extra spacing below the box esp. */),
                            zombie.EntityName.Replace("zombie", "Zombie_"), Color.red, true, 12, FontStyle.Normal);
                        }

                        if (SETT.zombieHealth) {
                            float health = zombie.Health;
                            int maxHealth = zombie.GetMaxHealth();
                            float percentage = health / maxHealth;
                            float barHeight = height * percentage;

                            Color barColour = ESPUtils.GetHealthColour(health, maxHealth);

                            ESPUtils.RectFilled(x - 5f, y, 4f, height, blackCol);
                            ESPUtils.RectFilled(x - 4f, y + height - barHeight - 1f, 2f, barHeight, barColour);
                        }
                    }
                }
            }//some zombie check 

            if (O.PlayerList.Count > 1 && (SETT.playerName || SETT.playerBox || SETT.playerHealth)) {
                foreach (EntityPlayer player in O.PlayerList) {
                    if (!player || player == O.ELP || !player.IsAlive()) {
                        continue;
                    }

                    Vector3 w2s = mainCam.WorldToScreenPoint(player.transform.position);

                    if (ESPUtils.IsOnScreen(w2s)) {
                        Vector3 w2sHead = mainCam.WorldToScreenPoint(player.emodel.GetHeadTransform().position);

                        float height = Mathf.Abs(w2sHead.y - w2s.y);
                        float x = w2s.x - height * 0.3f ;
                        float y = Screen.height - w2sHead.y;

                        if (SETT.playerBox) {
                            ESPUtils.OutlineBox(new Vector2(x - 1f, y - 1f), new Vector2((height / 2f) + 2f, height + 2f), blackCol);
                            ESPUtils.OutlineBox(new Vector2(x, y), new Vector2(height / 2f, height), entityBoxCol);
                            ESPUtils.OutlineBox(new Vector2(x + 1f, y + 1f), new Vector2((height / 2f) - 2f, height - 2f), blackCol);
                        }
                        else if (SETT.playerCornerBox) {
                            ESPUtils.CornerBox(new Vector2(w2sHead.x, y), height / 2f, height, 2f, entityBoxCol, true);
                        }

                        if (SETT.playerName) {
                            ESPUtils.DrawString(new Vector2(w2s.x, Screen.height - w2s.y + 8f),
                            player.EntityName, Color.red, true, 12, FontStyle.Normal);
                        }

                        if (SETT.playerHealth) {
                            float health = player.Health;
                            int maxHealth = player.GetMaxHealth();
                            float percentage = health / maxHealth;
                            float barHeight = height * percentage;

                            Color barColour = ESPUtils.GetHealthColour(health, maxHealth);

                            ESPUtils.RectFilled(x - 5f, y, 4f, height, blackCol);
                            ESPUtils.RectFilled(x - 4f, y + height - barHeight - 1f, 2f, barHeight, barColour);
                        }
                    }
                }
            }//some Player check
        }


    }
}
