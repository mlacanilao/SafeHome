using System.Collections.Generic;
namespace SafeHome
{
    internal class FactionBranchPatch
    {
        internal static void OnSimulateHourPostfix()
        {
            if (EClass._zone?.IsPlayerFaction == false)
            {
                return;
            }
            
            List<Chara> charasToDestroy = new List<Chara>();
            
            foreach (Chara chara in EClass._map.charas)
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
}