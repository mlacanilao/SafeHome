namespace SafeHome;

internal static class ZonePatch
{
    internal static void RespawnRatePostfix(Zone zone, ref float __result)
    {
        if (SafeHomeScope.ShouldSuppressZoneSpawns(zone: zone) == false)
        {
            return;
        }

        __result = 0;
    }

    internal static void PrespawnRatePostfix(Zone zone, ref float __result)
    {
        if (SafeHomeScope.ShouldSuppressZoneSpawns(zone: zone) == false)
        {
            return;
        }

        __result = 0;
    }
}
