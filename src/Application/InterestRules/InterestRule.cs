namespace Application.InterestRules
{
    public class InterestRule : IInterestRateRule
    {
        private readonly int _minRating;
        private readonly int _maxRating;
        private readonly int _duration;
        public decimal Rate { get; }

        public InterestRule(int minRating, int maxRating, int duration, decimal rate)
        {
            _minRating = minRating;
            _maxRating = maxRating;
            _duration = duration;
            Rate = rate;
        }

        public bool IsMatch(int creditRating, int duration)
        {
            return creditRating >= _minRating
                && creditRating <= _maxRating
                && duration == _duration;
        }
    }
}
