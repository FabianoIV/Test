namespace Grafik.Helpers;

public static class ColorHelper
{
    public static string GenerateColorFromString(string text)
    {
        if (string.IsNullOrEmpty(text))
            throw new ArgumentException("Email cannot be null or empty.");

        using var sha256 = System.Security.Cryptography.SHA256.Create();
        byte[] hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(text));

        int r = hash[0];
        int g = hash[1];
        int b = hash[2];

        return $"#{r:X2}{g:X2}{b:X2}";
    }
}