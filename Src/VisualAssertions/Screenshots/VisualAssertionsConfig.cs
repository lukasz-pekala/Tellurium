using System;
using Tellurium.VisualAssertions.Screenshots.Service.ComparisonStrategies;

namespace Tellurium.VisualAssertions.Screenshots
{
    public class VisualAssertionsConfig
    {
        public string BrowserName { get; set; }
        public string ProjectName { get; set; }
        public string ScreenshotCategory { get; set; }
        public bool ProcessScreenshotsAsynchronously { get; set; }

        /// <summary>
        /// It is possible to implement custom comparison strategy by supplying a class implementing IScreenshotComparisonStrategy interface
        /// </summary>
        public IScreenshotComparisonStrategy ScreenshotComparisonStrategy { get; set; }
    }
}