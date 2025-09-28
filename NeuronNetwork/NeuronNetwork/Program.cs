
using Microsoft.VisualBasic;
using NeuronNetwork;
using System.Runtime.CompilerServices;

Random r = new Random();

NeuronNet neuronNet = new NeuronNet(2 /*Количество входных нейронов*/, 2, /*Количество скрытых слоёв*/ 2 /*Количество выходных нейронов*/);
HiddenNeuronLayer<HiddenNeuron> hiddenLayer1 = new HiddenNeuronLayer<HiddenNeuron>();

neuronNet.DoPulse();

int l = 1;

for (int i = 0; i < 300; i++)
{
    neuronNet.Train();
    neuronNet.DoPulse();
    Console.WriteLine(l);
    l++;
}

Console.WriteLine("КОНЕЦ ОБУЧЕНИЯ 1");
Console.ReadKey();

neuronNet.InputLayer.Clear();
InputNeuron n = new InputNeuron(r.Next(1, 1));
neuronNet.InputLayer.Add(n);
InputNeuron d = new InputNeuron(r.Next(0, 0));
neuronNet.InputLayer.Add(d);

l = 1;

for (int i = 0; i < 300; i++)
{
    neuronNet.Train();
    neuronNet.DoPulse();
    Console.WriteLine(l);
    l++;
}

Console.WriteLine("КОНЕЦ ОБУЧЕНИЯ 2");
//Console.ReadKey();
/*
for (int g = 0; g < 500; g++)
{
    if (r.Next(1, 100) < 50)
    {
        neuronNet.InputLayer[0] = new InputNeuron(r.Next(0, 0));
        neuronNet.InputLayer[1] = new InputNeuron(r.Next(1, 1));
    }
    else
    {
        neuronNet.InputLayer[0] = new InputNeuron(r.Next(1, 1));
        neuronNet.InputLayer[1] = new InputNeuron(r.Next(0, 0));
    }

    l = 1;

    for (int i = 0 + g; i < 500; i++)
    {
        neuronNet.Train();
        neuronNet.DoPulse();
        Console.WriteLine(l);
        l++;
    }


    Console.WriteLine("КОНЕЦ ОБУЧЕНИЯ " + g);
}

*/

// ожидаемое - полученное в функцию потерь
// вычисленние частной производной ошибки по каждому весу - вклад каждого веса в отклонение от ожидаемого значения
// Умножение дифференциалов на n, где n - скорость обучения


//double Error1 = neuronNet.InputLayer[0].Value - neuronNet.OutputLayer[0].GetValue();
//double Error2 = neuronNet.InputLayer[1].Value - neuronNet.OutputLayer[1].GetValue();  //Функция ошибки
//double Error = Error1 * Error1 + Error2 * Error2;
//Error1 *= Error1;




//Console.WriteLine(Error1);
/*
double delta = - neuronNet.OutputLayer[0].GetValue() + neuronNet.InputLayer[0].Value;
Console.WriteLine("delta = " + delta);

double d = delta * Function.Derivative_Sigmoid(neuronNet.InputLayer[0].Value);
Console.WriteLine("d = " + d);

Console.WriteLine("----------------------");


for (int i = 0; i < neuronNet.HiddenLayerList.Count(); i++)
{

    foreach (IOutput n in neuronNet.HiddenLayerList[i])
    {
        n.WeightDelta += n.GetValue() * d;
        for (int j = 0; j < n.Weights.Count(); j++)
        {
            n.Weights[i] += d;
            Console.WriteLine("HiddenLearning");
            Console.WriteLine(n.Weights[i]);
        }
    }

}

foreach (IOutput n in neuronNet.OutputLayer)
{
    n.WeightDelta += n.GetValue() * d;
    for (int i = 0; i < n.Weights.Count(); i++)
    {
        n.Weights[i] += d;
        Console.WriteLine("OutputLearning");
        Console.WriteLine(n.Weights[i]);
    }
}

neuronNet.OutputLayer.PrintValues();
neuronNet.InputLayer.PrintValues();


Console.WriteLine("----------------------");
*/


/*Console.WriteLine("ASFfF");

InputNeuron i1 = new InputNeuron(1);
Console.WriteLine("Input = " + i1.Value);
InputNeuron i2 = new InputNeuron(0);
Console.WriteLine("Input = " + i2.Value);

neuronNet.InputLayer.Add(i1);
neuronNet.InputLayer.Add(i2);

HiddenNeuron h1 = new HiddenNeuron()
{
    LayerNumber = 0
};
h1.InitializeWeight(r, neuronNet);

HiddenNeuron h2 = new HiddenNeuron()
{
    LayerNumber = 0
};
h2.InitializeWeight(r, neuronNet);

neuronNet.HiddenLayerList.Add(hiddenLayer1);

neuronNet.HiddenLayerList[0].Add(h1);
neuronNet.HiddenLayerList[0].Add(h2);

HiddenNeuronLayer<HiddenNeuron> lastHidden = neuronNet.HiddenLayerList.Last();
lastHidden.Count();

OutputNeuron o1 = new OutputNeuron(r, neuronNet);
OutputNeuron o2 = new OutputNeuron(r, neuronNet);

//Console.WriteLine(o1.CountNeuronsOnPreviousLayer(neuronNet));

neuronNet.OutputLayer.Add(o1);
neuronNet.OutputLayer.Add(o2);

Console.WriteLine("PULSE MOTHERFUCKER");

h1.GetPulse(neuronNet);
h2.GetPulse(neuronNet);

o1.GetPulse(neuronNet);
o2.GetPulse(neuronNet);

Console.WriteLine("Output 1 = " + o1._value);
Console.WriteLine("Output 1 = " + o2._value);
*/



