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

        /*
The variable comes before the switch keyword. The different order makes it visually easy to distinguish the 
  switch expression from the switch statement.
The case and : elements are replaced with =>. It's more concise and intuitive.
The default case is replaced with a _ discard.
The bodies are expressions, not statements.
Must either produce a value or throw an exception
         */
    }
}