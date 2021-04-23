namespace Tellurium.VisualAssertions.Screenshots
{
    public class PixelByPixelComparisonParameters
    {
        /// <summary>
        /// Percentage of pixels that can be different when matching two images.
        /// If percentage of pixels that are different is greater than this value then the images are considered unmatched
        /// </summary>
        /// <remarks>
        /// Accepted values: <0.0, 100.0>
        /// </remarks>
        public double MaxPercentOfUnmatchedPixels { get; }

        /// <summary>
        /// Number of pixels that can be different when matching two images.
        /// If number of pixels that are different is greater than this value then the images are considered unmatched
        /// </summary>
        public uint PixelToleranceCount { get; }

        public PixelByPixelComparisonParameters(double maxPercentOfUnmatchedPixels)
        {
            MaxPercentOfUnmatchedPixels = maxPercentOfUnmatchedPixels;
            PixelToleranceCount = uint.MaxValue;
        }

        public PixelByPixelComparisonParameters(uint pixelToleranceCount)
        {
            PixelToleranceCount = pixelToleranceCount;
            MaxPercentOfUnmatchedPixels = 100.0;
        }
    }
}