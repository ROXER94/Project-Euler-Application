using ICSharpCode.TextEditor.Document;
using Project_Euler_Application.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Project_Euler_Application
{
    public partial class frmMain : Form
    {
        private List<string> solvedProblems { get; set; }
        private string previousID { get; set; }
        private string currentID { get; set; }
        private string nextID { get; set; }
        private string language { get; set; }
        private IDictionary<string, string> problemsDictCSharp = new Dictionary<string, string>();
        private IDictionary<string, string> problemsDictPython = new Dictionary<string, string>();
        private IDictionary<string, string> specialDict = new Dictionary<string, string>();
        private WebClient webpage { get; set; }

        #region Initialization

        public frmMain()
        {
            InitializeComponent();
            InitializeControls();
            solvedProblems = parseProblemHistory();
            listSolvedProblems(solvedProblems);
            language = "C#";
        }

        private void InitializeControls()
        {
            // Window initialization
            this.WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            // Form initialization
            tableLayoutProblems.Left = 100;
            tableLayoutProblems.Top = 50;
            groupBoxProblems.Left = tableLayoutProblems.Left - 10;
            groupBoxProblems.Top = tableLayoutProblems.Top - 15;
            groupBoxProblems.SendToBack();
            panelSolution.Left = tableLayoutProblems.Left;
            panelSolution.Top = tableLayoutProblems.Top;
            panelSolution.Height = 600;
            panelSolution.Width = 1200;
            int buttonsLeft = (int)(this.Width * .86);
            int buttonsTop = tableLayoutProblems.Top;
            btnClose.Left = buttonsLeft;
            btnClose.Top = buttonsTop;
            btnPrevious.Left = buttonsLeft;
            btnPrevious.Top = buttonsTop + 35;
            btnNext.Top = buttonsTop + 35;
            btnNext.Left = btnPrevious.Left + btnNext.Width + 5;
            linkLabelProblem.Top = btnPrevious.Top + 35;
            linkLabelProblem.Left = buttonsLeft;
            lblTimeSolved.Top = btnPrevious.Top + 55;
            lblTimeSolved.Left = buttonsLeft;
            webpage = new WebClient();
            webpage.Encoding = Encoding.UTF8;
            showForm();
        }

        private List<string> parseProblemHistory()
        {
            List<string> solvedProblems = new List<string>();
            string[] lines = Resources.roxer94_history.Split('\n');
            foreach (string line in lines)
                solvedProblems.Add(line.Substring(0, 3));
            return solvedProblems.OrderBy(c => c).ToList();
        }

        private string parsePython(string problemID)
        {
            string[] lines = Resources.PythonURL.Split('\n');
            foreach (string line in lines)
                if (line.Substring(0, 3) == problemID)
                    return String.Join("", line.Skip(4).ToArray());
            return String.Join("", lines[0].Skip(4).ToArray());
        }

        private void txtEditor_Load(object sender, EventArgs e)
        {
            string currentDirectory = Application.StartupPath;
            FileSyntaxModeProvider fsmp = new FileSyntaxModeProvider(currentDirectory);
            HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
            txtEditor.ReadOnly = true;
        }

        #endregion Initialization

        #region Solution

        private void showForm()
        {
            this.Text = "Home";
            groupBoxProblems.Visible = true;
            tableLayoutProblems.Visible = true;
            txtEditor.Visible = false;
            txtEditor.Text = "";
            panelSolution.Visible = false;
            btnClose.Visible = false;
            btnPrevious.Visible = false;
            btnNext.Visible = false;
            linkLabelProblem.Visible = false;
            linkLabelProblem.Text = "";
            lblTimeSolved.Visible = false;
            lblTimeSolved.Text = "";
            SwitchLanguageToolStripMenuItem.Enabled = false;
            previousID = "";
            currentID = "";
            nextID = "";
            Focus();
            Refresh();
        }

        private void showSolution()
        {
            groupBoxProblems.Visible = false;
            tableLayoutProblems.Visible = false;
            txtEditor.SetHighlighting(language);
            txtEditor.Visible = true;
            panelSolution.Visible = true;
            btnClose.Visible = true;
            btnPrevious.Visible = true;
            btnNext.Visible = true;
            linkLabelProblem.Text = "From Project Euler: Problem " + currentID.TrimStart('0');
            linkLabelProblem.Visible = true;
            lblTimeSolved.Text = "Completed on " + TimeSolved(currentID);
            lblTimeSolved.Visible = true;
            SwitchLanguageToolStripMenuItem.Enabled = true;
            Focus();
            Refresh();
        }

        private void listSolvedProblems(List<string> solvedProblems)
        {
            int x = 0;
            int y = 0;
            int length = (int)(Math.Sqrt(solvedProblems.Count));
            bool firstRowComplete = false;
            tableLayoutProblems.Controls.Clear();
            tableLayoutProblems.ColumnStyles.Clear();
            tableLayoutProblems.RowStyles.Clear();
            tableLayoutProblems.ColumnCount = length;
            tableLayoutProblems.RowCount = length;
            tableLayoutProblems.Height = 5;
            tableLayoutProblems.Width = 0;
            foreach (string problemID in solvedProblems)
            {
                Button button = new Button();
                button.Click += delegate(object sender, EventArgs e) { btn_Click(sender, e, problemID); };
                button.Text = problemID;
                button.TabStop = false;
                if (x == length)
                {
                    tableLayoutProblems.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    tableLayoutProblems.Controls.Add(button, x, y);
                    x = 0;
                    y++;
                    tableLayoutProblems.Height += button.Height + button.Margin.Top + button.Margin.Bottom;
                    if (!firstRowComplete) tableLayoutProblems.Height += button.Height + button.Margin.Top + button.Margin.Bottom;
                    firstRowComplete = true;
                }
                else
                {
                    tableLayoutProblems.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    tableLayoutProblems.Controls.Add(button, x, y);
                    if (!firstRowComplete) tableLayoutProblems.Width += button.Width + button.Margin.Left + button.Margin.Right;
                }
                x++;
            }
            groupBoxProblems.Width = tableLayoutProblems.Width + 20;
            groupBoxProblems.Height = tableLayoutProblems.Height + 20;
        }

        private void getProblemSolution(string problemID)
        {
            try
            {
                string source = "";
                string githubURL = "";
                if (language == "C#")
                {
                    if (!problemsDictCSharp.ContainsKey(problemID))
                    {

                        githubURL = "https://raw.githubusercontent.com/ROXER94/Project-Euler-CSharp/master/ProjectEuler/Problem" + problemID + ".cs";
                        problemsDictCSharp[problemID] = webpage.DownloadString(githubURL);
                    }
                    source = problemsDictCSharp[problemID];
                }
                else if (language == "Python")
                {
                    if (!problemsDictPython.ContainsKey(problemID))
                    {
                        githubURL = parsePython(problemID);
                        problemsDictPython[problemID] = webpage.DownloadString(githubURL);
                    }
                    source = problemsDictPython[problemID];
                }
                currentID = problemID;
                this.Text = "Problem " + problemID;
                txtEditor.Text = source;
                showSolution();
                previousID = getPreviousID(problemID);
                nextID = getNextID(problemID);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The solution to this problem cannot be displayed.\r\n\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getPreviousID(string problemID)
        {
            int index = solvedProblems.IndexOf(problemID);
            string previousID;
            if (index == 0) previousID = solvedProblems.Last();
            else previousID = solvedProblems[index - 1];
            return previousID;
        }

        private string getNextID(string problemID)
        {
            int index = solvedProblems.IndexOf(problemID);
            string nextID;
            if (index == solvedProblems.Count - 1) nextID = solvedProblems.First();
            else nextID = solvedProblems[index + 1];
            return nextID;
        }

        private void btn_Click(object sender, EventArgs e, string problemID)
        {
            currentID = problemID;
            getProblemSolution(problemID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            showForm();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            getProblemSolution(previousID);
            Refresh();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            getProblemSolution(nextID);
            Refresh();
        }

        private void linkLabelProblem_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenResource("https://projecteuler.net/problem=" + currentID.TrimStart('0'));
        }

        private void OpenResource(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open " + url + "\r\n\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string TimeSolved(string problemID)
        {
            string[] lines = Resources.roxer94_history.Split('\n');
            foreach (string line in lines)
                if (line.Substring(0, 3) == problemID)
                {
                    string day = line.Substring(5, 2);
                    day = day.TrimStart('0');
                    string month = line.Substring(8, 3);
                    string year = line.Substring(12, 2);
                    string hour = line.Substring(16, 2);
                    if (hour == "00") hour = "12";
                    hour = hour.TrimStart('0');
                    string minute = line.Substring(19, 2);
                    string period = "";
                    if (Int32.Parse(hour) > 12)
                    {
                        period = "PM";
                        hour = (Int32.Parse(hour) - 12).ToString();
                    }
                    else period = "AM";
                    return String.Format("{0} {1}, 20{2}, {3}:{4} {5}", month, day, year, hour, minute, period);
                }
            return "";
        }

        #endregion Solution

        #region ToolStrip

        private void viewSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Project Euler Application Source";
            loadSpecialPage("https://raw.githubusercontent.com/ROXER94/Project-Euler-Application/master/Project-Euler-Application/frmMain.cs", text);
        }

        private void SwitchLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchLanguageToolStripMenuItem.Text = "View " + language;
            if (language == "C#") language = "Python";
            else if (language == "Python") language = "C#";
            getProblemSolution(currentID);
            Refresh();
        }

        private void viewFunctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Project Euler Common Functions";
            loadSpecialPage("https://raw.githubusercontent.com/ROXER94/Project-Euler-CSharp/master/ProjectEuler/Common/Functions.cs", text);
        }

        private void loadSpecialPage(string githubURL, string text)
        {
            try
            {
                string source = "";
                previousID = "";
                nextID = "";
                if (!specialDict.ContainsKey(text))
                    specialDict[text] = webpage.DownloadString(githubURL);
                source = specialDict[text];
                groupBoxProblems.Visible = false;
                tableLayoutProblems.Visible = false;
                txtEditor.SetHighlighting("C#");
                txtEditor.Text = source;
                txtEditor.Visible = true;
                panelSolution.Visible = true;
                this.Text = text;
                btnClose.Visible = true;
                btnPrevious.Visible = false;
                btnNext.Visible = false;
                linkLabelProblem.Visible = false;
                lblTimeSolved.Visible = false;
                SwitchLanguageToolStripMenuItem.Enabled = false;
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(text + " cannot be displayed.\r\n\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Are you sure you want to quit?", "Project Euler Application", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            switch (dr)
            {
                case DialogResult.Yes:
                    {
                        Application.Exit();
                        break;
                    }
                case DialogResult.No: break;
            }
        }

        #endregion ToolStrip

        #region Extra

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && nextID != "") btnNext_Click(this, e);
            if (e.KeyCode == Keys.Left && previousID != "") btnPrevious_Click(this, e);
            if (e.KeyCode == Keys.Escape) { btnClose.Focus(); btnClose_Click(this, e); }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion Extra
    }
}