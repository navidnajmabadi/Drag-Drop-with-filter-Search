using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.DragDrop;

namespace StarControlUI
{
    /// <summary>
    /// Interaction logic for DragDropUC.xaml
    /// </summary>
    public partial class DragDropUC : UserControl
    {
        public DragDropUC()
        {
            InitializeComponent();
            AllItems = ApplicationInfo.GenerateApplicationInfos();
            MyItems = new ObservableCollection<ApplicationInfo>(AllItems);
            DragDropManager.AddDragInitializeHandler(ApplicationList, OnDragInitialize);
            DragDropManager.AddGiveFeedbackHandler(ApplicationList, OnGiveFeedback);
            DragDropManager.AddDragDropCompletedHandler(ApplicationList, OnDragCompleted);
            DragDropManager.AddDropHandler(ApplicationList, OnDrop);
        }


        public ObservableCollection<ApplicationInfo> MyItems
        {
            get { return (ObservableCollection<ApplicationInfo>)GetValue(MyItemsProperty); }
            set { SetValue(MyItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyItemsProperty =
            DependencyProperty.Register("MyItems", typeof(ObservableCollection<ApplicationInfo>), typeof(DragDropUC), new PropertyMetadata(new ObservableCollection<ApplicationInfo>()));

        ObservableCollection<ApplicationInfo> AllItems;
        private void textSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MyItems.Clear();
            foreach (var item1 in AllItems.Where(x => x.Name.CaseInsensitiveContains(textSearchBox.Text)))
                MyItems.Add(item1);
        }


        private void OnDragInitialize(object sender, DragInitializeEventArgs args)
        {
            args.AllowedEffects = DragDropEffects.All;
            var payload = DragDropPayloadManager.GeneratePayload(null);
            var data = ((FrameworkElement)args.OriginalSource).DataContext;
            payload.SetData("DragData", data);
            args.Data = payload;
            args.DragVisual = new ContentControl { Content = data, ContentTemplate = LayoutRoot.Resources["ApplicationTemplate"] as DataTemplate };
        }
        //
        // <summary>
        // set mouse cursor to be arrow
        // </summary>
        // <param name="sender"></param>
        // <param name="args"></param>
        private void OnGiveFeedback(object sender, Telerik.Windows.DragDrop.GiveFeedbackEventArgs args)
        {
            args.SetCursor(Cursors.Arrow);
            args.Handled = true;
        }
        //
        // <summary>
        // executed when drag and drop operations finish
        // </summary>
        // <param name="sender"></param>
        // <param name="args"></param>
        private void OnDrop(object sender, Telerik.Windows.DragDrop.DragEventArgs args)
        {
            var data = ((DataObject)args.Data).GetData("DragData");
            ((IList)(sender as ListBox).ItemsSource).Add(data);
        }

        public void OnDragCompleted(object sender, Telerik.Windows.DragDrop.DragDropCompletedEventArgs args)
        {
            var data = DragDropPayloadManager.GetDataFromObject(args.Data, "DragData");
            //  ((IList)(sender as ListBox).ItemsSource).Remove(data);
        }

    }
    public static class Extensions
    {
        public static bool CaseInsensitiveContains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }
    }
}

