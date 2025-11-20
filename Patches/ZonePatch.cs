namespace SafeHome
{
    internal static class ZonePatch
    {
        internal static void RespawnRatePostfix(ref float __result)
        {
            if (EClass._zone?.IsPlayerFaction == false)
            {
                return;
            }

            __result = 0;
        }
        
        internal static void PrespawnRatePostfix(ref float __result)
        {
            if (EClass._zone?.IsPlayerFaction == false)
            {
                return;
            }

            __result = 0;
        }
        
        internal static void MaxSpawnPostfix(ref int __result)
        {
            if (EClass._zone?.IsPlayerFaction == false)
            {
                return;
            }

            __result = 0;
        }
        
        internal static void RespawnPerHourPostfix(ref int __result)
        {
            if (EClass._zone?.IsPlayerFaction == false)
            {
                return;
            }

            __result = 0;
        }
    }
}