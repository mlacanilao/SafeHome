namespace SafeHome;

internal static class MapPatch
{
    private const int BlockedSpawnCount = 9999;

    internal static void CountHostilePostfix(Map map, ref int __result)
    {
        if (SafeHomeScope.ShouldSuppressZoneSpawns(zone: map.zone) == false)
        {
            return;
        }

        __result = BlockedSpawnCount;
    }

    internal static void CountWildAnimalPostfix(Map map, ref int __result)
    {
        if (SafeHomeScope.ShouldSuppressZoneSpawns(zone: map.zone) == false)
        {
            return;
        }

        __result = BlockedSpawnCount;
    }
}
