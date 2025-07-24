using GramR.Controller;

namespace GramR.View
{
    public partial class UCDB : EventAwareUserControl
    {
        private readonly DataController _c;
        public UCDB(DataController controller)
        {
            _c = controller;

            InitializeComponent();
        }

        public override void SubscribeEvents()
        {
            // Avoid subscribing twice
            if (IsSubscribed) return;

            base.SubscribeEvents(); // Let the base class do any setup it needs

            // Attach Click event handlers to all buttons in the control
            foreach (var control in AllControls)
            {
                if (control is Button btn)
                {
                    btn.Click += OnClick;
                }
                else if (control is TextBox txt)
                {
                    txt.TextChanged += OnTextChanged;
                }
            }

            Task.Run(async () =>
            {
                try
                {
                    int accCount = await DB.GetRowCountAsync("Accounts");
                    int userCount = await DB.GetRowCountAsync("Users");
                    string accMsg = $"Accounts: {accCount}";
                    string userMsg = $"Id: {userCount}";

                    if (lblAcc.InvokeRequired || lblId.InvokeRequired)
                    {
                        lblAcc.Invoke(() => lblAcc.Text = accMsg);
                        lblId.Invoke(() => lblId.Text = userMsg);
                    }
                    else
                    {
                        lblAcc.Text = accMsg;
                        lblId.Text = userMsg;
                    }
                }
                catch (Exception ex)
                {

                }
            });
        }

        // Disables event listeners to prevent memory leaks or errors
        public override void UnsubscribeEvents()
        {
            foreach (var control in AllControls)
            {
                if (control is Button btn)
                {
                    btn.Click -= OnClick;
                }
                else if (control is TextBox txt)
                {
                    txt.TextChanged -= OnTextChanged;
                }
            }

            lblAcc.Text = "Accounts: ";
            lblId.Text = "Id: ";

            base.UnsubscribeEvents(); // Clean up any base class listeners
        }

        private async void OnClick(object sender, EventArgs e)
        {

        }

        private async void OnTextChanged(object sender, EventArgs e)
        {

        }
    }
}
