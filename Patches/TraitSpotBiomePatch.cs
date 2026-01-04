using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace SafeHome
{
    internal static class TraitSpotBiomePatch
    {
        internal static IEnumerable<CodeInstruction> UpdateTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var codeMatcher = new CodeMatcher(instructions: instructions);
            
            MethodInfo spawnMob = AccessTools.Method(
                type: typeof(Zone),
                name: nameof(Zone.SpawnMob),
                parameters: new[] { typeof(Point), typeof(SpawnSetting) }
            );
            
            if (spawnMob == null)
            {
                SafeHome.Log(payload: "TraitSpotBiome.Update transpiler: Zone.SpawnMob not found");
                return codeMatcher.Instructions();
            }
            
            codeMatcher.MatchStartForward(matches: new[]
            {
                new CodeMatch(opcode: OpCodes.Callvirt, operand: spawnMob)
            });
            
            if (codeMatcher.IsValid)
            {
                codeMatcher.SetInstruction(instruction: new CodeInstruction(opcode: OpCodes.Pop));
                codeMatcher.Insert(instructions: new[]
                {
                    new CodeInstruction(opcode: OpCodes.Pop),
                    new CodeInstruction(opcode: OpCodes.Pop),
                    new CodeInstruction(opcode: OpCodes.Ldnull),
                });
                
                codeMatcher.Advance(offset: 1);
            }
            
            codeMatcher.MatchStartForward(matches: new[]
            {
                new CodeMatch(opcode: OpCodes.Callvirt, operand: spawnMob)
            });
            
            if (codeMatcher.IsValid)
            {
                codeMatcher.SetInstruction(instruction: new CodeInstruction(opcode: OpCodes.Pop));
                codeMatcher.Insert(instructions: new[]
                {
                    new CodeInstruction(opcode: OpCodes.Pop),
                    new CodeInstruction(opcode: OpCodes.Pop),
                    new CodeInstruction(opcode: OpCodes.Ldnull),
                });
            }
            
            return codeMatcher.Instructions();
        }
    }
}