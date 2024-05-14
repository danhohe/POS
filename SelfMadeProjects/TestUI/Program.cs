using System.Drawing;

namespace Program {
    class Program {
        private static void Main() {
            System.Windows.Forms.Form mainForm = new System.Windows.Forms.Form();
            System.Windows.Forms.Label lblFirst = new System.Windows.Forms.Label();
            mainForm.Width = 300;
            mainForm.Height = 400; 
            lblFirst.Text = "Hello World";
            lblFirst.Location = new System.Drawing.Point(150, 200);
            mainForm.Controls.Add(lblFirst);
            System.Windows.Forms.Application.Run(mainForm);
        }   
    }
}
