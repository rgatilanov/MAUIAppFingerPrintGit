using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace MauiAppFingerPrint;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}
    private async void btnFinger(object sender, EventArgs e)
    {

        await AuthenticateAsync("Toca el sensor", "Abortar", "", "Demasiado rápido");
        //var result = await CrossFingerprint.Current.IsAvailableAsync(true);

        //if (result)
        //{
        //    var dialogConfig = new AuthenticationRequestConfiguration("Hola", "Toca el sensor")
        //    {
        //        CancelTitle = null,
        //        FallbackTitle = null
        //    };
        //    var auth = await CrossFingerprint.Current.AuthenticateAsync(dialogConfig);
        //    if (auth.Authenticated)
        //        resultado.Text = "¡AUTENTICADO!";
        //    else
        //        resultado.Text = "Huella digital no reconocida";
        //}
        //else
        //    await DisplayAlert("Oops", "Dispositivo no compatible", "OK");
    }

    private async Task AuthenticateAsync(string reason, string cancel = null, string fallback = null, string tooFast = null)
    {

        var dialogConfig = new AuthenticationRequestConfiguration("MAUIFingerprint", reason)
        { // all optional
            CancelTitle = cancel,
            FallbackTitle = fallback,
            AllowAlternativeAuthentication = false,
            ConfirmationRequired = false
        };

        // optional
        dialogConfig.HelpTexts.MovedTooFast = tooFast;

        var result = await Plugin.Fingerprint.CrossFingerprint.Current.AuthenticateAsync(dialogConfig);

        SetResult(result);
    }

    private void SetResult(FingerprintAuthenticationResult result)
    {
        if (result.Authenticated)
            resultado.Text = "¡AUTENTICADO!";
        else
            resultado.Text = "Huella digital no reconocida";
    }

    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count++;
    //	CounterLabel.Text = $"Current count: {count}";

    //	SemanticScreenReader.Announce(CounterLabel.Text);
    //}
}

