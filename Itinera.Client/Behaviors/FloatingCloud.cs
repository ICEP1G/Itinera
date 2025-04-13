namespace Itinera.Client.Behaviors
{
    public class FloatingCloud : Behavior<Image>
    {
        private Image _cloud;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        protected override void OnAttachedTo(Image bindable)
        {
            base.OnAttachedTo(bindable);
            _cloud = bindable;
            StartFloatingAnimation();
        }

        protected override void OnDetachingFrom(Image bindable)
        {
            _cts.Cancel();
            bindable.CancelAnimations();
            base.OnDetachingFrom(bindable);
        }

        private void StartFloatingAnimation()
        {
            var random = new Random();
            double initialY = _cloud.TranslationY;


            var animation = new Animation
            {
                // Up
                { 0, 0.5, new Animation(v => _cloud.TranslationY = v, initialY, initialY - random.Next(10, 16), Easing.SinInOut) },
                // Down
                { 0.5, 1, new Animation(v => _cloud.TranslationY = v, initialY - random.Next(10, 16), initialY + random.Next(10, 16), Easing.SinInOut) }
            };

            // Up and Down
            animation.Commit(_cloud, "FloatingAnimation", length: 4000, repeat: () => !_cts.Token.IsCancellationRequested);
        }
    }
}