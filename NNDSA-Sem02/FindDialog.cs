
namespace NNDSA_Sem02
{
    public partial class FindDialog : Form
    {
        public string ResultValue { get; set; }
        public FindDialog()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Name can not be empty!", "Validation");
            }
            else
            {
                ResultValue = textBoxName.Text;
                this.Close();
            }
        }
    }
}
