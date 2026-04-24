using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            OverlayLayer.Visibility = Visibility.Visible;
            double windowHeight = RootGrid.ActualHeight;
            DoubleAnimationUsingKeyFrames animation = new DoubleAnimationUsingKeyFrames();
            var keyFrame = new SplineDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.525)),
                Value = 0,
                KeySpline = new KeySpline(0.0, 0.9, 0.4, 1.0)
            };
            animation.KeyFrames.Add(keyFrame);
            OverlayTransform.Y = windowHeight;
            OverlayTransform.BeginAnimation(TranslateTransform.YProperty, animation);
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            double windowHeight = RootGrid.ActualHeight;
            DoubleAnimationUsingKeyFrames slideDown = new DoubleAnimationUsingKeyFrames();
            var keyFrame = new SplineDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.525)),
                Value = windowHeight,
                KeySpline = new KeySpline(0.1, 0.9, 0.4, 1.0)
            };
            slideDown.KeyFrames.Add(keyFrame);
            slideDown.Completed += (s, a) => {
                OverlayLayer.Visibility = Visibility.Collapsed;
            };
            OverlayTransform.BeginAnimation(TranslateTransform.YProperty, slideDown);
        }
    }
}