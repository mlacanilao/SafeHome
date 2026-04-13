namespace SafeHome;

internal static class TraitBaseSpellbookPatch
{
    internal static bool ReadFailEffectPrefix(Chara c)
    {
        if (EClass.core?.IsGameStarted == false ||
            SafeHomeScope.ShouldSuppressZoneSpawns(zone: c.currentZone) == false)
        {
            return true;
        }

        return false;
    }
}
