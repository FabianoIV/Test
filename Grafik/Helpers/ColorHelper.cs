using System.Drawing;

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

    public static string ConvertRadzenControlColorToHexColor(string color)
    {
        // Usunięcie "rgb(" lub "rgba(" oraz ")"
        color = color.Replace("rgba(", "").Replace("rgb(", "").Replace(")", "");

        // Podział na komponenty
        var components = color.Split(',');

        if (components.Length < 3 || components.Length > 4)
        {
            throw new ArgumentException("Invalid RGB(A) format.");
        }

        // Parsowanie RGB
        int r = int.Parse(components[0].Trim());
        int g = int.Parse(components[1].Trim());
        int b = int.Parse(components[2].Trim());

        // Parsowanie wartości alfa, jeśli istnieje
        double alpha = components.Length == 4 ? Convert.ToDouble(components[3].Replace('.', ',').Trim()) : 1.0;

        // Konwersja alfa na wartość 0-255
        int alphaInt = (int)(alpha * 255);

        // Zwrócenie w formacie ARGB (HEX z przezroczystością)
        return $"#{r:X2}{g:X2}{b:X2}{alphaInt:X2}";
    }
}