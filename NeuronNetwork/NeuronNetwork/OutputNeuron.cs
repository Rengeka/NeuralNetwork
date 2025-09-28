namespace NeuronNetwork
{
    class OutputNeuron : IOutput
    {

        public List<double> Weights { get; set; } = new List<double>();
        public List<double> WeightDeltas { get; set; } = new List<double>();
        public double delta { get; set; }   

        public double Bias { get; set; }

        public double _value;

        public void SetValue(double value)
        {
            _value = value;
        }

        public double GetValue()
        {
            return _value;
        }

        public OutputNeuron(Random r, NeuronNet neuronNet)
        {
            for (int i = 0; i < this.CountNeuronsOnPreviousLayer(neuronNet); i++)
            {
                Console.WriteLine("Output");
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

            HiddenNeuronLayer<HiddenNeuron> lastHidden = neuronNet.HiddenLayerList.Last();

            return lastHidden.Count();

        }

        public void GetPulse(NeuronNet net)
        {
            HiddenNeuron neuron;

            for (int i = 0; i < net.HiddenLayerList.Last().Count(); i++)
            {
                neuron = net.HiddenLayerList.Last()[i];
                this.SetValue(this._value + neuron.GetValue() * this.Weights[i]);// += neuron._NeuronValue * this._weights[i];
            }

            this.SetValue(_value + Bias);
            this.SetValue(Function.Sigmoid(this._value));
            //this.SetValue(ActivationFunction.Sigmoid(this._value)); Не уверен нужно ли


        }

    }

}
