#region copyright
// Copyright Information
// ==============================
// PatternsExamples - LightCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace PatternsExamples.C_Behavioral.Commands
{
    public class LightCommand : IDemoCommand
    {
        private readonly ILight _light;

        public LightCommand(ILight light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.LightIsOn = !_light.LightIsOn;
        }
    }
}