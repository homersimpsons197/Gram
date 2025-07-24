using GramR.Model;

namespace GramR.Controller
{
    public class DataController
    {
        private readonly DataModel _model;

        public DataController(DataModel model)
        {
            _model = model;
        }

        // Delegate for logging text messages — used by UCLog
        public Action<string>? LogAction { get; set; }

        // A helper method for logging a message
        public void Log(string message)
        {
            LogAction?.Invoke(message); // Only call if LogAction is set
        }
    }
}
