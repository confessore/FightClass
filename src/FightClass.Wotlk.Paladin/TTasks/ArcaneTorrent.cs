﻿using FightClass.Wotlk.Paladin.Services.Interfaces;
using TreeTask;

namespace FightClass.Wotlk.Paladin.TTasks
{
    internal class ArcaneTorrent : TTask
    {
        readonly ISpellService spellService;

        public ArcaneTorrent(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 20000;

        public override bool Activate()
        {
            return spellService.ArcaneTorrent.KnownSpell
                && spellService.ArcaneTorrent.IsSpellUsable;
        }

        public override void Execute()
        {
            spellService.ArcaneTorrent.Launch();
        }
    }
}
