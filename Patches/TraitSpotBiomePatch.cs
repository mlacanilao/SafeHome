using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace SafeHome;

internal static class TraitSpotBiomePatch
{
    private static Chara? SpawnMobOrSuppress(Zone zone, Point pos, SpawnSetting? setting)
    {
        if (SafeHomeScope.ShouldSuppressZoneSpawns(zone: zone))
        {
            return null;
        }

        return zone.SpawnMob(pos, setting);
    }

    internal static IEnumerable<CodeInstruction> UpdateTranspiler(IEnumerable<CodeInstruction> instructions)
    {
        MethodInfo? spawnMob = AccessTools.Method(
            type: typeof(Zone),
            name: nameof(Zone.SpawnMob),
            parameters: new[] { typeof(Point), typeof(SpawnSetting) }
        );

        MethodInfo? spawnMobOrSuppress = AccessTools.Method(
            type: typeof(TraitSpotBiomePatch),
            name: nameof(SpawnMobOrSuppress)
        );

        if (spawnMob == null ||
            spawnMobOrSuppress == null)
        {
            SafeHome.LogError(message: "TraitSpotBiome.Update transpiler: required method lookup failed");
            return instructions;
        }

        List<CodeInstruction> patchedInstructions = new List<CodeInstruction>();
        int replacementCount = 0;

        foreach (CodeInstruction instruction in instructions)
        {
            if (instruction.opcode == OpCodes.Callvirt &&
                Equals(objA: instruction.operand, objB: spawnMob))
            {
                CodeInstruction replacement = new CodeInstruction(instruction)
                {
                    opcode = OpCodes.Call,
                    operand = spawnMobOrSuppress
                };

                patchedInstructions.Add(item: replacement);
                replacementCount++;
                continue;
            }

            patchedInstructions.Add(item: instruction);
        }

        if (replacementCount != 2)
        {
            SafeHome.LogError(message: $"TraitSpotBiome.Update transpiler expected 2 SpawnMob replacements, but found {replacementCount}");
        }

        return patchedInstructions;
    }
}
