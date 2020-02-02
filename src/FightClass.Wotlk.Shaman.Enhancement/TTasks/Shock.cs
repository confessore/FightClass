using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Shaman.Enhancement.TTasks
{
    internal class Shock : TTask
    {
        readonly ISpellService spellService;

        public Shock(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 100;

        public override bool Activate()
        {
            return (spellService.EarthShock.KnownSpell
                || spellService.FlameShock.KnownSpell)
                && (spellService.EarthShock.IsSpellUsable
                || spellService.FlameShock.IsSpellUsable);
        }

        public override void Execute()
        {
            if (!ObjectManager.Target.HaveBuff("Flame Shock"))
                spellService.FlameShock.Launch();
            else
                spellService.EarthShock.Launch();
        }
    }
}
