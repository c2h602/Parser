using Parser.Core;
using Parser.Habr;

namespace Parser
{
    public partial class Form1 : Form
    {

        ParserWorker<string[]> parser;
        
        
        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(new HabrParser());
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }
        
        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            ListTitles.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done!");
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            parser.Settings = new HabrSettings((int)NumericStart.Value, (int)NumericEnd.Value);
            parser.Start();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            parser.Stop();
        }

        private void NumericEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void EndPoint_Click(object sender, EventArgs e)
        {

        }

        private void NumericStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void StartPoint_Click(object sender, EventArgs e)
        {

        }

        
    }
}