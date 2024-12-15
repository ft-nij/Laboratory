using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditor
{
    public partial class Form1 : Form
    {
        public System.Drawing.Drawing2D.SmoothingMode SmoothingMode { get; set; }
        Graphics g;
        Bitmap _buffer;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        [Serializable]
        public class Point
        {
            public int x1;
            public int y1;
            public int z1;
        }

        [Serializable]
        public class Figure
        {
            public List<Point> points = new List<Point>();
            public bool selected = false;
            public bool trimetric = false;
        }

        public double[,] GetRotateXMatrix(double a)
        {
            double[,] rotatex = new double[,] {
        {1,0,0,0 },
        { 0,Math.Cos(a),Math.Sin(a),0 },
        { 0,-Math.Sin(a),Math.Cos(a),0},
        { 0,0,0,1}
        };
            return rotatex;
        }

        public double[,] GetRotateYMatrix(double a)
        {
            double[,] rotatey = new double[,] {
        {Math.Cos(a),0,-Math.Sin(a),0 },
        { 0,1,0,0 },
        { Math.Sin(a),0,Math.Cos(a),0},
        { 0,0,0,1}
        };
            return rotatey;
        }

        public double[,] GetRotateZMatrix(double a)
        {
            double[,] rotatez = new double[,] {
        {Math.Cos(a),Math.Sin(a),0,0},
        { -Math.Sin(a),Math.Cos(a),0,0 },
        { 0,0,1,0},
        { 0,0,0,1}
        };
            return rotatez;
        }

        public double[,] GetTransformatrix(int m, int n, int l)
        {
            double[,] rotatez = new double[,] {
            {1,0,0,0},
            { 0,1,0,0 },
            { 0,0,1,0},
            { m,n,l,1}
        };
            return rotatez;
        }

        public double[,] GetMirrorXMatrix()
        {
            double[,] rotatez = new double[,] {
            {-1,0,0,0},
            { 0,1,0,0 },
            { 0,0,1,0},
            { 0,0,0,1}
        };
            return rotatez;
        }

        public double[,] GetMirrorYMatrix()
        {
            double[,] rotatez = new double[,] {
            {1,0,0,0},
            { 0,-1,0,0 },
            { 0,0,1,0},
            { 0,0,0,1}
        };
            return rotatez;
        }

        public double[,] GetMirrorZMatrix()
        {
            double[,] rotatez = new double[,] {
            {1,0,0,0},
            { 0,1,0,0 },
            { 0,0,-1,0},
            { 0,0,0,1}
        };
            return rotatez;
        }

        public double[,] GetScaleMatrix(double a, double b, double c)
        {
            double[,] rotatez = new double[,] {
            {a,0,0,0},
            { 0,b,0,0 },
            { 0,0,c,0},
            { 0,0,0,1}
        };
            return rotatez;
        }

        public double[,] getMatrix(Figure f)
        {
            var matrix = new double[f.points.Count, 4];
            for (int i = 0; i < f.points.Count; i++)
            {
                matrix[i, 0] = f.points[i].x1;
                matrix[i, 1] = f.points[i].y1;
                matrix[i, 2] = f.points[i].z1;
                matrix[i, 3] = 1;
            }
            return matrix;
        }

        public Figure matrixToPoint(double[,] matrix)
        {
            var p = new Figure();
            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                p.points.Add(new Point());
                if(matrix[i,3]!=1)
                {
                    matrix[i, 0] = matrix[i, 0] / matrix[i, 3];
                    matrix[i, 1] = matrix[i, 1] / matrix[i, 3];
                    matrix[i, 2] = matrix[i, 2] / matrix[i, 3];
                    matrix[i, 3] = matrix[i, 3] / matrix[i, 3];
                    p.points[i].x1 = Convert.ToInt32(matrix[i, 0]);
                    p.points[i].y1 = Convert.ToInt32(matrix[i, 1]);
                    p.points[i].z1 = Convert.ToInt32(matrix[i, 2]);
                }
                else
                {
                    p.points[i].x1 = Convert.ToInt32(matrix[i, 0]);
                    p.points[i].y1 = Convert.ToInt32(matrix[i, 1]);
                    p.points[i].z1 = Convert.ToInt32(matrix[i, 2]);
                }
          
            }
            return p;
        }

     
        public double[,] MatrixMultiplication(double[,] matrixA, double[,] matrixB)
        {
            if (matrixA.GetUpperBound(1) + 1 != matrixB.GetUpperBound(0) + 1)
            {
                throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }

            var matrixC = new double[matrixA.GetUpperBound(0) + 1, matrixB.GetUpperBound(1) + 1];

            for (var i = 0; i < matrixA.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < matrixB.GetUpperBound(1) + 1; j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.GetUpperBound(1) + 1; k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }

        List<Figure> selected = new List<Figure>();
        List<Figure> figures = new List<Figure>();
        List<Figure> trimetricMatrix = new List<Figure>();
        Point[] selection = new Point[2];
        Point[] transform = new Point[2];
        bool mdown = false;
        String mode;
        bool point_focused;
        bool figure_focused;
        int catch_point_index;
        int catch_figure_index;
        int counter = -1;
        int trackbarLastValue = 0;
        int trackbarLastValueZ = 0;
        int trackbarLastValueY = 0;
        int trackbarLastValueX = 0;
        
        public Form1()
        {
            InitializeComponent();
            label7.Hide();
            label8.Hide();
            point_focused = false;
            figure_focused = false;
            catch_point_index = -1;
            counter = -1;
            catch_figure_index = -1;
            HideAllButtons();
                    typeof(Panel).InvokeMember("DoubleBuffered",
                     BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                     null, panel1, new object[] { true });
            this.MouseWheel += new MouseEventHandler(this_MouseWheel);
            button_SetCoord.Enabled = false;
            saveFileDialog.Filter = "Binary files(*.bin)|*.bin|All files(*.*)|*.*";
            openFileDialog.Filter = "Binary files(*.bin)|*.bin|All files(*.*)|*.*";
            mode = "Selection";

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            HideAllButtons();
            mode = "Add Figure";
            figures.Add(new Figure());
            counter++;
            StopDrawing.Show();
            label8.Text = mode;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void StopDrawing_Click(object sender, EventArgs e)
        {
            HideAllButtons();
            buttonAdd.Show();
            buttonDelete.Show();
            buttonEdit.Show();
            buttonTransform2d.Show();
            RefreshCoord();
            mode = "Selection";
            label8.Text = mode;

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            mode = "Edit Points";
            HideAllButtons();
            label8.Text = mode;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mdown)
            {
                if (mode == "Add Figure")
                {
                    figures[counter].points[figures[counter].points.Count - 1].x1 = e.X;
                    figures[counter].points[figures[counter].points.Count - 1].y1 = e.Y;
                }
                if (point_focused == true && mode == "Edit Points")
                {
                    figures[catch_figure_index].points[catch_point_index].x1 = e.X;
                    figures[catch_figure_index].points[catch_point_index].y1 = e.Y;
                }
                if (mode == "Transform")
                {
                    Point p = new Point();
                    p.x1 = e.X;
                    p.y1 = e.Y;
                    transform[1] = p;

                    int movex = transform[0].x1 - transform[1].x1;
                    int movey = transform[0].y1 - transform[1].y1;
                    for (int i = 0; i < figures.Count; i++)
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {
                            if (figures[i].selected)
                            {
                                figures[i].points[j].x1 -= movex;
                                figures[i].points[j].y1 -= movey;
                                Point p2 = new Point();
                                p2.x1 = e.X;
                                p2.y1 = e.Y;
                                transform[0] = p2;
                            }
                        }
                }
            }
            else
                if (mode == "Edit Points")
            {
                point_focused = false;
                catch_point_index = -1;
                catch_figure_index = -1;

                for (int i = 0; i < figures.Count; i++)
                {

                    for (int j = 0; j < figures[i].points.Count; j++)
                    {

                        if (Math.Abs(figures[i].points[j].x1 - e.X) < 5 && Math.Abs(figures[i].points[j].y1 - e.Y) < 5)
                        {
                            point_focused = true;
                            catch_point_index = j;
                            catch_figure_index = i;
                            break;
                        }
                    }
                }
            }
            panel1.Invalidate();
        }


        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mdown = false;
            if (mode == "Add Figure")
            {
                figures[counter].points[figures[counter].points.Count - 1].x1 = e.X;
                figures[counter].points[figures[counter].points.Count - 1].y1 = e.Y;
            }
            if (point_focused == true && mode == "Edit Points")
            {
                figures[catch_figure_index].points[catch_point_index].x1 = e.X;
                figures[catch_figure_index].points[catch_point_index].y1 = e.Y;
            }
            if (mode == "Selection")
            {
                if (selection[0] != null)
                {
                    Point p = new Point();
                    p.x1 = e.X;
                    p.y1 = e.Y;
                    selection[1] = p;
                    int maxX, maxY, minX, minY;
                    if (selection[1].x1 > selection[0].x1)
                    {
                        maxX = selection[1].x1;
                        minX = selection[0].x1;
                    }
                    else
                    {
                        maxX = selection[0].x1;
                        minX = selection[1].x1;
                    }
                    if (selection[1].y1 > selection[0].y1)
                    {
                        maxY = selection[1].y1;
                        minY = selection[0].y1;
                    }
                    else
                    {
                        maxY = selection[0].y1;
                        minY = selection[1].y1;
                    }
                    for (int i = 0; i < figures.Count; i++)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            if (figures[i].points[j].x1 < maxX && figures[i].points[j].x1 > minX && figures[i].points[j].y1 < maxY && figures[i].points[j].y1 > minY)
                            {
                                figures[i].selected = true;
                            }
                            else
                                figures[i].selected = false;
                        }
                    }
                    RefreshCoord();
                }
            }
            if (mode == "Transform")
            {
                Point p = new Point();
                p.x1 = e.X;
                p.y1 = e.Y;
                transform[1] = p;
                int movex = transform[0].x1 - transform[1].x1;
                int movey = transform[0].y1 - transform[1].y1;
                for (int i = 0; i < figures.Count; i++)
                    for (int j = 0; j < figures[i].points.Count; j++)
                    {
                        if (figures[i].selected)
                        {
                            figures[i].points[j].x1 -= movex;
                            figures[i].points[j].y1 -= movey;
                        }
                    }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mdown = true;
            if (mode == "Add Figure")
            {
                Point p = new Point();
                figures[counter].points.Add(p);
                figures[counter].points[figures[counter].points.Count - 1].x1 = e.X;
                figures[counter].points[figures[counter].points.Count - 1].y1 = e.Y;
            }
            if (point_focused == true && mode == "Edit Points")
            {
                figures[catch_figure_index].points[catch_point_index].x1 = e.X;
                figures[catch_figure_index].points[catch_point_index].y1 = e.Y;
            }
            if (mode == "Selection")
            {
                Point p = new Point();
                p.x1 = e.X;
                p.y1 = e.Y;
                selection[0] = p;
            }
            if (mode == "Transform")
            {

                Point p = new Point();
                p.x1 = e.X;
                p.y1 = e.Y;
                transform[0] = p;

            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            RefreshCoord();
            
            for (int i = 0; i < figures.Count; i++)
                for (int j = 0;  j < figures[i].points.Count - 1; j++)
                {
                    if (figures[i].selected)
                        g.DrawLine(new Pen(Color.Red,2), figures[i].points[j].x1, figures[i].points[j].y1, figures[i].points[j + 1].x1, figures[i].points[j + 1].y1);
                    else
                        g.DrawLine(new Pen(Color.Black, 2), figures[i].points[j].x1, figures[i].points[j].y1, figures[i].points[j + 1].x1, figures[i].points[j + 1].y1);
                }
            for (int i = 0; i < figures.Count; i++)
                for (int j = 0; j < figures[i].points.Count; j++)
                {
                    g.DrawEllipse(new Pen(Color.Black, 2), figures[i].points[j].x1 - 3, figures[i].points[j].y1 - 3, 6, 6);
                    g.FillEllipse(Brushes.Black, new Rectangle(figures[i].points[j].x1 - 3, figures[i].points[j].y1 - 3, 6, 6));
                }
            if (point_focused)
            {
                g.DrawEllipse(new Pen(Color.Red, 2), figures[catch_figure_index].points[catch_point_index].x1 - 3, figures[catch_figure_index].points[catch_point_index].y1 - 3, 6, 6);
                g.FillEllipse(Brushes.Red, new Rectangle(figures[catch_figure_index].points[catch_point_index].x1 - 3, figures[catch_figure_index].points[catch_point_index].y1 - 3, 6, 6));
            }

        }

        private void buttonTransform_Click(object sender, EventArgs e)
        {
            HideAllButtons();
            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    count++;
            if (count != 0)
                mode = "Transform";
            else
            {
                MessageBox.Show("Выберите объект для выполнения операции!");
                mode = "Selection";
            }
            label8.Text = mode;
        }

        private void buttonMirror2d_Click(object sender, EventArgs e)
        {
            HideAllButtons();
            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    count++;
            if (count != 0)
            {
                mode = "Mirror2D";
                button_MirrorX2d.Show();
                button_MirrorY2d.Show();
            }
            else
            {
                MessageBox.Show("Выберите объект для выполнения операции!");
                mode = "Selection";
            }
            label8.Text = mode;

        }

        private void button_MirrorX2d_Click(object sender, EventArgs e)
        {
            if (mode == "Mirror2D")
            {
                int distToZero = 0;
                int count = 0;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {
                            distToZero += figures[i].points[j].x1;
                            count++;
                        }
                    }
                }
                distToZero = distToZero / count;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            figures[i].points[j].x1 = -figures[i].points[j].x1;
                            figures[i].points[j].x1 += distToZero * 2;
                        }
                    }
                }
            }
            panel1.Invalidate();
        }

        private void button_MirrorY2d_Click(object sender, EventArgs e)
        {


            if (mode == "Mirror2D")
            {
                int distToZero = 0;
                int count = 0;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            distToZero += figures[i].points[j].y1;
                            count++;
                        }
                    }
                }
                distToZero = distToZero / count;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            figures[i].points[j].y1 = -figures[i].points[j].y1;
                            figures[i].points[j].y1 += distToZero * 2;
                        }
                    }
                }
            }
            panel1.Invalidate();
        }


        private void button_Rotation2d_Click(object sender, EventArgs e)
        {
            HideAllButtons();
            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    count++;
            if (count != 0)
            {
                mode = "Rotation2D";
                label_Rotation2d.Text = "0°";
                trackBar1.Value = 0;
                label_Rotation2d.Show();
                trackBar1.Show();
                trackbarLastValue = 0;
            }
            else
            {
                MessageBox.Show("Выберите объект для выполнения операции!");
                mode = "Selection";
            }
            label8.Text = mode;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int countf = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    countf++;
            if (countf != 0)
            {

                label_Rotation2d.Text = (trackBar1.Value).ToString() + "°";
                if (mode == "Rotation2D")
                {
                    if (trackBar1.Value > trackbarLastValue)
                    {

                        int angle = 0;
                        angle = trackBar1.Value - trackbarLastValue;
                        trackbarLastValue = trackBar1.Value;
                        double d = angle * (Math.PI / 180);
                        int distToZeroX = 0;
                        int distToZeroY = 0;
                        int count = 0;
                        for (int i = 0; i < figures.Count; i++)
                        {
                            if (figures[i].selected)
                            {
                                for (int j = 0; j < figures[i].points.Count; j++)
                                {

                                    distToZeroX += figures[i].points[j].x1;
                                    distToZeroY += figures[i].points[j].y1;
                                    count++;
                                }
                            }
                        }
                        distToZeroX = distToZeroX / count;
                        distToZeroY = distToZeroY / count;
                        for (int i = 0; i < figures.Count; i++)
                            if (figures[i].selected)
                                for (int j = 0; j < figures[i].points.Count; j++)
                                {
                                    float x = (float)((figures[i].points[j].x1 - distToZeroX) * Math.Cos(d) - (figures[i].points[j].y1 - distToZeroY) * Math.Sin(d) + distToZeroX);
                                    float y = (float)((figures[i].points[j].x1 - distToZeroX) * Math.Sin(d) + (figures[i].points[j].y1 - distToZeroY) * Math.Cos(d) + distToZeroY);
                                    figures[i].points[j].x1 = Convert.ToInt32(x);
                                    figures[i].points[j].y1 = Convert.ToInt32(y);

                                }

                    }
                    else if (trackBar1.Value < trackbarLastValue)
                    {
                        int angle = 0;
                        angle = trackBar1.Value - trackbarLastValue;
                        trackbarLastValue = trackBar1.Value;
                        double d = angle * (Math.PI / 180);
                        int distToZeroX = 0;
                        int distToZeroY = 0;
                        int count = 0;
                        for (int i = 0; i < figures.Count; i++)
                        {
                            if (figures[i].selected)
                            {
                                for (int j = 0; j < figures[i].points.Count; j++)
                                {

                                    distToZeroX += figures[i].points[j].x1;
                                    distToZeroY += figures[i].points[j].y1;
                                    count++;
                                }
                            }
                        }
                        distToZeroX = distToZeroX / count;
                        distToZeroY = distToZeroY / count;
                        for (int i = 0; i < figures.Count; i++)
                            if (figures[i].selected)
                                for (int j = 0; j < figures[i].points.Count; j++)
                                {
                                    float x = (float)((figures[i].points[j].x1 - distToZeroX) * Math.Cos(d) - (figures[i].points[j].y1 - distToZeroY) * Math.Sin(d) + distToZeroX);
                                    float y = (float)((figures[i].points[j].x1 - distToZeroX) * Math.Sin(d) + (figures[i].points[j].y1 - distToZeroY) * Math.Cos(d) + distToZeroY);
                                    figures[i].points[j].x1 = Convert.ToInt32(x);
                                    figures[i].points[j].y1 = Convert.ToInt32(y);
                                }
                    }
                    if (mode == "Rotation3D")
                    {

                    }

                    panel1.Invalidate();
                }
            }
            else
            {
                MessageBox.Show("Выберите объект для выполнения операции!");
                mode = "Selection";
            }

        }


        void this_MouseWheel(object sender, MouseEventArgs e)
        {
            if (mode == "Rotation3D")
            {
                try
                {
                    int distToZeroX = 0;
                    int distToZeroY = 0;
                    int distToZeroZ = 0;

                    int count = 0;
                    for (int i = 0; i < figures.Count; i++)
                    {
                        if (figures[i].selected)
                        {
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {

                                distToZeroX += figures[i].points[j].x1;
                                distToZeroY += figures[i].points[j].y1;
                                distToZeroZ += figures[i].points[j].z1;
                                count++;
                            }
                        }
                    }
                    distToZeroX = distToZeroX / count;
                    distToZeroY = distToZeroY / count;
                    distToZeroZ = distToZeroZ / count;


                    if (e.Delta > 0)
                    {


                        int angle = Convert.ToInt32(textBoxY.Text);
                        double d = angle * (Math.PI / 180);
                        double[,] rY = GetRotateYMatrix(d);
                        for (int i = 0; i < figures.Count; i++)
                            if (figures[i].selected)
                            {
                                double[,] matrixB = getMatrix(figures[i]);
                                Figure result = matrixToPoint(MatrixMultiplication(matrixB, rY));
                                figures[i] = result;
                                figures[i].selected = true;
                            }
                        angle = Convert.ToInt32(textBoxZ.Text);
                        d = angle * (Math.PI / 180);
                        double[,] rZ = GetRotateZMatrix(d);
                        for (int i = 0; i < figures.Count; i++)
                            if (figures[i].selected)
                            {
                                double[,] matrixB = getMatrix(figures[i]);
                                Figure result = matrixToPoint(MatrixMultiplication(matrixB, rZ));
                                figures[i] = result;
                                figures[i].selected = true;
                            }

                        angle = Convert.ToInt32(textBoxX.Text);
                        d = angle * (Math.PI / 180);
                        double[,] rX = GetRotateXMatrix(d);
                        for (int i = 0; i < figures.Count; i++)
                            if (figures[i].selected)
                            {
                                double[,] matrixB = getMatrix(figures[i]);
                                Figure result = matrixToPoint(MatrixMultiplication(matrixB, rX));
                                figures[i] = result;
                                figures[i].selected = true;
                            }
                    }
                    if (e.Delta < 0)
                    {
                        int angle = Convert.ToInt32(textBoxY.Text);
                        double d = angle * (Math.PI / 180);
                        double[,] rY = GetRotateYMatrix(-d);
                        for (int i = 0; i < figures.Count; i++)
                            if (figures[i].selected)
                            {
                                double[,] matrixB = getMatrix(figures[i]);
                                Figure result = matrixToPoint(MatrixMultiplication(matrixB, rY));
                                figures[i] = result;
                                figures[i].selected = true;
                            }
                        angle = Convert.ToInt32(textBoxZ.Text);
                        d = angle * (Math.PI / 180);
                        double[,] rZ = GetRotateZMatrix(-d);
                        for (int i = 0; i < figures.Count; i++)
                            if (figures[i].selected)
                            {
                                double[,] matrixB = getMatrix(figures[i]);
                                Figure result = matrixToPoint(MatrixMultiplication(matrixB, rZ));
                                figures[i] = result;
                                figures[i].selected = true;
                            }

                        angle = Convert.ToInt32(textBoxX.Text);
                        d = angle * (Math.PI / 180);
                        double[,] rX = GetRotateXMatrix(-d);
                        for (int i = 0; i < figures.Count; i++)
                            if (figures[i].selected)
                            {
                                double[,] matrixB = getMatrix(figures[i]);
                                Figure result = matrixToPoint(MatrixMultiplication(matrixB, rX));
                                figures[i] = result;
                                figures[i].selected = true;
                            }

                    }

                    int distToZeroX2 = 0;
                    int distToZeroY2 = 0;
                    int distToZeroZ2 = 0;
                    int count2 = 0;
                    for (int i = 0; i < figures.Count; i++)
                    {
                        if (figures[i].selected)
                        {
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {

                                distToZeroX2 += figures[i].points[j].x1;
                                distToZeroY2 += figures[i].points[j].y1;
                                distToZeroZ2 += figures[i].points[j].z1;
                                count2++;
                            }
                        }
                    }
                    distToZeroX2 = distToZeroX2 / count2;
                    distToZeroY2 = distToZeroY2 / count2;
                    distToZeroZ2 = distToZeroZ2 / count2;
                    for (int i = 0; i < figures.Count; i++)
                        if (figures[i].selected)
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {
                                figures[i].points[j].x1 -= (distToZeroX2 - distToZeroX);
                                figures[i].points[j].y1 -= (distToZeroY2 - distToZeroY);
                                figures[i].points[j].z1 -= (distToZeroZ2 - distToZeroZ);
                            }
                }
                catch
                {
                    MessageBox.Show("Неверный формат ввода");
                }
            }

            if (mode == "Rotation2D")
            {
                if (e.Delta > 0)
                {
                    int angle = 0;
                    angle = trackBar1.Value;

                    double d = angle * (Math.PI / 180);
                    int distToZeroX = 0;
                    int distToZeroY = 0;
                    int count = 0;
                    for (int i = 0; i < figures.Count; i++)
                    {
                        if (figures[i].selected)
                        {
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {

                                distToZeroX += figures[i].points[j].x1;
                                distToZeroY += figures[i].points[j].y1;
                                count++;
                            }
                        }
                    }
                    distToZeroX = distToZeroX / count;
                    distToZeroY = distToZeroY / count;
                    for (int i = 0; i < figures.Count; i++)
                        if (figures[i].selected)
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {
                                float x = (float)((figures[i].points[j].x1 - distToZeroX) * Math.Cos(d) - (figures[i].points[j].y1 - distToZeroY) * Math.Sin(d) + distToZeroX);
                                float y = (float)((figures[i].points[j].x1 - distToZeroX) * Math.Sin(d) + (figures[i].points[j].y1 - distToZeroY) * Math.Cos(d) + distToZeroY);
                                figures[i].points[j].x1 = Convert.ToInt32(x);
                                figures[i].points[j].y1 = Convert.ToInt32(y);
                            }

                }
                else if (e.Delta < 0)
                {
                    int angle = 0;
                    angle = trackBar1.Value;

                    double d = angle * (Math.PI / 180);
                    int distToZeroX = 0;
                    int distToZeroY = 0;
                    int count = 0;
                    for (int i = 0; i < figures.Count; i++)
                    {
                        if (figures[i].selected)
                        {
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {

                                distToZeroX += figures[i].points[j].x1;
                                distToZeroY += figures[i].points[j].y1;
                                count++;
                            }
                        }
                    }
                    distToZeroX = distToZeroX / count;
                    distToZeroY = distToZeroY / count;
                    for (int i = 0; i < figures.Count; i++)
                        if (figures[i].selected)
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {
                                float x = (float)((figures[i].points[j].x1 - distToZeroX) * Math.Cos(-d) - (figures[i].points[j].y1 - distToZeroY) * Math.Sin(-d) + distToZeroX);
                                float y = (float)((figures[i].points[j].x1 - distToZeroX) * Math.Sin(-d) + (figures[i].points[j].y1 - distToZeroY) * Math.Cos(-d) + distToZeroY);
                                figures[i].points[j].x1 = Convert.ToInt32(x);
                                figures[i].points[j].y1 = Convert.ToInt32(y);
                            }
                }
            }
            panel1.Invalidate();
        }

        private void button_ScaleIt2D_Click(object sender, EventArgs e)
        {
            if (mode == "Scale2D")
            {
                int distToZeroX = 0;
                int distToZeroY = 0;
                int count = 0;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            distToZeroX += figures[i].points[j].x1;
                            distToZeroY += figures[i].points[j].y1;
                            count++;
                        }
                    }
                }
                distToZeroX = distToZeroX / count;
                distToZeroY = distToZeroY / count;
                double k = 0;
                try
                {
                    k = Convert.ToDouble((textBox_ScaleK2D.Text));
                }
                catch
                {
                    MessageBox.Show("Некорректный формат!");
                }

                for (int i = 0; i < figures.Count; i++)
                    if (figures[i].selected)
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {
                            float x = (float)((figures[i].points[j].x1 * k));
                            float y = (float)((figures[i].points[j].y1 * k));
                            figures[i].points[j].x1 = Convert.ToInt32(x);
                            figures[i].points[j].y1 = Convert.ToInt32(y);
                        }
                int distToZeroX2 = 0;
                int distToZeroY2 = 0;
                int count2 = 0;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            distToZeroX2 += figures[i].points[j].x1;
                            distToZeroY2 += figures[i].points[j].y1;
                            count2++;
                        }
                    }
                }
                distToZeroX2 = distToZeroX2 / count2;
                distToZeroY2 = distToZeroY2 / count2;
                for (int i = 0; i < figures.Count; i++)
                    if (figures[i].selected)
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {
                            figures[i].points[j].x1 -= (distToZeroX2 - distToZeroX);
                            figures[i].points[j].y1 -= (distToZeroY2 - distToZeroY);
                        }


            }
            panel1.Invalidate();

        }




        private void button_Scale2D_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    count++;
            if (count != 0)
            {

                HideAllButtons();
                button_ScaleIt2D.Show();
                textBox_ScaleK2D.Show();
                mode = "Scale2D";
            }
            else
            {
                MessageBox.Show("Выберите объект для выполнения операции!");
                mode = "Selection";
            }
            label8.Text = mode;
        }

        public void HideAllButtons()
        {
            StopDrawing.Hide();
            button_MirrorX2d.Hide();
            button_MirrorY2d.Hide();
            label_Rotation2d.Hide();
            trackBar1.Hide();
            textBox_ScaleK2D.Hide();
            button_ScaleIt2D.Hide();
            textBoxX.Hide();
            textBoxY.Hide();
            textBoxZ.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            textBoxTransformX.Hide();
            textBoxTransformY.Hide();
            textBoxTransformZ.Hide();
            labelTransform.Hide();
            button_doTransform3D.Hide();
            button_Mirror3dX.Hide();
            button_Mirror3dY.Hide();
            button_Mirror3dZ.Hide();
            textBoxZc.Hide();
            textBoxAlpha.Hide();
            textBoxGamma.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            button1.Hide();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            mode = "Delete2D";
            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    count++;
            if (count != 0)
            {
                for (int i = 0; i < figures.Count; i++)
                    if (figures[i].selected)
                    {
                        figures.RemoveAt(i); i--; counter--;
                    }
            }
            else
            {
                MessageBox.Show("Выберите объект для выполнения операции!");
                mode = "Selection";
            }
            label8.Text = mode;

            panel1.Invalidate();
        }

        private void button_TrimetrPorekciya_Click(object sender, EventArgs e)
        {
            HideAllButtons();
            Figure fRect = new Figure();
            Figure sRect = new Figure();
            Figure fsLine = new Figure();
            Figure sLine = new Figure();
            Figure tLine = new Figure();
            Figure frLine = new Figure();
            var trMatrix = new double[,]{   { 200,200,0,1},
                                            { 400,200,0,1},
                                            { 400,400,0,1},
                                            { 200,400,0,1},
                                            { 200,200,0,1}};
            fRect = matrixToPoint(trMatrix);
            fRect.trimetric = true;
            figures.Add(fRect);


            trMatrix = new double[,]{   { 200,200,-200,1},
                                            { 400,200,-200,1},
                                            { 400,400,-200,1},
                                            { 200,400,-200,1},
                                            { 200,200,-200,1}};
            sRect = matrixToPoint(trMatrix);
            sRect.trimetric = true;
            figures.Add(sRect);


            trMatrix = new double[,]{   { 200,200,-200,1},
                                            { 200,200,0,1}};
            fsLine = matrixToPoint(trMatrix);
            fsLine.trimetric = true;
            figures.Add(fsLine);


            trMatrix = new double[,]{   { 400,200,-200,1},
                                            { 400,200,0,1}};
            sLine = matrixToPoint(trMatrix);
            sLine.trimetric = true;
            figures.Add(sLine);


            trMatrix = new double[,]{   { 400,400,-200,1},
                                            { 400,400,0,1}};
            tLine = matrixToPoint(trMatrix);
            tLine.trimetric = true;
            figures.Add(tLine);


            trMatrix = new double[,]{   { 200,400,-200,1},
                                            { 200,400,0,1}};
            frLine = matrixToPoint(trMatrix);
            frLine.trimetric = true;
            figures.Add(frLine);

            counter = counter + 6;
            mode = "Selection";
            panel1.Invalidate();


        }

     

        public void RefreshCoord()
        {
            dataGridView_SetCoord.Rows.Clear();
            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    for (int j = 0; j < figures[i].points.Count; j++)
                    {
                        dataGridView_SetCoord.Rows.Add();
                        dataGridView_SetCoord.Rows[count].Cells[0].Value = figures[i].points[j].x1;
                        dataGridView_SetCoord.Rows[count].Cells[1].Value = figures[i].points[j].y1;
                        dataGridView_SetCoord.Rows[count].Cells[2].Value = figures[i].points[j].z1;
                        count++;
                    }

        }



        private void button_SetCoord_Click(object sender, EventArgs e)
        {

            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    for (int j = 0; j < figures[i].points.Count; j++)
                    {
                        figures[i].points[j].x1 = Convert.ToInt32(dataGridView_SetCoord.Rows[count].Cells[0].Value);
                        figures[i].points[j].y1 = Convert.ToInt32(dataGridView_SetCoord.Rows[count].Cells[1].Value);
                        figures[i].points[j].z1 = Convert.ToInt32(dataGridView_SetCoord.Rows[count].Cells[2].Value);
                        count++;
                    }
            RefreshCoord();
            button_SetCoord.Enabled = false;
            panel1.Invalidate();
        }

        private void dataGridView_SetCoord_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            button_SetCoord.Enabled = true;
        }

        private void button_Rotate3D_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    count++;
            if (count != 0)
            {
                HideAllButtons();
                mode = "Rotation3D";
                textBoxX.Text = "0";
                textBoxZ.Text = "0";
                textBoxY.Text = "0";
                textBoxX.Show();
                textBoxY.Show();
                textBoxZ.Show();
                label1.Show();
                label2.Show();
                label3.Show();
            }
            else
            {
                MessageBox.Show("Выберите объект для выполнения операции!");
                mode = "Selection";
            }
            label8.Text = mode;
        }

        private void button_Transform3D_Click(object sender, EventArgs e)
        {

            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    count++;
            if (count != 0)
            {
                HideAllButtons();
                mode = "Transform3D";
                label4.Show();
                label5.Show();
                label6.Show();
                textBoxTransformX.Text = "0";
                textBoxTransformY.Text = "0";
                textBoxTransformZ.Text = "0";
                textBoxTransformX.Show();
                textBoxTransformY.Show();
                textBoxTransformZ.Show();
                labelTransform.Show();
                button_doTransform3D.Show();
            }
            else
            {
                MessageBox.Show("Выберите объект для выполнения операции!");
                mode = "Selection";
            }
            label8.Text = mode;

        }

        private void button_doTransform3D_Click(object sender, EventArgs e)
        {
            if (mode == "Transform3D")
            {
                try
                {
                    int m = Convert.ToInt32(textBoxTransformX.Text);
                    int n = Convert.ToInt32(textBoxTransformY.Text);
                    int l = Convert.ToInt32(textBoxTransformZ.Text);

                    double[,] X = GetTransformatrix(m, n, l);
                    for (int i = 0; i < figures.Count; i++)
                        if (figures[i].selected)
                        {
                            double[,] matrixB = getMatrix(figures[i]);
                            Figure result = matrixToPoint(MatrixMultiplication(matrixB, X));
                            figures[i] = result;
                            figures[i].selected = true;
                        }
                    panel1.Invalidate();
                    textBoxTransformX.Text = "0";
                    textBoxTransformY.Text = "0";
                    textBoxTransformZ.Text = "0";
                }
                catch
                {
                    MessageBox.Show("Неверный формат ввода");
                }



            }

            if (mode == "Scale3D")
            {
                try
                {
                    int distToZeroX = 0;
                    int distToZeroY = 0;
                    int distToZeroZ = 0;

                    int count = 0;
                    for (int i = 0; i < figures.Count; i++)
                    {
                        if (figures[i].selected)
                        {
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {

                                distToZeroX += figures[i].points[j].x1;
                                distToZeroY += figures[i].points[j].y1;
                                distToZeroZ += figures[i].points[j].z1;
                                count++;
                            }
                        }
                    }
                    distToZeroX = distToZeroX / count;
                    distToZeroY = distToZeroY / count;
                    distToZeroZ = distToZeroZ / count;

                    double a = Convert.ToDouble(textBoxTransformX.Text);
                    double b = Convert.ToDouble(textBoxTransformY.Text);
                    double c = Convert.ToDouble(textBoxTransformZ.Text);

                    double[,] X = GetScaleMatrix(a, b, c);
                    for (int i = 0; i < figures.Count; i++)
                        if (figures[i].selected)
                        {
                            double[,] matrixB = getMatrix(figures[i]);
                            Figure result = matrixToPoint(MatrixMultiplication(matrixB, X));
                            figures[i] = result;
                            figures[i].selected = true;
                        }

                    int distToZeroX2 = 0;
                    int distToZeroY2 = 0;
                    int distToZeroZ2 = 0;
                    int count2 = 0;
                    for (int i = 0; i < figures.Count; i++)
                    {
                        if (figures[i].selected)
                        {
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {

                                distToZeroX2 += figures[i].points[j].x1;
                                distToZeroY2 += figures[i].points[j].y1;
                                distToZeroZ2 += figures[i].points[j].z1;
                                count2++;
                            }
                        }
                    }
                    distToZeroX2 = distToZeroX2 / count2;
                    distToZeroY2 = distToZeroY2 / count2;
                    distToZeroZ2 = distToZeroZ2 / count2;
                    for (int i = 0; i < figures.Count; i++)
                        if (figures[i].selected)
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {
                                figures[i].points[j].x1 -= (distToZeroX2 - distToZeroX);
                                figures[i].points[j].y1 -= (distToZeroY2 - distToZeroY);
                                figures[i].points[j].z1 -= (distToZeroZ2 - distToZeroZ);
                            }

                    textBoxTransformX.Text = "1";
                    textBoxTransformY.Text = "1";
                    textBoxTransformZ.Text = "1";

                    panel1.Invalidate();
                }
                catch
                {
                    MessageBox.Show("Неверный формат ввода");
                }



            }
        }

        private void button_Mirror3D_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    count++;
            if (count != 0)
            {
                HideAllButtons();
                mode = "Mirror3D";
                button_Mirror3dX.Show();
                button_Mirror3dY.Show();
                button_Mirror3dZ.Show();
            }
            else
            {
                MessageBox.Show("Выберите объект для выполнения операции!");
                mode = "Selection";
            }
            label8.Text = mode;
        }

        private void button_Mirror3dX_Click(object sender, EventArgs e)
        {
            if (mode == "Mirror3D")
            {
                int distToZeroX = 0;
                int distToZeroY = 0;
                int distToZeroZ = 0;

                int count = 0;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            distToZeroX += figures[i].points[j].x1;
                            distToZeroY += figures[i].points[j].y1;
                            distToZeroZ += figures[i].points[j].z1;
                            count++;
                        }
                    }
                }
                distToZeroX = distToZeroX / count;
                distToZeroY = distToZeroY / count;
                distToZeroZ = distToZeroZ / count;

                double[,] X = GetMirrorXMatrix();
                for (int i = 0; i < figures.Count; i++)
                    if (figures[i].selected)
                    {
                        double[,] matrixB = getMatrix(figures[i]);
                        Figure result = matrixToPoint(MatrixMultiplication(matrixB, X));
                        figures[i] = result;
                        figures[i].selected = true;
                    }
                int distToZeroX2 = 0;
                int distToZeroY2 = 0;
                int distToZeroZ2 = 0;
                int count2 = 0;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            distToZeroX2 += figures[i].points[j].x1;
                            distToZeroY2 += figures[i].points[j].y1;
                            distToZeroZ2 += figures[i].points[j].z1;
                            count2++;
                        }
                    }
                }
                distToZeroX2 = distToZeroX2 / count2;
                distToZeroY2 = distToZeroY2 / count2;
                distToZeroZ2 = distToZeroZ2 / count2;
                for (int i = 0; i < figures.Count; i++)
                    if (figures[i].selected)
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {
                            figures[i].points[j].x1 -= (distToZeroX2 - distToZeroX);
                            figures[i].points[j].y1 -= (distToZeroY2 - distToZeroY);
                            figures[i].points[j].z1 -= (distToZeroZ2 - distToZeroZ);
                        }

                panel1.Invalidate();
            }
        }

        private void button_Mirror3dY_Click(object sender, EventArgs e)
        {
            if (mode == "Mirror3D")
            {
                int distToZeroX = 0;
                int distToZeroY = 0;
                int distToZeroZ = 0;

                int count = 0;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            distToZeroX += figures[i].points[j].x1;
                            distToZeroY += figures[i].points[j].y1;
                            distToZeroZ += figures[i].points[j].z1;
                            count++;
                        }
                    }
                }
                distToZeroX = distToZeroX / count;
                distToZeroY = distToZeroY / count;
                distToZeroZ = distToZeroZ / count;

                double[,] X = GetMirrorYMatrix();
                for (int i = 0; i < figures.Count; i++)
                    if (figures[i].selected)
                    {
                        double[,] matrixB = getMatrix(figures[i]);
                        Figure result = matrixToPoint(MatrixMultiplication(matrixB, X));
                        figures[i] = result;
                        figures[i].selected = true;
                    }
                int distToZeroX2 = 0;
                int distToZeroY2 = 0;
                int distToZeroZ2 = 0;
                int count2 = 0;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            distToZeroX2 += figures[i].points[j].x1;
                            distToZeroY2 += figures[i].points[j].y1;
                            distToZeroZ2 += figures[i].points[j].z1;
                            count2++;
                        }
                    }
                }
                distToZeroX2 = distToZeroX2 / count2;
                distToZeroY2 = distToZeroY2 / count2;
                distToZeroZ2 = distToZeroZ2 / count2;
                for (int i = 0; i < figures.Count; i++)
                    if (figures[i].selected)
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {
                            figures[i].points[j].x1 -= (distToZeroX2 - distToZeroX);
                            figures[i].points[j].y1 -= (distToZeroY2 - distToZeroY);
                            figures[i].points[j].z1 -= (distToZeroZ2 - distToZeroZ);
                        }

                panel1.Invalidate();
            }
        }

        private void button_Mirror3dZ_Click(object sender, EventArgs e)
        {
            if (mode == "Mirror3D")
            {
                int distToZeroX = 0;
                int distToZeroY = 0;
                int distToZeroZ = 0;

                int count = 0;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            distToZeroX += figures[i].points[j].x1;
                            distToZeroY += figures[i].points[j].y1;
                            distToZeroZ += figures[i].points[j].z1;
                            count++;
                        }
                    }
                }
                distToZeroX = distToZeroX / count;
                distToZeroY = distToZeroY / count;
                distToZeroZ = distToZeroZ / count;

                double[,] X = GetMirrorZMatrix();
                for (int i = 0; i < figures.Count; i++)
                    if (figures[i].selected)
                    {
                        double[,] matrixB = getMatrix(figures[i]);
                        Figure result = matrixToPoint(MatrixMultiplication(matrixB, X));
                        figures[i] = result;
                        figures[i].selected = true;
                    }
                int distToZeroX2 = 0;
                int distToZeroY2 = 0;
                int distToZeroZ2 = 0;
                int count2 = 0;
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].selected)
                    {
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {

                            distToZeroX2 += figures[i].points[j].x1;
                            distToZeroY2 += figures[i].points[j].y1;
                            distToZeroZ2 += figures[i].points[j].z1;
                            count2++;
                        }
                    }
                }
                distToZeroX2 = distToZeroX2 / count2;
                distToZeroY2 = distToZeroY2 / count2;
                distToZeroZ2 = distToZeroZ2 / count2;
                for (int i = 0; i < figures.Count; i++)
                    if (figures[i].selected)
                        for (int j = 0; j < figures[i].points.Count; j++)
                        {
                            figures[i].points[j].x1 -= (distToZeroX2 - distToZeroX);
                            figures[i].points[j].y1 -= (distToZeroY2 - distToZeroY);
                            figures[i].points[j].z1 -= (distToZeroZ2 - distToZeroZ);
                        }

                panel1.Invalidate();
            }
        }

        private void button_Scale3D_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    count++;
            if (count != 0)
            {
                HideAllButtons();
                mode = "Scale3D";
                textBoxTransformX.Show(); 
                textBoxTransformY.Show();
                textBoxTransformZ.Show();
                textBoxTransformX.Text="1";
                textBoxTransformY.Text="1";
                textBoxTransformZ.Text="1";
                button_doTransform3D.Show();
            }
            else
            {
                MessageBox.Show("Выберите объект для выполнения операции!");
                mode = "Selection";
            }
            label8.Text = mode;
        }

        private void button_Selection_Click(object sender, EventArgs e)
        {
            mode = "Selection";
            label8.Text = mode;
        }

        private void button_trimetrProekc_Click(object sender, EventArgs e)
        {
            
                HideAllButtons();
                mode = "Trimetr";
                textBoxZc.Show();
                textBoxAlpha.Show();
                textBoxGamma.Show();
                label9.Show();
                label10.Show();
                label11.Show();
                button1.Show();
                textBoxZc.Text = "0";
                textBoxAlpha.Text = "0";
                textBoxGamma.Text = "0";
            figures.Clear();
            counter = -1;
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream reader = new FileStream("trimetric.bin", FileMode.Open))
            {
                trimetricMatrix = (List<Figure>)bf.Deserialize(reader);
            }
            for (int i = 0; i < trimetricMatrix.Count; i++)
            {
                trimetricMatrix[i].selected = true;
                figures.Add(trimetricMatrix[i]);
                counter++;
            }
            label8.Text = mode;
            panel1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                if (mode == "Trimetr")
                {
                     figures.Clear();
            counter = -1;
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream reader = new FileStream("trimetric.bin", FileMode.Open))
            {
                trimetricMatrix = (List<Figure>)bf.Deserialize(reader);
            }
            for (int i = 0; i < trimetricMatrix.Count; i++)
            {
                trimetricMatrix[i].selected = true;
                figures.Add(trimetricMatrix[i]);
                counter++;
            }
                    int distToZeroX = 0;
                    int distToZeroY = 0;
                    int distToZeroZ = 0; 
                   
                       int count = 0;
                    for (int i = 0; i < figures.Count; i++)
                    {
                        if (figures[i].selected)
                        {
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {

                                distToZeroX += figures[i].points[j].x1;
                                distToZeroY += figures[i].points[j].y1;
                                distToZeroZ += figures[i].points[j].z1;
                                count++;
                            }
                        }
                    }
                    distToZeroX = distToZeroX / count;
                    distToZeroY = distToZeroY / count;
                    distToZeroZ = distToZeroZ / count;
                    distToZeroX = panel1.Width / 2;
                    distToZeroY = panel1.Height / 2;
                    double[,] matrixB = new double[,] { };
                    double a = Convert.ToInt32(textBoxAlpha.Text) * Math.PI / 180;
                    double g = Convert.ToInt32(textBoxGamma.Text) * Math.PI / 180;
                    double Zc = Convert.ToDouble(textBoxZc.Text);
                    var trMatrix = new double[,] { { Math.Cos(a), Math.Sin(a) * Math.Cos(g) , 0 ,Math.Sin(a)*Math.Cos(g)/Zc},
                                        {   0 ,       Math.Cos(g)       ,      0    ,   -Math.Sin(g)/Zc   },
                                        { Math.Sin(a)       ,   -Math.Cos(a)*Math.Sin(g)    ,   0   ,   -Math.Cos(a)*Math.Cos(g)/Zc   },
                                        {   0   ,    0  ,  0    ,   1    } };
                    for (int i = 0; i < figures.Count; i++)
                        if (figures[i].selected)
                        {
                            matrixB = getMatrix(figures[i]);
                            Figure result = matrixToPoint(MatrixMultiplication(matrixB, trMatrix));
                            figures[i] = result;
                            figures[i].selected = true;
                        }
                   int distToZeroX2 = 0;
                    int distToZeroY2 = 0;
                    int distToZeroZ2 = 0;
                    int count2 = 0;
                    for (int i = 0; i < figures.Count; i++)
                    {
                        if (figures[i].selected)
                        {
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {

                                distToZeroX2 += figures[i].points[j].x1;
                                distToZeroY2 += figures[i].points[j].y1;
                                distToZeroZ2 += figures[i].points[j].z1;
                                count2++;
                            }
                        }
                    }
                    distToZeroX2 = distToZeroX2 / count2;
                    distToZeroY2 = distToZeroY2 / count2;
                    distToZeroZ2 = distToZeroZ2 / count2;
                    for (int i = 0; i < figures.Count; i++)
                        if (figures[i].selected)
                            for (int j = 0; j < figures[i].points.Count; j++)
                            {
                                figures[i].points[j].x1 -= (distToZeroX2 - distToZeroX);
                                figures[i].points[j].y1 -= (distToZeroY2 - distToZeroY);
                            }

                    panel1.Invalidate();
                }
            }
            catch
            {
                MessageBox.Show("");
            }
            
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                    count++;
            if (count != 0)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog.FileName;

                List<Figure> toSerialize = new List<Figure>();
                for (int i = 0; i < figures.Count; i++)
                    if (figures[i].selected)
                    {
                        toSerialize.Add(figures[i]);
                    }
                BinaryFormatter bf = new BinaryFormatter();
                using (Stream writer = new FileStream(filename, FileMode.Create))
                {
                    bf.Serialize(writer, toSerialize);
                }
            }
            else
            {
                MessageBox.Show("Выберите объект для выполнения операции!");
                mode = "Selection";
            }
        }

        private void button_Upload_Click(object sender, EventArgs e)
        {
            mode = "Upload obj";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            List<Figure> toSerialize = new List<Figure>();
            for (int i = 0; i < figures.Count; i++)
                if (figures[i].selected)
                {
                    figures[i].selected=false;
                }
            List<Figure> deserialize = new List<Figure>();
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                deserialize = (List<Figure>)bf.Deserialize(reader);
            }
            for (int i = 0; i < deserialize.Count; i++)
            {
                deserialize[i].selected = true;
                figures.Add(deserialize[i]);
                counter++;
            }
            mode = "Selection";
            panel1.Invalidate();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
