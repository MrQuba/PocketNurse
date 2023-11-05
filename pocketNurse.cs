using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework.Input;

namespace pocketNurse
{
    [Label("Hotkey Config")]
    public class YourModConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Pocket Nurse Settings")]
        [Label("Accessory Activation Key")]
        [DefaultValue("H")]
        public string AccessoryActivationKey;
    }
    public class pocketNurse : Mod
    { }
    public class pocketNurseConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Accessory Activation Key")]
        [DefaultValue(Keys.H)] // Default key binding
        [ReloadRequired]
        public Keys AccessoryActivationKey;
    }

}