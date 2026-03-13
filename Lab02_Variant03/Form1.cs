using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab02_Variant03
{
    public partial class Form1 : Form
    {
        // Флаг используется чтобы избежать бесконечного обновления TextBox
        bool updating = false;

        public Form1()
        {
            InitializeComponent();

            // Подключение обработчиков событий
            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.TextChanged += textBox2_TextChanged;

            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        // КОНВЕРТЕР ТЕМПЕРАТУР

        // Событие срабатывает при изменении текста в textBox1 (Цельсий)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Если уже происходит обновление второго поля — выходим
            if (updating) return;

            try
            {
                updating = true;

                // Если поле не пустое
                if (textBox1.Text != "")
                {
                    double c = Convert.ToDouble(textBox1.Text);

                    // перевод в Фаренгейты
                    double f = c * 9 / 5 + 32;

                    textBox2.Text = f.ToString("F2");
                }
                else
                {
                    textBox2.Clear();
                }
            }
            catch
            {
                textBox2.Clear();
            }

            updating = false;
        }

        // Событие изменения температуры в Фаренгейтах
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;

            try
            {
                updating = true;

                if (textBox2.Text != "")
                {
                    double f = Convert.ToDouble(textBox2.Text);

                    // перевод в Цельсии
                    double c = (f - 32) * 5 / 9;

                    textBox1.Text = c.ToString("F2");
                }
                else
                {
                    textBox1.Clear();
                }
            }
            catch
            {
                textBox1.Clear();
            }

            updating = false;
        }

        // ГЕНЕРАЦИЯ ЧИСЕЛ ФИБОНАЧЧИ

        // Событие нажатия кнопки "Сгенерировать"
        private void button1_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();

            try
            {
                int n = Convert.ToInt32(textBox3.Text);

                if (n <= 0)
                {
                    MessageBox.Show("Введите число больше 0");
                    return;
                }

                // первые два числа последовательности
                int a = 1;
                int b = 1;

                // добавляем первое число
                listBox1.Items.Add(a);

                if (n > 1)
                    listBox1.Items.Add(b);

                // вычисление остальных чисел
                for (int i = 3; i <= n; i++)
                {
                    int c = a + b;

                    listBox1.Items.Add(c);

                    // сдвиг значений
                    a = b;
                    b = c;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка ввода числа");
            }
        }


        // ТРЕУГОЛЬНИК

        // Событие нажатия кнопки "Построить"
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox4.Text);
                double b = Convert.ToDouble(textBox5.Text);
                double c = Convert.ToDouble(textBox6.Text);

                // проверка существования треугольника
                if (a + b <= c || a + c <= b || b + c <= a)
                {
                    MessageBox.Show("Такого треугольника не существует");
                    return;
                }

                // определение типа треугольника

                if (a == b && b == c)
                    label8.Text = "Тип: равносторонний";

                else if (a == b || a == c || b == c)
                    label8.Text = "Тип: равнобедренный";

                else
                    label8.Text = "Тип: разносторонний";


                DrawTriangle(a, b, c);
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

            // масштаб, чтобы треугольник помещался
            double maxSide = Math.Max(a, Math.Max(b, c));
            double scale = (pictureBox1.Width - 80) / maxSide;

            a *= scale;
            b *= scale;
            c *= scale;

            // первая точка
            PointF p1 = new PointF(40, pictureBox1.Height - 40);

            // вторая точка
            PointF p2 = new PointF(40 + (float)a, pictureBox1.Height - 40);

            // вычисляем координаты третьей точки
            double x = (c * c - b * b + a * a) / (2 * a);
            double y = Math.Sqrt(c * c - x * x);

            PointF p3 = new PointF(
                40 + (float)x,
                pictureBox1.Height - 40 - (float)y
            );

            // рисуем треугольник
            g.DrawLine(Pens.Black, p1, p2);
            g.DrawLine(Pens.Black, p2, p3);
            g.DrawLine(Pens.Black, p3, p1);

            pictureBox1.Image = bmp;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}