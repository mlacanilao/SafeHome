using System.Collections.Generic;
using HarmonyLib;

namespace SafeHome;

internal static class Patcher
{
    [HarmonyPostfix]
    [HarmonyPatch(declaringType: typeof(Map), methodName: nameof(Map.CountHostile))]
    internal static void MapCountHostile(Map __instance, ref int __result)
    {
        MapPatch.CountHostilePostfix(map: __instance, __result: ref __result);
    }

    [HarmonyPostfix]
    [HarmonyPatch(declaringType: typeof(Map), methodName: nameof(Map.CountWildAnimal))]
    internal static void MapCountWildAnimal(Map __instance, ref int __result)
    {
        MapPatch.CountWildAnimalPostfix(map: __instance, __result: ref __result);
    }

    [HarmonyPostfix]
    [HarmonyPatch(declaringType: typeof(Zone), methodName: nameof(Zone.RespawnRate), methodType: MethodType.Getter)]
    internal static void ZoneRespawnRate(Zone __instance, ref float __result)
    {
        ZonePatch.RespawnRatePostfix(zone: __instance, __result: ref __result);
    }

    [HarmonyPostfix]
    [HarmonyPatch(declaringType: typeof(FactionBranch), methodName: nameof(FactionBranch.OnSimulateHour))]
    internal static void FactionBranchOnSimulateHour(FactionBranch __instance)
    {
        FactionBranchPatch.OnSimulateHourPostfix(branch: __instance);
    }

    [HarmonyPrefix]
    [HarmonyPatch(declaringType: typeof(TraitBaseSpellbook), methodName: nameof(TraitBaseSpellbook.ReadFailEffect))]
    internal static bool TraitBaseSpellbookReadFailEffect(Chara c)
    {
        return TraitBaseSpellbookPatch.ReadFailEffectPrefix(c: c);
    }

    [HarmonyPostfix]
    [HarmonyPatch(declaringType: typeof(Zone), methodName: nameof(Zone.PrespawnRate), methodType: MethodType.Getter)]
    internal static void ZonePrespawnRate(Zone __instance, ref float __result)
    {
        ZonePatch.PrespawnRatePostfix(zone: __instance, __result: ref __result);
    }

    [HarmonyTranspiler]
    [HarmonyPatch(declaringType: typeof(TraitSpotBiome), methodName: nameof(TraitSpotBiome.Update))]
    internal static IEnumerable<CodeInstruction> TraitSpotBiomeUpdate(IEnumerable<CodeInstruction> instructions)
    {
        return TraitSpotBiomePatch.UpdateTranspiler(instructions: instructions);
    }
}
