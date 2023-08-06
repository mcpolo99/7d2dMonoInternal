

using System.IO;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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












using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class Progression
{
    public Progression()
    {
        this.ExpToNextLevel = this.getExpForLevel((float)(this.Level + 1));
    }
    public Progression(EntityAlive _parent)
    {
        this.parent = _parent;
        this.ExpToNextLevel = this.getExpForLevel((float)(this.Level + 1));
        this.SetupData();
    }
    public Dictionary<int, ProgressionValue> GetDict()
    {
        return this.ProgressionValues.Dict;
    }
    public static int CalcId(string _name)
    {
        return Progression.ProgressionNameIds.Add(_name);
    }
    public ProgressionValue GetProgressionValue(int _id)
    {
        return this.ProgressionValues.Get(_id);
    }
    protected float getLevelFloat()
    {
        return (float)this.Level + (1f - (float)this.ExpToNextLevel / (float)this.GetExpForNextLevel());
    }
    protected int getExpForLevel(float _level)
    {
        return (int)Math.Min((float)Progression.BaseExpToLevel * Mathf.Pow(Progression.ExpMultiplier, _level), 2.1474836E+09f);
    }
    public int GetLevel()
    {
        return this.Level;
    }
    public int GetExpForNextLevel()
    {
        return this.getExpForLevel((float)Mathf.Clamp(this.Level + 1, 0, Progression.ClampExpCostAtLevel));
    }
    public float GetLevelProgressPercentage()
    {
        return this.getLevelFloat() - (float)this.Level;
    }
    public void ModifyValue(PassiveEffects _effect, ref float _base_val, ref float _perc_val, FastTags _tags)
    {
        if (_effect == PassiveEffects.AttributeLevel)
        {
            return;
        }
        if (_effect == PassiveEffects.SkillLevel)
        {
            return;
        }
        if (_effect == PassiveEffects.PerkLevel)
        {
            return;
        }
        for (int i = 0; i < this.ProgressionValueQuickList.Count; i++)
        {
            ProgressionValue progressionValue = this.ProgressionValueQuickList[i];
            if (progressionValue != null)
            {
                ProgressionClass progressionClass = progressionValue.ProgressionClass;
                if (progressionClass != null)
                {
                    MinEffectController effects = progressionClass.Effects;
                    if (effects != null)
                    {
                        HashSet<PassiveEffects> passivesIndex = effects.PassivesIndex;
                        if (passivesIndex != null && passivesIndex.Contains(_effect))
                        {
                            progressionClass.ModifyValue(this.parent, progressionValue, _effect, ref _base_val, ref _perc_val, _tags);
                        }
                    }
                }
            }
        }
    }
    public void GetModifiedValueData(List<EffectManager.ModifierValuesAndSources> _modValueSources, EffectManager.ModifierValuesAndSources.ValueSourceType _sourceType, PassiveEffects _effect, ref float _base_val, ref float _perc_val, FastTags _tags)
    {
        if (_effect == PassiveEffects.AttributeLevel)
        {
            return;
        }
        if (_effect == PassiveEffects.SkillLevel)
        {
            return;
        }
        if (_effect == PassiveEffects.PerkLevel)
        {
            return;
        }
        for (int i = 0; i < this.ProgressionValueQuickList.Count; i++)
        {
            ProgressionValue progressionValue = this.ProgressionValueQuickList[i];
            if (progressionValue != null)
            {
                ProgressionClass progressionClass = progressionValue.ProgressionClass;
                if (progressionClass != null && progressionClass.Effects != null && progressionClass.Effects.PassivesIndex != null && progressionClass.Effects.PassivesIndex.Contains(_effect))
                {
                    progressionClass.GetModifiedValueData(_modValueSources, _sourceType, this.parent, progressionValue, _effect, ref _base_val, ref _perc_val, _tags);
                }
            }
        }
    }
    public void Update()
    {
        if (this.timer <= 0f)
        {
            this.FireEvent(MinEventTypes.onSelfProgressionUpdate, this.parent.MinEventContext);
            this.timer = 1f;
        }
        else
        {
            this.timer -= Time.deltaTime;
        }
        this.parent.Buffs.SetCustomVar("_expdeficit", (float)this.ExpDeficit, true);
    }
    public void FireEvent(MinEventTypes _eventType, MinEventParams _params)
    {
        if (this.eventList == null)
        {
            return;
        }
        for (int i = 0; i < this.eventList.Count; i++)
        {
            this.eventList[i].FireEvent(_eventType, _params);
        }
    }
    public int AddLevelExp(int _exp, string _cvarXPName = "_xpOther", Progression.XPTypes _xpType = Progression.XPTypes.Other, bool useBonus = true)
    {
        if (this.parent as EntityPlayer == null)
        {
            return _exp;
        }
        float num = (float)_exp;
        if (useBonus)
        {
            if (this.xpFastTags == null)
            {
                this.xpFastTags = new FastTags[11];
                for (int i = 0; i < 11; i++)
                {
                    this.xpFastTags[i] = FastTags.Parse(((Progression.XPTypes)i).ToStringCached<Progression.XPTypes>());
                }
            }
            num = num * (float)GameStats.GetInt(EnumGameStats.XPMultiplier) / 100f;
            num = EffectManager.GetValue(PassiveEffects.PlayerExpGain, null, num, this.parent, null, this.xpFastTags[(int)_xpType], true, true, true, true, 1, true, false);
        }
        if (num > 214748370f)
        {
            num = 214748370f;
        }
        if (_xpType != Progression.XPTypes.Debug)
        {
            GameSparksCollector.IncrementCounter(GameSparksCollector.GSDataKey.XpEarnedBy, _xpType.ToStringCached<Progression.XPTypes>(), num, true, GameSparksCollector.GSDataCollection.SessionUpdates);
        }
        int level = this.Level;
        EntityPlayerLocal entityPlayerLocal = this.parent as EntityPlayerLocal;
        if (entityPlayerLocal)
        {
            entityPlayerLocal.PlayerUI.xui.CollectedItemList.AddIconNotification("ui_game_symbol_xp", (int)num, false);
        }
        this.AddLevelExpRecursive((int)num, _cvarXPName);
        if (this.Level != level)
        {
            Log.Out("{0} made level {1} (was {2}), exp for next level {3}", new object[]
            {
                this.parent.EntityName,
                this.Level,
                level,
                this.ExpToNextLevel
            });
        }
        return (int)num;
    }
    public void OnDeath()
    {
    }
    public void AddXPDeficit()
    {
        this.ExpDeficit += (int)((float)this.GetExpForNextLevel() * EffectManager.GetValue(PassiveEffects.ExpDeficitPerDeathPercentage, null, 0.1f, this.parent, null, default(FastTags), true, true, true, true, 1, true, false));
        this.ExpDeficit = Mathf.Clamp(this.ExpDeficit, 0, (int)((float)this.GetExpForNextLevel() * EffectManager.GetValue(PassiveEffects.ExpDeficitMaxPercentage, null, 0.5f, this.parent, null, default(FastTags), true, true, true, true, 1, true, false)));
        this.ExpDeficitGained = true;
    }
    public void OnRespawnFromDeath()
    {
        if (!this.ExpDeficitGained)
        {
            return;
        }
        EntityPlayerLocal entityPlayerLocal = this.parent as EntityPlayerLocal;
        if (this.ExpDeficit == (int)((float)this.GetExpForNextLevel() * EffectManager.GetValue(PassiveEffects.ExpDeficitMaxPercentage, null, 0.5f, this.parent, null, default(FastTags), true, true, true, true, 1, true, false)))
        {
            GameManager.ShowTooltip(entityPlayerLocal, Localization.Get("ttResurrectMaxXPLost"));
        }
        else
        {
            GameManager.ShowTooltip(entityPlayerLocal, string.Format(Localization.Get("ttResurrectXPLost"), EffectManager.GetValue(PassiveEffects.ExpDeficitPerDeathPercentage, null, 0.1f, this.parent, null, default(FastTags), true, true, true, true, 1, true, false) * 100f));
        }
        this.ExpDeficitGained = false;
    }
    private void AddLevelExpRecursive(int exp, string _cvarXPName)
    {
        if (this.Level >= Progression.MaxLevel)
        {
            this.Level = Progression.MaxLevel;
            return;
        }
        this.parent.Buffs.IncrementCustomVar(_cvarXPName, (float)exp);
        int num;
        if (this.ExpDeficit > 0)
        {
            num = exp - this.ExpDeficit;
            this.ExpDeficit -= exp;
            this.ExpDeficit = Mathf.Clamp(this.ExpDeficit, 0, (int)((float)this.GetExpForNextLevel() * EffectManager.GetValue(PassiveEffects.ExpDeficitMaxPercentage, null, 0.5f, this.parent, null, default(FastTags), true, true, true, true, 1, true, false)));
        }
        else
        {
            num = exp - this.ExpToNextLevel;
            this.ExpToNextLevel -= exp;
        }
        EntityPlayerLocal entityPlayerLocal = this.parent as EntityPlayerLocal;
        if (this.ExpDeficit <= 0)
        {
            int level = this.Level;
            if (this.ExpToNextLevel <= 0)
            {
                this.Level++;
                if (Progression.SkillPointMultiplier == 0f)
                {
                    this.SkillPoints += Progression.SkillPointsPerLevel;
                }
                else
                {
                    this.SkillPoints += (int)Math.Min((float)Progression.SkillPointsPerLevel * Mathf.Pow(Progression.SkillPointMultiplier, (float)this.Level), 2.1474836E+09f);
                }
                if (entityPlayerLocal)
                {
                    entityPlayerLocal.PlayerJournal.AddJournalEntry("skillPointTip", null, true, false);
                    GameSparksCollector.PlayerLevelUp(entityPlayerLocal, this.Level);
                }
                this.ExpToNextLevel = this.GetExpForNextLevel();
            }
            if ((this.ExpToNextLevel > num || this.Level == Progression.MaxLevel) && level != this.Level && entityPlayerLocal)
            {
                GameManager.ShowTooltip(entityPlayerLocal, string.Format(Localization.Get("ttLevelUp"), this.Level.ToString(), this.SkillPoints), string.Empty, "levelupplayer", null);
            }
        }
        if (num > 0)
        {
            this.AddLevelExpRecursive(num, _cvarXPName);
        }
    }
    public void SpendSkillPoints(int _points, string _progressionName)
    {
        ProgressionValue progressionValue = this.GetProgressionValue(_progressionName);
        if (progressionValue != null && progressionValue.ProgressionClass.CurrencyType == ProgressionCurrencyType.SP)
        {
            this.addProgressionCurrency(_points, progressionValue);
        }
    }
    public ProgressionValue GetProgressionValue(string _progressionName)
    {
        return this.ProgressionValues.Get(_progressionName);
    }
    public void GetPerkList(List<ProgressionValue> perkList, string _skillName)
    {
        perkList.Clear();
        for (int i = 0; i < this.ProgressionValueQuickList.Count; i++)
        {
            ProgressionValue progressionValue = this.ProgressionValueQuickList[i];
            if ((progressionValue.ProgressionClass.Type == ProgressionType.Perk || progressionValue.ProgressionClass.Type == ProgressionType.Book) && progressionValue.ProgressionClass.Parent.Name == _skillName)
            {
                perkList.Add(progressionValue);
            }
        }
    }
    private void addProgressionCurrency(int _currencyAmount, ProgressionValue _pv)
    {
        if (_pv == null)
        {
            return;
        }
        ProgressionClass progressionClass = _pv.ProgressionClass;
        if (_pv.Level >= progressionClass.MaxLevel)
        {
            if (_pv.Level > progressionClass.MaxLevel)
            {
                _pv.Level = progressionClass.MaxLevel;
            }
            return;
        }
        if (progressionClass.Type == ProgressionType.Skill)
        {
            _currencyAmount = (int)EffectManager.GetValue(PassiveEffects.SkillExpGain, null, (float)_currencyAmount, this.parent, null, default(FastTags), true, true, true, true, 1, true, false);
        }
        int num = _currencyAmount - _pv.CostForNextLevel;
        _pv.CostForNextLevel -= _currencyAmount;
        if (_pv.CostForNextLevel <= 0)
        {
            int level = _pv.Level;
            _pv.Level = level + 1;
            _pv.CostForNextLevel = progressionClass.CalculatedCostForLevel(_pv.Level + 1);
        }
        if (num > 0)
        {
            this.addProgressionCurrency(num, _pv);
        }
    }
    public void Write(BinaryWriter _bw, bool _IsNetwork = false)
    {
        _bw.Write(3);
        _bw.Write((ushort)this.Level);
        _bw.Write(this.ExpToNextLevel);
        _bw.Write((ushort)this.SkillPoints);
        int count = this.ProgressionValues.Count;
        _bw.Write(count);
        foreach (KeyValuePair<int, ProgressionValue> keyValuePair in this.ProgressionValues.Dict)
        {
            keyValuePair.Value.Write(_bw, _IsNetwork);
        }
        _bw.Write(this.ExpDeficit);
    }
    public static Progression Read(BinaryReader _br, EntityAlive _parent)
    {
        Progression progression = _parent.Progression;
        if (progression == null)
        {
            Log.Warning("Progression Read {0}, new", new object[] { _parent });
            progression = new Progression(_parent);
            _parent.Progression = progression;
        }
        byte b = _br.ReadByte();
        progression.Level = (int)_br.ReadUInt16();
        progression.ExpToNextLevel = _br.ReadInt32();
        progression.SkillPoints = (int)_br.ReadUInt16();
        int num = _br.ReadInt32();
        ProgressionValue progressionValue = new ProgressionValue();
        for (int i = 0; i < num; i++)
        {
            progressionValue.Read(_br);
            if (Progression.ProgressionClasses.ContainsKey(progressionValue.Name))
            {
                ProgressionValue progressionValue2 = progression.ProgressionValues.Get(progressionValue.Name);
                if (progressionValue2 != null)
                {
                    progressionValue2.CopyFrom(progressionValue);
                }
                else
                {
                    Log.Error("ProgressionValues missing {0}", new object[] { progressionValue.Name });
                    progressionValue2 = new ProgressionValue();
                    progressionValue2.CopyFrom(progressionValue);
                    progression.ProgressionValues.Add(progressionValue.Name, progressionValue2);
                }
            }
        }
        if (b > 2)
        {
            progression.ExpDeficit = _br.ReadInt32();
        }
        progression.SetupData();
        return progression;
    }
    private void SetupData()
    {
        foreach (KeyValuePair<string, ProgressionClass> keyValuePair in Progression.ProgressionClasses)
        {
            string name = keyValuePair.Value.Name;
            if (!this.ProgressionValues.Contains(name))
            {
                ProgressionValue progressionValue = new ProgressionValue(name)
                {
                    Level = keyValuePair.Value.MinLevel,
                    CostForNextLevel = keyValuePair.Value.CalculatedCostForLevel(this.Level + 1)
                };
                this.ProgressionValues.Add(name, progressionValue);
            }
        }
        this.ProgressionValueQuickList.Clear();
        foreach (KeyValuePair<int, ProgressionValue> keyValuePair2 in this.ProgressionValues.Dict)
        {
            this.ProgressionValueQuickList.Add(keyValuePair2.Value);
        }
        this.eventList.Clear();
        for (int i = 0; i < this.ProgressionValueQuickList.Count; i++)
        {
            ProgressionClass progressionClass = this.ProgressionValueQuickList[i].ProgressionClass;
            if (progressionClass.HasEvents())
            {
                this.eventList.Add(progressionClass);
            }
        }
    }
    public void ClearProgressionClassLinks()
    {
        if (this.ProgressionValueQuickList == null)
        {
            return;
        }
        foreach (ProgressionValue progressionValue in this.ProgressionValueQuickList)
        {
            if (progressionValue != null)
            {
                progressionValue.ClearProgressionClassLink();
            }
        }
        this.ProgressionValueQuickList.Clear();
    }
    public static void Cleanup()
    {
        if (Progression.ProgressionClasses != null)
        {
            Progression.ProgressionClasses.Clear();
        }
    }
    public void ResetProgression(bool _resetSkills = true, bool _resetBooks = false, bool _resetCrafting = false)
    {
        int num = 0;
        int i = 0;
        while (i < this.ProgressionValueQuickList.Count)
        {
            ProgressionValue progressionValue = this.ProgressionValueQuickList[i];
            ProgressionClass progressionClass = progressionValue.ProgressionClass;
            if (!progressionClass.IsBook)
            {
                goto IL_34;
            }
            if (_resetBooks)
            {
                progressionValue.Level = 0;
                goto IL_34;
            }
IL_C3:
            i++;
            continue;
IL_34:
            if (progressionClass.IsCrafting)
            {
                if (!_resetCrafting)
                {
                    goto IL_C3;
                }
                progressionValue.Level = 1;
            }
            if (!_resetSkills)
            {
                goto IL_C3;
            }
            if (progressionClass.IsAttribute)
            {
                if (progressionValue.Level > 1)
                {
                    for (int j = 2; j <= progressionValue.Level; j++)
                    {
                        num += progressionClass.CalculatedCostForLevel(j);
                    }
                    progressionValue.Level = 1;
                    goto IL_C3;
                }
                goto IL_C3;
            }
            else
            {
                if (progressionClass.IsPerk && progressionValue.Level > 0)
                {
                    for (int k = 1; k <= progressionValue.Level; k++)
                    {
                        num += progressionClass.CalculatedCostForLevel(k);
                    }
                    progressionValue.Level = 0;
                    goto IL_C3;
                }
                goto IL_C3;
            }
        }
        EntityPlayerLocal entityPlayerLocal = this.parent as EntityPlayerLocal;
        if (entityPlayerLocal != null)
        {
            entityPlayerLocal.PlayerUI.xui.Recipes.RefreshTrackedRecipe();
        }
        this.SkillPoints += num;
    }
    public const byte cVersion = 3;
    public static int BaseExpToLevel;
    public static int ClampExpCostAtLevel;
    public static float ExpMultiplier;
    public static int MaxLevel;
    public static int SkillPointsPerLevel;
    public static float SkillPointMultiplier;
    public static Dictionary<string, ProgressionClass> ProgressionClasses;
    private static DictionaryNameIdMapping ProgressionNameIds = new DictionaryNameIdMapping();
    public bool bProgressionStatsChanged;
    public int ExpToNextLevel;
    public int ExpDeficit;
    public int Level = 1;
    public int SkillPoints;
    private bool ExpDeficitGained;
    private DictionaryNameId<ProgressionValue> ProgressionValues = new DictionaryNameId<ProgressionValue>(Progression.ProgressionNameIds);
    private List<ProgressionValue> ProgressionValueQuickList = new List<ProgressionValue>();
    private List<ProgressionClass> eventList = new List<ProgressionClass>();
    private EntityAlive parent;
    private FastTags[] xpFastTags;
    private float timer = 1f;
    public enum XPTypes
    {
        Kill,
        Harvesting,
        Upgrading,
        Crafting,
        Selling,
        Quest,
        Looting,
        Party,
        Other,
        Repairing,
        Debug,
        Max
    }
}







using System;
using System.Collections.Generic;
using UnityEngine;
public class ProgressionClass
{
    public bool IsBookGroup
    {
        get
        {
            return this.Type == ProgressionType.BookGroup;
        }
    }
    public bool IsBook
    {
        get
        {
            return this.Type == ProgressionType.Book;
        }
    }
    public bool ValidDisplay(ProgressionClass.DisplayTypes displayType)
    {
        switch (displayType)
        {
            case ProgressionClass.DisplayTypes.Standard:
                return this.Type != ProgressionType.BookGroup && this.Type != ProgressionType.Crafting;
            case ProgressionClass.DisplayTypes.Book:
                return this.Type == ProgressionType.BookGroup;
            case ProgressionClass.DisplayTypes.Crafting:
                return this.Type == ProgressionType.Crafting;
            default:
                return false;
        }
    }
    public ProgressionCurrencyType CurrencyType
    {
        get
        {
            switch (this.Type)
            {
                case ProgressionType.Attribute:
                    return ProgressionCurrencyType.SP;
                case ProgressionType.Skill:
                    return ProgressionCurrencyType.XP;
                case ProgressionType.Perk:
                    return ProgressionCurrencyType.SP;
                default:
                    return ProgressionCurrencyType.None;
            }
        }
    }
    public ProgressionClass Parent
    {
        get
        {
            if (this.ParentName == null)
            {
                return this;
            }
            ProgressionClass progressionClass;
            if (Progression.ProgressionClasses.TryGetValue(this.ParentName, out progressionClass))
            {
                return progressionClass;
            }
            return null;
        }
    }
    public bool IsPerk
    {
        get
        {
            return this.Type == ProgressionType.Perk;
        }
    }
    public bool IsSkill
    {
        get
        {
            return this.Type == ProgressionType.Skill;
        }
    }
    public bool IsAttribute
    {
        get
        {
            return this.Type == ProgressionType.Attribute;
        }
    }
    public bool IsCrafting
    {
        get
        {
            return this.Type == ProgressionType.Crafting;
        }
    }
    public float ListSortOrder
    {
        get
        {
            if (this.IsPerk)
            {
                return this.Parent.ListSortOrder + this.listSortOrder * 0.001f;
            }
            if (this.IsSkill)
            {
                return this.Parent.ListSortOrder + this.listSortOrder;
            }
            return this.listSortOrder * 100f;
        }
        set
        {
            this.listSortOrder = value;
        }
    }
    public ProgressionClass.DisplayData AddDisplayData(string _item, int[] _qualityStarts, string[] _customIcon, string[] _customIconTint, string[] _customName, bool _customHasQuality)
    {
        if (this.DisplayDataList == null)
        {
            this.DisplayDataList = new List<ProgressionClass.DisplayData>();
        }
        ProgressionClass.DisplayData displayData = new ProgressionClass.DisplayData
        {
            ItemName = _item,
            QualityStarts = _qualityStarts,
            Owner = this,
            CustomIcon = _customIcon,
            CustomIconTint = _customIconTint,
            CustomName = _customName,
            CustomHasQuality = _customHasQuality
        };
        this.DisplayDataList.Add(displayData);
        return displayData;
    }
    public ProgressionClass(string _name)
    {
        this.Name = _name;
        this.NameKey = this.Name;
        this.NameTag = FastTags.GetTag(_name);
        this.DescKey = "";
        this.ListSortOrder = float.MaxValue;
        this.ParentName = null;
        this.Type = ProgressionType.None;
    }
    public void ModifyValue(EntityAlive _ea, ProgressionValue _pv, PassiveEffects _effect, ref float _base_value, ref float _perc_value, FastTags _tags = default(FastTags))
    {
        if (this.Effects == null)
        {
            return;
        }
        this.Effects.ModifyValue(_ea, _effect, ref _base_value, ref _perc_value, ProgressionClass.GetCalculatedLevel(_ea, _pv), _tags, 1);
    }
    public void GetModifiedValueData(List<EffectManager.ModifierValuesAndSources> _modValueSources, EffectManager.ModifierValuesAndSources.ValueSourceType _sourceType, EntityAlive _ea, ProgressionValue _pv, PassiveEffects _effect, ref float _base_value, ref float _perc_value, FastTags _tags = default(FastTags))
    {
        if (this.Effects == null)
        {
            return;
        }
        this.Effects.GetModifiedValueData(_modValueSources, _sourceType, _ea, _effect, ref _base_value, ref _perc_value, ProgressionClass.GetCalculatedLevel(_ea, _pv), _tags, 1);
    }
    public bool HasEvents()
    {
        return this.Effects != null && this.Effects.HasEvents();
    }
    public void FireEvent(MinEventTypes _eventType, MinEventParams _params)
    {
        if (this.Effects != null)
        {
            this.Effects.FireEvent(_eventType, _params);
        }
    }
    public static float GetCalculatedLevel(EntityAlive _ea, ProgressionValue _pv)
    {
        if (_pv == null)
        {
            return 0f;
        }
        if (_pv.calculatedFrame == Time.frameCount)
        {
            return _pv.calculatedLevel;
        }
        ProgressionClass progressionClass = _pv.ProgressionClass;
        if (progressionClass == null)
        {
            return 0f;
        }
        float num = (float)_pv.Level;
        if (progressionClass.Type == ProgressionType.Attribute)
        {
            num = EffectManager.GetValue(PassiveEffects.AttributeLevel, null, num, _ea, null, progressionClass.NameTag, true, true, true, true, 1, true, false);
        }
        else if (progressionClass.Type == ProgressionType.Skill)
        {
            num = EffectManager.GetValue(PassiveEffects.SkillLevel, null, num, _ea, null, progressionClass.NameTag, true, true, true, true, 1, true, false);
        }
        else if (progressionClass.Type == ProgressionType.Perk)
        {
            num = EffectManager.GetValue(PassiveEffects.PerkLevel, null, num, _ea, null, progressionClass.NameTag, true, true, true, true, 1, true, false);
        }
        num = Mathf.Min(num, ProgressionClass.GetCalculatedMaxLevel(_ea, _pv));
        num = Mathf.Max(num, (float)progressionClass.MinLevel);
        _pv.calculatedFrame = Time.frameCount;
        _pv.calculatedLevel = num;
        return num;
    }
    private static bool canRun(List<IRequirement> Requirements, MinEventParams _params)
    {
        if (Requirements != null)
        {
            int count = Requirements.Count;
            for (int i = 0; i < count; i++)
            {
                if (!Requirements[i].IsValid(_params))
                {
                    return false;
                }
            }
        }
        return true;
    }
    public static float GetCalculatedMaxLevel(EntityAlive _ea, ProgressionValue _pv)
    {
        ProgressionClass progressionClass = _pv.ProgressionClass;
        float num = 0f;
        if (progressionClass.LevelRequirements != null && progressionClass.LevelRequirements.Count > 0)
        {
            for (int i = 0; i < progressionClass.LevelRequirements.Count; i++)
            {
                LevelRequirement levelRequirement = progressionClass.LevelRequirements[i];
                if (ProgressionClass.canRun(levelRequirement.Requirements, _ea.MinEventContext) && (float)levelRequirement.Level > num)
                {
                    num = (float)levelRequirement.Level;
                }
            }
            if (!progressionClass.IsAttribute && num > (float)progressionClass.MaxLevel)
            {
                num = (float)progressionClass.MaxLevel;
            }
        }
        else if (progressionClass.IsAttribute)
        {
            num = 20f;
        }
        else
        {
            num = (float)progressionClass.MaxLevel;
        }
        return num;
    }
    public int CalculatedCostForLevel(int _level)
    {
        return (int)(Mathf.Pow(this.CostMultiplier, (float)_level) * (float)this.BaseCostToLevel);
    }
    public float GetPercentThisLevel(ProgressionValue _pv)
    {
        if (this.Type != ProgressionType.Skill)
        {
            return 0f;
        }
        if (_pv.Level == this.MaxLevel)
        {
            return 0f;
        }
        float num = (float)((int)(Mathf.Pow(this.CostMultiplier, (float)_pv.Level) * (float)this.BaseCostToLevel) - _pv.CostForNextLevel) / (Mathf.Pow(this.CostMultiplier, (float)_pv.Level) * (float)this.BaseCostToLevel);
        if (!float.IsNaN(num))
        {
            return num;
        }
        return 0f;
    }
    public void HandleCheckCrafting(EntityPlayerLocal _player, int _oldLevel, int _newLevel)
    {
        if (this.DisplayDataList != null)
        {
            for (int i = 0; i < this.DisplayDataList.Count; i++)
            {
                this.DisplayDataList[i].HandleCheckCrafting(_player, _oldLevel, _newLevel);
            }
        }
    }
    public override string ToString()
    {
        return string.Format("{0}, {1}, lvl {2} to {3}", new object[]
        {
            base.ToString(),
            this.Name,
            this.MinLevel,
            this.MaxLevel
        });
    }
    public readonly string Name;
    public readonly FastTags NameTag;
    public float ParentMaxLevelRatio = 1f;
    public string NameKey;
    public string DescKey;
    public string LongDescKey;
    public string Icon;
    public int MinLevel;
    public int MaxLevel;
    public int BaseCostToLevel;
    public float CostMultiplier;
    public ProgressionClass.DisplayTypes DisplayType;
    public MinEffectController Effects;
    public List<LevelRequirement> LevelRequirements;
    public List<ProgressionClass> Children;
    public string ParentName;
    public ProgressionType Type;
    private float listSortOrder;
    public List<ProgressionClass.DisplayData> DisplayDataList;
    public enum DisplayTypes
    {
        Standard,
        Book,
        Crafting
    }
    public class ListSortOrderComparer : IComparer<ProgressionValue>
    {
        private ListSortOrderComparer()
        {
        }
        public int Compare(ProgressionValue _x, ProgressionValue _y)
        {
            return _x.ProgressionClass.ListSortOrder.CompareTo(_y.ProgressionClass.ListSortOrder);
        }
        public static ProgressionClass.ListSortOrderComparer Instance = new ProgressionClass.ListSortOrderComparer();
    }
    public class DisplayData
    {
        public ItemClass Item
        {
            get
            {
                if (this.item == null)
                {
                    this.item = ItemClass.GetItemClass(this.ItemName, false);
                }
                return this.item;
            }
        }
        public bool HasQuality
        {
            get
            {
                if (this.ItemName != "")
                {
                    return this.Item.HasQuality;
                }
                return this.CustomHasQuality;
            }
        }
        public string GetName(int level)
        {
            if (this.ItemName != "")
            {
                return this.Item.GetLocalizedItemName();
            }
            if (this.CustomName == null)
            {
                return "";
            }
            int num = this.GetQualityLevel(level);
            if (num >= this.CustomName.Length)
            {
                num = 0;
            }
            return this.CustomName[num];
        }
        public string GetIcon(int level)
        {
            if (this.ItemName != "")
            {
                return this.Item.GetIconName();
            }
            if (this.CustomIcon == null)
            {
                return "";
            }
            int num = this.GetQualityLevel(level);
            if (num >= this.CustomIcon.Length)
            {
                num = 0;
            }
            return this.CustomIcon[num];
        }
        public string GetIconTint(int level)
        {
            if (this.ItemName != "")
            {
                return Utils.ColorToHex(this.Item.GetIconTint(null));
            }
            if (this.CustomIconTint == null)
            {
                return "FFFFFF";
            }
            int num = this.GetQualityLevel(level);
            if (num >= this.CustomName.Length)
            {
                num = 0;
            }
            return this.CustomIconTint[num];
        }
        public int GetQualityLevel(int level)
        {
            for (int i = 0; i < this.QualityStarts.Length; i++)
            {
                if (this.QualityStarts[i] > level)
                {
                    return i;
                }
            }
            return this.QualityStarts.Length;
        }
        public int GetNextPoints(int level)
        {
            for (int i = 0; i < this.QualityStarts.Length; i++)
            {
                if (this.QualityStarts[i] > level)
                {
                    return this.QualityStarts[i];
                }
            }
            return 0;
        }
        public bool IsComplete(int level)
        {
            for (int i = 0; i < this.QualityStarts.Length; i++)
            {
                if (this.QualityStarts[i] > level)
                {
                    return false;
                }
            }
            return true;
        }
        public void AddUnlockData(string itemName, int unlockTier, string[] recipeList)
        {
            if (this.UnlockDataList == null)
            {
                this.UnlockDataList = new List<ProgressionClass.DisplayData.UnlockData>();
            }
            this.UnlockDataList.Add(new ProgressionClass.DisplayData.UnlockData
            {
                ItemName = itemName,
                UnlockTier = unlockTier,
                RecipeList = recipeList
            });
        }
        public ItemClass GetUnlockItem(int index)
        {
            if (this.UnlockDataList == null)
            {
                return null;
            }
            if (index >= this.UnlockDataList.Count)
            {
                return null;
            }
            return this.UnlockDataList[index].Item;
        }
        private ProgressionClass.DisplayData.UnlockData GetUnlockData(int index)
        {
            if (this.UnlockDataList == null)
            {
                return null;
            }
            if (index >= this.UnlockDataList.Count)
            {
                return null;
            }
            return this.UnlockDataList[index];
        }
        public string GetUnlockItemIconName(int index)
        {
            ItemClass unlockItem = this.GetUnlockItem(index);
            if (unlockItem != null)
            {
                return unlockItem.GetIconName();
            }
            return "";
        }
        public string GetUnlockItemName(int index)
        {
            ItemClass unlockItem = this.GetUnlockItem(index);
            if (unlockItem != null)
            {
                return unlockItem.GetLocalizedItemName();
            }
            return "";
        }
        public List<int> GetUnlockItemRecipes(int index)
        {
            if (this.UnlockDataList == null)
            {
                return null;
            }
            if (index >= this.UnlockDataList.Count)
            {
                return null;
            }
            List<int> list = new List<int>();
            if (this.Item != null)
            {
                list.Add(this.Item.Id);
            }
            else
            {
                ProgressionClass.DisplayData.UnlockData unlockData = this.UnlockDataList[index];
                if (unlockData != null)
                {
                    if (unlockData.RecipeList != null)
                    {
                        for (int i = 0; i < unlockData.RecipeList.Length; i++)
                        {
                            list.Add(ItemClass.GetItemClass(unlockData.RecipeList[i], true).Id);
                        }
                    }
                    else if (unlockData.Item != null)
                    {
                        list.Add(unlockData.Item.Id);
                    }
                }
            }
            return list;
        }
        public string GetUnlockItemIconAtlas(EntityPlayerLocal player, int index)
        {
            ProgressionClass.DisplayData.UnlockData unlockData = this.GetUnlockData(index);
            if (unlockData == null)
            {
                return "ItemIconAtlas";
            }
            if (this.GetQualityLevel(player.Progression.GetProgressionValue(this.Owner.Name).Level) <= unlockData.UnlockTier)
            {
                return "ItemIconAtlasGreyscale";
            }
            return "ItemIconAtlas";
        }
        public bool GetUnlockItemLocked(EntityPlayerLocal player, int index)
        {
            ProgressionClass.DisplayData.UnlockData unlockData = this.GetUnlockData(index);
            return unlockData != null && this.GetQualityLevel(player.Progression.GetProgressionValue(this.Owner.Name).Level) <= unlockData.UnlockTier;
        }
        public void HandleCheckCrafting(EntityPlayerLocal _player, int _oldLevel, int _newLevel)
        {
            if (this.UnlockDataList == null)
            {
                return;
            }
            for (int i = 0; i < this.QualityStarts.Length; i++)
            {
                int num = this.QualityStarts[i];
                if (_oldLevel < num && _newLevel >= num)
                {
                    if (this.HasQuality)
                    {
                        GameManager.ShowTooltip(_player, Localization.Get("ttCraftingSkillUnlockQuality"), new string[]
                        {
                            Localization.Get(this.Owner.NameKey),
                            this.GetName(_newLevel),
                            (i + 1).ToString()
                        }, ProgressionClass.DisplayData.CompletionSound, null);
                    }
                    else
                    {
                        GameManager.ShowTooltip(_player, Localization.Get("ttCraftingSkillUnlock"), new string[]
                        {
                            Localization.Get(this.Owner.NameKey),
                            this.GetName(_oldLevel)
                        }, ProgressionClass.DisplayData.CompletionSound, null);
                    }
                }
            }
        }
        private ItemClass item;
        public string ItemName = "";
        public string[] CustomIcon;
        public string[] CustomIconTint;
        public string[] CustomName;
        public bool CustomHasQuality;
        public int[] QualityStarts;
        public List<ProgressionClass.DisplayData.UnlockData> UnlockDataList = new List<ProgressionClass.DisplayData.UnlockData>();
        public static string CompletionSound = "";
        public ProgressionClass Owner;
        public class UnlockData
        {
            public ItemClass Item
            {
                get
                {
                    if (this.item == null)
                    {
                        this.item = ItemClass.GetItemClass(this.ItemName, false);
                    }
                    return this.item;
                }
            }
            private ItemClass item;
            public string[] RecipeList;
            public string ItemName = "";
            public int UnlockTier;
        }
    }
}




using System;
using System.IO;
public class ProgressionValue
{
    public ProgressionValue()
    {
    }
    public ProgressionValue(string _name)
    {
        this.name = _name;
    }
    public string Name
    {
        get
        {
            return this.name;
        }
    }
    public ProgressionClass ProgressionClass
    {
        get
        {
            if (this.cachedProgressionClass == null && !Progression.ProgressionClasses.TryGetValue(this.name, out this.cachedProgressionClass))
            {
                Log.Error("ProgressionValue ProgressionClasses missing {0}", new object[] { this.name });
            }
            return this.cachedProgressionClass;
        }
    }
    public int CostForNextLevel
    {
        get
        {
            if (this.ProgressionClass.CurrencyType == ProgressionCurrencyType.SP)
            {
                return this.ProgressionClass.CalculatedCostForLevel(this.Level + 1);
            }
            return this.costForNextLevel;
        }
        set
        {
            if (this.ProgressionClass.CurrencyType != ProgressionCurrencyType.SP)
            {
                this.costForNextLevel = value;
            }
        }
    }
    public int Level
    {
        get
        {
            ProgressionClass progressionClass = this.ProgressionClass;
            if (progressionClass == null)
            {
                return this.level;
            }
            if (progressionClass.IsSkill)
            {
                return progressionClass.MaxLevel;
            }
            return this.level;
        }
        set
        {
            this.calculatedFrame = -1;
            if (this.ProgressionClass == null)
            {
                this.level = value;
                return;
            }
            if (this.ProgressionClass.IsSkill)
            {
                this.level = this.ProgressionClass.MaxLevel;
                return;
            }
            this.level = value;
        }
    }
    public int CalculatedLevel(EntityAlive _ea)
    {
        return (int)ProgressionClass.GetCalculatedLevel(_ea, this);
    }
    public int CalculatedMaxLevel(EntityAlive _ea)
    {
        return (int)ProgressionClass.GetCalculatedMaxLevel(_ea, this);
    }
    public bool IsLocked(EntityAlive _ea)
    {
        return ProgressionClass.GetCalculatedMaxLevel(_ea, this) == 0f;
    }
    public float PercToNextLevel
    {
        get
        {
            return 1f - (float)this.CostForNextLevel / (float)this.ProgressionClass.CalculatedCostForLevel(this.level + 1);
        }
    }
    public void ClearProgressionClassLink()
    {
        this.cachedProgressionClass = null;
    }
    public bool CanPurchase(EntityAlive _ea, int _level)
    {
        return _level <= this.ProgressionClass.MaxLevel;
    }
    public void CopyFrom(ProgressionValue _pv)
    {
        this.name = _pv.name;
        this.level = _pv.level;
        this.costForNextLevel = _pv.costForNextLevel;
    }
    public void Read(BinaryReader _reader)
    {
        _reader.ReadByte();
        this.name = _reader.ReadString();
        this.level = (int)_reader.ReadByte();
        this.costForNextLevel = _reader.ReadInt32();
    }
    public void Write(BinaryWriter _writer, bool _IsNetwork)
    {
        _writer.Write(1);
        _writer.Write(this.name);
        _writer.Write((byte)this.level);
        _writer.Write(this.costForNextLevel);
    }
    private const byte Version = 1;
    private string name;
    private int level;
    private int costForNextLevel;
    public int calculatedFrame;
    public float calculatedLevel;
    private ProgressionClass cachedProgressionClass;
}




for each ProgressionClass that is inside some where of Progression.ProgressionClasses, i want to take ProgressionClass.Name to be the name of the button 

foreach ()
{

        if (GUILayout.Button(ProgressionClass.Name))
        {
            int maxlvl = ProgressionClass.MaxLevel; // i want to get the maxlevel for  later sett the ProgressionValue

        }
}


But the thing is That the current level is inside of ProgressionValue.Level  that need to be set to ProgressionClass.MaxLevel

Mayebe i should make a buttonlist of ProgressionValue instead? 


                