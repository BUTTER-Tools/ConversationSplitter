using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConversationSplitter
{
    internal partial class SettingsForm_ConversationSplitter : Form
    {


        #region Get and Set Options

        public string SpeakerListText { get; set; }
        public bool multiLine { get; set; }
        public string regexRepl { get; set; }


       #endregion



        public SettingsForm_ConversationSplitter(string speakerList, bool speakerMultiLine, string regExp)
        {
            InitializeComponent();

            SpeakerTags.Text = speakerList;
            SpeakersMultipleLinesCheckbox.Checked = speakerMultiLine;
            RegexTextBox.Text = regExp;



        }






        

        private void OKButton_Click(object sender, System.EventArgs e)
        {

            
            this.SpeakerListText = SpeakerTags.Text;
            this.multiLine = SpeakersMultipleLinesCheckbox.Checked;

            try
            {
                Regex Test = new Regex(RegexTextBox.Text, RegexOptions.Compiled);
            }
            catch
            {
                MessageBox.Show("Your regular expression does not appear to be valid.", "Segmentation Parameter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.regexRepl = RegexTextBox.Text;



            this.DialogResult = DialogResult.OK;
        }
    }
}
