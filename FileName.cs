

using System.IO;
using System.Reflection;
using System;

namespace Filename
{
    public class File{
        EntityAlive.Stamina  // float realtime stamina value
        
            EntityAlive.Water   // float realtime water value
       
            EntityAlive.Stats = EntityStats
    
            EntityStats.Entity = EntityPlayerlocal
    
            EntityStats.m_isEntityPlayer // bool value must be true to be player

    
            st= EntityStats.Water // actuall stats group for modifieble values
                st.BaseMax=100f  //float value for how much water player can have realtime does not change shit
                st.max and st.modifedmax are = To basemax
                st.max //just a read value
            st.value = //value rigth now, cannot exced st.max
            st.LossPassive = PassiveEffects(WaterGain)???
            st.m_value = //field value of the water
            st.regenerationAmount = //how much to regen

            a good infinity water would be to set stat.value=stat.max



            for food we can edit originalmax to higher valu and get the change 




            buffvalue.finished = true removes a buff
            buffvalue.buffclass = buffclass.damagetype(enumdamagetype)

Execute buff(string buff)
            
        {


            EntityPlayer primaryPlayer = GameManager.Instance.World.GetPrimaryPlayer();
            if (primaryPlayer != null)
            {
                EntityBuffs.BuffStatus buffStatus = primaryPlayer.Buffs.AddBuff(_params[0], -1, true, false, false, -1f);
                if (buffStatus != EntityBuffs.BuffStatus.Added)
                {
                    switch (buffStatus)
                    {
                        case EntityBuffs.BuffStatus.FailedInvalidName:
                            SingletonMonoBehaviour<SdtdConsole>.Instance.Output("Buff failed: buff \"" + _params[0] + "\" unknown");
                            ConsoleCmdBuff.PrintAvailableBuffNames();
                            return;
                        case EntityBuffs.BuffStatus.FailedImmune:
                            SingletonMonoBehaviour<SdtdConsole>.Instance.Output("Buff failed: entity is immune to \"" + _params[0] + "\"");
                            return;
                        case EntityBuffs.BuffStatus.FailedFriendlyFire:
                            SingletonMonoBehaviour<SdtdConsole>.Instance.Output("Buff failed: entity is friendly");
                            return;
                        default:
                            return;
                    }
                }
            }
        }
            


        private static void LoadAssembly(string assemblyName)
        {
            if (!IsAssemblyLoaded(assemblyName))
            {


                string assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "load", $"{assemblyName}.dll");
                if (File.Exists(assemblyPath))
                {
                    Assembly assembly = Assembly.LoadFrom(assemblyPath);
                    loadedAssemblies[assemblyName] = assembly;
                    Log.Out($"{assemblyName} has been loaded.");

                }
                else
                {
                    Log.Out($"{assemblyName} is not present at location: {assemblyPath}");
                }

                //Assembly assembly = Assembly.LoadFrom(assemblyPath);
                //loadedAssemblies[assemblyName] = assembly;

                //Log.Out($"{assemblyName} has been loaded.");
            }
        }








        private static void LoadAdditionalDLLs()
        {
            string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Load\\");


            foreach (string assemblyName in assembliesToLoad)
            {
                LoadAssembly(assemblyName);
            }

            //"7DaysToDie_Data\\Managed\\"
            // Load additional DLLs here using Assembly.LoadFrom()
            // For example:
            // Assembly additionalAssembly = Assembly.LoadFrom("path/to/additional.dll");
            // Add logic here to use types and methods from the loaded assembly as needed.
        }
        private static void LoadAdditionalDLLs()
        {
            string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Load\\");


            foreach (string assemblyName in assembliesToLoad)
            {
                LoadAssembly(assemblyName);
            }

            //"7DaysToDie_Data\\Managed\\"
            // Load additional DLLs here using Assembly.LoadFrom()
            // For example:
            // Assembly additionalAssembly = Assembly.LoadFrom("path/to/additional.dll");
            // Add logic here to use types and methods from the loaded assembly as needed.
        }
        private static void LoadAssembly(string assemblyName)
        {
            if (!IsAssemblyLoaded(assemblyName))
            {


                string assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "load", $"{assemblyName}.dll");
                if (File.Exists(assemblyPath))
                {
                    Assembly assembly = Assembly.LoadFrom(assemblyPath);
                    loadedAssemblies[assemblyName] = assembly;
                    Log.Out($"{assemblyName} has been loaded.");

                }
                else
                {
                    Log.Out($"{assemblyName} is not present at location: {assemblyPath}");
                }

                //Assembly assembly = Assembly.LoadFrom(assemblyPath);
                //loadedAssemblies[assemblyName] = assembly;

                //Log.Out($"{assemblyName} has been loaded.");
            }
        }
        private static bool IsAssemblyLoaded(string assemblyName)
        {
            return loadedAssemblies.ContainsKey(assemblyName);
        }
        private static void UnloadAdditionalDLLs()
        {
            // Unload additional DLLs if needed
            // Implement any cleanup logic for the loaded assemblies.
        }
        public static bool AreAllAssembliesLoaded()
        {
            foreach (string assemblyName in assembliesToLoad)
            {
                if (!IsAssemblyLoaded(assemblyName))
                {
                    return false;
                }
            }

            return true;
        }

    }




}

----------------------------------------------------------------------------------------------

if (SingletonMonoBehaviour<ConnectionManager>.Instance.IsServer)
	{
		QuestEventManager.Current.FinishTreasureQuest(base.OwnerQuest.QuestCode, base.OwnerQuest.OwnerJournal.OwnerPlayer);
		return;
	}
	SingletonMonoBehaviour<ConnectionManager>.Instance.SendToServer(NetPackageManager.GetPackage<NetPackageQuestObjectiveUpdate>().Setup(NetPackageQuestObjectiveUpdate.QuestObjectiveEventTypes.TreasureComplete, base.OwnerQuest.OwnerJournal.OwnerPlayer.entityId, base.OwnerQuest.QuestCode), false);
