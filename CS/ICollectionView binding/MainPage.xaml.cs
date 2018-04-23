using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace ICollectionView_binding
{
    public sealed partial class MainPage : Page
    {
        DataModel grid_data = new DataModel();
        public MainPage()
        {
            this.DataContext = grid_data;
            this.InitializeComponent();
            
        }

        public class DataModel {
            public ICollectionView Data { get; set; }
            public DataModel() {
                Data = new CollectionViewSource {
                    Source = CreateList()
                }.View;
            }
        }

        public static IList CreateList() {
            List<TestData> list = new List<TestData>();
            for (int i = 0; i < 100; i++) {
                list.Add(new TestData() {
                    Number1 = i,
                    Number2 = i * 10,
                    Text1 = "row " + i,
                    Text2 = "ROW " + i
                });
            }
            return list;
        }
        public class TestData {
            public int Number1 { get; set; }
            public int Number2 { get; set; }
            public string Text1 { get; set; }
            public string Text2 { get; set; }
        }

        private void Button_Left(object sender, RoutedEventArgs e) {
            if (grid_data.Data.CurrentPosition == 0)
                grid_data.Data.MoveCurrentToLast();
            else
                grid_data.Data.MoveCurrentToPrevious();
        }

        private void Button_Right(object sender, RoutedEventArgs e) {
            if (grid_data.Data.CurrentItem == grid_data.Data.Last())
                grid_data.Data.MoveCurrentToFirst();
            else
                grid_data.Data.MoveCurrentToNext();
        }
    }
}
