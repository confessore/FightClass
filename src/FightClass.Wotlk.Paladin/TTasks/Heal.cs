using FightClass.Wotlk.Paladin.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Paladin.TTasks
{
    internal class Heal : TTask
    {
        readonly ISpellService spellService;

        public Heal(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 15000;

        public override bool Activate()
        {
            return ObjectManager.Me.HealthPercent < 55
                && (spellService.HolyLight.KnownSpell
                || spellService.FlashOfLight.KnownSpell)
                && (spellService.HolyLight.IsSpellUsable
                || spellService.FlashOfLight.IsSpellUsable);
        }

        public override void Execute()
        {
            if (spellService.HolyLight.IsSpellUsable)
                spellService.HolyLight.Launch(true);
            else
                spellService.FlashOfLight.Launch(true);
        }
    }
}
