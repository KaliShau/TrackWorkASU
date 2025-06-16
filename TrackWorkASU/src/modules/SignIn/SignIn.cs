using System;
using System.Windows.Forms;
using App.src.modules.SignIn;

namespace App
{
    public partial class SignIn : Form
    {
        Home home;
        SignInController _controller;
        public SignIn(Home form)
        {
            InitializeComponent();
            this.home = form;
            _controller = new SignInController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.signin(home, textBox1, textBox2, this);
        }
    }
}
