using GramR.Controller;

namespace GramR.View
{
    public partial class UCLOG : EventAwareUserControl
    {
        private readonly DataController _c;
        public UCLOG(DataController controller)
        {
            _c = controller;

            InitializeComponent();
        }

        // Delegating function for logging text messages
        //private void Log(string message)
        //{
        //    if (LOG.InvokeRequired)
        //    {
        //        LOG.Invoke(() => LOG.AppendText(message + Environment.NewLine));
        //    }
        //    else
        //    {
        //        LOG.AppendText(message + Environment.NewLine);
        //    }

        //    // Enable or disable buttons based on current content
        //    btnSaveLog.Enabled = ShouldEnable(btnSaveLog.Name);
        //    btnClearLog.Enabled = ShouldEnable(btnClearLog.Name);
        //}

        public override void SubscribeEvents()
        {
            // Avoid subscribing twice
            if (IsSubscribed) return;

            base.SubscribeEvents(); // Let the base class do any setup it needs

            // Attach Click event handlers to all buttons in the control
            foreach (var control in AllControls)
            {

            }
        }

        // Disables event listeners to prevent memory leaks or errors
        public override void UnsubscribeEvents()
        {
            foreach (var control in AllControls)
            {

            }

            base.UnsubscribeEvents(); // Clean up any base class listeners
        }
    }
}
