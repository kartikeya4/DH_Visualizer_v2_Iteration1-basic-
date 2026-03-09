using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DH_Visualizer_v2.Modal;
using DH_Visualizer_v2.View;

namespace DH_Visualizer_v2.Controller
{
    public class RobotController

    {
        private readonly IRobotView _View;
        private readonly RobotModal _Modal;

        public RobotController(IRobotView View, RobotModal Modal)
        {
            _View = View ?? throw new ArgumentNullException(nameof(View));
            _Modal = Modal ?? throw new ArgumentNullException(nameof(Modal));
            // View -> Controller
            _View.UpdateRequested += OnUpdateRequested;
            //Modal ->View
            _Modal.ParametersChanged += OnParametersChanged;


        }
        public void Initialize()
        {
            var default_param = GetDefaultParams();
            _Modal.SetParameters(default_param);
            _View.PopulateGrid(default_param);
        }
        private void OnUpdateRequested(object sender, EventArgs e)
        {
            var List = _View.GetParametersFromGrid(animated: false);
            _Modal.SetParameters(List);

        }
        private void OnParametersChanged(List<DHParameter> parameters)
        {
            _View.UpdateVisualization(parameters);
        }

        private List<DHParameter> GetDefaultParams()
        {
            return new List<DHParameter>
            {
                new DHParameter { Theta = 90, LinkOffset = 4, LinkLength = 4, Alpha = 90, Jointype = jointType.P },
                new DHParameter { Theta = 90, LinkOffset = 4, LinkLength = 4, Alpha = 90, Jointype = jointType.R }

            };
            
        }
    }
}
