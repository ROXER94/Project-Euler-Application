namespace Project_Euler_Application
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnClose = new System.Windows.Forms.Button();
            this.txtEditor = new ICSharpCode.TextEditor.TextEditorControl();
            this.panelSolution = new System.Windows.Forms.Panel();
            this.tableLayoutProblems = new System.Windows.Forms.TableLayoutPanel();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SwitchLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewFunctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.linkLabelProblem = new System.Windows.Forms.LinkLabel();
            this.groupBoxProblems = new System.Windows.Forms.GroupBox();
            this.lblTimeSolved = new System.Windows.Forms.Label();
            this.panelSolution.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1466, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 41);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close Solution";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtEditor
            // 
            this.txtEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEditor.Highlighting = null;
            this.txtEditor.Location = new System.Drawing.Point(0, 0);
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.ShowVRuler = false;
            this.txtEditor.Size = new System.Drawing.Size(604, 290);
            this.txtEditor.TabIndex = 7;
            this.txtEditor.TabStop = false;
            this.txtEditor.Load += new System.EventHandler(this.txtEditor_Load);
            // 
            // panelSolution
            // 
            this.panelSolution.Controls.Add(this.txtEditor);
            this.panelSolution.Location = new System.Drawing.Point(12, 12);
            this.panelSolution.Name = "panelSolution";
            this.panelSolution.Size = new System.Drawing.Size(604, 290);
            this.panelSolution.TabIndex = 6;
            this.panelSolution.TabStop = true;
            // 
            // tableLayoutProblems
            // 
            this.tableLayoutProblems.ColumnCount = 1;
            this.tableLayoutProblems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutProblems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutProblems.Location = new System.Drawing.Point(12, 31);
            this.tableLayoutProblems.Name = "tableLayoutProblems";
            this.tableLayoutProblems.RowCount = 1;
            this.tableLayoutProblems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutProblems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 503F));
            this.tableLayoutProblems.Size = new System.Drawing.Size(1448, 503);
            this.tableLayoutProblems.TabIndex = 5;
            this.tableLayoutProblems.TabStop = true;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewSourceToolStripMenuItem,
            this.SwitchLanguageToolStripMenuItem,
            this.viewFunctionsToolStripMenuItem,
            this.toolStripSeparator,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewSourceToolStripMenuItem
            // 
            this.viewSourceToolStripMenuItem.Name = "viewSourceToolStripMenuItem";
            this.viewSourceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.viewSourceToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.viewSourceToolStripMenuItem.Text = "View Source";
            this.viewSourceToolStripMenuItem.Click += new System.EventHandler(this.viewSourceToolStripMenuItem_Click);
            // 
            // SwitchLanguageToolStripMenuItem
            // 
            this.SwitchLanguageToolStripMenuItem.Name = "SwitchLanguageToolStripMenuItem";
            this.SwitchLanguageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.SwitchLanguageToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.SwitchLanguageToolStripMenuItem.Text = "View {Language}";
            this.SwitchLanguageToolStripMenuItem.Click += new System.EventHandler(this.SwitchLanguageToolStripMenuItem_Click);
            // 
            // viewFunctionsToolStripMenuItem
            // 
            this.viewFunctionsToolStripMenuItem.Name = "viewFunctionsToolStripMenuItem";
            this.viewFunctionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.viewFunctionsToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.viewFunctionsToolStripMenuItem.Text = "View Functions";
            this.viewFunctionsToolStripMenuItem.Click += new System.EventHandler(this.viewFunctionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(245, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(248, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1902, 28);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1547, 78);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(1466, 78);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // linkLabelProblem
            // 
            this.linkLabelProblem.AutoSize = true;
            this.linkLabelProblem.Location = new System.Drawing.Point(1466, 128);
            this.linkLabelProblem.Name = "linkLabelProblem";
            this.linkLabelProblem.Size = new System.Drawing.Size(107, 17);
            this.linkLabelProblem.TabIndex = 3;
            this.linkLabelProblem.TabStop = true;
            this.linkLabelProblem.Text = "projecteuler.net";
            this.linkLabelProblem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelProblem_Click);
            // 
            // groupBoxProblems
            // 
            this.groupBoxProblems.Location = new System.Drawing.Point(1628, 31);
            this.groupBoxProblems.Name = "groupBoxProblems";
            this.groupBoxProblems.Size = new System.Drawing.Size(231, 70);
            this.groupBoxProblems.TabIndex = 0;
            this.groupBoxProblems.TabStop = false;
            this.groupBoxProblems.Text = "Solved Project Euler Problems";
            // 
            // lblTimeSolved
            // 
            this.lblTimeSolved.AutoSize = true;
            this.lblTimeSolved.Location = new System.Drawing.Point(1466, 148);
            this.lblTimeSolved.Name = "lblTimeSolved";
            this.lblTimeSolved.Size = new System.Drawing.Size(46, 17);
            this.lblTimeSolved.TabIndex = 7;
            this.lblTimeSolved.Text = "label1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.lblTimeSolved);
            this.Controls.Add(this.groupBoxProblems);
            this.Controls.Add(this.linkLabelProblem);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.tableLayoutProblems);
            this.Controls.Add(this.panelSolution);
            this.Controls.Add(this.btnClose);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.panelSolution.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private ICSharpCode.TextEditor.TextEditorControl txtEditor;
        private System.Windows.Forms.Panel panelSolution;
        private System.Windows.Forms.TableLayoutPanel tableLayoutProblems;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.ToolStripMenuItem SwitchLanguageToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabelProblem;
        private System.Windows.Forms.GroupBox groupBoxProblems;
        private System.Windows.Forms.ToolStripMenuItem viewFunctionsToolStripMenuItem;
        private System.Windows.Forms.Label lblTimeSolved;
    }
}