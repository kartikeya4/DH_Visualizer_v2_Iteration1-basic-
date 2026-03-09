using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DH_Visualizer_v2.Modal
{
    public class RobotModal
    {
        //STtorage class for the robot parameters
        public List<DHParameter> _parameters = new List<DHParameter>();
        //Parameters change event
        public event Action<List<DHParameter>>ParametersChanged;
        //Parameter Set method
        public void SetParameters(List<DHParameter> parameters)
        { 
            //parameters null protectection and 
            _parameters = parameters ??new List<DHParameter>();
            //creates a copy of the _parameters list so subscribers do not modify the orignal list 
            ParametersChanged?.Invoke(_parameters.ToList());
        }
    }
}
