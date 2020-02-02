using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Shaman.Enhancement.TTasks
{
    internal class Heal : TTask
    {
        readonly ISpellService spellService;

        public Heal(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 500;

        public override bool Activate()
        {
            return ObjectManager.Me.HealthPercent < 55
                && (spellService.HealingWave.KnownSpell
                || spellService.LesserHealingWave.KnownSpell)
                && (spellService.HealingWave.IsSpellUsable
                || spellService.LesserHealingWave.IsSpellUsable);
        }

        public override void Execute()
        {
            if (spellService.HealingWave.IsSpellUsable)
                spellService.HealingWave.Launch(true);
            else
                spellService.LesserHealingWave.Launch(true);
        }
    }
}
