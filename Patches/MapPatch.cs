namespace SafeHome
{
    internal static class MapPatch
    {
        internal static void CountHostilePostfix(ref int __result)
        {
            if (EClass._zone?.IsPlayerFaction == false)
            {
                return;
            }

            __result = 9999;
        }
        
        internal static void CountWildAnimalPostfix(ref int __result)
        {
            if (EClass._zone?.IsPlayerFaction == false)
            {
                return;
            }
            
            __result = 9999;
        }
    }
}