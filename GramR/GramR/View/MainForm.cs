using GramR.Controller;

namespace GramR
{
    public partial class MainForm : Form
    {
        private readonly DataController _controller;
        
        public MainForm(DataController controller)
        {
            _controller = controller;

            InitializeComponent();
        }
    }
}
