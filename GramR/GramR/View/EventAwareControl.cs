namespace GramR.View
{
    // A custom base class that extends UserControl and provides smart event management
    public class EventAwareUserControl : UserControl, IEventAwareControl
    {
        // Tracks whether events are currently subscribed — prevents double-binding
        protected bool IsSubscribed { get; private set; }

        // Stores all controls inside this user control (used for dynamic event handling)
        protected List<Control> AllControls = new();

        // Constructor — called when a new instance is created
        public EventAwareUserControl()
        {
            // Subscribe to the VisibleChanged event, which triggers when control is shown/hidden
            VisibleChanged += OnVisibilityChanged;
        }

        // Automatically handles event subscription based on visibility state
        private void OnVisibilityChanged(object sender, EventArgs e)
        {
            if (Visible && !IsSubscribed)
                EnsureEventsSubscribed();     // Attach event handlers when shown
            else if (!Visible && IsSubscribed)
                UnsubscribeEvents();         // Detach them when hidden
        }

        // Ensures events are subscribed if they’re not already
        public void EnsureEventsSubscribed()
        {
            if (IsSubscribed) return;
            SubscribeEvents(); // Calls the overrideable method
        }

        // Subscribes necessary events and gathers all child controls
        public virtual void SubscribeEvents()
        {
            IsSubscribed = true;
            AllControls = this.GetAllControls(); // Extension method collects all nested controls
        }

        // Cleans up by removing event handlers and clearing control list
        public virtual void UnsubscribeEvents()
        {
            IsSubscribed = false;
            AllControls.Clear();
        }
    }
}