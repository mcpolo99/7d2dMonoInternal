using System;
using System.Runtime.InteropServices;
using UnityEngine;
using SETT = SevenDTDMono.Settings;
using Eutl = SevenDTDMono.ESPUtils;
using O = SevenDTDMono.Objects;

namespace SevenDTDMono
{
    public class Aimbot : MonoBehaviour {
        [DllImport("user32.dll")]//
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private void Start() 
        {

        }

        private void _Aimbot() {
            // This aimbot is pasted, if you wrote this let me know and I'll credit you.
            float minDist = 9999f;

            Vector2 target = Vector2.zero;

            foreach (EntityZombie zombie in O.zombieList)
                if (zombie && zombie.IsAlive()) {
                    Vector3 lookAt = zombie.emodel.GetBellyPosition();
                    Vector3 w2s = ESP.mainCam.WorldToScreenPoint(lookAt);

                    // If they're outside of our FOV.
                    if (Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(w2s.x, w2s.y)) > 150f)
                        continue;

                    if (Eutl.IsOnScreen(w2s)) {
                        float distance = Math.Abs(Vector2.Distance(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(Screen.width / 2, Screen.height / 2)));

                        if (distance < minDist) {
                            minDist = distance;
                            target = new Vector2(w2s.x, Screen.height - w2s.y);
                        }
                    }
                }

            if (O.PlayerList.Count > 1) {
                foreach (EntityPlayer player in O.PlayerList) {
                    if (player && player.IsAlive() && player != O.ELP) {
                        Vector3 lookAt = player.emodel.GetBellyPosition();
                        Vector3 w2s = ESP.mainCam.WorldToScreenPoint(lookAt);

                        if (Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(w2s.x, w2s.y)) > 150f)
                            continue;

                        if (Eutl.IsOnScreen(w2s)) {
                            float distance = Math.Abs(Vector2.Distance(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(Screen.width / 2, Screen.height / 2)));

                            if (distance < minDist) {
                                minDist = distance;
                                target = new Vector2(w2s.x, Screen.height - w2s.y);
                            }
                        }
                    }
                }
            }

            if (target != Vector2.zero) {
                double distX = target.x - Screen.width / 2f;
                double distY = target.y - Screen.height / 2f;

                distX /= 10;
                distY /= 10;

                mouse_event(0x0001, (int)distX, (int)distY, 0, 0);
            }
        }

        private void _MagicBullet() {
            EntityZombie ztarget = null;
            EntityPlayer pTarget = null;

            foreach (EntityZombie zombie in O.zombieList)
                if (zombie && zombie.IsAlive()) {
                    Vector3 head = zombie.emodel.GetHeadTransform().position;
                    Vector3 w2s = ESP.mainCam.WorldToScreenPoint(head);

                    // If they're outside of our FOV.
                    if (Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(w2s.x, w2s.y)) > 120f)
                        continue;

                    ztarget = zombie;
                }

            foreach (EntityPlayer player in O.PlayerList) {
                if (player && player.IsAlive() && player != O.ELP) {
                    Vector3 head = player.emodel.GetHeadTransform().position;
                    Vector3 w2s = ESP.mainCam.WorldToScreenPoint(head);

                    if (Vector2.Distance(new Vector2(Screen.width / 2, Screen.height / 2), new Vector2(w2s.x, w2s.y)) > 120f)
                        continue;

                    pTarget = player;
                }
            }

            if (pTarget) {
                // Purposely not giving the damage source an ID, so servers can't track you for killing people.
                DamageSource source = new DamageSource(EnumDamageSource.External, EnumDamageTypes.Concuss);

                ztarget.DamageEntity(source, 100, false, 1f);
                ztarget.AwardKill(O.ELP);
            }

            if (ztarget) {
                DamageSource source = new DamageSource(EnumDamageSource.External, EnumDamageTypes.Concuss);
                source.CreatorEntityId = O.ELP.entityId;

                ztarget.DamageEntity(source, 100, false, 1f);
                ztarget.AwardKill(O.ELP);

                O.ELP.AddKillXP(ztarget);
            }
        }

        private void Update() {
            /*if (!Input.anyKey || !Input.anyKeyDown) {
                return;
            }*/

            if (Input.GetKey(KeyCode.LeftAlt) && SETT.magicBullet) {
                _MagicBullet();
            }

            if (Input.GetKey(KeyCode.LeftAlt) && O.zombieList.Count > 0 && SETT.aimbot) {
                _Aimbot();
            }
        }


        public static bool infiniteAmmo;
    }


}
