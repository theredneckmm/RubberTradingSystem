using System.Security.Claims;
using System.Text.Json;

namespace RubberTradingSystem.Auth;

public static class JwtParser
{
    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var claims = new List<Claim>();

        // JWT Token ရဲ့ အလယ်ပိုင်း (Payload) ကို ဖြတ်ယူပါမည်
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);

        // JSON ကို Dictionary အနေဖြင့် ပြောင်းပါမည်
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        if (keyValuePairs != null)
        {
            foreach (var kvp in keyValuePairs)
            {
                // Supabase မှ လာသော Claim များကို Blazor User Identity အတွက် ထည့်သွင်းပါမည်
                claims.Add(new Claim(kvp.Key, kvp.Value?.ToString() ?? string.Empty));
            }
        }
        return claims;
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        // Base64 string များတွင် လိုအပ်သော Padding (=) များကို ဖြည့်ပေးသည့် အပိုင်း
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}