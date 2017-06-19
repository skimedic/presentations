// Copyright Information
// =============================
// PatternsExamples - LightCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
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