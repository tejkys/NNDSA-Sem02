
using System.Globalization;

namespace NNDSA_Sem02
{
    public partial class AddDialog : Form
    {
        public Product? ResultValue { get; set; }
        public Dictionary<string, Product> ResultValues { get; set; } = new();
        public AddDialog()
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
                ResultValue = new Product() { ProductNumber = textBoxName.Text };
                this.Close();
            }
        }
        private void buttonMultipleAdd_Click(object sender, EventArgs e)
        {
            var ids = Enumerable.Range(1, (int)numericUpDownMultipleAmount.Value).OrderBy(i => Guid.NewGuid()).ToList();
            foreach (var id in ids)
            {
                ResultValues.Add(id.ToString("D"+ (int)numericUpDownMultipleAmount.Value.ToString(CultureInfo.InvariantCulture).Length), new Product { ProductNumber = id.ToString() });
            }

        }
    }
}
