namespace CryptoCodeGenerator
{
    public struct CodeRequirements
    {
        public int CodewordsLength { get; }
        public int NumberOfCodewords { get; }
        public int MinimalHammingDistance { get; }

        public CodeRequirements(int codewordsLength, int numberOfCodewords, int minimalHammingDistance)
        {
            CodewordsLength = codewordsLength;
            NumberOfCodewords = numberOfCodewords;
            MinimalHammingDistance = minimalHammingDistance;
        }
    }
}