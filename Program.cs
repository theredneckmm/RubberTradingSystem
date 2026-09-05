using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using RubberTradingSystem;
using RubberTradingSystem.Auth;
using RubberTradingSystem.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// --- 1. Supabase API & HttpClient Setup ---
// DelegatingHandler ကို Register လုပ်ခြင်း
builder.Services.AddTransient<SupabaseAuthorizationHandler>();

// appsettings.json မှ Supabase Settings များကို ယူပါ
var supabaseUrl = builder.Configuration["Supabase:Url"];
var supabaseAnonKey = builder.Configuration["Supabase:AnonKey"];

// IHttpClientFactory သုံး၍ Handler နှင့် ချိတ်ဆက်ပါ
builder.Services.AddHttpClient("SupabaseAPI", client =>
{
    // appsettings ထဲက url ကို ယူပြီး Base Address အဖြစ်သတ်မှတ်သည်
    client.BaseAddress = new Uri($"{supabaseUrl}/");
    client.DefaultRequestHeaders.Add("apikey", supabaseAnonKey!);
})
.AddHttpMessageHandler<SupabaseAuthorizationHandler>();

// System တစ်ခုလုံးတွင် @inject HttpClient အလွယ်တကူ သုံးနိုင်ရန်
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SupabaseAPI"));


// --- 2. Other Services Setup ---
builder.Services.AddScoped<LanguageService>();
builder.Services.AddScoped<AppThemeService>();
builder.Services.AddMudServices();
builder.Services.AddScoped<UserContextService>();

// --- 3. Authentication Setup ---
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<SupabaseAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp =>
    sp.GetRequiredService<SupabaseAuthStateProvider>());

// Program.cs ၏ Main method သို့မဟုတ် top-level statements တွင် ထည့်ပါ
//QuestPDF.Settings.License = LicenseType.Community;

await builder.Build().RunAsync();