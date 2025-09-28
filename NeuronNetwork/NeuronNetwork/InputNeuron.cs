using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronNetwork
{
    class InputNeuron : IInput
    {
        public double Value { get; }

        public InputNeuron(/*int value */ double value)
        {
            Value = value;
        }

    }
}
