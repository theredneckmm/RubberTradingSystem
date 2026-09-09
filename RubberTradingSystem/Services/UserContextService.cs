using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using RubberTradingSystem.Models;

namespace RubberTradingSystem.Services
{
    public class UserContextService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly HttpClient _http;

        public UserContextService(AuthenticationStateProvider authStateProvider, HttpClient http)
        {
            _authStateProvider = authStateProvider;
            _http = http;
        }

        private Profile? _currentUserProfile;
        private bool _isLoading = false;

        public async Task<Profile?> GetCurrentUserProfileAsync()
        {
            // အကြိမ်ကြိမ် API ခေါ်ဆိုမှု မများစေရန် Cache သုံးသည်
            if (_currentUserProfile != null) return _currentUserProfile;

            try
            {
                var authState = await _authStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;

                // User ဝင်ထားခြင်း ရှိမရှိ စစ်ဆေးခြင်း
                if (user?.Identity == null || !user.Identity.IsAuthenticated)
                {
                    return null;
                }

                var authUserId = user.FindFirst(c => c.Type == "sub" || c.Type == ClaimTypes.NameIdentifier)?.Value;

                // တခါတရံ Session ချက်ချင်းမရ နိုင်သဖြင့် ခဏစောင့်ရန် (Retry 1 ချိန်)
                if (string.IsNullOrEmpty(authUserId))
                {
                    await Task.Delay(500); // 0.5 စက္ကန့် စောင့်မည်
                    authState = await _authStateProvider.GetAuthenticationStateAsync();
                    user = authState.User;
                    authUserId = user?.FindFirst(c => c.Type == "sub" || c.Type == ClaimTypes.NameIdentifier)?.Value;
                }

                if (string.IsNullOrEmpty(authUserId)) return null;

                // Supabase profiles ဇယားမှ အချက်အလက်ဆွဲထုတ်ခြင်း
                var response = await _http.GetFromJsonAsync<List<Profile>>($"rest/v1/profiles?id=eq.{authUserId}&select=*");

                if (response != null && response.Count > 0)
                {
                    _currentUserProfile = response[0];
                    return _currentUserProfile;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting user profile: {ex.Message}");
            }

            return null;
        }

        public async Task<string> GetCurrentStaffIdAsync()
        {
            var profile = await GetCurrentUserProfileAsync();
            return profile?.Id ?? string.Empty;
        }

        public async Task<string> GetCurrentOwnerIdAsync()
        {
            var profile = await GetCurrentUserProfileAsync();

            // အကယ်၍ profile ထဲတွင် owner_id က null သို့မဟုတ် အလွတ်ဖြစ်နေပါက 
            // staff ၏ id ကိုယ်တိုင် (သို့မဟုတ် Default ID တစ်ခုခု) ကို owner_id အဖြစ် ယာယီသုံးမည်
            if (profile == null) return string.Empty;

            if (string.IsNullOrEmpty(profile.OwnerId))
            {
                return profile.Id; // Fallback: Owner မရှိသေးလျှင် မိမိကိုယ်တိုင် Owner ဟု သတ်မှတ်မည်
            }

            return profile.OwnerId;
        }

        // Cache ကို ရှင်းလင်းရန် (Logout လုပ်သည့်အခါ သုံးရန်)
        public void ClearCache()
        {
            _currentUserProfile = null;
        }
    }
}