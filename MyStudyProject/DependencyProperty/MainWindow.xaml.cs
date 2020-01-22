using System;
using System.Collections.Generic;
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

namespace DependencyPropertyTest
{
    /// <summary>
    /// 바인딩 개념이해
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty UserTextProperty = DependencyProperty.Register(nameof(UserText), typeof(string), typeof(MainWindow),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextChangeCallBack)));

        /// <summary>
        /// 실제로 Text가 변경되지 않으면 callback 되지 않음
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnTextChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow w = d as MainWindow;
            if (w.OldValue == null || w.NewValue == null) return;

            w.OldValue.Text = e.OldValue as string;
            w.NewValue.Text = e.NewValue as string;
        }

        public string UserText
        {
            get { return GetValue(UserTextProperty) as string; }
            set { SetValue(UserTextProperty, value); }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserText = MyTextBox.Text;
        }

        private void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txt = sender as TextBox;
            UserText = txt.Text;
        }
    }
}