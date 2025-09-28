using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronNetwork
{
    public class InputNeuronLayer : List<IInput>
    {
        public void CreateLayer(int neuronsAmmount, Random r)
        {
            for (int i = 0; i < neuronsAmmount; i++)
            {
                //InputNeuron n = new InputNeuron(r.Next(1, 1));
                InputNeuron n = new InputNeuron(r.NextDouble());
                this.Add(n);
            }
        }

        public void PrintValues()
        {
            for (int i = 0; i < this.Count(); i++)
            {
                Console.WriteLine("Input value " + i + " = " + this[i].Value);
            }
        }
    }

    public class OutputNeuronLayer : List<IOutput>
    {
        public void CreateLayer(int neuronsAmmount, Random r, NeuronNet neuronNet)
        {
            for (int i = 0; i < neuronsAmmount; i++)
            {
                OutputNeuron n = new OutputNeuron(r, neuronNet);
                this.Add(n);
            }
        }

        public void PrintValues()
        {
            for (int i = 0; i < this.Count(); i++)
            {
                Console.WriteLine("Output value " + i + " = " + this[i].GetValue());
            }
        }

    }

    public class HiddenNeuronLayer<TNeuron> : List<TNeuron>
        where TNeuron : IOutput, IInput, new()
    {
    }
}
