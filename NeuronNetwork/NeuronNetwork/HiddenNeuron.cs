using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronNetwork
{
    public class HiddenNeuron : /*BaseNeuron,*/ IOutput, IInput
    {
        private List<double> _weights = new List<double>();
        public List<double> _weightDelta = new List<double>();
        public double delta { get; set; }


        public List<double> Weights { get { return _weights; } set { _weights = value; } }
        public List<double> WeightDeltas { get { return _weightDelta; } set { _weightDelta = value; } }
        public double Bias { get; set; }
        public double Value
        {
            get
            {
                return (GetValue());
            }
        }


        private double _value; //Смещение функции активации

        public int LayerNumber { get; set; }

        public void SetValue(double value)
        {
            _value = value;
        }
        public double GetValue()
        {
            return _value;
        }


        public void InitializeNeiron(Random r, NeuronNet neuronNet)
        {
            Console.WriteLine("Hidden");
            for (int i = 0; i < this.CountNeuronsOnPreviousLayer(neuronNet); i++)
            {
                double d = new double();
                d = r.NextDouble();
                Weights.Add(d);
                WeightDeltas.Add(0);

                Console.WriteLine(Weights[i]);
            }
            Bias = 0;
        }

        public int CountNeuronsOnPreviousLayer(NeuronNet neuronNet)
        {
            if (LayerNumber == 0)
            {
                return neuronNet.InputLayer.Count();
            }
            else
            {
                HiddenNeuronLayer<HiddenNeuron> lastHidden = neuronNet.HiddenLayerList.Last();

                return lastHidden.Count();

            }

        }

        public void GetPulse(NeuronNet net)
        {

            IInput neuron;

            if (LayerNumber == 0)
            {
                for (int i = 0; i < net.InputLayer.Count(); i++)
                {
                    neuron = net.InputLayer[i];
                    this.SetValue(this._value + neuron.Value * this.Weights[i]);
                    this.SetValue(this._value + Bias); // Смещение 
                }
            }
            else
            {
                for (int i = 0; i < net.HiddenLayerList.Count(); i++)
                {
                    neuron = net.HiddenLayerList[LayerNumber][i]; // ДОДЕЛАТЬ

                    this.SetValue(this._value + neuron.Value * this.Weights[i]);
                  

                    // this._NeuronValue += neuron.Value * this._weights[i];   
                }
                this.SetValue(this._value + Bias); // Смещение 
            }
            this.SetValue(Function.Sigmoid(this._value));
        }
    }

}
