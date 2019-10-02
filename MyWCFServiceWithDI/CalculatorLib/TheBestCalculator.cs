using Microsoft.Extensions.Logging;
using System;

namespace CalculatorLib
{
    public class TheBestCalculator : ITheBestCalculator
    {
        private readonly ILogger _logger;
        public TheBestCalculator(ILogger<TheBestCalculator> logger)
        {
            _logger = logger;
        }
        public int Add(int x, int y)
        {
            _logger.LogDebug("Add invoked");
            return x + y;
        }

        public int Subtract(int x, int y) => x - y;
    }
}
