namespace Itinera.Client.Behaviors
{
    public class FloatingCloud : Behavior<Image>
    {
        private Image _cloud;
        private Random _random = new Random();
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private double _initialX;
        private double _initialY;

        protected override void OnAttachedTo(Image bindable)
        {
            base.OnAttachedTo(bindable);
            _cloud = bindable;

            _initialX = _cloud.TranslationX;
            _initialY = _cloud.TranslationY;

            StartFloatingAnimation();
        }

        protected override void OnDetachingFrom(Image bindable)
        {
            _cts.Cancel();
            bindable.CancelAnimations();
            base.OnDetachingFrom(bindable);
        }

        private async void StartFloatingAnimation()
        {
            try
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    double deltaX = _random.Next(-20, 21);
                    double deltaY = _random.Next(-20, 21);
                    uint duration = (uint)_random.Next(3000, 5001);

                    await _cloud.TranslateTo(
                        _initialX + deltaX,
                        _initialY + deltaY,
                        duration,
                        Easing.SinInOut);

                    await Task.Delay(100, _cts.Token);
                }
            }
            catch (TaskCanceledException)
            {
                // Thomas : Does nothing
            }
        }
    }
}