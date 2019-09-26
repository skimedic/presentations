using System;
using System.Drawing;

namespace WhatsNewInCSharp8.E_Patterns
{
    public enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    public class SwitchExpressions
    {
        public static Color FromRainbow(Rainbow colorBand) =>
            colorBand switch
                {
                Rainbow.Red => Color.FromArgb(0xFF, 0x00, 0x00),
                Rainbow.Orange => Color.FromArgb(0xFF, 0x7F, 0x00),
                Rainbow.Yellow => Color.FromArgb(0xFF, 0xFF, 0x00),
                Rainbow.Green => Color.FromArgb(0x00, 0xFF, 0x00),
                Rainbow.Blue => Color.FromArgb(0x00, 0x00, 0xFF),
                Rainbow.Indigo => Color.FromArgb(0x4B, 0x00, 0x82),
                Rainbow.Violet => Color.FromArgb(0x94, 0x00, 0xD3),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
                };

        public static Color FromRainbowClassic(Rainbow colorBand)
        {
            switch (colorBand)
            {
                case Rainbow.Red:
                    return Color.FromArgb(0xFF, 0x00, 0x00);
                case Rainbow.Orange:
                    return Color.FromArgb(0xFF, 0x7F, 0x00);
                case Rainbow.Yellow:
                    return Color.FromArgb(0xFF, 0xFF, 0x00);
                case Rainbow.Green:
                    return Color.FromArgb(0x00, 0xFF, 0x00);
                case Rainbow.Blue:
                    return Color.FromArgb(0x00, 0x00, 0xFF);
                case Rainbow.Indigo:
                    return Color.FromArgb(0x4B, 0x00, 0x82);
                case Rainbow.Violet:
                    return Color.FromArgb(0x94, 0x00, 0xD3);
                default:
                    throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand));
            };
        }

    }
}