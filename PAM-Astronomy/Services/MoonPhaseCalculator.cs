using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAM_Astronomy.Services
{
    public static class MoonPhaseCalculator
    {
        static double synodicLength = 29.530588853; //length in days of a complete moon cycle
        static DateTime referenceNewMoonDate = new DateTime(2017, 11, 18);

        public enum MoonPhase
        {
            Nova,
            Crescente,
            QuartoCrescente,
            QuaseCheia,
            Cheia,
            Minguante,
            QuartoMinguante,
            QuaseNova,
        }

        public static MoonPhase GetPhase(DateTime date)
        {
            return GetPhase(GetAge(date));
        }

        static double GetAge(DateTime date)
        {
            double days = (date - referenceNewMoonDate).TotalDays;

            return days % synodicLength;
        }

        static MoonPhase GetPhase(double age)
        {
            if (age < 1) return MoonPhase.Nova;
            if (age < 7) return MoonPhase.Crescente;
            if (age < 8) return MoonPhase.QuartoCrescente;
            if (age < 14) return MoonPhase.QuaseCheia;
            if (age < 15) return MoonPhase.Cheia;
            if (age < 22) return MoonPhase.Minguante;
            if (age < 23) return MoonPhase.QuartoMinguante;
            if (age < 29) return MoonPhase.QuaseNova;

            return MoonPhase.Nova;
        }
    }
}
