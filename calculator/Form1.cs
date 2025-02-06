namespace calculator
{
    public partial class Form1 : Form
    {
        private calculator calculator = new calculator();
        public Form1()
        {
            InitializeComponent();
        }

        private void numberButton_click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                calculator.appendInput(button.Text, textBox2);
            }
        }

        public void operatorButton_click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            
            if (button != null)
            {
                double result = calculator.setOperator(button.Text, textBox2.Text);
                textBox2.Text = result.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                double newValue = double.Parse(textBox2.Text);
                double result = calculator.evaluate(newValue);
                textBox2.Text = result.ToString();
                calculator.clear();
            }
        }
    }
}
