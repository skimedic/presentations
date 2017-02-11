#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - WatermarkTextBehavior.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

//http://www.microsoft.com/downloads/details.aspx?FamilyID=F1AE9A30-4928-411D-970B-E682AB179E17&displaylang=en
//Microsoft.Expression.Interactions
//System.Windows.Interactivity
namespace WPFDemo.D_Behaviors
{
    /// <summary>
    /// This behavior associates a watermark onto a TextBox indicating what the user should
    /// provide as input.
    /// </summary>
    public class WatermarkTextBehavior : Behavior<TextBox>
    {
        /// <summary>
        /// The watermark text
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(WatermarkTextBehavior),
                                        new FrameworkPropertyMetadata(string.Empty));

        static readonly DependencyPropertyKey IsWatermarkedPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly("IsWatermarked", typeof(bool), typeof(WatermarkTextBehavior),
                                        new FrameworkPropertyMetadata(false));

        /// <summary>
        /// This readonly property is applied to the TextBox and indicates whether the watermark
        /// is currently being displayed.  It allows a style to change the visual appearanve of the
        /// TextBox.
        /// </summary>
        public static readonly DependencyProperty IsWatermarkedProperty = IsWatermarkedPropertyKey.DependencyProperty;

        /// <summary>
        /// Retrieves the current watermarked state of the TextBox.
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool GetIsWatermarked(TextBox tb)
        {
            return (bool)tb.GetValue(IsWatermarkedProperty);
        }

        /// <summary>
        /// Retrieves the current watermarked state of the TextBox.
        /// </summary>
        public bool IsWatermarked
        {
            get { return GetIsWatermarked(AssociatedObject); }
            private set { AssociatedObject.SetValue(IsWatermarkedPropertyKey, value); }
        }

        /// <summary>
        /// The watermark text
        /// </summary>
        public string Text
        {
            get { return (string)base.GetValue(TextProperty); }
            set { base.SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>
        /// Override this to hook up functionality to the AssociatedObject.
        /// </remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += OnGotFocus;
            AssociatedObject.LostFocus += OnLostFocus;

            OnLostFocus(null, null);
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>
        /// Override this to unhook functionality from the AssociatedObject.
        /// </remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.GotFocus -= OnGotFocus;
            AssociatedObject.LostFocus -= OnLostFocus;
        }

        /// <summary>
        /// This method is called when the textbox gains focus.  It removes the watermark.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (string.Compare(AssociatedObject.Text, this.Text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                AssociatedObject.Text = string.Empty;
                IsWatermarked = false;
            }
        }

        /// <summary>
        /// This method is called when focus is lost from the TextBox.  It puts the watermark
        /// into place if no text is in the textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(AssociatedObject.Text))
            {
                AssociatedObject.Text = this.Text;
                IsWatermarked = true;
            }
        }
    }
}
