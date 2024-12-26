namespace SafeHome.Patches
{
    public static class MapPatch
    {
        public static bool CountHostilePrefix(ref int __result)
        {
            if (EClass._zone?.IsPlayerFaction == false)
            {
                return true;
            }

            __result = 9999;
            return false;
        }
        
        public static bool CountWildAnimalPrefix(ref int __result)
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