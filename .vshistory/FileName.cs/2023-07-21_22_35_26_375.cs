//using System.Collections.Generic;
//using UnityEngine;

//public class BuffClass
//{
//    public float DurationMax
//    {
//        get
//        {
//            return this.durationMax;
//        }
//        set
//        {
//            if (this.initialDurationMax == 0f && value > 0f)
//            {
//                this.initialDurationMax = value;
//            }
//            this.durationMax = value;
//        }
//    }
//    public float InitialDurationMax
//    {
//        get
//        {
//            return this.initialDurationMax;
//        }
//    }
//    public BuffClass(string _name = "")
//    {
//        this.Name = _name.ToLower();
//        this.LocalizedName = string.Empty;
//        this.DescriptionKey = string.Empty;
//        this.TooltipKey = string.Empty;
//        this.Icon = string.Empty;
//        this.IconBlink = false;
//        this.OrCompare = false;
//        this.Requirements = new List<IRequirement>();
//        this.Hidden = false;
//        this.DamageType = EnumDamageTypes.None;
//        this.StackType = BuffEffectStackTypes.Replace;
//        this.durationMax = 0f;
//        this.initialDurationMax = 0f;
//    }
//    public void UpdateTimer(BuffValue _ev, float _deltaTime)
//    {
//        uint durationInTicks = _ev.DurationInTicks;
//        _ev.DurationInTicks = durationInTicks + 1U;
//        if (this.DurationMax > 0f && _ev.DurationInSeconds >= this.DurationMax)
//        {
//            _ev.Finished = true;
//        }
//    }
//    public void ModifyValue(EntityAlive _self, PassiveEffects _effect, BuffValue _bv, ref float _base_value, ref float _perc_value, FastTags _tags)
//    {
//        if (_bv.Remove)
//        {
//            return;
//        }
//        if (this.Requirements.Count > 0)
//        {
//            _self.MinEventContext.Tags |= _tags;
//            if (!this.canRun(_self.MinEventContext))
//            {
//                return;
//            }
//        }
//        if (this.Effects != null)
//        {
//            this.Effects.ModifyValue(_self, _effect, ref _base_value, ref _perc_value, _bv.DurationInSeconds, _tags, (this.StackType == BuffEffectStackTypes.Effect) ? _bv.StackEffectMultiplier : 1);
//        }
//    }
//    public void GetModifiedValueData(List<EffectManager.ModifierValuesAndSources> _modValueSources, EffectManager.ModifierValuesAndSources.ValueSourceType _sourceType, EntityAlive _self, PassiveEffects _effect, BuffValue _bv, ref float _base_value, ref float _perc_value, FastTags _tags)
//    {
//        if (_bv.Remove)
//        {
//            return;
//        }
//        if (this.Requirements.Count > 0)
//        {
//            _self.MinEventContext.Tags |= _tags;
//            if (!this.canRun(_self.MinEventContext))
//            {
//                return;
//            }
//        }
//        if (this.Effects != null)
//        {
//            this.Effects.GetModifiedValueData(_modValueSources, _sourceType, _self, _effect, ref _base_value, ref _perc_value, _bv.DurationInSeconds, _tags, (this.StackType == BuffEffectStackTypes.Effect) ? _bv.StackEffectMultiplier : 1);
//        }
//    }
//    public void FireEvent(MinEventTypes _eventType, MinEventParams _params)
//    {
//        if (this.Effects == null)
//        {
//            return;
//        }
//        if (!this.canRun(_params))
//        {
//            return;
//        }
//        this.Effects.FireEvent(_eventType, _params);
//    }
//    private bool canRun(MinEventParams _params)
//    {
//        if (this.Requirements == null || this.Requirements.Count <= 0)
//        {
//            return true;
//        }
//        if (this.OrCompare)
//        {
//            for (int i = 0; i < this.Requirements.Count; i++)
//            {
//                if (this.Requirements[i].IsValid(_params))
//                {
//                    return true;
//                }
//            }
//            return false;
//        }
//        for (int j = 0; j < this.Requirements.Count; j++)
//        {
//            if (!this.Requirements[j].IsValid(_params))
//            {
//                return false;
//            }
//        }
//        return true;
//    }
//    public string Name;
//    public string LocalizedName;
//    public string Description;
//    public string DescriptionKey;
//    public string Tooltip;
//    public string TooltipKey;
//    public string Icon;
//    public string DisplayValueCVar;
//    public string DisplayValueKey;
//    public BuffClass.CVarDisplayFormat DisplayValueFormat;
//    public Color IconColor;
//    public bool IconBlink;
//    public EnumEntityUINotificationDisplayMode DisplayType;
//    public List<string> Cures;
//    public bool OrCompare;
//    public List<IRequirement> Requirements;
//    public MinEffectController Effects;
//    public bool Hidden;
//    public bool ShowOnHUD = true;
//    private float durationMax;
//    private float initialDurationMax;
//    public float UpdateRate = 1f;
//    public EnumDamageTypes DamageType;
//    public EnumDamageSource DamageSource;
//    public BuffEffectStackTypes StackType;
//    public bool RemoveOnDeath = true;
//    public FastTags NameTag;
//    public FastTags Tags = FastTags.none;
//    public enum CVarDisplayFormat
//    {
//        None,
//        Float,
//        FlooredToInt,
//        RoundedToInt,
//        CeiledToInt,
//        Time,
//        Percentage
//    }
//}