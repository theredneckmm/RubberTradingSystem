using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using RubberTradingSystem.Models;

namespace RubberTradingSystem.Auth;

public class SupabaseAuthorizationHandler : DelegatingHandler
{
    private readonly IJSRuntime _jsRuntime;
    private readonly IConfiguration _configuration;

    public SupabaseAuthorizationHandler(IJSRuntime jsRuntime, IConfiguration configuration)
    {
        _jsRuntime = jsRuntime;
        _configuration = configuration;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // 1. LocalStorage ထဲမှ Access Token ကို ယူမည်
        var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "supabase_access_token");

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        // 2. မူလ Request ကို ပို့မည်
        var response = await base.SendAsync(request, cancellationToken);

        // 3. 401 Unauthorized (JWT Expired) ဖြစ်မဖြစ် စစ်ဆေးမည်
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            Console.WriteLine("⚠️ Token သက်တမ်းကုန်သွားပါပြီ (401 Unauthorized)။ Refresh လုပ်ရန် ကြိုးစားနေသည်...");

            var success = await TryRefreshTokenAsync();
            if (success)
            {
                Console.WriteLine("✅ Token အသစ် လဲလှယ်ခြင်း အောင်မြင်ပါသည်။ Request ကို ထပ်မံ ပို့နေပါပြီ...");

                // Token အသစ်ကို ပြန်ယူမည်
                var newToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "supabase_access_token");

                // Request အသစ်တစ်ခု တည်ဆောက်၍ Token အသစ်ထည့်မည်
                var newRequest = new HttpRequestMessage(request.Method, request.RequestUri);

                if (request.Content != null)
                {
                    var contentBytes = await request.Content.ReadAsByteArrayAsync(cancellationToken);
                    newRequest.Content = new ByteArrayContent(contentBytes);
                    foreach (var header in request.Content.Headers)
                    {
                        newRequest.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }

                foreach (var header in request.Headers)
                {
                    if (header.Key != "Authorization")
                    {
                        newRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }

                newRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", newToken);

                return await base.SendAsync(newRequest, cancellationToken);
            }
            else
            {
                Console.WriteLine("❌ Token အသစ် လဲလှယ်၍ မရပါ။ (Refresh Token သက်တမ်းကုန်သွားပါပြီ)");
            }
        }

        return response;
    }

    private async Task<bool> TryRefreshTokenAsync()
    {
        try
        {
            var refreshToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "supabase_refresh_token");
            if (string.IsNullOrEmpty(refreshToken))
            {
                Console.WriteLine("❌ LocalStorage ထဲတွင် Refresh Token မရှိပါ။");
                return false;
            }

            var supabaseUrl = _configuration["Supabase:Url"];
            var supabaseAnonKey = _configuration["Supabase:AnonKey"];

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("apikey", supabaseAnonKey);

            var refreshUrl = $"{supabaseUrl}/auth/v1/token?grant_type=refresh_token";
            var response = await client.PostAsJsonAsync(refreshUrl, new { refresh_token = refreshToken });

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<SupabaseTokenResponse>();
                if (data != null)
                {
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "supabase_access_token", data.AccessToken);
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "supabase_refresh_token", data.RefreshToken);
                    return true;
                }
            }
            else
            {
                var err = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"❌ Supabase Refresh Error: {err}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Refresh Exception: {ex.Message}");
        }

        return false;
    }
}