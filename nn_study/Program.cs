using System;
namespace nn_study
{
    public class Perceptron
    {
        private double learningRate;
        private double bias;
        private double[] weights;

        public Perceptron()
        {
            weights = new double[3];
            var rand = new Random();
            learningRate = 1.0;
            bias = 1.0;
            for (int i = 0; i < 3; i++)
                weights[i] = rand.NextDouble();
        }

        public Perceptron(double lr, double b)
        {
            weights = new double[3];
            var rand = new Random();
            learningRate = lr;
            bias = b;
            for (int i = 0; i < 3; i++)
            {
                double d = rand.NextDouble();
                weights[i] = d;
            }
        }

        public double LearningRate
        {
            get { return learningRate; }
            set { learningRate = value; }
        }

        public double Bias
        {
            get { return bias; }
            set { bias = value; }
        }

        public bool GetOutput(int a, int b)
        {
            return Heaviside(a, b) != 0;
        }
        public void PerceptronSchool(int times)
        {
            for (int i = 0; i < times; i++)
            {
                TeachPerceptron(1, 1, 1);
                TeachPerceptron(1, 0, 1);
                TeachPerceptron(0, 1, 1);
                TeachPerceptron(0, 0, 0);
            }
        }

        private int Heaviside(int a, int b)
        {
            double outputCounted = a * weights[0] + b * weights[1] + bias * weights[2];
            if (outputCounted > 0)
                outputCounted = 1;
            else
                outputCounted = 0;
            return (int)outputCounted;
        }
        private void TeachPerceptron(double inputA, double inputB, double outputExpected)
        {
            double outputCounted = inputA * weights[0] + inputB * weights[1] + bias * weights[2];
            if (outputCounted > 0)
                outputCounted = 1;
            else
                outputCounted = 0;
            double error = outputExpected - outputCounted;
            weights[0] += error * inputA * learningRate;
            weights[1] += error * inputB * learningRate;
            weights[2] += error * bias * learningRate;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Perceptron p = new Perceptron(1.0, 1.0);
            p.PerceptronSchool(50);

            Console.Write("Please type 1 (as true) or 0 (as false) for 2nd input: ");
            int inputA = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nPlease type 1 (as true) or 0 (as false) for 2nd input: ");
            int inputB = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\n\t\tOutput for your inputs (" + inputA + ") and (" + inputB + ") is: " + p.GetOutput(inputA, inputB));
        }
    }
}
