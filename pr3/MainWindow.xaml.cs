using System;
using System.Collections.Generic;
using System.Data;
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
using Lib_13_3;

namespace pr3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] matr;   
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void InfoCLick(object sender, RoutedEventArgs e)//инфокнопка
        {
            MessageBox.Show("Практическая 3 Кульковой Ангелины ИСП-31\r\nДана матрица размера M × N. В каждой ее строке найти количество элементов, меньших среднего арифметического всех элементов этой строки.");
        }

        private void ExitCLick(object sender, RoutedEventArgs e)//кнопка выхода
        {
            this.Close();
        }

        private void CreateClick(object sender, RoutedEventArgs e)//Кнопка создания и заполнения матрицы рандомом
        {
            int M, N;
            Random rnd = new Random();
            if (Int32.TryParse(tbM.Text, out M)==true)//проверяем, какого типа значения в текстбоксе и присваиваем значение строкам
                M = Convert.ToInt32(tbM.Text);
            if(Int32.TryParse(tbN.Text, out N)==true)//проверяем то же самое во втором и присваиваем столбцам
                N = Convert.ToInt32(tbN.Text);
            matr = new Int32 [M, N];
            for(int i = 0; i < M; i++)//проходим всю матрицу и заполняем её рандомными цифрами, затем выводим массив на форму
            {
                for (int j = 0; j < N; j++)
                    matr[i, j] = rnd.Next(10);
            }
            datagrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
        }

        private void RasClick(object sender, RoutedEventArgs e)//кнопка рассчёта, вызывает окно сообщения
        {
            if(datagrid.ItemsSource != null)
            MessageBox.Show(prakt3.KolMatr(matr));
        }

        private void DeleteCLick(object sender, RoutedEventArgs e)//очищение матрицы и текстбоксов заодно
        {
            datagrid.ItemsSource = null;
            matr = null;
            tbM.Text = string.Empty;
            tbN.Text = string.Empty;
        }

        private void CellEditEnd(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (datagrid.CurrentCell.Column != null)
            {
                int RowIndex = e.Row.GetIndex();//определяем номер строки
                int ColumnIndex = e.Column.DisplayIndex;//определяем номер столбца
                matr[RowIndex, ColumnIndex] = Convert.ToInt32(((TextBox)e.EditingElement).Text);//заносим ответ в матрицу
            }
        }
    }
}
