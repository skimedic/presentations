using System;
using System.Diagnostics;
using TechTalk.SpecRun.Framework;

namespace CustomDeploymentSteps
{
    public class StartWinAppDeploymentStep : IDeploymentTransformationStep
    {
        public void Apply(IDeploymentContext deploymentContext)
        {
            var pathToWinApp = deploymentContext.CustomData[this] as string;
            if (pathToWinApp != null)
            {
                var winApp = Process.Start(pathToWinApp);

                deploymentContext.CustomData["WinAppDriver"] = winApp;
            }
        }

        public void Restore(IDeploymentContext deploymentContext)
        {
            var winApp = (Process)deploymentContext.CustomData["WinAppDriver"];
            winApp?.Kill();
        }
    }
}
