using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Security.Cryptography;

namespace SevenDTDMono
{
    public class CBuffs : MonoBehaviour
    {
        public static void LoadCustomXml(string rss)
        {
            // Replace "YourNamespace.YourXmlFileName.xml" with the correct namespace and file name of your embedded XML file.
            //string resourceName = "SevenDTDMono.Features.Buffs.Cbuffs.XML";
            
            // Get the assembly where your embedded resource is located (assuming it's the current assembly).
            Assembly assembly = Assembly.GetExecutingAssembly();
            Debug.LogWarning($"Searching in {assembly}");

            // Open the embedded resource as a stream.
            using (Stream resourceStream = assembly.GetManifestResourceStream(rss))
            {
                Debug.LogWarning($"Looking for {rss}...");
                if (resourceStream != null)
                {
                    Debug.LogWarning($"{rss} was found, loading..");
                    // Create an XmlReader to read the XML content from the stream.
                    using (XmlReader xmlReader = XmlReader.Create(resourceStream))
                    {
                        //MicroStopwatch msw = new MicroStopwatch(true);
                        // Now you can parse the XML using XElement or other XML parsing methods.
                        XElement rootElement = XElement.Load(xmlReader);
                        Debug.LogWarning($"Adding Buffs from {rss}");
                        foreach (XElement xelement in rootElement.Elements())
                        {
                            ParseAddBuff(xelement);
                        }
                    }
                }
                else
                {
                    Debug.LogWarning($"{rss} Could not be found!!");
                    // Handle the case when the embedded resource is not found.
                    //throw new FileNotFoundException("Embedded resource not found: " + resourceName);
                    
                }
            }
        }
        public static void ParseAddBuff(XElement _element)
        {

            BuffClass buffClass = new BuffClass("");
            if (_element.HasAttribute("name"))
            {
                buffClass.Name = _element.GetAttribute("name").ToLower();
                buffClass.NameTag = FastTags.Parse(_element.GetAttribute("name"));
                if (_element.HasAttribute("name_key"))
                {
                    buffClass.LocalizedName = Localization.Get(_element.GetAttribute("name_key"));
                }
                else
                {
                    buffClass.LocalizedName = Localization.Get(buffClass.Name);
                }
                if (_element.HasAttribute("description_key"))
                {
                    buffClass.DescriptionKey = _element.GetAttribute("description_key");
                    buffClass.Description = Localization.Get(buffClass.DescriptionKey);
                }
                if (_element.HasAttribute("tooltip_key"))
                {
                    buffClass.TooltipKey = _element.GetAttribute("tooltip_key");
                    buffClass.Tooltip = Localization.Get(buffClass.TooltipKey);
                }
                if (_element.HasAttribute("icon"))
                {
                    buffClass.Icon = _element.GetAttribute("icon");
                }
                if (_element.HasAttribute("hidden"))
                {
                    buffClass.Hidden = StringParsers.ParseBool(_element.GetAttribute("hidden"), 0, -1, true);
                }
                else
                {
                    buffClass.Hidden = false;
                }
                if (_element.HasAttribute("showonhud"))
                {
                    buffClass.ShowOnHUD = StringParsers.ParseBool(_element.GetAttribute("showonhud"), 0, -1, true);
                }
                else
                {
                    buffClass.ShowOnHUD = true;
                }
                if (_element.HasAttribute("update_rate"))
                {
                    buffClass.UpdateRate = StringParsers.ParseFloat(_element.GetAttribute("update_rate"), 0, -1, NumberStyles.Any);
                }
                else
                {
                    buffClass.UpdateRate = 1f;
                }
                if (_element.HasAttribute("remove_on_death"))
                {
                    buffClass.RemoveOnDeath = StringParsers.ParseBool(_element.GetAttribute("remove_on_death"), 0, -1, true);
                }
                if (_element.HasAttribute("display_type"))
                {
                    buffClass.DisplayType = EnumUtils.Parse<EnumEntityUINotificationDisplayMode>(_element.GetAttribute("display_type"), false);
                }
                else
                {
                    buffClass.DisplayType = EnumEntityUINotificationDisplayMode.IconOnly;
                }
                if (_element.HasAttribute("icon_color"))
                {
                    buffClass.IconColor = StringParsers.ParseColor32(_element.GetAttribute("icon_color"));
                }
                else
                {
                    buffClass.IconColor = Color.white;
                }
                if (_element.HasAttribute("icon_blink"))
                {
                    buffClass.IconBlink = StringParsers.ParseBool(_element.GetAttribute("icon_blink"), 0, -1, true);
                }
                buffClass.DamageSource = EnumDamageSource.Internal;
                buffClass.DamageType = EnumDamageTypes.None;
                buffClass.StackType = BuffEffectStackTypes.Replace;
                buffClass.DurationMax = 0f;
                foreach (XElement xelement in _element.Elements())
                {
                    if (xelement.Name == "display_value" && xelement.HasAttribute("value"))
                    {
                        buffClass.DisplayValueCVar = xelement.GetAttribute("value");
                    }
                    if (xelement.Name == "display_value_key" && xelement.HasAttribute("value"))
                    {
                        buffClass.DisplayValueKey = xelement.GetAttribute("value");
                    }
                    if (xelement.Name == "display_value_format" && xelement.HasAttribute("value") && !Enum.TryParse<BuffClass.CVarDisplayFormat>(xelement.GetAttribute("value"), true, out buffClass.DisplayValueFormat))
                    {
                        buffClass.DisplayValueFormat = BuffClass.CVarDisplayFormat.None;
                    }
                    if (xelement.Name == "damage_source" && xelement.HasAttribute("value"))
                    {
                        buffClass.DamageSource = EnumUtils.Parse<EnumDamageSource>(xelement.GetAttribute("value"), true);
                    }
                    if (xelement.Name == "damage_type" && xelement.HasAttribute("value"))
                    {
                        buffClass.DamageType = EnumUtils.Parse<EnumDamageTypes>(xelement.GetAttribute("value"), true);
                    }
                    if (xelement.Name == "stack_type" && xelement.HasAttribute("value"))
                    {
                        buffClass.StackType = EnumUtils.Parse<BuffEffectStackTypes>(xelement.GetAttribute("value"), true);
                    }
                    if (xelement.Name == "tags" && xelement.HasAttribute("value"))
                    {
                        buffClass.Tags = FastTags.Parse(xelement.GetAttribute("value"));
                    }
                    if (xelement.Name == "cures")
                    {
                        if (xelement.HasAttribute("value"))
                        {
                            buffClass.Cures = new List<string>(xelement.GetAttribute("value").Split(','));
                        }
                        else
                        {
                            buffClass.Cures = new List<string>();
                        }
                    }
                    else
                    {
                        buffClass.Cures = new List<string>();
                    }
                    if (xelement.Name == "duration" && xelement.HasAttribute("value"))
                    {
                        buffClass.DurationMax = StringParsers.ParseFloat(xelement.GetAttribute("value"), 0, -1, NumberStyles.Any);
                    }
                    if (xelement.Name == "update_rate" && xelement.HasAttribute("value"))
                    {
                        buffClass.UpdateRate = StringParsers.ParseFloat(xelement.GetAttribute("value"), 0, -1, NumberStyles.Any);
                    }
                    if (xelement.Name == "remove_on_death" && xelement.HasAttribute("value"))
                    {
                        buffClass.RemoveOnDeath = StringParsers.ParseBool(xelement.GetAttribute("value"), 0, -1, true);
                    }
                    if (xelement.Name == "requirement")
                    {
                        IRequirement requirement = RequirementBase.ParseRequirement(_element);
                        if (requirement != null)
                        {
                            buffClass.Requirements.Add(requirement);
                        }
                    }
                    if (xelement.Name == "requirements")
                    {
                        parseBuffRequirements(buffClass, xelement);
                    }
                    if (xelement.Name == "effect_group")
                    {
                        buffClass.Effects = MinEffectController.ParseXml(_element, null, MinEffectController.SourceParentType.BuffClass, buffClass.Name);
                    }
                }
                Debug.LogWarning($"adding {buffClass.Name} to O._listCbuffs");
                Objects._listCbuffs.Add(buffClass);
                Debug.LogWarning($"adding {buffClass.Name} to BuffManager");
                BuffManager.AddBuff(buffClass);
                return;
            }
            throw new Exception("buff must have an name!");
        }
        private static void parseBuffRequirements(BuffClass _buff, XElement _element)
        {
            if (_element.HasAttribute("compare_type") && _element.GetAttribute("compare_type").EqualsCaseInsensitive("or"))
            {
                _buff.OrCompare = true;
            }
            foreach (XElement xelement in _element.Elements("requirement"))
            {
                IRequirement requirement = RequirementBase.ParseRequirement(_element);
                if (requirement != null)
                {
                    _buff.Requirements.Add(requirement);
                }
            }
        } 
    }
}
