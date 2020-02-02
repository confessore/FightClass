using FightClass.Wotlk.Shaman.Enhancement.Helpers;
using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Shaman.Enhancement.TTasks
{
    internal class Imbue : TTask
    {
        readonly ISpellService spellService;

        public Imbue(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 999;

        public override bool Activate()
        {
            return (spellService.RockbiterWeapon.KnownSpell
                || spellService.WindfuryWeapon.KnownSpell
                || spellService.FlametongueWeapon.KnownSpell)
                && (spellService.RockbiterWeapon.IsSpellUsable
                || spellService.WindfuryWeapon.IsSpellUsable
                || spellService.FlametongueWeapon.IsSpellUsable)
                &&  (!EnhancementHelper.HasMainHandEnhancement
                    || (!EnhancementHelper.HasShieldEquipped
                    && !EnhancementHelper.HasTwoHandEquipped
                    && !EnhancementHelper.HasOffHandEnhancement));
        }

        public override void Execute()
        {
            if (spellService.WindfuryWeapon.KnownSpell && !EnhancementHelper.HasMainHandEnhancement)
                spellService.WindfuryWeapon.Launch();
            else if (spellService.FlametongueWeapon.KnownSpell && EnhancementHelper.HasMainHandEnhancement && !EnhancementHelper.HasOffHandEnhancement)
                spellService.FlametongueWeapon.Launch();
            else
                spellService.RockbiterWeapon.Launch();
        }
    }
}
