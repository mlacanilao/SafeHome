using System.Collections.Generic;

namespace SafeHome;

internal static class FactionBranchPatch
{
    internal static void OnSimulateHourPostfix(FactionBranch branch)
    {
        if (SafeHomeScope.ShouldSuppressZoneSpawns(zone: branch.owner) == false)
        {
            return;
        }

        List<Chara> charasToDestroy = new List<Chara>();

        foreach (Chara chara in branch.owner.map.charas)
        {
            bool removeGuestEnemy =
                chara.memberType == FactionMemberType.Guest &&
                chara.hostility == Hostility.Enemy;

            bool removeOtherEnemy =
                chara.hostility == Hostility.Enemy &&
                !chara.IsPCParty &&
                chara.faction != EClass.Home;

            if (removeGuestEnemy == true ||
                removeOtherEnemy == true)
            {
                charasToDestroy.Add(item: chara);
            }
        }

        foreach (Chara hostileChara in charasToDestroy)
        {
            hostileChara.Destroy();
            hostileChara.ClearBed(map: null);
        }
    }
}
