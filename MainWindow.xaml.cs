using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace CalculatorApp
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
            foreach(UIElement elem in Main.Children) // Получаем все элементы нашей сетки
            {
                if(elem is Button) // если элемент имеет тип кнопки
                { 
                    ((Button)elem).Click += Button_Click; // создаём для него обработчик события нажатия
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) // обработчик собития нажатия на клавишу
        {
            string? currentLine = (string)((Button)e.OriginalSource).Content; // получаем надпись на кнопке

            if(currentLine == "AC") { CurrentResult.Text = ""; } // если АС то стираем строку

            else if(currentLine == "=") // если =
            { 
                string result = new DataTable().Compute(CurrentResult.Text, null).ToString(); // вычисляем значение(работает только для +-/*%)
                CurrentResult.Text = result; // выводим ответ

                PastResult.Text = "Ans = " + result; // в отдельном боксе выводим предыдущий результат вычислений
            }

            else if(currentLine == "C") // если С
            {
                CurrentResult.Text = CurrentResult.Text.Remove(CurrentResult.Text.Length - 1); // удаляем последний символ из строки
            }

            else { CurrentResult.Text += currentLine; } // ввод выражения для остальных кнопок
        }
    }
}