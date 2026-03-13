using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab02_Variant03
{
    public partial class Form1 : Form
    {
        // Флаг для предотвращения бесконечного обновления TextBox
        bool updating = false;

        public Form1()
        {
            InitializeComponent();

            // Привязка обработчиков событий
            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.TextChanged += textBox2_TextChanged;

            button1.Click += button1_Click; // Фибоначчи
            button2.Click += button2_Click; // Треугольник
        }

        // КОНВЕРТЕР ТЕМПЕРАТУР

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;

            try
            {
                updating = true;

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    double c = Convert.ToDouble(textBox1.Text);
                    // Вызов метода логики для перевода в Фаренгейт
                    double f = Logic.CelsiusToFahrenheit(c);
                    textBox2.Text = f.ToString("F2");
                }
                else
                {
                    textBox2.Clear();
                }
            }
            catch
            {
                textBox2.Clear(); // Очистка при некорректном вводе
            }

            updating = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;

            try
            {
                updating = true;

                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    double f = Convert.ToDouble(textBox2.Text);
                    // Вызов метода логики для перевода в Цельсий
                    double c = Logic.FahrenheitToCelsius(f);
                    textBox1.Text = c.ToString("F2");
                }
                else
                {
                    textBox1.Clear();
                }
            }
            catch
            {
                textBox1.Clear(); // Очистка при некорректном вводе
            }

            updating = false;
        }

        // ФИБОНАЧЧИ

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            try
            {
                int n = Convert.ToInt32(textBox3.Text);
                // Вызов метода логики для генерации чисел Фибоначчи
                var numbers = Logic.GenerateFibonacci(n);

                foreach (var num in numbers)
                    listBox1.Items.Add(num);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ТРЕУГОЛЬНИК

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox4.Text);
                double b = Convert.ToDouble(textBox5.Text);
                double c = Convert.ToDouble(textBox6.Text);

                // Проверка существования треугольника
                if (!Logic.TriangleExists(a, b, c))
                {
                    MessageBox.Show("Такого треугольника не существует");
                    return;
                }

                // Определение типа треугольника
                label8.Text = "Тип: " + Logic.GetTriangleType(a, b, c);

                DrawTriangle(a, b, c); // Вызов метода для рисования
            }
            catch
            {
                MessageBox.Show("Ошибка ввода сторон");
            }
        }

        // РИСОВАНИЕ ТРЕУГОЛЬНИКА

        private void DrawTriangle(double a, double b, double c)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            // Получаем координаты точек треугольника из Logic
            var points = Logic.GetTrianglePoints(a, b, c, pictureBox1.Width, pictureBox1.Height);

            // Рисуем линии треугольника
            g.DrawLine(Pens.Black, points[0], points[1]);
            g.DrawLine(Pens.Black, points[1], points[2]);
            g.DrawLine(Pens.Black, points[2], points[0]);

            pictureBox1.Image = bmp;
        }
    }
}