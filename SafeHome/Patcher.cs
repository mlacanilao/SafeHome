using HarmonyLib;

namespace SafeHome
{
    internal class Patcher
    {
        [HarmonyPostfix]
        [HarmonyPatch(declaringType: typeof(Map), methodName: nameof(Map.CountHostile))]
        internal static void MapCountHostile(ref int __result)
        {
            MapPatch.CountHostilePostfix(__result: ref __result); 
        }
        
        [HarmonyPostfix]
        [HarmonyPatch(declaringType: typeof(Map), methodName: nameof(Map.CountWildAnimal))]
        internal static void MapCountWildAnimal(ref int __result)
        {
            MapPatch.CountWildAnimalPostfix(__result: ref __result); 
        }
        
        [HarmonyPostfix]
        [HarmonyPatch(declaringType: typeof(Zone), methodName: nameof(Zone.RespawnRate), methodType: MethodType.Getter)]
        internal static void ZoneRespawnRate(ref float __result)
        {
            ZonePatch.RespawnRatePostfix(__result: ref __result);
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
        
        [HarmonyPostfix]
        [HarmonyPatch(declaringType: typeof(Zone), methodName: nameof(Zone.PrespawnRate), methodType: MethodType.Getter)]
        internal static void ZonePrespawnRate(ref float __result)
        {
            ZonePatch.PrespawnRatePostfix(__result: ref __result);
        }
        
        [HarmonyPostfix]
        [HarmonyPatch(declaringType: typeof(Zone), methodName: nameof(Zone.MaxSpawn), methodType: MethodType.Getter)]
        internal static void ZoneMaxSpawn(ref int __result)
        {
            ZonePatch.MaxSpawnPostfix(__result: ref __result);
        }
        
        [HarmonyPostfix]
        [HarmonyPatch(declaringType: typeof(Zone), methodName: nameof(Zone.RespawnPerHour), methodType: MethodType.Getter)]
        internal static void ZoneRespawnPerHour(ref int __result)
        {
            ZonePatch.RespawnPerHourPostfix(__result: ref __result);
        }
    }
}