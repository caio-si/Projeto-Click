using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace ClickAutomation.Services
{
    public class AnimationHelper
    {
        /// <summary>
        /// Cria uma animação de pulso para indicadores de status
        /// </summary>
        public static Storyboard CreatePulseAnimation(FrameworkElement target, TimeSpan duration)
        {
            var storyboard = new Storyboard();
            
            var opacityAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.3,
                Duration = duration,
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };
            
            Storyboard.SetTarget(opacityAnimation, target);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));
            
            storyboard.Children.Add(opacityAnimation);
            return storyboard;
        }

        /// <summary>
        /// Cria uma animação de click (escala)
        /// </summary>
        public static Storyboard CreateClickAnimation(FrameworkElement target)
        {
            var storyboard = new Storyboard();
            
            // Garantir que o elemento tenha RenderTransform
            if (target.RenderTransform == null)
            {
                target.RenderTransform = new ScaleTransform();
            }

            var scaleXAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 1.3,
                Duration = TimeSpan.FromMilliseconds(200),
                AutoReverse = true
            };

            var scaleYAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 1.3,
                Duration = TimeSpan.FromMilliseconds(200),
                AutoReverse = true
            };

            Storyboard.SetTarget(scaleXAnimation, target);
            Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            
            Storyboard.SetTarget(scaleYAnimation, target);
            Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

            storyboard.Children.Add(scaleXAnimation);
            storyboard.Children.Add(scaleYAnimation);
            
            return storyboard;
        }

        /// <summary>
        /// Cria uma animação de fade in/out
        /// </summary>
        public static Storyboard CreateFadeAnimation(FrameworkElement target, double fromOpacity, double toOpacity, TimeSpan duration)
        {
            var storyboard = new Storyboard();
            
            var opacityAnimation = new DoubleAnimation
            {
                From = fromOpacity,
                To = toOpacity,
                Duration = duration
            };
            
            Storyboard.SetTarget(opacityAnimation, target);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));
            
            storyboard.Children.Add(opacityAnimation);
            return storyboard;
        }

        /// <summary>
        /// Cria uma animação de slide (movimento horizontal)
        /// </summary>
        public static Storyboard CreateSlideAnimation(FrameworkElement target, double fromX, double toX, TimeSpan duration)
        {
            var storyboard = new Storyboard();
            
            // Garantir que o elemento tenha RenderTransform
            if (target.RenderTransform == null)
            {
                target.RenderTransform = new TranslateTransform();
            }

            var slideAnimation = new DoubleAnimation
            {
                From = fromX,
                To = toX,
                Duration = duration
            };
            
            Storyboard.SetTarget(slideAnimation, target);
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));
            
            storyboard.Children.Add(slideAnimation);
            return storyboard;
        }

        /// <summary>
        /// Executa uma animação de forma assíncrona
        /// </summary>
        public static async Task ExecuteAnimationAsync(Storyboard storyboard)
        {
            var tcs = new TaskCompletionSource<bool>();
            
            EventHandler handler = (s, e) => tcs.SetResult(true);
            storyboard.Completed += handler;
            
            try
            {
                storyboard.Begin();
                await tcs.Task;
            }
            finally
            {
                storyboard.Completed -= handler;
            }
        }

        /// <summary>
        /// Cria uma animação de bounce para botões
        /// </summary>
        public static Storyboard CreateBounceAnimation(FrameworkElement target)
        {
            var storyboard = new Storyboard();
            
            // Garantir que o elemento tenha RenderTransform
            if (target.RenderTransform == null)
            {
                target.RenderTransform = new ScaleTransform();
            }

            var scaleXAnimation = new DoubleAnimationUsingKeyFrames();
            scaleXAnimation.KeyFrames.Add(new EasingDoubleKeyFrame(1.0, KeyTime.FromTimeSpan(TimeSpan.Zero)));
            scaleXAnimation.KeyFrames.Add(new EasingDoubleKeyFrame(1.1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(100)), new ElasticEase { EasingMode = EasingMode.EaseOut }));
            scaleXAnimation.KeyFrames.Add(new EasingDoubleKeyFrame(1.0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300))));

            var scaleYAnimation = new DoubleAnimationUsingKeyFrames();
            scaleYAnimation.KeyFrames.Add(new EasingDoubleKeyFrame(1.0, KeyTime.FromTimeSpan(TimeSpan.Zero)));
            scaleYAnimation.KeyFrames.Add(new EasingDoubleKeyFrame(1.1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(100)), new ElasticEase { EasingMode = EasingMode.EaseOut }));
            scaleYAnimation.KeyFrames.Add(new EasingDoubleKeyFrame(1.0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300))));

            Storyboard.SetTarget(scaleXAnimation, target);
            Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleX)"));
            
            Storyboard.SetTarget(scaleYAnimation, target);
            Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

            storyboard.Children.Add(scaleXAnimation);
            storyboard.Children.Add(scaleYAnimation);
            
            return storyboard;
        }
    }
}
