using FightClass.Wotlk.Shaman.Services.Interfaces;
using System.Linq;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Shaman.TTasks
{
    internal class Totem : TTask
    {
        readonly ISpellService spellService;

        public Totem(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 997;

        public override bool Activate()
        {
            return (spellService.StrengthOfEarthTotem.KnownSpell
                || spellService.WindfuryTotem.KnownSpell
                || spellService.SearingTotem.KnownSpell
                || spellService.HealingStreamTotem.KnownSpell)
                && (spellService.StrengthOfEarthTotem.IsSpellUsable
                || spellService.WindfuryTotem.IsSpellUsable
                || spellService.SearingTotem.IsSpellUsable
                || spellService.HealingStreamTotem.IsSpellUsable)
                && (!spellService.StrengthOfEarth.HaveBuff
                || !spellService.WindfuryTotem.HaveBuff
                || NeedSearingTotem
                || NeedHealingStreamTotem);
        }

        public override void Execute()
        {
            if (spellService.StrengthOfEarth.HaveBuff && spellService.WindfuryTotem.HaveBuff && spellService.SearingTotem.KnownSpell)
                spellService.SearingTotem.Launch();
            else if (spellService.StrengthOfEarth.HaveBuff && spellService.WindfuryTotem.KnownSpell)
                spellService.WindfuryTotem.Launch();
            else if (NeedHealingStreamTotem && spellService.HealingStreamTotem.KnownSpell)
                spellService.HealingStreamTotem.Launch();
            else if (spellService.StrengthOfEarthTotem.KnownSpell)
                spellService.StrengthOfEarthTotem.Launch();
        }

        bool NeedSearingTotem =>
            !ObjectManager.GetObjectWoWUnit().Any(x => x.Name.Contains("Searing"))
            || ObjectManager.GetObjectWoWUnit().FirstOrDefault(x => x.Name.Contains("Searing")).GetDistance > 19f;

        bool NeedHealingStreamTotem =>
            !ObjectManager.GetObjectWoWUnit().Any(x => x.Name.Contains("Healing Stream"))
            || ObjectManager.GetObjectWoWUnit().FirstOrDefault(x => x.Name.Contains("Healing Stream")).GetDistance > 29f;
    }
}
