using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronNetwork
{
    internal class Function
    {
        public static double Sigmoid(double value)
        {
            return 1 / (1 + Math.Exp(-value));
        }

        public static double ReLU(double x)
        {
            return (Math.Max(x, 0));
        }

        public static double HyperbologicTg(double x)
        {
            return (Math.Tanh(x));
            // return ((e^(2*x) - 1) / (e^(2*x) - 1));
        }

        public static double Derivative_Sigmoid(double x)
        {
            double fx = Sigmoid(x);
            return (fx * (1 - fx));
        }
    }
}
