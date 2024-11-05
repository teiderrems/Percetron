namespace Perceptron;

public class Perceptron
{
    public List<double> Weigth { get; set; } = [];
    
    private readonly Random _random=new();

    public double Biais { get; set; }

    private int Heaviside(double x)
    {
        return x<0 ? 0 : 1;
    }

    public Perceptron()
    {
        Biais = _random.NextDouble();
    }

    /*private double Sigmoid(double x)
    {
        return 1.0 / (1.0 + Math.Exp(-x));
    }
    */

    /*private double SigmoidDerivative(double x)
    {
        return (1.0 - Sigmoid(x))*Sigmoid(x);
    }*/

    private double Activate(List<double> x)
    {
        double output = 0.0;
        for (int i = 0; i < x.Count; i++)
        {
            output += x[i] * Weigth[i]+Biais;
        }
        return output;
    }

    private List<double> DerivativeWeigth(List<double> x,int y, int fx)
    {
        List<double> delta = [];
        for (int i = 0; i < x.Count; i++)
        {
            delta.Add(x[i] * (y - fx));
        }
        return delta;
    }

    private void UpdateBiais(int y, int fx, double learningRate)
    {
        Biais+=learningRate * (y - fx);
    }

    private void GenerateWeights(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Weigth.Add(_random.NextDouble());
        }
    }

    private void UpdateWeights(List<double> deltaWeight,double learnRate)
    {
        for (int i = 0; i < deltaWeight.Count; i++)
        {
            Weigth.Insert(i,Weigth[i]+learnRate*deltaWeight[i]);
        }
    }

    public void Fit(List<List<double>> x, List<int> y, double learningRate=0.005, int maxIter = 50)
    {
        GenerateWeights(x[0].Count);
        int k = 0;
        while (k<maxIter)
        {
            for (int i = 0; i < x.Count; i++)
            {
                int fx = Predict(x[i]);
                UpdateWeights(DerivativeWeigth(x[i],y[i],fx),learningRate);
                UpdateBiais(y[i],fx,learningRate);
            }
            k++;
        }
    }

    public int Predict(List<double> x)
    {
        return Heaviside(Activate(x));
    }
}