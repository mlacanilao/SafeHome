using HarmonyLib;

namespace SafeHome
{
    internal class Patcher
    {
        [HarmonyPrefix]
        [HarmonyPatch(declaringType: typeof(Map), methodName: nameof(Map.CountHostile))]
        internal static bool MapCountHostile(ref int __result)
        {
            return MapPatch.CountHostilePrefix(__result: ref __result); 
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(declaringType: typeof(Map), methodName: nameof(Map.CountWildAnimal))]
        internal static bool MapCountWildAnimal(ref int __result)
        {
            return MapPatch.CountWildAnimalPrefix(__result: ref __result); 
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(declaringType: typeof(Zone), methodName: nameof(Zone.RespawnRate), methodType: MethodType.Getter)]
        internal static bool ZoneRespawnRate(ref float __result)
        {
            return ZonePatch.RespawnRatePrefix(__result: ref __result);
        }
        
        [HarmonyPostfix]
        [HarmonyPatch(declaringType: typeof(FactionBranch), methodName: nameof(FactionBranch.OnSimulateHour))]
        internal static void FactionBranchOnSimulateHour()
        {
            FactionBranchPatch.OnSimulateHourPostfix();
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(declaringType: typeof(TraitBaseSpellbook), methodName: nameof(TraitBaseSpellbook.ReadFailEffect))]
        internal static bool TraitBaseSpellbookReadFailEffect(Chara c)
        {
            return TraitBaseSpellbookPatch.ReadFailEffectPrefix(c: c);
        }
    }
}