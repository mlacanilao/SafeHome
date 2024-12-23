using System.Collections.Generic;

namespace SafeHome.Patches
{
    public class FactionBranchPatch
    {
        public static void OnSimulateHourPostfix()
        {
            List<Chara> charasToDestroy = new List<Chara>();
            
            foreach (Chara chara in EClass._map.charas)
            {
                if (chara.memberType == FactionMemberType.Guest && chara.hostility == Hostility.Enemy)
                {
                    charasToDestroy.Add(chara);
                }
            }

            foreach (Chara hostileChara in charasToDestroy)
            {
                hostileChara.Destroy();
                hostileChara.ClearBed(null);
            }
        }
    }
}