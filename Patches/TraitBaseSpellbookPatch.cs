namespace SafeHome
{
    internal class TraitBaseSpellbookPatch
    {
        internal static bool ReadFailEffectPrefix(Chara c)
        {
            if (EClass.core?.IsGameStarted == false ||
                EClass._zone?.IsPCFaction == false)
            {
                return true;
            }
            
            return false;
        }
    }
}