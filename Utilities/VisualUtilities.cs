using System.Windows;
using System.Windows.Media;

namespace Utilities
{
    public static class VisualUtilities
    {
        public static int CountVisualChildren<T>(DependencyObject obj) where T : DependencyObject
        {
            int count = 0;

            if (obj is T)
                count = 1;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                count += CountVisualChildren<T>(VisualTreeHelper.GetChild(obj, i));

            return count;
        }
    }
}