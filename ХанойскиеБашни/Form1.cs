using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ХанойскиеБашни
{
    public partial class Ханойские_башни : Form
    {       
        public Ханойские_башни()
        {
            InitializeComponent();
            rectangleSize(kol);
            deletePBoxes(kol);
            changeSizes(kol);
            comboBox1.Text = Convert.ToString(8);
        }
        public class InfoRect//информация о прямоугольнике(кольца башни)
        {
            public PictureBox p;
            public bool top;//является ли данный прямоугольник верхним
            public int number; //номер кольца(чем больше число, тем меньше кольцо) от 1 до 8
            public InfoRect(PictureBox p,int n, bool t = false)
            {
                this.p = p;
                this.top = t;
                this.number = n;
            }
        }
        int kol = 8;//количество колец(минимум 3)  

        Stack<InfoRect> k1 = new Stack<InfoRect>();
        Stack<InfoRect> k2 = new Stack<InfoRect>();
        Stack<InfoRect> k3 = new Stack<InfoRect>(); // информация о кольцах в каждом стержне               

        InfoRect temp; //Кольцо для которого drag=true
        

        float high; //высота каждого прямоугольника
        float width; //изменение ширины каждого последующего прямоугольника

        int dx;
        int dy;// для перетаскивания

        int count = 0; // количество шагов

        int m;// количество строк
        bool drag = false;
        //вывод в текстбокс алгоритма решения
        private void SolutionHanoibns(int k, char a, char b, char c)
        {
            if (k > 1) SolutionHanoibns(k - 1, a, c, b);
            textBox1.AppendText("Переложить диск из " + a + " в " + b + "\n");
            if (k > 1) SolutionHanoibns(k - 1, c, b, a);
        }
        private void movePBox(InfoRect t, int n)//Перенести пикчербокс на стержень n (1,2,3)
        {
            temp = t;
            switch (n)
            {
                case 1:
                    {
                        t.p.Location = new Point(Col1.Width + Col1.Location.X - t.p.Width / 2, 75);
                        break;
                    }
                case 2:
                    {
                        t.p.Location = new Point(Col2.Width + Col2.Location.X - t.p.Width / 2, 75);
                        break;
                    }
                case 3:
                    {
                        t.p.Location = new Point(Col3.Width + Col3.Location.X - t.p.Width / 2, 75);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void rectangleSize(int k)//определяет размеры и координаты прямоугольников исходя от их количества
        {
            switch (k)
            {
                case 3:
                    {
                        high = 100;
                        width = 50;//вычитаем 50 из предыдущего
                        break;
                    }
                case 4:
                    {
                        high = 86;
                        width = 40;                        
                        break;
                    }
                case 5:
                    {
                        high = 66;
                        width = 36;
                        break;
                    }
                case 6:
                    {
                        high = 54;
                        width = 30;
                        break;
                    }
                case 7:
                    {
                        high = 45;
                        width = 26;
                        break;
                    }
                case 8:
                    {
                        high = 39;
                        width = 22;
                        break;
                    }
                default:  //по умолчанию 8 колец
                    {
                        high = 39;
                        width = 22;
                        break;
                    }
            }
        }
        private void deletePBoxes(int k)//делает неведимым ненужные пикчербоксы, в зависимости от количества
        {
            switch (k)
            {
                case 3:
                    {
                        pictureBox9.Visible = false;
                        pictureBox9.Enabled = false;
                        pictureBox8.Visible = false;
                        pictureBox8.Enabled = false;
                        pictureBox7.Visible = false;
                        pictureBox7.Enabled = false;
                        pictureBox6.Visible = false;
                        pictureBox6.Enabled = false;
                        pictureBox5.Visible = false;
                        pictureBox5.Enabled = false;
                        break;
                    }
                case 4:
                    {
                        pictureBox9.Visible = false;
                        pictureBox9.Enabled = false;
                        pictureBox8.Visible = false;
                        pictureBox8.Enabled = false;
                        pictureBox7.Visible = false;
                        pictureBox7.Enabled = false;
                        pictureBox6.Visible = false;
                        pictureBox6.Enabled = false;
                        pictureBox5.Visible = true;
                        pictureBox5.Enabled = true;
                        break;
                    }
                case 5:
                    {
                        pictureBox9.Visible = false;
                        pictureBox9.Enabled = false;
                        pictureBox8.Visible = false;
                        pictureBox8.Enabled = false;
                        pictureBox7.Visible = false;
                        pictureBox7.Enabled = false;
                        pictureBox6.Visible = true;
                        pictureBox6.Enabled = true;
                        pictureBox5.Visible = true;
                        pictureBox5.Enabled = true;
                        break;
                    }
                case 6:
                    {
                        pictureBox9.Visible = false;
                        pictureBox9.Enabled = false;
                        pictureBox8.Visible = false;
                        pictureBox8.Enabled = false;
                        pictureBox7.Visible = true;
                        pictureBox7.Enabled = true;
                        pictureBox6.Visible = true;
                        pictureBox6.Enabled = true;
                        pictureBox5.Visible = true;
                        pictureBox5.Enabled = true;
                        break;
                    }
                case 7:
                    {
                        pictureBox9.Visible = false;
                        pictureBox9.Enabled = false;
                        pictureBox8.Visible = true;
                        pictureBox8.Enabled = true;
                        pictureBox7.Visible = true;
                        pictureBox7.Enabled = true;
                        pictureBox6.Visible = true;
                        pictureBox6.Enabled = true;
                        pictureBox5.Visible = true;
                        pictureBox5.Enabled = true;
                        break;
                    }
                default:
                    {
                        pictureBox9.Visible = true;
                        pictureBox9.Enabled = true;
                        pictureBox8.Visible = true;
                        pictureBox8.Enabled = true;
                        pictureBox7.Visible = true;
                        pictureBox7.Enabled = true;
                        pictureBox6.Visible = true;
                        pictureBox6.Enabled = true;
                        pictureBox5.Visible = true;
                        pictureBox5.Enabled = true;
                        break;
                    }
            }
        }
        private void changeSizes(int k)//меняет размеры пикчербоксов в зависимости от их количества и записывает их в стек k1
        {
            rectangleSize(kol);
            switch (k)
            {
                case 3:
                    {
                        pictureBox2.Width = 244;
                        pictureBox2.Location = new Point(Col1.Width + Col1.Location.X - pictureBox2.Width / 2, 434-Convert.ToInt32(high));                       
                        pictureBox2.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox2,1));

                        pictureBox3.Width = 244- Convert.ToInt32(width);
                        pictureBox3.Location = new Point(Col1.Width + Col1.Location.X - pictureBox3.Width / 2, Convert.ToInt32(434 - (2*high+6)));                        
                        pictureBox3.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox3,2));

                        pictureBox4.Width = 244 - Convert.ToInt32(width*2);
                        pictureBox4.Location = new Point(Col1.Width + Col1.Location.X - pictureBox4.Width / 2, Convert.ToInt32(434 - (3*high + 2*6)));                        
                        pictureBox4.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox4,3,true));
                        break;
                    }
                case 4:
                    {
                        pictureBox2.Width = 244;
                        pictureBox2.Location = new Point(Col1.Width + Col1.Location.X - pictureBox2.Width / 2, 434 - Convert.ToInt32(high));
                        pictureBox2.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox2, 1));

                        pictureBox3.Width = 244 - Convert.ToInt32(width);
                        pictureBox3.Location = new Point(Col1.Width + Col1.Location.X - pictureBox3.Width / 2, Convert.ToInt32(434 - (2 * high + 6)));
                        pictureBox3.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox3, 2));

                        pictureBox4.Width = 244 - Convert.ToInt32(width * 2);
                        pictureBox4.Location = new Point(Col1.Width + Col1.Location.X - pictureBox4.Width / 2, Convert.ToInt32(434 - (3 * high + 2 * 6)));
                        pictureBox4.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox4, 3));

                        pictureBox5.Width = 244 - Convert.ToInt32(width * 3);
                        pictureBox5.Location = new Point(Col1.Width + Col1.Location.X - pictureBox5.Width / 2, Convert.ToInt32(434 - (4 * high + 3 * 6)));
                        pictureBox5.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox5, 4,true));
                        break;
                    }
                case 5:
                    {
                        pictureBox2.Width = 244;
                        pictureBox2.Location = new Point(Col1.Width + Col1.Location.X - pictureBox2.Width / 2, 434 - Convert.ToInt32(high));
                        pictureBox2.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox2, 1));

                        pictureBox3.Width = 244 - Convert.ToInt32(width);
                        pictureBox3.Location = new Point(Col1.Width + Col1.Location.X - pictureBox3.Width / 2, Convert.ToInt32(434 - (2 * high + 6)));
                        pictureBox3.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox3, 2));

                        pictureBox4.Width = 244 - Convert.ToInt32(width * 2);
                        pictureBox4.Location = new Point(Col1.Width + Col1.Location.X - pictureBox4.Width / 2, Convert.ToInt32(434 - (3 * high + 2 * 6)));
                        pictureBox4.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox4, 3));

                        pictureBox5.Width = 244 - Convert.ToInt32(width * 3);
                        pictureBox5.Location = new Point(Col1.Width + Col1.Location.X - pictureBox5.Width / 2, Convert.ToInt32(434 - (4 * high + 3 * 6)));
                        pictureBox5.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox5, 4));

                        pictureBox6.Width = 244 - Convert.ToInt32(width * 4);
                        pictureBox6.Location = new Point(Col1.Width + Col1.Location.X - pictureBox6.Width / 2, Convert.ToInt32(434 - (5 * high + 4 * 6)));
                        pictureBox6.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox6, 5,true));
                        break;
                    }
                case 6:
                    {
                        pictureBox2.Width = 244;
                        pictureBox2.Location = new Point(Col1.Width + Col1.Location.X - pictureBox2.Width / 2, 434 - Convert.ToInt32(high));
                        pictureBox2.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox2, 1));

                        pictureBox3.Width = 244 - Convert.ToInt32(width);
                        pictureBox3.Location = new Point(Col1.Width + Col1.Location.X - pictureBox3.Width / 2, Convert.ToInt32(434 - (2 * high + 6)));
                        pictureBox3.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox3, 2));

                        pictureBox4.Width = 244 - Convert.ToInt32(width * 2);
                        pictureBox4.Location = new Point(Col1.Width + Col1.Location.X - pictureBox4.Width / 2, Convert.ToInt32(434 - (3 * high + 2 * 6)));
                        pictureBox4.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox4, 3));

                        pictureBox5.Width = 244 - Convert.ToInt32(width * 3);
                        pictureBox5.Location = new Point(Col1.Width + Col1.Location.X - pictureBox5.Width / 2, Convert.ToInt32(434 - (4 * high + 3 * 6)));
                        pictureBox5.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox5, 4));

                        pictureBox6.Width = 244 - Convert.ToInt32(width * 4);
                        pictureBox6.Location = new Point(Col1.Width + Col1.Location.X - pictureBox6.Width / 2, Convert.ToInt32(434 - (5 * high + 4 * 6)));
                        pictureBox6.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox6, 5));

                        pictureBox7.Width = 244 - Convert.ToInt32(width * 5);
                        pictureBox7.Location = new Point(Col1.Width + Col1.Location.X - pictureBox7.Width / 2, Convert.ToInt32(434 - (6 * high + 5 * 6)));
                        pictureBox7.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox7, 6,true));
                        break;
                    }
                case 7:
                    {
                        pictureBox2.Width = 244;
                        pictureBox2.Location = new Point(Col1.Width + Col1.Location.X - pictureBox2.Width / 2, 434 - Convert.ToInt32(high));
                        pictureBox2.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox2, 1));

                        pictureBox3.Width = 244 - Convert.ToInt32(width);
                        pictureBox3.Location = new Point(Col1.Width + Col1.Location.X - pictureBox3.Width / 2, Convert.ToInt32(434 - (2 * high + 6)));
                        pictureBox3.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox3, 2));

                        pictureBox4.Width = 244 - Convert.ToInt32(width * 2);
                        pictureBox4.Location = new Point(Col1.Width + Col1.Location.X - pictureBox4.Width / 2, Convert.ToInt32(434 - (3 * high + 2 * 6)));
                        pictureBox4.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox4, 3));

                        pictureBox5.Width = 244 - Convert.ToInt32(width * 3);
                        pictureBox5.Location = new Point(Col1.Width + Col1.Location.X - pictureBox5.Width / 2, Convert.ToInt32(434 - (4 * high + 3 * 6)));
                        pictureBox5.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox5, 4));

                        pictureBox6.Width = 244 - Convert.ToInt32(width * 4);
                        pictureBox6.Location = new Point(Col1.Width + Col1.Location.X - pictureBox6.Width / 2, Convert.ToInt32(434 - (5 * high + 4 * 6)));
                        pictureBox6.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox6, 5));

                        pictureBox7.Width = 244 - Convert.ToInt32(width * 5);
                        pictureBox7.Location = new Point(Col1.Width + Col1.Location.X - pictureBox7.Width / 2, Convert.ToInt32(434 - (6 * high + 5 * 6)));
                        pictureBox7.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox7, 6));

                        pictureBox8.Width = 244 - Convert.ToInt32(width * 6);
                        pictureBox8.Location = new Point(Col1.Width + Col1.Location.X - pictureBox8.Width / 2, Convert.ToInt32(434 - (7 * high + 6 * 6)));
                        pictureBox8.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox8, 7,true));
                        break;
                    }
                default:
                    {
                        pictureBox2.Width = 244;
                        pictureBox2.Location = new Point(Col1.Width + Col1.Location.X - pictureBox2.Width / 2, 434 - Convert.ToInt32(high));
                        pictureBox2.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox2, 1));

                        pictureBox3.Width = 244 - Convert.ToInt32(width);
                        pictureBox3.Location = new Point(Col1.Width + Col1.Location.X - pictureBox3.Width / 2, Convert.ToInt32(434 - (2 * high + 6)));
                        pictureBox3.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox3, 2));

                        pictureBox4.Width = 244 - Convert.ToInt32(width * 2);
                        pictureBox4.Location = new Point(Col1.Width + Col1.Location.X - pictureBox4.Width / 2, Convert.ToInt32(434 - (3 * high + 2 * 6)));
                        pictureBox4.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox4, 3));

                        pictureBox5.Width = 244 - Convert.ToInt32(width * 3);
                        pictureBox5.Location = new Point(Col1.Width + Col1.Location.X - pictureBox5.Width / 2, Convert.ToInt32(434 - (4 * high + 3 * 6)));                        
                        pictureBox5.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox5, 4));

                        pictureBox6.Width = 244 - Convert.ToInt32(width * 4);
                        pictureBox6.Location = new Point(Col1.Width + Col1.Location.X - pictureBox6.Width / 2, Convert.ToInt32(434 - (5 * high + 4 * 6)));                      
                        pictureBox6.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox6, 5));

                        pictureBox7.Width = 244 - Convert.ToInt32(width * 5);
                        pictureBox7.Location = new Point(Col1.Width + Col1.Location.X - pictureBox7.Width / 2, Convert.ToInt32(434 - (6 * high + 5 * 6)));                      
                        pictureBox7.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox7, 6));

                        pictureBox8.Width = 244 - Convert.ToInt32(width * 6);
                        pictureBox8.Location = new Point(Col1.Width + Col1.Location.X - pictureBox8.Width / 2, Convert.ToInt32(434 - (7 * high + 6 * 6)));                        
                        pictureBox8.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox8, 7));

                        pictureBox9.Width = 244 - Convert.ToInt32(width * 7);
                        pictureBox9.Location = new Point(Col1.Width + Col1.Location.X - pictureBox9.Width / 2, Convert.ToInt32(434 - (8 * high + 7 * 6)));
                        pictureBox9.Height = Convert.ToInt32(high);
                        k1.Push(new InfoRect(pictureBox9, 8,true));
                        break;
                    }
            }
        }
        private bool inters(PictureBox p1, PictureBox p2) //проверка на пересечение двух пикчербоксов
        {           
            if (p1.Location.X + p1.Width < p2.Location.X || p1.Location.X > p2.Location.X + p2.Width ||
                 p1.Location.Y > p2.Location.Y + p2.Height || p1.Location.Y + p1.Height < p2.Location.Y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //проверяет, пересекается ли выбранное кольцо со стержнем и перемещает кольцо на новый стержень
        private void CheckPBox()
        {

            if ((inters(temp.p, Col1)) && (k1.Count != 0 && k1.Peek().number < temp.number || k1.Count == 0)) 
            {
                if(k2.Count != 0 && k2.Peek() == temp)// Если это кольцо из второго стержня
                {
                    k2.Pop(); // убираем это кольцо из второго стержня
                    if(k2.Count !=0)
                    {
                        k2.Peek().top = true;//Если на втором стержне остались кольца, отмечаем самую верхнюю                     
                    }
                }
                if (k3.Count != 0 && k3.Peek() == temp)
                {
                    k3.Pop(); 
                    if (k3.Count != 0)
                    {
                        k3.Peek().top = true;
                    }
                }
                if(k1.Count!=0)
                {
                    k1.Peek().top = false;
                }
                temp.top = true;
                temp.p.Location = new Point(Col1.Width + Col1.Location.X - temp.p.Width / 2, Convert.ToInt32(434 - (k1.Count + 1) * high - (k1.Count * 6)));
                k1.Push(temp);
                temp = null;
                drag = false;
                count++;
                countLabel.Text = "Количество ходов " + count;
                return;
            }
            if ((inters(temp.p, Col2)) && (k2.Count != 0 && k2.Peek().number < temp.number || k2.Count == 0))
            {
                if (k1.Count != 0 && k1.Peek() == temp)
                {
                    k1.Pop(); 
                    if (k1.Count != 0)
                    {
                        k1.Peek().top = true;
                    }
                }
                if (k3.Count != 0 && k3.Peek() == temp)
                {
                    k3.Pop();
                    if (k3.Count != 0)
                    {
                        k3.Peek().top = true;
                    }
                }
                if (k2.Count != 0)
                {
                    k2.Peek().top = false;
                }
                temp.top = true;
                temp.p.Location = new Point((Col2.Width + Col2.Location.X - Convert.ToInt32(temp.p.Width / 2)), Convert.ToInt32(434 - (k2.Count + 1) * high - (k2.Count * 6)));
                k2.Push(temp);
                temp = null;
                drag = false;
                count++;
                countLabel.Text = "Количество ходов " + count;
                return;
            }
            if ((inters(temp.p, Col3)) && (k3.Count != 0 && k3.Peek().number < temp.number || k3.Count == 0))
            {
                if (k1.Count != 0 && k1.Peek() == temp)
                {
                    k1.Pop();
                    if (k1.Count != 0)
                    {
                        k1.Peek().top = true;
                    }
                }
                if (k2.Count != 0 && k2.Peek() == temp)
                {
                    k2.Pop();
                    if (k2.Count != 0)
                    {
                        k2.Peek().top = true;
                    }
                }
                if (k3.Count != 0)
                {
                    k3.Peek().top = false;
                }
                temp.top = true;
                temp.p.Location = new Point(Col3.Width + Col3.Location.X - temp.p.Width / 2, Convert.ToInt32(434 - (k3.Count + 1) * high - (k3.Count * 6)));
                k3.Push(temp);
                temp = null;
                drag = false;
                count++;
                countLabel.Text = "Количество ходов " + count;
                return;
            }
            else
            {
                if (k1.Count != 0 && k1.Peek() == temp)
                {
                    temp.p.Location = new Point(Col1.Width + Col1.Location.X - temp.p.Width / 2, Convert.ToInt32(434 - (k1.Count) * high - ((k1.Count-1) * 6)));
                    temp = null;
                    drag = false;
                    return;
                }
                if (k2.Count != 0 && k2.Peek() == temp)
                {
                    temp.p.Location = new Point(Col2.Width + Col2.Location.X - temp.p.Width / 2, Convert.ToInt32(434 - (k2.Count) * high - ((k2.Count-1) * 6)));
                    temp = null;
                    drag = false;
                    return;
                }
                if (k3.Count != 0 && k3.Peek() == temp)
                {
                    temp.p.Location = new Point(Col3.Width + Col3.Location.X - temp.p.Width / 2, Convert.ToInt32(434 - (k3.Count) * high - ((k3.Count-1) * 6)));
                    temp = null;
                    drag = false;
                    return;
                }
            }
            temp = null;
            drag = false;            
        }
        private void CheckWin()
        {
            if (k2.Count == kol || k3.Count == kol)
            {
                MessageBox.Show("You win! Количество шагов: "+ count);
                if (k2.Count == kol)
                    k2.Peek().p.Enabled = false;
                if (k3.Count == kol)
                    k3.Peek().p.Enabled = false;         
            }
        }
        private void Start()
        {
            while (k1.Count != 0)
            { k1.Pop(); }
            while (k2.Count != 0)
            { k2.Pop(); }
            while (k3.Count != 0) //очищает стеки
            { k3.Pop(); }
            count = 0;
            countLabel.Text = "Количество ходов " + count;
            temp = null;
            drag = false;
            if (comboBox1.Text != "")
                kol = Convert.ToInt32(comboBox1.Text);
            textBox1.Text = "";
            rectangleSize(kol);
            deletePBoxes(kol);
            changeSizes(kol);
        }

        private void началоToolStripMenuItem_Click(object sender, EventArgs e)//кнопка "Начало" в меню
        {
            Start();
        }
        //pictureBox2 - самое большое кольцо
        // ...
        //pictureBox9 - самое маленькое кольцо (если колец 8шт)
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (k1.Count != 0 && k1.Peek().p == pictureBox2) 
            {
                drag = true;
                temp = k1.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k2.Count != 0 && k2.Peek().p == pictureBox2)
            {
                drag = true;
                temp = k2.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k3.Count != 0 && k3.Peek().p == pictureBox2)
            {
                drag = true;
                temp = k3.Peek();
                dx = e.X;
                dy = e.Y;
            }
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                CheckPBox();
                CheckWin();
            }
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                temp.p.Location = new Point(temp.p.Location.X + e.X - dx, temp.p.Location.Y + e.Y - dy);
            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (k1.Count != 0 && k1.Peek().p == pictureBox3)
            {
                drag = true;
                temp = k1.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k2.Count != 0 && k2.Peek().p == pictureBox3)
            {
                drag = true;
                temp = k2.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k3.Count != 0 && k3.Peek().p == pictureBox3)
            {
                drag = true;
                temp = k3.Peek();
                dx = e.X;
                dy = e.Y;
            }
        }
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                CheckPBox();
                CheckWin();
            }
        }
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                temp.p.Location = new Point(temp.p.Location.X + e.X - dx, temp.p.Location.Y + e.Y - dy);
            }
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            if (k1.Count != 0 && k1.Peek().p == pictureBox4)
            {
                drag = true;
                temp = k1.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k2.Count != 0 && k2.Peek().p == pictureBox4)
            {
                drag = true;
                temp = k2.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k3.Count != 0 && k3.Peek().p == pictureBox4)
            {
                drag = true;
                temp = k3.Peek();
                dx = e.X;
                dy = e.Y;
            }
        }
        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                CheckPBox();
                CheckWin();
            }
        }
        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                temp.p.Location = new Point(temp.p.Location.X+e.X-dx, temp.p.Location.Y + e.Y-dy);                
            }                        
        }
        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            if (k1.Count != 0 && k1.Peek().p == pictureBox5)
            {
                drag = true;
                temp = k1.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k2.Count != 0 && k2.Peek().p == pictureBox5)
            {
                drag = true;
                temp = k2.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k3.Count != 0 && k3.Peek().p == pictureBox5)
            {
                drag = true;
                temp = k3.Peek();
                dx = e.X;
                dy = e.Y;
            }
        }
        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                CheckPBox();
                CheckWin();
            }
        }
        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                temp.p.Location = new Point(temp.p.Location.X + e.X - dx, temp.p.Location.Y + e.Y - dy);
            }
        }
        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            if (k1.Count != 0 && k1.Peek().p == pictureBox6)
            {
                drag = true;
                temp = k1.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k2.Count != 0 && k2.Peek().p == pictureBox6)
            {
                drag = true;
                temp = k2.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k3.Count != 0 && k3.Peek().p == pictureBox6)
            {
                drag = true;
                temp = k3.Peek();
                dx = e.X;
                dy = e.Y;
            }
        }
        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                CheckPBox();
                CheckWin();
            }
        }
        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                temp.p.Location = new Point(temp.p.Location.X + e.X - dx, temp.p.Location.Y + e.Y - dy);
            }
        }

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            if (k1.Count != 0 && k1.Peek().p == pictureBox7)
            {
                drag = true;
                temp = k1.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k2.Count != 0 && k2.Peek().p == pictureBox7)
            {
                drag = true;
                temp = k2.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k3.Count != 0 && k3.Peek().p == pictureBox7)
            {
                drag = true;
                temp = k3.Peek();
                dx = e.X;
                dy = e.Y;
            }
        }
        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                CheckPBox();
                CheckWin();
            }
        }
        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                temp.p.Location = new Point(temp.p.Location.X + e.X - dx, temp.p.Location.Y + e.Y - dy);
            }
        }

        private void pictureBox8_MouseDown(object sender, MouseEventArgs e)
        {
            if (k1.Count != 0 && k1.Peek().p == pictureBox8)
            {
                drag = true;
                temp = k1.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k2.Count != 0 && k2.Peek().p == pictureBox8)
            {
                drag = true;
                temp = k2.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k3.Count != 0 && k3.Peek().p == pictureBox8)
            {
                drag = true;
                temp = k3.Peek();
                dx = e.X;
                dy = e.Y;
            }
        }
        private void pictureBox8_MouseUp(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                CheckPBox();
                CheckWin();
            }
        }
        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                temp.p.Location = new Point(temp.p.Location.X + e.X - dx, temp.p.Location.Y + e.Y - dy);
            }
        }

        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            if (k1.Count != 0 && k1.Peek().p == pictureBox9)
            {
                drag = true;
                temp = k1.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k2.Count != 0 && k2.Peek().p == pictureBox9)
            {
                drag = true;
                temp = k2.Peek();
                dx = e.X;
                dy = e.Y;
            }
            if (k3.Count != 0 && k3.Peek().p == pictureBox9)
            {
                drag = true;
                temp = k3.Peek();
                dx = e.X;
                dy = e.Y;
            }
        }
        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                CheckPBox();
                CheckWin();
            }
        }
        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                temp.p.Location = new Point(temp.p.Location.X + e.X - dx, temp.p.Location.Y + e.Y - dy);
            }
        }
        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Даны три стержня, на одном из которых находятся от трех до восьми колец, причем кольца отличаются размером и лежат меньшее на большем. Задача состоит в том, чтобы перенести пирамиду из колец за наименьшее число ходов на другой стержень. За один раз разрешается переносить только одно кольцо, причём нельзя класть большее кольцо на меньшее.");
        }
        //кнопка "Начать заново"
        private void button1_Click(object sender, EventArgs e)
        {
            Start();
        }
        //кнопка "Написать алгоритм"
        private void button2_Click(object sender, EventArgs e)
        {
            Start();
            m = Convert.ToInt32(Math.Pow(Convert.ToDouble(2), Convert.ToDouble(kol))) - 1;//количество строк
            char a = '1';
            char b = '2';
            char c = '3';
            SolutionHanoibns(kol, a, b, c);
        }
        //кнопка "Шаг вперед"
        private void button3_Click(object sender, EventArgs e)
        {                       
            if(count<m&&textBox1.Text != "")
            {
                string s = textBox1.Text;
                string f = s.Substring(19 + 25 * count, 1);
                string g = s.Substring(23 + 25 * count, 1);
                if(Convert.ToInt32(f)==1)
                {
                    switch(Convert.ToInt32(g))
                    {
                        case 2:
                            {
                                movePBox(k1.Peek(), 2);
                                CheckPBox();
                                break;
                            }
                        case 3:
                            {
                                movePBox(k1.Peek(), 3);
                                CheckPBox();
                                break;
                            }
                    }
                }
                if (Convert.ToInt32(f) == 2)
                {
                    switch (Convert.ToInt32(g))
                    {
                        case 1:
                            {
                                movePBox(k2.Peek(), 1);
                                CheckPBox();
                                break;
                            }
                        case 3:
                            {
                                movePBox(k2.Peek(), 3);
                                CheckPBox();
                                break;
                            }
                    }
                }
                if (Convert.ToInt32(f) == 3)
                {
                    switch (Convert.ToInt32(g))
                    {
                        case 1:
                            {
                                movePBox(k3.Peek(), 1);
                                CheckPBox();
                                break;
                            }
                        case 2:
                            {
                                movePBox(k3.Peek(), 2);
                                CheckPBox();
                                break;
                            }
                    }
                }
                
            }
            
        }
        //Кнопка "Выполнить алгоритм"
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (timer1.Enabled)
                    timer1.Enabled = false;
                else
                    timer1.Enabled = true;
            }
        }
        //таймер для автоматической сборки
        private void timer1_Tick(object sender, EventArgs e)
        {
            button3_Click(sender,e);
        }
        //информация о кнопке
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(button4, "Выполнить алгоритм");
        }
        //информация о кнопке
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(button3, "Следующий шаг");
        }
    }
}
