using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameScriptManager
{
    public class MainForm : Form
    {
        private StoryLinkedList storyList = new StoryLinkedList();

        private RichTextBox rtbFull;
        private RichTextBox rtbSingle;
        private Button btnPrev, btnNext, btnLoad, btnToggle;
        private Label lblMode;

        private int currentIndex = 0;
        private bool fullView = true;

        public MainForm()
        {
            InitializeComponents();
            PopulateSampleData();
            storyList.SortByNumber();
            ShowFullScript();
            ShowSingleLine(0);
        }

        private void InitializeComponents()
        {
            this.Text = "Game Script Manager";
            this.Size = new Size(920, 620);
            this.StartPosition = FormStartPosition.CenterScreen;

            rtbFull = new RichTextBox()
            {
                Location = new Point(10, 10),
                Size = new Size(560, 560),
                ReadOnly = true,
                WordWrap = true,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };
            rtbFull.Font = new Font("Consolas", 11);
            this.Controls.Add(rtbFull);

            rtbSingle = new RichTextBox()
            {
                Location = new Point(580, 10),
                Size = new Size(320, 140),
                ReadOnly = true,
                Multiline = true
            };
            rtbSingle.Font = new Font("Consolas", 12);
            this.Controls.Add(rtbSingle);

            btnPrev = new Button() { Text = "⏮️ Previous", Location = new Point(580, 160), Size = new Size(150, 40) };
            btnPrev.Click += (s, e) => { if (currentIndex > 0) { currentIndex--; ShowSingleLine(currentIndex); } };
            this.Controls.Add(btnPrev);

            btnNext = new Button() { Text = "Next ▶️", Location = new Point(750, 160), Size = new Size(150, 40) };
            btnNext.Click += (s, e) => { if (currentIndex < storyList.Count - 1) { currentIndex++; ShowSingleLine(currentIndex); } };
            this.Controls.Add(btnNext);

            btnLoad = new Button() { Text = "Reload & Sort", Location = new Point(580, 220), Size = new Size(320, 40) };
            btnLoad.Click += (s, e) => { storyList = new StoryLinkedList(); PopulateSampleData(); storyList.SortByNumber(); currentIndex = 0; ShowFullScript(); ShowSingleLine(0); };
            this.Controls.Add(btnLoad);

            btnToggle = new Button() { Text = "Switch View", Location = new Point(580, 280), Size = new Size(320, 40) };
            btnToggle.Click += (s, e) => { fullView = !fullView; UpdateView(); };
            this.Controls.Add(btnToggle);

            lblMode = new Label() { Text = "Mode: Full Script", Location = new Point(580, 340), Size = new Size(320, 30) };
            this.Controls.Add(lblMode);

            UpdateView();
        }

        private void UpdateView()
        {
            rtbFull.Visible = fullView;
            rtbSingle.Visible = !fullView;
            btnPrev.Visible = !fullView;
            btnNext.Visible = !fullView;
            lblMode.Text = fullView ? "Mode: Full Script" : $"Mode: One-line ({currentIndex + 1}/{Math.Max(1, storyList.Count)})";
            if (!fullView) ShowSingleLine(currentIndex);
        }

        private void ShowFullScript()
        {
            rtbFull.Text = storyList.GetCombinedText();
        }

        private void ShowSingleLine(int index)
        {
            var node = storyList.GetNodeAt(index);
            if (node != null)
            {
                rtbSingle.Text = $"{node.Number} - {node.Text}";
            }
            else
            {
                rtbSingle.Text = "(no line)";
            }
            lblMode.Text = fullView ? "Mode: Full Script" : $"Mode: One-line ({index + 1}/{Math.Max(1, storyList.Count)})";
        }

        private void PopulateSampleData()
        {
            storyList.Add(3, "With every line of code mastered, Alex gains experience points, leveling up and unlocking new abilities like Debugging Dash and Algorithmic Aura.");
            storyList.Add(12, "The tale of Alex, the IT student-turned-digital-legend, is forever etched in the annals of Cybersphere, inspiring aspiring programmers to pursue their dreams.");
            storyList.Add(4, "The Firewall Fortress looms ahead, its defenses formidable, but Alex's mastery of cybersecurity allows them to breach the walls with a series of perfectly timed hacks.");
            storyList.Add(2, "Armed with a trusty keyboard and a digital sword, Alex enters the Coding Caverns, where bugs and glitches guard the treasures of programming wisdom.");
            storyList.Add(1, "In the virtual realm of Cybersphere, our hero, Alex, a determined IT student, embarks on an epic quest for knowledge.");
            storyList.Add(7, "Along the journey, Alex forges alliances with NPC coders, forming a guild known as 'Syntax Sentinels,' united by their dedication to digital mastery.");
            storyList.Add(10, "Victory is hard-won, but Alex's leadership and IT prowess lead to the defeat of the Malware Marauders, restoring peace to Cybersphere.");
            storyList.Add(11, "Celebrated as a digital hero, Alex stands at the forefront of innovation, using the knowledge gained to create groundbreaking applications that shape the future of technology.");
            storyList.Add(9, "In a climactic battle, Alex and the Syntax Sentinels engage in a virtual war, using complex algorithms and strategic thinking to outwit the Malware Marauders' schemes.");
            storyList.Add(5, "Inside the fortress, a virtual reality riddle awaits – a puzzle that can only be solved by applying principles of encryption and decryption learned during countless late-night study sessions.");
            storyList.Add(6, "Emerging victorious, Alex discovers the hidden Repository of the Ancients, a collection of long-lost IT texts rumored to contain the ultimate programming language.");
            storyList.Add(8, "The guild faces its nemesis in the form of the Malware Marauders, a rival group aiming to spread chaos and disrupt the digital realm.");
        }
    }
}
