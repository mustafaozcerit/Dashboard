using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DasboardYap
{
    public partial class Form1 : Form
    {
        string yapildi="Yapıldı";
        string yapilmadi = "Yapılmadı";
        int yapilandeger = 60;
        int yapilmayandeger = 40;
        int deger = 10;
        public Form1()
        {
            Göster();
            InitializeComponent();
           
        }
        public void Göster()
        {
            // Create an empty chart.
            ChartControl PieChart3D = new ChartControl();

            // Create a pie series.
            Series series1 = new Series("Pie Series 1", ViewType.Pie3D);

            // Populate the series with points~.~
            series1.Points.Add(new SeriesPoint(yapildi, yapilandeger));
            series1.Points.Add(new SeriesPoint(yapilmadi, yapilmayandeger));




            // Add the series to the chart.
            PieChart3D.Series.Add(series1);

            // Adjust the value numeric options of the series.
            series1.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            series1.PointOptions.ValueNumericOptions.Precision = 0; // Küsüratları kaldırıyor yuvarlama işlemi yapıyor

            // Adjust the view-type-specific options of the series.
            ((Pie3DSeriesView)series1.View).Depth = 25; //Dilimlerin kalınlıklarını belirliyor.
            ((Pie3DSeriesView)series1.View).ExplodedPoints.Add(series1.Points[0]); //Boşluk yapıyor
            ((Pie3DSeriesView)series1.View).ExplodedDistancePercentage = 15; //Aradaki boşlukların mesafesini ayarlıyor

            // Access the diagram's options.
            ((SimpleDiagram3D)PieChart3D.Diagram).RotationType = RotationType.UseAngles; //Döndürme izni
            ((SimpleDiagram3D)PieChart3D.Diagram).RotationAngleX = -35; // Döndürme derinliği
            ((SimpleDiagram3D)PieChart3D.Diagram).RotationAngleZ = -65; // Döndürme derinliği

            // Add a title to the chart and hide the legend.
            //ChartTitle chartTitle1 = new ChartTitle();
            //chartTitle1.Text = "3D Pie Chart"; // yazı
            //PieChart3D.Titles.Add(chartTitle1); // Üsteki yazıyı ekleme~
            //PieChart3D.Legend.Visible = false; //Sağda değer göstermeyi ~açıp kapatma
            PieChart3D.Legend.BackColor = Color.FromArgb(255, 232, 232); //Legend backcolor
            PieChart3D.Legend.Font = new Font("Tahoma", 10, FontStyle.Bold); //legend text boyut yazı tipi
            PieChart3D.Legend.TextColor= System.Drawing.Color.Red; // Legend text rengi

            // Add the chart to the form.
            PieChart3D.Dock = DockStyle.Fill;
            this.Controls.Add(PieChart3D);

            ChartTitle chartTitle2 = new ChartTitle();
            chartTitle2.Text = "Onaylananan =%"+ yapilandeger; // yazı
            ChartTitle chartTitle3 = new ChartTitle();
            chartTitle3.Text = "Onaylanmayan =%" + yapilmayandeger; // yazı
            PieChart3D.Titles.Add(chartTitle2); // Üsteki yazıyı ekleme
            PieChart3D.Titles.Add(chartTitle3); // Üsteki yazıyı ekleme
        }
    }
}
