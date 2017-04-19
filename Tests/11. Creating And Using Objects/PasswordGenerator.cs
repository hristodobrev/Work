using System;
using System.Text;
public class PasswordGenerator
{
    private const string CapitalLetters =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string SmallLetters =
          "abcdefghijklmnopqrstuvwxyz";
    private const string Digits = "0123456789";
    private const string SpecialChars =
          "~!@#$%^&*()_+=`{}[]\\|':;.,/?<>";
    private const string AllChars =
          CapitalLetters + SmallLetters + Digits + SpecialChars;

    private Random rand;

    public PasswordGenerator()
        : this(2, 2, 1, 3, 8)
    {
    }

    public PasswordGenerator(
        int capitalLettersCoount,
        int smallLettersCoount,
        int digitsCoount,
        int specialCharsCoount,
        int additionalCharsCount)
    {
        this.CapitalLettersCount = capitalLettersCoount;
        this.SmallLettersCount = smallLettersCoount;
        this.DigitsCount = digitsCoount;
        this.SpecialCharsCount = specialCharsCoount;
        this.AdditionalCharsCount = additionalCharsCount;
        this.rand = new Random();
    }

    public int CapitalLettersCount { get; set; }

    public int SmallLettersCount { get; set; }

    public int DigitsCount { get; set; }

    public int SpecialCharsCount { get; set; }

    public int AdditionalCharsCount { get; set; }

    public string GetRandomPassword()
    {
        StringBuilder password = new StringBuilder();
        for (int i = 0; i < this.CapitalLettersCount; i++)
        {
            char capitalLetter = this.GenerateChar(CapitalLetters);
            this.InsertAtRandomPosition(password, capitalLetter);
        }

        for (int i = 0; i < this.SmallLettersCount; i++)
        {
            char smallLetter = this.GenerateChar(SmallLetters);
            this.InsertAtRandomPosition(password, smallLetter);
        }

        for (int i = 0; i < this.DigitsCount; i++)
        {
            char digit = this.GenerateChar(Digits);
            this.InsertAtRandomPosition(password, digit);
        }

        for (int i = 0; i < this.SpecialCharsCount; i++)
        {
            char specialChar = this.GenerateChar(SpecialChars);
            this.InsertAtRandomPosition(password, specialChar);
        }

        int count = rand.Next(this.AdditionalCharsCount);
        for (int i = 1; i <= count; i++)
        {
            char specialChar = GenerateChar(AllChars);
            InsertAtRandomPosition(password, specialChar);
        }

        return password.ToString();
    }

    private char GenerateChar(string letters)
    {
        int randIndex = this.rand.Next(letters.Length);
        return letters[randIndex];
    }

    private void InsertAtRandomPosition(StringBuilder password, char character)
    {
        int randIndex = rand.Next(password.Length + 1);
        password.Insert(randIndex, character);
    }
}