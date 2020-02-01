using FightClass.Wotlk.Shaman.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class EmpoweredRuneWeapon : TTask
    {
        readonly ISpellService spellService;

        public EmpoweredRuneWeapon(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 5000;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.EmpoweredRuneWeapon.KnownSpell
                && spellService.EmpoweredRuneWeapon.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.EmpoweredRuneWeapon.Launch();
        }
    }
}
