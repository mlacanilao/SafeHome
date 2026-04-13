namespace SafeHome;

internal static class SafeHomeScope
{
    internal static bool ShouldSuppressZoneSpawns(Zone? zone = null)
    {
        Zone? activeZone = zone ?? EClass._zone;
        return activeZone?.IsPCFaction == true;
    }
}
