using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronNetwork
{
    public interface IOutput
    {
        public int CountNeuronsOnPreviousLayer(NeuronNet neuronNet);
        public void GetPulse(NeuronNet net);
        public void SetValue(double value);
        public double GetValue();

        public List<double> WeightDeltas { get; set; }
        public List<double> Weights { get; set; }
        public double Bias { get; set; }
        public double delta { get; set; }  

    }
}
