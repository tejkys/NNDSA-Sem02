
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Windows.Forms;

namespace NNDSA_Sem02
{
    public partial class ExperimentDialog : Form
    {
        private ExperimentResult? _resultFile;
        private ExperimentResult? _result;
        public class ExperimentResult
        {
            public Dictionary<int, int> ResultsAmounts { get; set; } = new();
            public List<double> CumulativeAvg { get; set; } = new();
            public List<List<int>> ExperimentNodes { get; set; } = new();
            public int ExperimentsAmount { get; set; } = 0;
            public int NodesAmount { get; set; } = 0;
            public int Max { get; set; } = 0;
            public int Min { get; set; } = Int32.MaxValue;
            public int Sum { get; set; } = 0;
            public int Modus { get; set; } = 0;
            public double Average { get; set; } = 0;
        }

        public ExperimentDialog()
        {
            InitializeComponent();
        }



        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var useFile = (bool)(e.Argument ?? false);
            if (useFile && _resultFile is null)
            {
                MessageBox.Show("No file loaded!");
                return;
            }
            _result = new ExperimentResult()
            {
                ExperimentsAmount =  (int)numericUpDownExperiments.Value,
                NodesAmount = (int)numericUpDownNodes.Value,
            };

            buttonOk.Invoke(() => buttonOk.Enabled = false);
            buttonSave.Invoke(() => buttonSave.Enabled = false);
            buttonLoad.Invoke(() => buttonLoad.Enabled = false);
            buttonRunFile.Invoke(() => buttonRunFile.Enabled = false);
            progressBar1.Invoke(() => progressBar1.Maximum = _result.ExperimentsAmount);
            progressBar1.Invoke(() => progressBar1.Value = 0);

            for (var i = 1; i < _result.ExperimentsAmount + 1; i++)
            {
                var tree = new SplayTree<string, Product>();
                var ids = useFile ? _resultFile.ExperimentNodes[i-1] : Enumerable.Range(1, _result.NodesAmount).OrderBy(i => Guid.NewGuid()).ToList();
                _result.ExperimentNodes.Add(ids);
                foreach (var id in ids)
                {
                    tree.Insert(id.ToString(), new Product { ProductNumber = id.ToString() });
                }

                var height = tree.GetHeight();
                if (height > _result.Max)
                {
                    _result.Max = height;
                }
                if (height < _result.Min)
                {
                    _result.Min = height;
                }

                _result.Sum += height;
                _result.Average = ((double)_result.Sum / (double)i);
                _result.ResultsAmounts[height] = _result.ResultsAmounts.ContainsKey(height) ? _result.ResultsAmounts[height] + 1 : 1;
                _result.Modus = _result.ResultsAmounts.MaxBy(m => m.Value).Key;
                _result.CumulativeAvg.Add(_result.Average);
                labelArithmeticMean.Invoke(() => labelArithmeticMean.Text = _result.Average.ToString("0.00000"));
                labelMax.Invoke(() => labelMax.Text = _result.Max.ToString());
                labelMin.Invoke(() => labelMin.Text = _result.Min.ToString());
                labelModus.Invoke(() => labelModus.Text = _result.Modus.ToString());
                progressBar1.Invoke(() => progressBar1.Value += 1);

            }
            buttonOk.Invoke(() => buttonOk.Enabled = true);
            buttonSave.Invoke(() => buttonSave.Enabled = true);
            buttonLoad.Invoke(() => buttonLoad.Enabled = true);
            buttonRunFile.Invoke(() => buttonRunFile.Enabled = true);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Title = "Browse json Files",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "json",
                    Filter = "json files (*.json)|*.json",
                    FilterIndex = 2,
                    RestoreDirectory = true,
                };
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _resultFile = JsonSerializer.Deserialize<ExperimentResult>(File.ReadAllText(openFileDialog1.FileName));
                    labelArithmeticMean.Text = _resultFile.Average.ToString("0.00000");
                    labelMax.Text = _resultFile.Max.ToString();
                    labelMin.Text = _resultFile.Min.ToString();
                    labelModus.Text = _resultFile.Modus.ToString();
                    numericUpDownExperiments.Value = _resultFile.ExperimentsAmount;
                    numericUpDownNodes.Value = _resultFile.NodesAmount;
                    labelFile.Text = Path.GetFileName(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deserialization went wrong: " + ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog()
                {
                    Title = "Save data",
                    DefaultExt = "json",
                    Filter = "json files (*.json)|*.json",
                    FilterIndex = 2,
                    RestoreDirectory = true,
                    CheckFileExists = false,
                    CheckPathExists = true,
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, JsonSerializer.Serialize(_result));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Serialization went wrong: " + ex.Message);
            }
        }

        private void buttonRunFile_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(argument: true);

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _resultFile = null;
            labelFile.Text = "none";
            backgroundWorker1.RunWorkerAsync(argument: false);
        }

    }
}
