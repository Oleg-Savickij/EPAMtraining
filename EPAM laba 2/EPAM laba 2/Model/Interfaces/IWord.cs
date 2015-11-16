namespace EPAM_laba_2.Model
{
    public interface IWord
    {
        Symbol this[int index] { get; }

        string Chars { get; }
        string chars { get; }
        bool IsFirstVowel { get; }
        int Length { get; }
    }
}