using FightClass.Wotlk.Druid.Restoration.Services.Interfaces;
using robotManager.Helpful;
using System;
using System.Linq;
using System.Threading.Tasks;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace FightClass.Wotlk.Druid.Restoration.Services
{
    internal class RotationService : IRotationService
    {
        readonly ISpellService spellService;

        public RotationService(
            ISpellService spellService)
        {
            this.spellService = spellService;
        }

        public async Task RotationAsync()
        {
            while (Main.Running)
            {
                try
                {
                    if (Conditions.InGameAndConnectedAndAliveAndProductStartedNotInPause)
                    {
                        if (ObjectManager.Me.ManaPercentage < 15 && spellService.Innervate.IsSpellUsable)
                        {
                            ObjectManager.Me.Target = ObjectManager.Me.Guid;
                            spellService.Innervate.Launch();
                            await Task.Delay(250);
                        }
                        var tmp = NeedsHealing;
                        if (tmp != null)
                            ObjectManager.Me.Target = tmp.Guid;
                        else
                        {
                            tmp = ObjectManager.Me;
                            ObjectManager.Me.Target = tmp.Guid;
                        }
                        if (tmp.HealthPercent < 50 && (ObjectManager.Me.Guid == tmp.BuffCastedBy("Regrowth") || ObjectManager.Me.Guid == tmp.BuffCastedBy("Rejuvenation")))
                        {
                            if (spellService.Swiftmend.IsSpellUsable)
                            {
                                spellService.Swiftmend.Launch(false);
                                await Task.Delay(250);
                            }
                            else if (spellService.Nourish.IsSpellUsable)
                            {
                                spellService.Nourish.Launch(false);
                                await Task.Delay(250);
                            }
                        }
                        if (tmp.HealthPercent < 70 && ObjectManager.Me.Guid != tmp.BuffCastedBy("Regrowth"))
                        {
                            if (spellService.Regrowth.IsSpellUsable)
                            {
                                spellService.Regrowth.Launch();
                                await Task.Delay(250);
                            }
                        }
                        else if (tmp.HealthPercent < 90 && ObjectManager.Me.Guid != tmp.BuffCastedBy("Rejuvenation"))
                        {
                            if (spellService.WildGrowth.IsSpellUsable)
                            {
                                spellService.WildGrowth.Launch();
                                await Task.Delay(250);
                            }
                            else if (spellService.Rejuvenation.IsSpellUsable)
                            {
                                spellService.Rejuvenation.Launch();
                                await Task.Delay(250);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Logging.WriteError("[My fightclass] ERROR: " + e);
                }
                await Task.Delay(10);
            }
        }

        public WoWPlayer NeedsHealing =>
            ObjectManager.GetObjectWoWPlayer().Where(x =>
            x.PlayerFaction == ObjectManager.Me.PlayerFaction
            && x.GetDistance < 40f
            && !x.IsDead
            && x.HealthPercent < 90)
            .OrderBy(x => x.HealthPercent)
            .FirstOrDefault();
    }
}
