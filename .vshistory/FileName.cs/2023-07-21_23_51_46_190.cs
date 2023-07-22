/*

                                scrollBuff = GUILayout.BeginScrollView(scrollBuff, GUILayout.MaxWidth(300f), GUILayout.Width(250f), GUILayout.Height(200f));
                                {
                                    if (O.localPlayer != null)
                                    {
                                        if (O._BuffNames.Count == 1)
                                        {

                                            foreach (string buffClass in O._BuffNames)
                                            {
                                                // You can use GUILayout.Button to create a button for each buff name
                                                if (GUILayout.Button(buffClass))
                                                {

                                                    //EntityBuffs.BuffStatus buffStatus =
                                                    O.localPlayer.Buffs.AddBuff(buffClass, -1, true, false, false, 200f);
                                                    // Your logic when the button is clicked
                                                }

                                                // Alternatively, you can use GUILayout.Label to display the buff name as a label
                                                // GUILayout.Label(buffName);
                                            
                                                // Add your logic for when the label is clicked (if needed)
                                            }

                                        }
                                        else
                                        {
                                            GUILayout.Label("No buffs1");
                                        }
                                    }
                                    else
                                    {
                                        GUILayout.Label("Not ingame");
                                    }


                                }
                                GUILayout.EndScrollView();



 * 
 */