using System;
using System.Windows.Forms;
using App.src.modules.SignUp;

namespace App
{
    public partial class SignUp : Form
    {
        Home home;
        SignUpController _controller;
        public SignUp(Home form)
        {
            InitializeComponent();
            this.home = form;
            _controller = new SignUpController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.signup(home, textBox1, textBox2, textBox3, this);
        }
    }
}
