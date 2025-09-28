using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronNetwork
{
    public class NeuronNet
    {
        public InputNeuronLayer InputLayer = new InputNeuronLayer();
        public List<HiddenNeuronLayer<HiddenNeuron>> HiddenLayerList = new List<HiddenNeuronLayer<HiddenNeuron>>();
        public OutputNeuronLayer OutputLayer = new OutputNeuronLayer();


        public NeuronNet(int InputsAmmount, int HiddenLayersAmmount, int OutputsAmmount)
        {
            Random r = new Random();
            InputLayer.CreateLayer(InputsAmmount, r);

            for (int i = 0; i < HiddenLayersAmmount; i++)
            {
                // HiddenNeuronLayer<HiddenNeuron> hiddenLayer = new HiddenNeuronLayer<HiddenNeuron>();

                Console.WriteLine("HiddenNeuronsAmmount on layer (" + i + ")");

                // CreateHiddenLayer(int.Parse(Console.ReadLine()), r);

                HiddenLayerList.Add(CreateHiddenLayer(int.Parse(Console.ReadLine()), r));
            }

            OutputLayer.CreateLayer(OutputsAmmount, r, this);

        }

        public void DoPulse()
        {
            for (int i = 0; i < this.HiddenLayerList.Count(); i++)
            {

                foreach (IOutput n in this.HiddenLayerList[i])
                {
                    n.GetPulse(this);
                }

            }

            foreach (IOutput n in this.OutputLayer)
            {
                n.GetPulse(this);
            }
        }

        public HiddenNeuronLayer<HiddenNeuron> CreateHiddenLayer(int neuronsAmmount, Random r)
        {
            HiddenNeuronLayer<HiddenNeuron> layer = new HiddenNeuronLayer<HiddenNeuron>();

            for (int i = 0; i < neuronsAmmount; i++)
            {
                HiddenNeuron n = new HiddenNeuron();
                n.InitializeNeiron(r, this);
                layer.Add(n);
            }
            return layer;
        }



        public void Train()
        {
            Console.WriteLine("----------------------");

            for (int i = 0; i < OutputLayer.Count(); i++)
            {
                double delta = InputLayer[i].Value - OutputLayer[i].GetValue();
                IOutput n = OutputLayer[i];
                n.delta = delta * Function.Derivative_Sigmoid(n.GetValue());

                for (int j = 0; j < n.WeightDeltas.Count(); j++)
                {
                    n.WeightDeltas[j] += n.delta * HiddenLayerList.Last()[j].Value;
                }

                n.Bias += n.delta;
            }

            for (int i = HiddenLayerList.Count(); i < 0; i--)
            {

                if (i == 0)
                {
                    for (int j = 0; j < HiddenLayerList[i].Count(); j++)
                    {
                        IOutput n = HiddenLayerList[i][j];
                        for (int a = 0; a < OutputLayer.Count(); a++)
                        {
                            n.WeightDeltas[j] += n.delta * InputLayer[j].Value;
                        }

                    }

                }
                else
                {

                    for (int j = 0; j < HiddenLayerList[i].Count(); j++)
                    {
                        IOutput n = HiddenLayerList[i][j];
                       /* for (int a = 0; a < OutputLayer.Count(); a++)
                        {
                            n.WeightDeltas[j] += n.delta * HiddenLayerList[i - 1][j].Value;
                        }*/
                        for (int a = 0; a < HiddenLayerList[i - 1].Count(); a++)   //НЕ УВЕРНЕ ЧТО ТУТ ВСЁ ПРАВИЛЬНО
                        {
                            n.WeightDeltas[j] += n.delta * HiddenLayerList[i - 1][j].Value;
                        }

                    }

                }
            }

            this.OutputLayer.PrintValues();
            this.InputLayer.PrintValues();

            Console.WriteLine("----------------------");

        }

    }
}
