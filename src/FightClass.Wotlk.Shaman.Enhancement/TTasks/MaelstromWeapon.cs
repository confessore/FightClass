using FightClass.Wotlk.Shaman.Enhancement.Services.Interfaces;
using TreeTask;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Shaman.Enhancement.TTasks
{
    internal class MaelstromWeapon : TTask
    {
        readonly ISpellService spellService;

        public MaelstromWeapon(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public override int Priority => 102;

        public override bool Activate()
        {
            return ObjectManager.Me.InCombat
                && ObjectManager.Target != null
                && spellService.LightningBolt.KnownSpell
                && spellService.LightningBolt.IsSpellUsable
                && ObjectManager.Me.BuffStack("Maelstrom Weapon") == 5;
        }

        public override void Execute()
        {
            spellService.LightningBolt.Launch();
        }
    }
}
