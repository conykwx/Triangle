using System;
using System.Drawing;
using System.Windows.Forms;

namespace RectangleAreaCalculator
{
    public class MainForm : Form
    {
        private TextBox txtWidth;
        private TextBox txtHeight;
        private Button btnCalculate;
        private Label lblResult;

        public MainForm()
        {
            this.Text = "Площа прямокутника";
            this.Size = new Size(400, 250);

            var lblWidth = new Label { Text = "Ширина:", Location = new Point(20, 20), AutoSize = true };
            txtWidth = new TextBox { Location = new Point(100, 20), Width = 100 };
            var lblHeight = new Label { Text = "Висота:", Location = new Point(20, 60), AutoSize = true };
            txtHeight = new TextBox { Location = new Point(100, 60), Width = 100 };
            btnCalculate = new Button { Text = "ПОРАХУВАТИ", Location = new Point(20, 100), Width = 180 };
            lblResult = new Label { Text = "Результат: ", Location = new Point(20, 140), AutoSize = true };

            btnCalculate.Click += BtnCalculate_Click;

            this.Controls.Add(lblWidth);
            this.Controls.Add(txtWidth);
            this.Controls.Add(lblHeight);
            this.Controls.Add(txtHeight);
            this.Controls.Add(btnCalculate);
            this.Controls.Add(lblResult);
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            txtWidth.BackColor = Color.White;
            txtHeight.BackColor = Color.White;

            bool isWidthValid = double.TryParse(txtWidth.Text, out double width) && width > 0;
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height) && height > 0;

            if (isWidthValid && isHeightValid)
            {
                double area = width * height;
                lblResult.Text = $"Результат: {area}";
            }
            else
            {
                lblResult.Text = "Некоректні дані!";

                if (!isWidthValid)
                    txtWidth.BackColor = Color.Red;

                if (!isHeightValid)
                    txtHeight.BackColor = Color.Red;
            }
        }


        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
