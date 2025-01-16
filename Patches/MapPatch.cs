namespace SafeHome
{
    internal static class MapPatch
    {
        internal static bool CountHostilePrefix(ref int __result)
        {
            if (EClass._zone?.IsPlayerFaction == false)
            {
                return true;
            }

            __result = 9999;
            return false;
        }
        
        internal static bool CountWildAnimalPrefix(ref int __result)
        {
            if (EClass._zone?.IsPlayerFaction == false)
            {
                return true;
            }
            
            __result = 9999;
            return false;
        }
    }
}