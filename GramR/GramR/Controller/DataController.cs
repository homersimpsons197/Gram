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
    }
}
