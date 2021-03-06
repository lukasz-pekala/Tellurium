﻿using System;
using Tellurium.MvcPages.Configuration;

namespace Tellurium.MvcPages.Reports.ErrorReport
{
    internal static class TelluriumErrorReportBuilderFactory
    {
        public static TelluriumErrorReportBuilder Create(BrowserAdapterConfig config)
        {
            var writeOutput = config.WriteOutput ?? Console.WriteLine;
            var outputDir = string.IsNullOrWhiteSpace(config.ErrorReportOutputDir)
                ? Environment.CurrentDirectory
                : config.ErrorReportOutputDir;
            var ciAdapter = new TeamCityAdapter(writeOutput);
            return new TelluriumErrorReportBuilder(outputDir, writeOutput, ciAdapter);
        }
    }
}