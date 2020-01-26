using FightClass.Wotlk.Paladin.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Paladin.TTasks
{
    internal class Judgement : TTask
    {
        readonly ISpellService spellService;

        public Judgement(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 9000;

        public override bool Activate()
        {
            return (spellService.JudgementOfLight.KnownSpell
                && spellService.JudgementOfLight.IsSpellUsable)
                || (spellService.JudgementOfWisdom.KnownSpell
                && spellService.JudgementOfWisdom.IsSpellUsable);
        }

        public override void Execute()
        {
            if (ObjectManager.Me.ManaPercentage > 50
                || !spellService.JudgementOfWisdom.KnownSpell)
                spellService.JudgementOfLight.Launch();
            else
                spellService.JudgementOfWisdom.Launch();
        }
    }
}
