using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using PluginContracts;
using OutputHelperLib;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GroupDataObj;


namespace ConversationSplitter
{
    public class ConversationSplitter : Plugin
    {


        public string[] InputType { get; } = { "String" };
        public string OutputType { get; } = "GroupData";

        public Dictionary<int, string> OutputHeaderData { get; set; } = new Dictionary<int, string>() { { 0, "TokenizedText" } };
        public bool InheritHeader { get; } = false;

        #region Plugin Details and Info

        public string PluginName { get; } = "Conversation Splitter";
        public string PluginType { get; } = "Dyads & Groups";
        public string PluginVersion { get; } = "1.0.1";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "Split transcripts into GroupData. With this plugin, you need to specify the specific Speaker ID tags in your transcript files. This plugin will then read each transcript and attempt to smartly break apart the text from each speaker into their own text. " + 
                                                   "What this means is that you must already know what *all* of the speaker tags are across *all* of your transcripts. If you do not have a comprehensive list of your speaker tags, the \"Detect Speakers\" plugin can help you discover all of them.";
        public string PluginTutorial { get; } = "https://youtu.be/dApAhVlmv-U";
        public bool TopLevel { get; } = false;


        public Icon GetPluginIcon
        {
            get
            {
                return Properties.Resources.icon;
            }
        }

        #endregion


        private string SpeakerListText { get; set; } = "Participant 1:" + Environment.NewLine + "Participant 2:";
        private bool multiLine { get; set; } = true;
        private string regexRepl { get; set; } = "";

        public void ChangeSettings()
        {

            using (var form = new SettingsForm_ConversationSplitter(SpeakerListText, multiLine, regexRepl))
            {


                form.Icon = Properties.Resources.icon;
                form.Text = PluginName;

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SpeakerListText = form.SpeakerListText;
                    multiLine = form.multiLine;
                    regexRepl = form.regexRepl;
                }
            }

        }





        public Payload RunPlugin(Payload Input)
        {



            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            


            for (int i = 0; i < Input.StringList.Count; i++)
            {



                //setting everything up
                Dictionary<string, List<string>> Text_Split = new Dictionary<string, List<string>>();
                string[] readText_Lines = NewlineClean.Split(Input.StringList[i]);
                int NumberOfLines = readText_Lines.Length;
                string PreviousSpeaker = "";
                GroupData group = new GroupData();
                Dictionary<ulong, Tuple<string, int>> TurnTracker = new Dictionary<ulong, Tuple<string, int>>();

                ulong turnCounter = 0;

                #region Parse Out Line into Speakers
              
                for (int j = 0; j < NumberOfLines; j++)
                {

                    string CurrentLine = readText_Lines[j];

                    if (regexRepl.Length > 0)
                    {
                        CurrentLine = CompiledRegex.Replace(CurrentLine, "").Trim();
                    }
                    else
                    {
                        CurrentLine = CurrentLine.Trim();
                    }


                    //if the line is empty, move along... move along
                    if (CurrentLine.Length == 0)
                    {
                        continue;
                    }

                    bool FoundSpeaker = false;

                    //loop through each speaker in list to see if the line starts with their name
                    for (int k = 0; k < SpeakerListLength; k++)
                    {

                        // here's what we do if we find a match
                        if (CurrentLine.StartsWith(SpeakerList[k]))
                        {

                            FoundSpeaker = true;
                            PreviousSpeaker = SpeakerList[k];

                            //clean up the line to remove the speaker tag from the beginning
                            int Place = CurrentLine.IndexOf(SpeakerList[k]);
                            CurrentLine = CurrentLine.Remove(Place, SpeakerList[k].Length).Insert(Place, "").Trim() + "\r\n";

                            if (Text_Split.ContainsKey(SpeakerList[k]))
                            {

                                Text_Split[SpeakerList[k]].Add(CurrentLine.Trim());
                            }
                            else
                            {
                                Text_Split.Add(SpeakerList[k], new List<string>() { CurrentLine.Trim() });
                            }

                            //make sure we track where the line is located
                            TurnTracker.Add(turnCounter, new Tuple<string, int>(SpeakerList[k], Text_Split[SpeakerList[k]].Count - 1));
                            turnCounter++;

                            //break to the next line in the text
                            break;
                        }


                    }
                    //what we will do if no speaker was found
                    if ((FoundSpeaker == false) && (PreviousSpeaker != ""))
                    {
                        if (multiLine)
                        {
                            Text_Split[PreviousSpeaker][Text_Split[PreviousSpeaker].Count - 1] += CurrentLine.Trim() + "\r\n";
                        }
                    }

                    //end of for loop through each line
                }
                #endregion

                StringBuilder segID = new StringBuilder();

                foreach (KeyValuePair<string, List<string>> entry in Text_Split)
                {
                    group.People.Add(new Person(entry.Key, entry.Value));
                    segID.Append(entry.Key + ";");
                }

                group.TurnTracker = TurnTracker;

                pData.ObjectList.Add(group);
                pData.SegmentID.Add(segID.ToString());
                pData.SegmentNumber.Add(Input.SegmentNumber[i]);

            }

            return (pData);

        }







        private static Regex NewlineClean { get; } = new Regex(@"[\r\n]+", RegexOptions.Compiled);
        private Regex CompiledRegex { get; set; }
        private string[] SpeakerList { get; set; }
        private int SpeakerListLength { get; set; }

        public void Initialize()
        {
            if (regexRepl.Length > 0) CompiledRegex = new Regex(regexRepl, RegexOptions.Compiled);
            SpeakerList = NewlineClean.Split(SpeakerListText);
            SpeakerList = SpeakerList.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            SpeakerListLength = SpeakerList.Length;
        }







        public bool InspectSettings()
        {
            return true;
        }

        public Payload FinishUp(Payload Input)
        {
            return (Input);
        }




        #region Import/Export Settings
        public void ImportSettings(Dictionary<string, string> SettingsDict)
        {
            SpeakerListText = SettingsDict["SpeakerListText"];
            multiLine = Boolean.Parse(SettingsDict["multiLine"]);
            regexRepl = SettingsDict["regexRepl"];
        }

        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> SettingsDict = new Dictionary<string, string>();

            SettingsDict.Add("SpeakerListText", SpeakerListText);
            SettingsDict.Add("multiLine", multiLine.ToString());
            SettingsDict.Add("regexRepl", regexRepl);
        
            return (SettingsDict);
        }
        #endregion





    }
}
