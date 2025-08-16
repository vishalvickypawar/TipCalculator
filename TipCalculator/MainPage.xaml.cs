namespace TipCalculator
{
    public partial class MainPage : ContentPage
    {
        decimal billAmount = 0.00m;
        int tip = 0;
        decimal tipAmount = 0.00m;
        int split = 1;
        decimal amountPerPerson = 0.00m;

        private void UpdateDisplay()
        {
            lblTip.Text = tip.ToString();
            lblTipAmount.Text = tipAmount.ToString("F2");
            lblSplit.Text = split.ToString();
            lblSplitAmount.Text = amountPerPerson.ToString("F2");
        }

        public MainPage()
        {
            InitializeComponent();
            UpdateDisplay();
        }

        private void tbTotal_Completed(object sender, EventArgs e)
        {
            try
            {
                billAmount = decimal.Parse(tbTotal.Text);
                Calculate();
            } catch(Exception) { }
            tbTotal.Unfocus();
            slrTip.Focus();
        }

        private void Calculate()
        {
            tipAmount = billAmount * tip / 100;
            amountPerPerson = (billAmount + tipAmount) / split;
            UpdateDisplay();
        }

        private void slrTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)Math.Round(slrTip.Value);
            slrTip.Value = tip;
            Calculate();
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if (split > 1)
                split--;
            Calculate();
        }

        private void brnPlus_Clicked(object sender, EventArgs e)
        {
            split++;
            Calculate();
        }
    }
}
