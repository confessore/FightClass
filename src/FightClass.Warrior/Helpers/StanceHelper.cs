using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wManager.Wow.Helpers;

namespace FightClass.Warrior.Helpers
{
    internal static class StanceHelper
    {
        public static Task<bool> HasBattleStance =>
            Task.FromResult(Lua.LuaDoString<int>("_,_,isActive,_ = GetShapeshiftFormInfo(1);", "isActive") == 1);

        public static Task CastBattleStanceAsync()
        {
            Lua.LuaDoString("CastSpellByName('Battle Stance')");
            return Task.CompletedTask;
        }

        public static Task<bool> HasDefensiveStance =>
            Task.FromResult(Lua.LuaDoString<int>("_,_,isActive,_ = GetShapeshiftFormInfo(2);", "isActive") == 1);

        public static Task CastDefensiveStanceAsync()
        {
            Lua.LuaDoString("CastSpellByName('Defensive Stance')");
            return Task.CompletedTask;
        }

        public static Task<bool> HasBerserkerStance =>
            Task.FromResult(Lua.LuaDoString<int>("_,_,isActive,_ = GetShapeshiftFormInfo(3);", "isActive") == 1);

        public static Task CastBerserkerStanceAsync()
        {
            Lua.LuaDoString("CastSpellByName('Berserker Stance')");
            return Task.CompletedTask;
        }

        public static Task<bool> HasMainHandEnhancement =>
            Task.FromResult(Lua.LuaDoString<int>("result = GetWeaponEnchantInfo()", "result") == 1);

        public static Task<bool> HasOffHandEnhancement =>
            Task.FromResult(Lua.LuaDoString<int>("_, _, _, result = GetWeaponEnchantInfo()", "result") == 1);
    }
}
