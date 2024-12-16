namespace SafeHome.Patches
{
    public static class SpawnSettingPatch
    {
        public static bool HomeEnemyPrefix(ref SpawnSetting __result, int lv)
        {
            __result = SpawnSetting.HomeGuest(lv);
            return false;
        }
        
        public static bool HomeWildPrefix(ref SpawnSetting __result, int lv)
        {
            __result = SpawnSetting.HomeGuest(lv);
            return false;
        }
    }
}