namespace Itinera.Client.Behaviors
{
    public class FloatingCloud : Behavior<Image>
    {
        private Image _cloud;
        private Random _random = new Random();
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private double _initialY;

        protected override void OnAttachedTo(Image bindable)
        {
            base.OnAttachedTo(bindable);
            _cloud = bindable;

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
                    double deltaY = _random.Next(-15, 17);
                    uint duration = (uint)_random.Next(3000, 5001);

                    await _cloud.TranslateTo(
                       _cloud.TranslationX,
                        _initialY + deltaY,
                        duration,
                        Easing.SinInOut);

                    await Task.Delay(100, _cts.Token);
                }
            }
            catch (TaskCanceledException)
            {
                // When animation is cancelledn, it does nothing
            }
        }
    }
}