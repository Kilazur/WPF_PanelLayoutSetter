using System.Windows;
using System.Windows.Controls;

//http://blogs.microsoft.co.il/eladkatz/2011/05/29/what-is-the-easiest-way-to-set-spacing-between-items-in-stackpanel/
namespace YourNamespace
{
	public class LayoutSetter
	{
		#region Margin
		public static Thickness GetMargin(DependencyObject obj)
		{
			return (Thickness)obj.GetValue(MarginProperty);
		}

		public static void SetMargin(DependencyObject obj, Thickness value)
		{
			obj.SetValue(MarginProperty, value);
		}

		public static readonly DependencyProperty MarginProperty =
			DependencyProperty.RegisterAttached("Margin", typeof(Thickness), typeof(LayoutSetter), new UIPropertyMetadata(new Thickness(), PropertyChangedCallback));
		#endregion

		#region VerticalAlignment
		public static VerticalAlignment GetVerticalAlignment(DependencyObject obj)
		{
			return (VerticalAlignment)obj.GetValue(VerticalAlignmentProperty);
		}

		public static void SetVerticalAlignment(DependencyObject obj, VerticalAlignment value)
		{
			obj.SetValue(VerticalAlignmentProperty, value);
		}

		public static readonly DependencyProperty VerticalAlignmentProperty =
			DependencyProperty.RegisterAttached("VerticalAlignment", typeof(VerticalAlignment), typeof(LayoutSetter), new UIPropertyMetadata(VerticalAlignment.Top, PropertyChangedCallback));
		#endregion

    // Add any other FrameworkElement properties you may need

		public static void PropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
		{
			// Make sure this is put on a panel (ex: Grid)
			var panel = sender as Panel;
			if (panel == null) return;

			panel.Loaded += panel_Loaded;
		}

		static void panel_Loaded(object sender, RoutedEventArgs e)
		{
			var panel = sender as Panel;
			panel.Loaded -= panel_Loaded; // avoids issues with potential reloading, from code-behind for example

			foreach (var child in panel.Children)
			{
				var fe = child as FrameworkElement;
				if (fe == null) continue;

				//http://stackoverflow.com/a/19798648/3283203
				if (fe.ReadLocalValue(FrameworkElement.MarginProperty) == DependencyProperty.UnsetValue)
					fe.Margin = LayoutSetter.GetMargin(panel);

				if (fe.ReadLocalValue(FrameworkElement.VerticalAlignmentProperty) == DependencyProperty.UnsetValue)
					fe.VerticalAlignment = LayoutSetter.GetVerticalAlignment(panel);
			}
		}
	}
}
