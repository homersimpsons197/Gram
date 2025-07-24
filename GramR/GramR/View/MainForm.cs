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

            // The settings view is prepared but not added or shown yet
            // _settings = new UCSettings(_c);
            // pnlController.Controls.Add(_settings);
            // _settings.Dock = DockStyle.Fill;
            // _settings.Visible = false;
        }
    }
}
