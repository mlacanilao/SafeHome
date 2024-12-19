using SafeHome.Patches;
using HarmonyLib;

namespace SafeHome
{
    public class Patcher
    {
        [HarmonyPrefix]
        [HarmonyPatch(declaringType: typeof(Map), methodName: nameof(Map.CountHostile))]
        public static bool MapCountHostile(ref int __result)
        {
            return MapPatch.CountHostilePrefix(__result: ref __result); 
        }
        
        [HarmonyPrefix]
        [HarmonyPatch(declaringType: typeof(Map), methodName: nameof(Map.CountWildAnimal))]
        public static bool MapCountWildAnimal(ref int __result)
        {
            return MapPatch.CountWildAnimalPrefix(__result: ref __result); 
        }
    }
}