namespace SafeHome
{
    internal class TraitBaseSpellbookPatch
    {
        internal static bool OnReadPrefix(Chara c)
        {
            if (EClass.core?.IsGameStarted == false ||
                EClass._zone?.IsPCFaction == false ||
                c.IsPC == true)
            {
                return true;
            }
            
            return false;
        }
    }
}