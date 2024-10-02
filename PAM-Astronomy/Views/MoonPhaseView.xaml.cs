namespace PAM_Astronomy.Views;
using PAM_Astronomy.Services;

public partial class MoonPhaseView : ContentPage
{
	public MoonPhaseView()
	{
		InitializeComponent();
	}

    void InitializeUI()
    {
        var phase = MoonPhaseCalculator.GetPhase(DateTime.Now);

        lblDate.Text = DateTime.Today.ToString("D");
        lblMoonPhaseIcon.Text = moonPhaseEmojis[phase];
        lblMoonPhaseText.Text = phase.ToString();

        SetMoonPhaseLabels(lblPhaseIcon1, lblPhaseText1, 1);
        SetMoonPhaseLabels(lblPhaseIcon2, lblPhaseText2, 2);
        SetMoonPhaseLabels(lblPhaseIcon3, lblPhaseText3, 3);
        SetMoonPhaseLabels(lblPhaseIcon4, lblPhaseText4, 4);
    }

    void SetMoonPhaseLabels(Label lblIcon, Label lblText, int dayOffset)
    {
        var phase = MoonPhaseCalculator.GetPhase(DateTime.Now.AddDays(dayOffset));
        lblIcon.Text = moonPhaseEmojis[phase];
        lblText.Text = DateTime.Now.AddDays(dayOffset).DayOfWeek.ToString();
    }

    static Dictionary<MoonPhaseCalculator.MoonPhase, string> moonPhaseEmojis = new Dictionary<MoonPhaseCalculator.MoonPhase, string>
        {
            { MoonPhaseCalculator.MoonPhase.Nova, "🌑" },
            { MoonPhaseCalculator.MoonPhase.Crescente, "🌒" },
            { MoonPhaseCalculator.MoonPhase.QuartoCrescente, "🌓" },
            { MoonPhaseCalculator.MoonPhase.QuaseCheia, "🌔" },
            { MoonPhaseCalculator.MoonPhase.Cheia, "🌕" },
            { MoonPhaseCalculator.MoonPhase.Minguante, "🌖" },
            { MoonPhaseCalculator.MoonPhase.QuartoMinguante, "🌗" },
            { MoonPhaseCalculator.MoonPhase.QuaseNova, "🌘" },
        };
}