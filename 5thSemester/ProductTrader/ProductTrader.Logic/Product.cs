namespace ProductTrader.Logic
{
    public class Product : IProduct
    {
        private const int UpdateTime = 500;
        #region fields
        private DateTime _startTime;
        private volatile bool _running;
        private static readonly Random Random = new (DateTime.UtcNow.Millisecond);
        #endregion fields

        #region properties
        public string Name { get; }
        public double MinValue { get; private set; }
        public double Value { get; private set; }
        public double MaxValue { get; private set; }
        #endregion properties

        #region events
        public event EventHandler? Changed;
        #endregion events

        #region constructors
        public Product(string name, double startValue)
        {
            Name = name;
            Value = MinValue = MaxValue = startValue;
        }
        #endregion constructors

        #region methods
        public void Start()
        {
            if (!_running)
            {
                _running = true;
                Thread t = new(Run)
                {
                    IsBackground = true
                };
                _startTime = DateTime.Now;
                t.Start();
            }
        }
        public void Stop()
        {
            _running = false;
        }

        private void Run()
        {
            double fluctuation;

            while (_running)
            {
                Thread.Sleep(UpdateTime);

                fluctuation = CalculateFluctuation(Random.Next(1, 51) / 1000.0);
                Value += fluctuation;
                if (Value < MinValue)
                {
                    MinValue = Value;
                }
                else if (Value > MaxValue)
                {
                    MaxValue = Value;
                }
                Changed?.Invoke(this, new ProductEventArgs(Name, MinValue, MaxValue, Value));
            }
        }

        private double CalculateFluctuation(double fluctuation)
        {
            double result;
            int upOrDown = Random.Next(1, 101);

            if (upOrDown >= 50)
            {
                result = Value * fluctuation;
            }
            else
            {
                fluctuation *= -1;
                result = Value * fluctuation;
            }
            return result;
        }

        public override string ToString()
        {
            return $"{Name,-20} {Value,10:f} EUR {MinValue,10:f} EUR {MaxValue,10:f} EUR Time:{(DateTime.UtcNow - _startTime).TotalSeconds:f} sec";
        }
        #endregion methods
    }
}