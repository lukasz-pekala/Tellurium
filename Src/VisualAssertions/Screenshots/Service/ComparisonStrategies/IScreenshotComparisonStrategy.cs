using Tellurium.VisualAssertions.Screenshots.Domain;

namespace Tellurium.VisualAssertions.Screenshots.Service.ComparisonStrategies
{
    public interface IScreenshotComparisonStrategy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="screenshot"></param>
        /// <param name="resultMessage"></param>
        /// <returns>true if images match compare using the specified comparison strategy</returns>
        bool Compare(BrowserPattern pattern, byte[] screenshot, out string resultMessage);
    }
}
