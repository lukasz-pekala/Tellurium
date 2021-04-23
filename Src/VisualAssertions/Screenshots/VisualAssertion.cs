using System;
using Tellurium.MvcPages;
using Tellurium.MvcPages.BrowserCamera;
using Tellurium.VisualAssertions.Infrastructure.Persistence;
using Tellurium.VisualAssertions.Screenshots.Domain;
using Tellurium.VisualAssertions.Screenshots.Service;
using Tellurium.VisualAssertions.Screenshots.Service.ComparisonStrategies;
using Tellurium.VisualAssertions.TestRunnersAdapters;
using Tellurium.VisualAssertions.TestRunnersAdapters.Providers;

namespace Tellurium.VisualAssertions.Screenshots
{
    public class TelluriumVisualAssertion : VisualAssertionBase
    {
        protected override Action<string> TestOutputWriter => Console.WriteLine;
        protected override ITestRunnerAdapter TestRunnerAdapter => new ConsoleTestRunnerAdapter(TestOutputWriter);
        protected override IScreenshotComparisonStrategy ScreenshotComparisonStrategy => new HashComparisonStrategy();

        public TelluriumVisualAssertion(VisualAssertionsConfig config) : base(config)
        {
        }
    }

    public abstract class VisualAssertionBase : IVisualAssertion
    {
        private VisualAssertionsService _visualAssertionsService;

        protected abstract ITestRunnerAdapter TestRunnerAdapter { get; }
        protected abstract Action<string> TestOutputWriter { get; }
        protected abstract IScreenshotComparisonStrategy ScreenshotComparisonStrategy { get; }

        protected VisualAssertionBase(VisualAssertionsConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            this.Init(config);
        }

        private void Init(VisualAssertionsConfig config)
        {
            var sessionContext = PersistanceEngine.GetSessionContext();
            var projectRepository = new Repository<Project>(sessionContext);

            _visualAssertionsService?.Dispose();
            _visualAssertionsService = new VisualAssertionsService(projectRepository, TestRunnerAdapter, config.ProcessScreenshotsAsynchronously, ScreenshotComparisonStrategy)
            {
                ProjectName = config.ProjectName,
                ScreenshotCategory = config.ScreenshotCategory,
                BrowserName = config.BrowserName
            };
        }

        public void AssertView(IBrowserCamera browserCamera, string viewName)
        {
            _visualAssertionsService.CheckViewWithPattern(browserCamera, viewName);
        }
    }
}