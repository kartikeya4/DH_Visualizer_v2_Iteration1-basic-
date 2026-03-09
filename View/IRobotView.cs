using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DH_Visualizer_v2.Controller;
using DH_Visualizer_v2.Modal;


namespace DH_Visualizer_v2.View
{
    public interface IRobotView 
    {
        //View ---> Controller
        event EventHandler UpdateRequested;

        //Controller ---> View
        void PopulateGrid(List<DHParameter> parameters);
        void UpdateVisualization(List<DHParameter> parameters);
        List<DHParameter> GetParametersFromGrid(bool animated);
        void ShowError(string message);
    }
}
