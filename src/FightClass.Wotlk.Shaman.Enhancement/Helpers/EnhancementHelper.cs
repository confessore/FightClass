using System.Threading.Tasks;
using wManager.Wow.Helpers;

namespace FightClass.Wotlk.Shaman.Enhancement.Helpers
{
    internal static class EnhancementHelper
    {
        public static bool HasTwoHandEquipped =>
            Lua.LuaDoString<int>("result = IsEquippedItemType('Two-Hand')", "result") == 1;
        public static bool HasShieldEquipped =>
            Lua.LuaDoString<int>("result = IsEquippedItemType('Shields')", "result") == 1;
        public static bool HasMainHandEnhancement =>
            Lua.LuaDoString<int>("result = GetWeaponEnchantInfo()", "result") == 1;
        public static bool HasOffHandEnhancement =>
            Lua.LuaDoString<int>("_, _, _, result = GetWeaponEnchantInfo()", "result") == 1;
    }
}
