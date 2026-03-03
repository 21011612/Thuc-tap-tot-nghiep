namespace SELAB
{
    partial class frmThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelCards = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblValTongTB = new System.Windows.Forms.Label();
            this.lblTongTB = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblValSanSang = new System.Windows.Forms.Label();
            this.lblSanSang = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblValLichDat = new System.Windows.Forms.Label();
            this.lblLichDat = new System.Windows.Forms.Label();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblValBaoTri = new System.Windows.Forms.Label();
            this.lblBaoTri = new System.Windows.Forms.Label();
            this.tableLayoutPanelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartTrangThai = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLichDat = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.pnlTop.SuspendLayout();
            this.tableLayoutPanelCards.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            this.tableLayoutPanelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLichDat)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1000, 60);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Dashboard Thống Kê";

            // tableLayoutPanelCards
            this.tableLayoutPanelCards.ColumnCount = 4;
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.Controls.Add(this.pnlCard1, 0, 0);
            this.tableLayoutPanelCards.Controls.Add(this.pnlCard2, 1, 0);
            this.tableLayoutPanelCards.Controls.Add(this.pnlCard3, 2, 0);
            this.tableLayoutPanelCards.Controls.Add(this.pnlCard4, 3, 0);
            this.tableLayoutPanelCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelCards.Location = new System.Drawing.Point(0, 60);
            this.tableLayoutPanelCards.Name = "tableLayoutPanelCards";
            this.tableLayoutPanelCards.Height = 120;
            this.tableLayoutPanelCards.Padding = new System.Windows.Forms.Padding(10);

            // Helper function to setup Card Panels (To save lines)
            void SetupCard(System.Windows.Forms.Panel pnl, System.Windows.Forms.Label lblT, System.Windows.Forms.Label lblV, string text, System.Drawing.Color color)
            {
                pnl.BackColor = color;
                pnl.Controls.Add(lblT);
                pnl.Controls.Add(lblV);
                pnl.Dock = System.Windows.Forms.DockStyle.Fill;
                pnl.Margin = new System.Windows.Forms.Padding(10);

                lblT.AutoSize = true;
                lblT.Font = new System.Drawing.Font("Segoe UI", 12F);
                lblT.ForeColor = System.Drawing.Color.White;
                lblT.Location = new System.Drawing.Point(15, 15);
                lblT.Text = text;

                lblV.AutoSize = true;
                lblV.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
                lblV.ForeColor = System.Drawing.Color.White;
                lblV.Location = new System.Drawing.Point(15, 45);
                lblV.Text = "0";
            }

            SetupCard(this.pnlCard1, this.lblTongTB, this.lblValTongTB, "Tổng Thiết Bị", System.Drawing.Color.FromArgb(41, 128, 185));
            SetupCard(this.pnlCard2, this.lblSanSang, this.lblValSanSang, "Đang Sẵn Sàng", System.Drawing.Color.FromArgb(39, 174, 96));
            SetupCard(this.pnlCard3, this.lblLichDat, this.lblValLichDat, "Lịch Đặt Chờ", System.Drawing.Color.FromArgb(243, 156, 18));
            SetupCard(this.pnlCard4, this.lblBaoTri, this.lblValBaoTri, "Đang Bảo Trì", System.Drawing.Color.FromArgb(192, 57, 43));

            // tableLayoutPanelCharts
            this.tableLayoutPanelCharts.ColumnCount = 2;
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelCharts.Controls.Add(this.chartTrangThai, 0, 0);
            this.tableLayoutPanelCharts.Controls.Add(this.chartLichDat, 1, 0);
            this.tableLayoutPanelCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCharts.Location = new System.Drawing.Point(0, 180);
            this.tableLayoutPanelCharts.Name = "tableLayoutPanelCharts";
            this.tableLayoutPanelCharts.Padding = new System.Windows.Forms.Padding(10);

            // chartTrangThai (Pie Chart)
            chartArea1.Name = "ChartArea1";
            this.chartTrangThai.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTrangThai.Legends.Add(legend1);
            this.chartTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTrangThai.Name = "chartTrangThai";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Trạng Thái";
            this.chartTrangThai.Series.Add(series1);
            this.chartTrangThai.Titles.Add("Tỷ lệ trạng thái thiết bị");

            // chartLichDat (Column Chart)
            chartArea2.Name = "ChartArea1";
            this.chartLichDat.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartLichDat.Legends.Add(legend2);
            this.chartLichDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLichDat.Name = "chartLichDat";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Lượt Đặt";
            this.chartLichDat.Series.Add(series2);
            this.chartLichDat.Titles.Add("Thống kê lượt đặt theo loại thiết bị");

            // frmThongKe
            this.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tableLayoutPanelCharts);
            this.Controls.Add(this.tableLayoutPanelCards);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKe";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmThongKe_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tableLayoutPanelCards.ResumeLayout(false);
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard4.ResumeLayout(false);
            this.tableLayoutPanelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLichDat)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCards;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblTongTB;
        private System.Windows.Forms.Label lblValTongTB;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblSanSang;
        private System.Windows.Forms.Label lblValSanSang;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblLichDat;
        private System.Windows.Forms.Label lblValLichDat;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblBaoTri;
        private System.Windows.Forms.Label lblValBaoTri;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrangThai;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLichDat;
    }
}