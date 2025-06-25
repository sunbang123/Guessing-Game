namespace Guessing_Game
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!","!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z",
        };

        Label firstClicked = null;

        Label secondClicked = null;

        int playTime = 0;

        int wrongCount = 0;

        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();

            timer0.Start();
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label? iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                    iconLabel.ForeColor = Color.Black;
                }
            }
        }

        private void Timer0_Tick(object sender, EventArgs e)
        {
            timer0.Stop();

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label? iconLabel = control as Label;
                // 숨기기
                iconLabel.ForeColor = iconLabel.BackColor;
            }

            timer2.Start();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        /// <summary>
        /// 각 라벨을 클릭했을 때 발생하는 이벤트입니다.
        /// </summary>
        /// <param name="sender">The label that was clicked</param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label? clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;

            if (clickedLabel.ForeColor == Color.Black)
                return;

            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            CheckForWinner();

            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }

            wrongCount++;

            timer1.Start();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label? iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return; // 게임이 끝나지 않았습니다.
                }
            }

            timer2.Stop();
            if(MessageBox.Show("축하합니다!모든 아이콘을 찾았습니다!\n" + "틀린횟수:" + wrongCount, "", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
            {
                Application.Restart();
            }
            else
                Application.Exit();
        }

        /// <summary>
        /// 플레이어가 클릭을 하면 타이머가 시작됩니다!
        /// 두 아이콘이 맞지않으면 숨겨짐. 0.75초 걸려요.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            playTime++;
            timerLabel.Text = (playTime/3600%60).ToString() + ":" + (playTime/60%60).ToString() + ":" + (playTime%60).ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
