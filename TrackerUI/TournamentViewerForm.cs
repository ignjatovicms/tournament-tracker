using System.ComponentModel;
using TrackerLibrary.Models;
using TrackerLibrary;
namespace TrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();

        BindingList<int> roundsBinding = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();


        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            LoadFormData();
            LoadRounds();
            LoadMatchups(1);
        }

        private void LoadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void LoadRounds()
        {

            rounds.Clear();

            // Get distinct round numbers
            var distinctRounds = tournament.Rounds
                .SelectMany(round => round)
                .Select(m => m.MatchupRound)
                .Distinct()
                .OrderBy(r => r);

            foreach (int round in distinctRounds)
            {
                rounds.Add(round);
            }

            WireUpRoundsLists();
        }


        //rounds = new BindingList<int>(); //?    
        //rounds.Clear();

        //rounds.Add(1);
        //int currRound = 1;

        //foreach (List<MatchupModel> matchups in tournament.Rounds)
        //{
        //    if (matchups.Count == 0)
        //    {
        //        continue;
        //    }

        //    var firstMatchup = matchups[0];
        //    if (firstMatchup.MatchupRound > currRound)
        //    {
        //        currRound = firstMatchup.MatchupRound;
        //        rounds.Add(currRound);
        //    }

        //if (matchups.First().MatchupRound > currRound)
        //{
        //    currRound = matchups.First().MatchupRound;
        //    rounds.Add(currRound);
        //}
    //}

    //WireUpRoundsLists();
    //    }
        private void WireUpRoundsLists()
        {
            roundDropDown.DataSource = null;
            roundDropDown.DataSource = rounds;
        }

        private void WireUpMatchupsLists()
        {
            MatchupListBox.DataSource = selectedMatchups;
            MatchupListBox.DisplayMember = "DisplayName";
        }

        private void LoadMatchups(int round)
        {
            selectedMatchups.Clear();

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.Count == 0) 
                    continue;

                if (matchups.First().MatchupRound == round)
                {
                    foreach (MatchupModel m in matchups)
                    {
                        if (m.Winner == null || !unplayedOnlyCheckBox.Checked)
                        {
                            selectedMatchups.Add(m);
                        }
                    }
                }
            }

            WireUpMatchupsLists();

            if (selectedMatchups.Count > 0)
            {
                LoadMatchup(selectedMatchups.First());
            }

            DisplayMatchupInfo();
        }

        private void DisplayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);

            teamOneName.Visible = isVisible;
            teamOneScoreLabel.Visible = isVisible;
            teamOneScoreValue.Visible = isVisible;

            teamTwoName.Visible = isVisible;
            teamTwoScoreLabel.Visible = isVisible;
            teamTwoScoreValue.Visible = isVisible;

            versusLabel.Visible = isVisible;
            ScoreButton.Visible = isVisible;
        }
        
        private string ValidateData()
        {
            string output = "";

            double teamOneScore = 0;
            double teamTwoScore = 0;

            bool scoreOneValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);
            bool scoreTwoValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

            if (!scoreOneValid)
            {
                output = "The Score One value is not a valid number.";
            }
            else if (!scoreTwoValid)
            {
                output = "The Score Two value is not a valid number.";

            }
            else if (teamOneScore == 0 && teamTwoScore == 0)
            {
                output = "you did not enter a score for either team.";
            }
            else if (teamOneScore == teamTwoScore)
            {
                output = "We do not allow ties in this application.";
            }

            return output;
        }


        private void ScoreButton_Click(object sender, EventArgs e)
        {
            if (MatchupListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a matchup first");
                return;
            }

            string errorMessage = ValidateData();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show($"Input error: {errorMessage}");
                return;
            }
            MatchupModel m = (MatchupModel)MatchupListBox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);

                        if (scoreValid)
                        {
                            m.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 1.");
                            return;
                        }
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

                        if (scoreValid)
                        {
                            m.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 2.");
                            return;
                        }
                    }
                }
            }

            try
            {
                TournamentLogic.UpdateTournamentResults(tournament);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The application had the following error: {ex.Message}");
                return;
            }

            LoadMatchups((int)roundDropDown.SelectedItem);
        }

        private void MatchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup((MatchupModel)MatchupListBox.SelectedItem);
        }

        private void LoadMatchup(MatchupModel m)
        {
            teamOneName.Text = "";
            teamOneScoreValue.Text = "";
            teamTwoName.Text = "";
            teamTwoScoreValue.Text = "";

            if (m == null) return;

            // Handle first entry
            if (m.Entries.Count > 0 && m.Entries[0].TeamCompeting != null)
            {
                teamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                teamOneScoreValue.Text = m.Entries[0].Score.ToString();
            }

            // Handle second entry or bye
            if (m.Entries.Count > 1 && m.Entries[1].TeamCompeting != null)
            {
                teamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
                teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
            }
            else if (m.Entries.Count == 1) // Bye week
            {
                teamTwoName.Text = "<bye>";
                teamTwoScoreValue.Text = "0";
            }

            //for (int i = 0; i < m.Entries.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        if (m.Entries[0].TeamCompeting != null)
            //        {
            //            teamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
            //            teamOneScoreValue.Text = m.Entries[0].Score.ToString();

            //            teamTwoName.Text = "<bye>";
            //            teamTwoScoreValue.Text = "0";
            //        }
            //        else
            //        {
            //            teamOneName.Text = "Not yet set";
            //            teamOneScoreValue.Text = "";
            //        }
            //    }

            //    if (i == 1)
            //    {
            //        if (m.Entries[1].TeamCompeting != null)
            //        {
            //            teamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
            //            teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
            //        }
            //        else
            //        {
            //            teamTwoName.Text = "Not yet set";
            //            teamTwoScoreValue.Text = "";
            //        }
            //    }
            //}
        }
        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDown.SelectedItem);
        }

        private void unplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundDropDown.SelectedItem);
        }
    }
}