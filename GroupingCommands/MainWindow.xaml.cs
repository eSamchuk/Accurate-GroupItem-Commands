using Prism.Commands;
using System;
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

namespace GroupingCommands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Book> Items { get; set; } = new ObservableCollection<Book>();

        private DelegateCommand<Book> myCommand;

        public DelegateCommand<Book> MyCommand => myCommand ?? (myCommand = new DelegateCommand<Book>(this.Execute, this.CanExecute));

        private bool CanExecute(Book value)
        {
            return value.Id != null;
        }

        private void Execute(Book value)
        {
            MessageBox.Show($"Value = {value.Name}");
        }

        public MainWindow()
        {
            InitializeComponent();

            this.Items.Add(new Book() { Id = 1, Name = "qwerty", Year = 2000 });
            this.Items.Add(new Book() { Id = 2, Name = "qwerty2", Year = 2000 });
            this.Items.Add(new Book() { Id = 3, Name = "qwerty3", Year = 2000 });

            this.Items.Add(new Book() { Id = 4, Name = "qwerty4", Year = 2001 });
            this.Items.Add(new Book() { Id = 5, Name = "qwerty5", Year = 2001 });
            this.Items.Add(new Book() { Id = null, Name = "qwerty6", Year = 2001 });


            this.DataContext = this;
        }
    }


    public class Book
    {
        public Book()
        {

        }

        public decimal? Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

    }

    public class BindingProxy : Freezable
    {
        #region Overrides of Freezable

        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        #endregion

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object),
                                         typeof(BindingProxy));
    }

}
