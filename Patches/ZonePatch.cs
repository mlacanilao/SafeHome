namespace SafeHome.Patches
{
    public static class ZonePatch
    {
        public static bool RespawnRatePrefix(ref float __result)
        {
            if (EClass._zone?.IsPlayerFaction == false)
            {
                return true;
            }

            __result = 0;
            return false;
        }
    }
}