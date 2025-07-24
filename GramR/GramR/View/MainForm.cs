using GramR.Controller;
using GramR.View;

namespace GramR
{
    public partial class MainForm : Form
    {
        // A reference to the data controller — used to interact with app data
        private readonly DataController _c;

        // Tracks which view (user control) is currently visible on the form
        private EventAwareUserControl? _activeView;

        // Specific user controls used in the app: log view and work view
        private UCDB _db;
        private UCLOG _log;

        // UCSettings is commented out, but it looks like a settings screen could be used later
        // private UCSettings _settings;

        // Constructor method – runs when MainForm is created
        public MainForm(DataController controller)
        {
            // Store the provided DataController so it can be used across the form
            _c = controller;

            // Set up all form controls defined in the designer (Visual Studio handles this)
            InitializeComponent();

            // Create the log view and add it to the form
            _log = new UCLOG(_c);
            pnlController.Controls.Add(_log); // Add to the placeholder panel
            _log.Dock = DockStyle.Fill;       // Make it stretch to fill the panel
            _log.Visible = false;             // Keep it hidden until we show it

            // Create the work view and add it the same way
            _db = new UCDB(_c);
            pnlController.Controls.Add(_db);
            _db.Dock = DockStyle.Fill;
            _db.Visible = false;
        }

        // Shows a specific user control view on the form
        private void ShowView(EventAwareUserControl view)
        {
            // If the requested view is already active, do nothing
            if (_activeView == view)
                return;

            // Hide the current view and unsubscribe from its events
            if (_activeView != null)
            {
                _activeView.Visible = false;
                _activeView.UnsubscribeEvents();
            }

            // Set the new view as active, make it visible, and subscribe to its events
            _activeView = view;
            _activeView.Visible = true;
            _activeView.SubscribeEvents(); // May be optional if the base class handles it
        }

        private void btnDb_Click(object sender, EventArgs e)
        {
            ShowView(_db); // Show the database view when button clicked
            btnDb.Enabled = false; // Disable the button to prevent re-clicking
            btnLog.Enabled = true; // Enable the log button for navigation
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            ShowView(_log); // Show the log view when button clicked
            btnLog.Enabled = false; // Disable the button to prevent re-clicking
            btnDb.Enabled = true; // Enable the database button for navigation
        }
    }
}
