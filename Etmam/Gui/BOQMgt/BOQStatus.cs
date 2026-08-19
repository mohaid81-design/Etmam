namespace Etmam
{
    /// <summary>
    /// Canonical Status values for BOQList, in Arabic. Shared by the list grid (ucBOQList) and the
    /// editor (ucBOQEditor) so both read, write, and compare the exact same vocabulary.
    /// </summary>
    public static class BOQStatus
    {
        public const string Draft    = "مسودة";
        public const string Approved = "معتمد";
    }
}
