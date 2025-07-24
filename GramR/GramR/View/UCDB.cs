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
