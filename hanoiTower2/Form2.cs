using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hanoiTower2
{
    public partial class Form2 : Form
    {

        Timer timer1;
        Graphics graphics;
        Bitmap bitmap;
        Pen pen;
        int[,] box;
        bool isSet = false;
        int[,] box2;
        char[,] move;
        SolidBrush solid;
        int x1, x2, x3;
        int n, m = 0, p = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1 = new Timer();
            timer1.Interval = 300;
          timer1.Tick += new EventHandler(timer1_Tick);

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            graphics = Graphics.FromImage(bitmap);

            pen = new Pen(Color.White, 3);
            button1.Visible = false;
            button4.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;

        }

        private void StartButton_Click(object sender, EventArgs e)     //set
        {
            button1.Visible = true;
            button4.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;

            graphics.DrawLine(pen, 60, 350, 200, 350);
            graphics.DrawLine(pen, 250, 350, 390, 350);
            graphics.DrawLine(pen, 440, 350, 580, 350);
            graphics.DrawLine(pen, 130, 350, 130, 150);
            graphics.DrawLine(pen, 320, 350, 320, 150);
            graphics.DrawLine(pen, 510, 350, 510, 150);

            int z = 0;
        

            n = Convert.ToInt32( numericUpDown1.Value);
            box = new int[3, n];
            box2 = new int[3, n];
            move = new char[2, 1000];
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (z <= n)
                    {
                        box[i, j] = n - z;
                        z++;
                    }

                }
                if (z > n)
                {
                    break;
                }
            }
            for (int i = 0; i < n; i++)
                box2[0, i] = n - i;

            hanoi(n, 'A', 'B', 'C');

            x1 = -1;
            x2 = -1;
            x3 = -1;

            for (; ; )
            {
                if(isEqual(box,box2))
                {
                  
                    break;
                }

                for (int i = 0; i < n; i++)
                {
                    if (box2[0, i] == 0)
                    {
                        x1 = i;
                        break;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (box2[1, i] == 0)
                    {
                        x2 = i;
                        break;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (box2[2, i] == 0)
                    {
                        x3 = i;
                        break;
                    }
                }

                if (x1 == -1)
                    x1 = n;
                if (x2 == -1)
                    x2 = n;
                if (x3 == -1)
                    x3 = n;

                switch (move[0, p])
                {

                    case 'A':
                        switch (move[1, p])
                        {
                            case 'B':
                                box2[1, x2] = box2[0, x1 - 1];
                                box2[0, x1 - 1] = 0;
                                break;
                            case 'C':
                                box2[2, x3] = box2[0, x1 - 1];
                                box2[0, x1 - 1] = 0;
                                break;
                        }
                        break;

                    case 'B':
                        switch (move[1, p])
                        {
                            case 'A':
                                box2[0, x1] = box2[1, x2 - 1];
                                box2[1, x2 - 1] = 0;
                                break;
                            case 'C':
                                box2[2, x3] = box2[1, x2 - 1];
                                box2[1, x2 - 1] = 0;
                                break;
                        }
                        break;

                    case 'C':

                        switch (move[1, p])
                        {
                            case 'A':
                                box2[0, x1] = box2[2, x3 - 1];
                                box2[2, x3 - 1] = 0;
                                break;
                            case 'B':
                                box2[1, x2] = box2[2, x3 - 1];
                                box2[2, x3 - 1] = 0;
                                break;
                        }
                        break;

                }
                p++;
            }
           
            draw_();
            refr();
            StartButton.Visible = false;
            numericUpDown1.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)   //start
        {
            timer1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)  //exit
        {
            Form1 form1 = new Form1();
            form1.Visible = true;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)   //stop
        {
            timer1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)   //manual move
        {
            graphics.Clear(Color.Black);

            x1 = -1;
            x2 = -1;
            x3 = -1;

            graphics.DrawLine(pen, 60, 350, 200, 350);
            graphics.DrawLine(pen, 250, 350, 390, 350);
            graphics.DrawLine(pen, 440, 350, 580, 350);
            graphics.DrawLine(pen, 130, 350, 130, 150);
            graphics.DrawLine(pen, 320, 350, 320, 150);
            graphics.DrawLine(pen, 510, 350, 510, 150);


            for (int i = 0; i < n; i++)
            {
                if (box2[0, i] == 0)
                {
                    x1 = i;
                    break;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (box2[1, i] == 0)
                {
                    x2 = i;
                    break;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (box2[2, i] == 0)
                {
                    x3 = i;
                    break;
                }
            }

            if (x1 == -1)
                x1 = n;
            if (x2 == -1)
                x2 = n;
            if (x3 == -1)
                x3 = n;

            switch (move[0, p])
            {
                case 'A':
                    switch (move[1, p])
                    {
                        case 'B':
                            box2[1, x2] = box2[0, x1 - 1];
                            box2[0, x1 - 1] = 0;
                            break;
                        case 'C':
                            box2[2, x3] = box2[0, x1 - 1];
                            box2[0, x1 - 1] = 0;
                            break;
                    }
                    break;

                case 'B':
                    switch (move[1, p])
                    {
                        case 'A':
                            box2[0, x1] = box2[1, x2 - 1];
                            box2[1, x2 - 1] = 0;
                            break;
                        case 'C':
                            box2[2, x3] = box2[1, x2 - 1];
                            box2[1, x2 - 1] = 0;
                            break;
                    }
                    break;

                case 'C':

                    switch (move[1, p])
                    {
                        case 'A':
                            box2[0, x1] = box2[2, x3 - 1];
                            box2[2, x3 - 1] = 0;
                            break;
                        case 'B':
                            box2[1, x2] = box2[2, x3 - 1];
                            box2[2, x3 - 1] = 0;
                            break;
                    }
                    break;

            }
            draw_();
            refr();
            p++;
        }

        private void button3_Click(object sender, EventArgs e) //reset
        {
            graphics.Clear(Color.Black);
            graphics.DrawLine(pen, 60, 350, 200, 350);
            graphics.DrawLine(pen, 250, 350, 390, 350);
            graphics.DrawLine(pen, 440, 350, 580, 350);
            graphics.DrawLine(pen, 130, 350, 130, 150);
            graphics.DrawLine(pen, 320, 350, 320, 150);
            graphics.DrawLine(pen, 510, 350, 510, 150);
            p = 0;
            m = 0;
            x1 = -1; x2 = -1; x3 = -1 ;
            for (int i = 0; i < n; i++)
                box2[0, i] = n - i;

            for (int i = 0; i < n; i++)
                box2[1, i] =0;

            for (int i = 0; i < n; i++)
                box2[2, i] =0;

            for (; ; )
            {
                if (isEqual(box, box2))
                {

                    break;
                }

                for (int i = 0; i < n; i++)
                {
                    if (box2[0, i] == 0)
                    {
                        x1 = i;
                        break;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (box2[1, i] == 0)
                    {
                        x2 = i;
                        break;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (box2[2, i] == 0)
                    {
                        x3 = i;
                        break;
                    }
                }

                if (x1 == -1)
                    x1 = n;
                if (x2 == -1)
                    x2 = n;
                if (x3 == -1)
                    x3 = n;

                switch (move[0, p])
                {

                    case 'A':
                        switch (move[1, p])
                        {
                            case 'B':
                                box2[1, x2] = box2[0, x1 - 1];
                                box2[0, x1 - 1] = 0;
                                break;
                            case 'C':
                                box2[2, x3] = box2[0, x1 - 1];
                                box2[0, x1 - 1] = 0;
                                break;
                        }
                        break;

                    case 'B':
                        switch (move[1, p])
                        {
                            case 'A':
                                box2[0, x1] = box2[1, x2 - 1];
                                box2[1, x2 - 1] = 0;
                                break;
                            case 'C':
                                box2[2, x3] = box2[1, x2 - 1];
                                box2[1, x2 - 1] = 0;
                                break;
                        }
                        break;

                    case 'C':

                        switch (move[1, p])
                        {
                            case 'A':
                                box2[0, x1] = box2[2, x3 - 1];
                                box2[2, x3 - 1] = 0;
                                break;
                            case 'B':
                                box2[1, x2] = box2[2, x3 - 1];
                                box2[2, x3 - 1] = 0;
                                break;
                        }
                        break;

                }
                p++;
            }
            
            draw_();
            refr();
            timer1.Stop();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if(p==999)
            {
                timer1.Enabled = false;
            }
            graphics.Clear(Color.Black);

            x1 = -1;
            x2 = -1;
            x3 = -1;

            graphics.DrawLine(pen, 60, 350, 200, 350);
            graphics.DrawLine(pen, 250, 350, 390, 350);
            graphics.DrawLine(pen, 440, 350, 580, 350);
            graphics.DrawLine(pen, 130, 350, 130, 150);
            graphics.DrawLine(pen, 320, 350, 320, 150);
            graphics.DrawLine(pen, 510, 350, 510, 150);


            for (int i = 0; i < n; i++)
            {
                if (box2[0, i] == 0)
                {
                    x1 = i;
                    break;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (box2[1, i] == 0)
                {
                    x2 = i;
                    break;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (box2[2, i] == 0)
                {
                    x3 = i;
                    break;
                }
            }

            if (x1 == -1)
                x1 = n;
            if (x2 == -1)
                x2 = n;
            if (x3 == -1)
                x3 = n;

            switch (move[0, p])
            {
                case 'A':
                    switch (move[1, p])
                    {
                        case 'B':
                            box2[1, x2] = box2[0, x1 - 1];
                            box2[0, x1 - 1] = 0;
                            break;
                        case 'C':
                            box2[2, x3] = box2[0, x1 - 1];
                            box2[0, x1 - 1] = 0;
                            break;
                    }
                    break;

                case 'B':
                    switch (move[1, p])
                    {
                        case 'A':
                            box2[0, x1] = box2[1, x2 - 1];
                            box2[1, x2 - 1] = 0;
                            break;
                        case 'C':
                            box2[2, x3] = box2[1, x2 - 1];
                            box2[1, x2 - 1] = 0;
                            break;
                    }
                    break;

                case 'C':

                    switch (move[1, p])
                    {
                        case 'A':
                            box2[0, x1] = box2[2, x3 - 1];
                            box2[2, x3 - 1] = 0;
                            break;
                        case 'B':
                            box2[1, x2] = box2[2, x3 - 1];
                            box2[2, x3 - 1] = 0;
                            break;
                    }
                    break;

            }
            draw_();
            refr();
            p++;
        }
        private void hanoi(int h, char s, char i, char d)
        {
            if (h == 1)
            {

                move[0, m] = s;
                move[1, m] = d;
                m++;
            }
            else
            {
                hanoi(h - 1, s, d, i);
                hanoi(1, s, i, d);
                hanoi(h - 1, i, s, d);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Interval+=100;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(timer1.Interval>100)
            timer1.Interval -= 100;
            else
            {
                if (timer1.Interval > 20)
                    timer1.Interval -=20;
                else
                {
                    timer1.Interval = 1;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);
            while (true)
            {
                if (p == 999)
                    break;

                x1 = -1;
                x2 = -1;
                x3 = -1;

                graphics.DrawLine(pen, 60, 350, 200, 350);
                graphics.DrawLine(pen, 250, 350, 390, 350);
                graphics.DrawLine(pen, 440, 350, 580, 350);
                graphics.DrawLine(pen, 130, 350, 130, 150);
                graphics.DrawLine(pen, 320, 350, 320, 150);
                graphics.DrawLine(pen, 510, 350, 510, 150);


                for (int i = 0; i < n; i++)
                {
                    if (box2[0, i] == 0)
                    {
                        x1 = i;
                        break;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (box2[1, i] == 0)
                    {
                        x2 = i;
                        break;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (box2[2, i] == 0)
                    {
                        x3 = i;
                        break;
                    }
                }

                if (x1 == -1)
                    x1 = n;
                if (x2 == -1)
                    x2 = n;
                if (x3 == -1)
                    x3 = n;

                switch (move[0, p])
                {
                    case 'A':
                        switch (move[1, p])
                        {
                            case 'B':
                                box2[1, x2] = box2[0, x1 - 1];
                                box2[0, x1 - 1] = 0;
                                break;
                            case 'C':
                                box2[2, x3] = box2[0, x1 - 1];
                                box2[0, x1 - 1] = 0;
                                break;
                        }
                        break;

                    case 'B':
                        switch (move[1, p])
                        {
                            case 'A':
                                box2[0, x1] = box2[1, x2 - 1];
                                box2[1, x2 - 1] = 0;
                                break;
                            case 'C':
                                box2[2, x3] = box2[1, x2 - 1];
                                box2[1, x2 - 1] = 0;
                                break;
                        }
                        break;

                    case 'C':

                        switch (move[1, p])
                        {
                            case 'A':
                                box2[0, x1] = box2[2, x3 - 1];
                                box2[2, x3 - 1] = 0;
                                break;
                            case 'B':
                                box2[1, x2] = box2[2, x3 - 1];
                                box2[2, x3 - 1] = 0;
                                break;
                        }
                        break;

                }

                p++;

            }
            draw_();
            refr();

        }

        private int pow(int a, int b)
        {
            if (b != 0)
                return a * pow(a, b - 1);
            else
                return 1;
        }
        private void draw_()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < n; j++)
                {
                    if (box2[i, j] != 0)
                    {
                        switch (box2[i, j])
                        {
                            case 1: solid = new SolidBrush(Color.IndianRed); break;
                            case 2: solid = new SolidBrush(Color.Thistle); break;
                            case 3: solid = new SolidBrush(Color.Khaki); break;
                            case 4: solid = new SolidBrush(Color.DarkSeaGreen); break;
                            case 5: solid = new SolidBrush(Color.CadetBlue); break;
                            case 6: solid = new SolidBrush(Color.RosyBrown); break;
                            case 7: solid = new SolidBrush(Color.DarkSlateBlue); break;
                            case 8: solid = new SolidBrush(Color.LightGreen); break;
                            case 9: solid = new SolidBrush(Color.MediumPurple); break;

                        }
                        graphics.FillRectangle(solid, (i + 1) * 190 - 60 - (box2[i, j]) * 10, 320 - j * 30, box2[i, j] * 20, 30);
                    }

                }
        }
        private void refr()
        {
            pictureBox1.Image = bitmap;
        }
        private bool isEqual(int[,] box1, int[,] box2 )
        {
            for(int i=0;i<3;i++)
                for (int j = 0; j < n; j++)
                {
                    if (box1[i, j] != box2[i, j])
                        return false;
                }
            return true;
        }
    }
}
