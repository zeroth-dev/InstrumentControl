using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SmithPlot
{
    public partial class SmithForm : Form
    {

        List<Complex> SmithPoints = null;
        bool updateSingle = false;
        bool updateMultiple = false;
        Complex SinglePoint;
        List<Complex> PointsToUpdate = new List<Complex>();
        public SmithForm()
        {
            this.DrawPanel.Paint += DrawPanel_Paint;
        }

        public SmithForm(List<Complex> SmithPoints, bool IsReflection)
        {

            updateSingle = false;
            updateMultiple = false;
            if (IsReflection)
            {
                this.SmithPoints = SmithPoints;
            }
            else
            {
                this.SmithPoints = ConvertImpedanceToReflection(SmithPoints);
            }
            InitializeComponent();
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            float radius = DrawPanel.Size.Height / 2-50;


            Pen blackpen = new Pen(Color.Black, 1);
            Brush blueBrush = Brushes.Blue;
            Brush orangeBrush = Brushes.Orange;
            Brush redBrush = Brushes.Red;

            Graphics g = e.Graphics;
            DrawSmithPlot(blackpen, g, radius, 50);
            
            if(SmithPoints != null)
            {
                DrawSmithPoints(blueBrush, g, this.SmithPoints, radius, 50);
            }
            if(updateSingle)
            {

                Point point = Gamma2Point(SinglePoint, radius);
                point.Offset(50, 50);
                g.FillEllipse(orangeBrush, point.X - 5, point.Y - 5, 10, 10);
            }
            if(updateMultiple)
            {
                DrawSmithPoints(redBrush, g, this.PointsToUpdate, radius, 50);
            }
            g.Dispose();

        }

        public void UpdateCurrPoint(Complex SmithPoint, bool IsReflection)
        {
            Complex Z0 = new Complex(50, 0);
            if(!IsReflection)
            {
                SmithPoint = (SmithPoint-Z0)/(SmithPoint+Z0);
            }
            SinglePoint = SmithPoint;
            this.updateSingle = true;
            this.Invalidate();
        }

        public void FinishedPoint(Complex SmithPoint, bool IsReflection)
        {
            Complex Z0 = new Complex(50, 0);
            if (!IsReflection)
            {
                SmithPoint = (SmithPoint - Z0) / (SmithPoint + Z0);
            }
            PointsToUpdate.Add(SmithPoint);
            this.updateMultiple = true;
            this.Invalidate();
        }

        public void ChangePoints(List<Complex> SmithPoints, bool IsReflection)
        {

            updateSingle = false;
            updateMultiple = false;
            if (IsReflection)
            {
                this.SmithPoints = SmithPoints;
            }
            else
            {
                this.SmithPoints = ConvertImpedanceToReflection(SmithPoints);
            }
            PointsToUpdate = new List<Complex>();
        }

        private void DrawSmithPoints(Brush brush, Graphics g, List<Complex> SmithPoints, float radius, int offset)
        {
            foreach (Complex gamma in SmithPoints)
            {
                Point point = Gamma2Point(gamma, radius);
                point.Offset(offset, offset);
                g.FillEllipse(brush, point.X - 5, point.Y - 5, 10, 10);
            }
        }

        private void DrawSmithPlot(Pen pen, Graphics g, float radius, int offset)
        {

            g.DrawEllipse(pen, offset, offset, 2 * radius, 2 * radius);
            g.DrawLine(pen, new Point(offset, (int)radius+offset), new Point(2 * (int)radius+offset, (int)radius + offset));

            Point[] line1j = GetRealPointListPosImag(25, radius);
            Point[] lineneg1j = GetRealPointListNegImag(25, radius);
            OffsetPointArray(ref line1j, offset, offset);
            OffsetPointArray(ref lineneg1j, offset, offset);
            g.DrawCurve(pen, line1j);
            g.DrawCurve(pen, lineneg1j);

            line1j = GetRealPointListPosImag(50, radius);
            lineneg1j = GetRealPointListNegImag(50, radius);
            OffsetPointArray(ref line1j, offset, offset);
            OffsetPointArray(ref lineneg1j, offset, offset);
            g.DrawCurve(pen, line1j);
            g.DrawCurve(pen, lineneg1j);

            line1j = GetRealPointListPosImag(100, radius);
            lineneg1j = GetRealPointListNegImag(100, radius);
            OffsetPointArray(ref line1j, offset, offset);
            OffsetPointArray(ref lineneg1j, offset, offset);

            g.DrawCurve(pen, line1j);
            g.DrawCurve(pen, lineneg1j);

            line1j = GetRealPointListPosImag(5, radius);
            lineneg1j = GetRealPointListNegImag(5, radius);
            OffsetPointArray(ref line1j, offset, offset);
            OffsetPointArray(ref lineneg1j, offset, offset);

            g.DrawCurve(pen, line1j);
            g.DrawCurve(pen, lineneg1j);

            line1j = GetRealPointListPosImag(500, radius);
            lineneg1j = GetRealPointListNegImag(500, radius);
            OffsetPointArray(ref line1j, offset, offset);
            OffsetPointArray(ref lineneg1j, offset, offset);

            g.DrawCurve(pen, line1j);
            g.DrawCurve(pen, lineneg1j);

            line1j = GetImagPointList(50, radius);
            lineneg1j = GetImagPointList(-50, radius);
            OffsetPointArray(ref line1j, offset, offset);
            OffsetPointArray(ref lineneg1j, offset, offset);

            g.DrawCurve(pen, line1j, -0.1f);
            g.DrawCurve(pen, lineneg1j, -0.1f);

            line1j = GetImagPointList(25, radius);
            lineneg1j = GetImagPointList(-25, radius);
            OffsetPointArray(ref line1j, offset, offset);
            OffsetPointArray(ref lineneg1j, offset, offset);

            g.DrawCurve(pen, line1j, -0.1f);
            g.DrawCurve(pen, lineneg1j, -0.1f);

            line1j = GetImagPointList(100, radius);
            lineneg1j = GetImagPointList(-100, radius);
            OffsetPointArray(ref line1j, offset, offset);
            OffsetPointArray(ref lineneg1j, offset, offset);

            g.DrawCurve(pen, line1j, -0.1f);
            g.DrawCurve(pen, lineneg1j, -0.1f);

        }
        private Point GetSmithPoint(double real, double imag, float radius)
        {
            Complex Z0 = new Complex(50, 0);
            Complex Z = new Complex(real, imag);
            Complex gamma = (Z - Z0) / (Z + Z0);
            
            return Gamma2Point(gamma, radius);


        }

        private List<Complex> ConvertImpedanceToReflection(List<Complex> impedances)
        {
            List<Complex> reflections = new List<Complex>();
            Complex Z0 = new Complex(50, 0);
            foreach (var Z in impedances)
            {
                Complex gamma = (Z - Z0) / (Z + Z0);
                reflections.Add(gamma);

            }
            return reflections;
        }

        private Point[] GetRealPointListNegImag(int Zreal, float radius)
        {
            Point[] points = new Point[]
            {
                GetSmithPoint(Zreal, 0, radius),
                GetSmithPoint(Zreal, -0.1, radius),
                GetSmithPoint(Zreal, -0.2, radius),
                GetSmithPoint(Zreal, -0.3, radius),
                GetSmithPoint(Zreal, -0.4, radius),
                GetSmithPoint(Zreal, -0.5, radius),
                GetSmithPoint(Zreal, -0.7, radius),
                GetSmithPoint(Zreal, -1, radius),
                GetSmithPoint(Zreal, -2, radius),
                GetSmithPoint(Zreal, -5, radius),
                GetSmithPoint(Zreal, -10, radius),
                GetSmithPoint(Zreal, -20, radius),
                GetSmithPoint(Zreal, -30, radius),
                GetSmithPoint(Zreal, -40, radius),
                GetSmithPoint(Zreal, -50, radius),
                GetSmithPoint(Zreal, -70, radius),
                GetSmithPoint(Zreal, -100, radius),
                GetSmithPoint(Zreal, -200, radius),
                GetSmithPoint(Zreal, -500, radius),
                GetSmithPoint(Zreal, -1000, radius),
                GetSmithPoint(Zreal, -2000, radius),
                GetSmithPoint(Zreal, -5000, radius),
                GetSmithPoint(Zreal, -10000, radius),
                GetSmithPoint(Zreal, -20000, radius),
                GetSmithPoint(Zreal, -50000, radius),
                new Point(2*(int)radius, (int)radius)
            };

            return points;
        }

        private Point[] GetRealPointListPosImag(int Zreal, float radius)
        {
            Point[] points = new Point[]
            {
                GetSmithPoint(Zreal, 0, radius),
                GetSmithPoint(Zreal, 0.1, radius),
                GetSmithPoint(Zreal, 0.2, radius),
                GetSmithPoint(Zreal, 0.3, radius),
                GetSmithPoint(Zreal, 0.4, radius),
                GetSmithPoint(Zreal, 0.5, radius),
                GetSmithPoint(Zreal, 0.7, radius),
                GetSmithPoint(Zreal, 1, radius),
                GetSmithPoint(Zreal, 2, radius),
                GetSmithPoint(Zreal, 5, radius),
                GetSmithPoint(Zreal, 10, radius),
                GetSmithPoint(Zreal, 20, radius),
                GetSmithPoint(Zreal, 30, radius),
                GetSmithPoint(Zreal, 40, radius),
                GetSmithPoint(Zreal, 50, radius),
                GetSmithPoint(Zreal, 70, radius),
                GetSmithPoint(Zreal, 100, radius),
                GetSmithPoint(Zreal, 200, radius),
                GetSmithPoint(Zreal, 500, radius),
                GetSmithPoint(Zreal, 1000, radius),
                GetSmithPoint(Zreal, 2000, radius),
                GetSmithPoint(Zreal, 5000, radius),
                GetSmithPoint(Zreal, 10000, radius),
                GetSmithPoint(Zreal, 20000, radius),
                GetSmithPoint(Zreal, 50000, radius),
                new Point(2*(int)radius, (int)radius)
            };

            return points;
        }

        private Point[] GetImagPointList(int Zimag, float radius)
        {
            Point[] points = new Point[]
            {
                GetSmithPoint(0, Zimag, radius),
                GetSmithPoint(0.1, Zimag, radius),
                GetSmithPoint(0.2, Zimag, radius),
                GetSmithPoint(0.3, Zimag, radius),
                GetSmithPoint(0.4, Zimag, radius),
                GetSmithPoint(0.5, Zimag, radius),
                GetSmithPoint(0.7, Zimag, radius),
                GetSmithPoint(1, Zimag, radius),
                GetSmithPoint(2, Zimag, radius),
                GetSmithPoint(3, Zimag, radius),
                GetSmithPoint(4, Zimag, radius),
                GetSmithPoint(5, Zimag, radius),
                GetSmithPoint(7, Zimag, radius),
                GetSmithPoint(10, Zimag, radius),
                GetSmithPoint(20, Zimag, radius),
                GetSmithPoint(30, Zimag, radius),
                GetSmithPoint(40, Zimag, radius),
                GetSmithPoint(50, Zimag, radius),
                GetSmithPoint(100, Zimag, radius),
                GetSmithPoint(200, Zimag, radius),
                GetSmithPoint(300, Zimag, radius),
                GetSmithPoint(500, Zimag, radius),
                GetSmithPoint(1000, Zimag, radius),
                GetSmithPoint(2000, Zimag, radius),
                GetSmithPoint(5000, Zimag, radius),
                GetSmithPoint(10000, Zimag, radius),
                GetSmithPoint(20000, Zimag, radius),
                GetSmithPoint(50000, Zimag, radius),
                new Point(2*(int)radius, (int)radius)
            };

            return points;
        }

        private Point Gamma2Point(Complex gamma, float radius)
        {
            gamma = new Complex(gamma.Real, -1 * gamma.Imaginary);
            Complex offset = new Complex(radius, radius);

            gamma *= radius;
            gamma += offset;
            return new Point((int)gamma.Real, (int)gamma.Imaginary);
        }

        public void OffsetPointArray(ref Point[] points, int offsetX, int offsetY)
        {
            for(int i = 0; i < points.Length; i++)
            {
                points[i].Offset(offsetX, offsetY);
            }
                
        }

        private void SmithForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel= true;
        }
    }
}
