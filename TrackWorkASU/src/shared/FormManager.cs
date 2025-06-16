using System.Windows.Forms;

namespace App.src.shared
{
    public class FormManager
    {
        public void changeForm(Form form, Panel panel)
        {
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Clear();
            panel.Controls.Add(form);
            form.Show();
        }
    }
}
