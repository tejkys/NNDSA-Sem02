namespace NNDSA_Sem02
{
    public partial class Form1 : Form
    {
        private readonly SplayTree<string, Product> _tree = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var addDialog = new AddDialog();
            if (addDialog.ShowDialog() == DialogResult.OK)
            {
                if (addDialog.ResultValue is not null)
                {
                    _tree.Insert(addDialog.ResultValue.ProductNumber, addDialog.ResultValue);
                    listBoxNodes.Items.Add(new KeyValuePair<string, Product>(addDialog.ResultValue.ProductNumber, addDialog.ResultValue));
                    RefreshGui();
                }
                else
                {
                    foreach (var (key, value) in addDialog.ResultValues)
                    {
                        listBoxNodes.Items.Add(new KeyValuePair<string, Product>(key, value));
                        _tree.Insert(key, value);
                    }

                    RefreshGui();
                }
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            var findDialog = new FindDialog();
            if (findDialog.ShowDialog() == DialogResult.OK && findDialog.ResultValue is not null)
            {
                var result = _tree.Find(findDialog.ResultValue);
                if (result is not null)
                {
                    MessageBox.Show("Found: " + result.ProductNumber);
                    RefreshGui();
                }
                else
                {
                    MessageBox.Show("Not found!");
                }
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog()
                {
                    Title = "Save data",
                    DefaultExt = "csv",
                    Filter = "csv files (*.csv)|*.csv",
                    FilterIndex = 2,
                    RestoreDirectory = true,
                    CheckFileExists = false,
                    CheckPathExists = true,
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var file = saveFileDialog1.FileName;
                    var nodes = listBoxNodes.Items.Cast<KeyValuePair<string, Product>>().ToDictionary(x => x.Key, x => x.Value);
                    Persistence.Save(file, nodes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serialization went wrong: " + ex.Message);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Title = "Browse csv Files",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "csv",
                    Filter = "csv files (*.csv)|*.csv",
                    FilterIndex = 2,
                    RestoreDirectory = true,
                };
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var file = openFileDialog1.FileName;
                    var content = Persistence.Load(file);
                    _tree.Clear();
                    listBoxNodes.Items.Clear();
                    foreach (var item in content)
                    {
                        listBoxNodes.Items.Add(item);
                        _tree.Insert(item.Key, item.Value);
                    }

                    RefreshGui();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deserialization went wrong: " + ex.Message);
            }
        }

        private void RefreshGui()
        {
            pictureBoxTree.Image = _tree.GetImage();
            labelHeight.Text = "Height: " + _tree.GetHeight().ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _tree.Clear();
            listBoxNodes.Items.Clear();
            RefreshGui();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxNodes.SelectedItem is KeyValuePair<string, Product> selectedItem)
            {
                listBoxNodes.Items.Remove(selectedItem);
                _tree.Delete(selectedItem.Key);
                RefreshGui();
            }
        }

        private void buttonRunExperiment_Click(object sender, EventArgs e)
        {
            var experimentDialog = new ExperimentDialog();
            experimentDialog.ShowDialog();
        }
        
    }
}