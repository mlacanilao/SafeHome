using SafeHome.Patches;
using HarmonyLib;

namespace SafeHome
{
    public class Patcher
    {
        [HarmonyPrefix]
        [HarmonyPatch(declaringType: typeof(SpawnSetting), methodName: nameof(SpawnSetting.HomeEnemy))]
        public static bool SpawnSettingHomeEnemy(ref SpawnSetting __result, int lv)
        {
            return SpawnSettingPatch.HomeEnemyPrefix(__result: ref __result, lv: lv);
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(declaringType: typeof(SpawnSetting), methodName: nameof(SpawnSetting.HomeWild))]
        public static bool SpawnSettingHomeWild(ref SpawnSetting __result, int lv)
        {
            return SpawnSettingPatch.HomeWildPrefix(__result: ref __result, lv: lv);
        }
    }
}