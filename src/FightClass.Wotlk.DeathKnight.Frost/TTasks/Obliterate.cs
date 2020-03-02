using FightClass.Wotlk.DeathKnight.Frost.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.DeathKnight.Frost.TTasks
{
    internal class Obliterate : TTask
    {
        readonly ISpellService spellService;

        public Obliterate(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 8000;

        public override bool Activate()
        {
            return ObjectManager.Target != null
                && spellService.Obliterate.KnownSpell
                && spellService.Obliterate.IsSpellUsable
                && ObjectManager.Target.HaveBuff("Frost Fever")
                && ObjectManager.Target.HaveBuff("Blood Plague");
        }

        public override void Execute()
        {
            spellService.Obliterate.Launch();
        }
    }
}
