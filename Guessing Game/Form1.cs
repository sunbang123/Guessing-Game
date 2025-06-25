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
                // �����
                iconLabel.ForeColor = iconLabel.BackColor;
            }

            timer2.Start();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        /// <summary>
        /// �� ���� Ŭ������ �� �߻��ϴ� �̺�Ʈ�Դϴ�.
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
                        return; // ������ ������ �ʾҽ��ϴ�.
                }
            }

            timer2.Stop();
            if(MessageBox.Show("�����մϴ�!��� �������� ã�ҽ��ϴ�!\n" + "Ʋ��Ƚ��:" + wrongCount, "", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
            {
                Application.Restart();
            }
            else
                Application.Exit();
        }

        /// <summary>
        /// �÷��̾ Ŭ���� �ϸ� Ÿ�̸Ӱ� ���۵˴ϴ�!
        /// �� �������� ���������� ������. 0.75�� �ɷ���.
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
