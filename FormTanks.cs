using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Tanks
{
    public partial class Tanks : Form
    {
        public static Size window;      //размер окна
        public const byte shadow = 8;   //размер тени
        public Point cursor;

        private Graphics g;
        private Game game;

        /// <summary>
        /// Окно формы игры
        /// </summary>
        public Tanks()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint   |
                    ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        //Запуск содержимого окна
        private void Tanks_Load(object sender, EventArgs e)
        {
            window = ClientSize;
            game = new Game();
        }

        //Запуск таймера
        private void Tanks_Click(object sender, EventArgs e)
        {
            Console.Beep(5000, 50);
            timer.Enabled = !timer.Enabled;
            //game.SelectUnit(cursor); //************** П Р О Б Н О *************
        }

        //Таймер обновления кадра
        private void timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        //Смена оконного режима
        private void Tanks_DoubleClick(object sender, EventArgs e)
        {
            if (FormBorderStyle == FormBorderStyle.None)
                FormBorderStyle = FormBorderStyle.Sizable;
            else
                FormBorderStyle = FormBorderStyle.None;
        }

        //Отрисовка кадра
        private void Tanks_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            cursor = PointToClient(Cursor.Position);
            game.StepGame(g);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game = new Game();
            Refresh();
        }
    }
}