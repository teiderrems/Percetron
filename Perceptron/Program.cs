namespace Perceptron;

class Program
{
    static void Main()
    {
        List<List<double>> data = new()
        {
            new List<double> { 0, 0 },
            new List<double> { 0, 1 },
            new List<double> { 1, 0 },
            new List<double> { 1, 1 }
        };

        /* OR*/
         
         List<int> y = new()
        {
            0, 1, 1, 1
        };

        
        /* AND
         
         List<int> y = new()
        {
            0, 0, 0, 1
        };*/
        
        /* XOR
         
         List<int> y = new()
        {
            0, 1, 1, 0
        };*/

        Perceptron p = new();
        
        // operator  OR || AND
        
        Console.WriteLine("Biais before learning={0}",p.Biais);
        p.Fit(data,y,0.01,60);
        Console.WriteLine("Biais after learning={0}",p.Biais);

        Console.WriteLine("x=(0,0),y={0}",p.Predict(new List<double> { 0,  0}));
        Console.WriteLine("x=(0,1),y={0}",p.Predict(new List<double> { 0,  1}));
        Console.WriteLine("x=(1,0),y={0}",p.Predict(new List<double> { 1,  0}));
        Console.WriteLine("x=(1,1),y={0}", p.Predict(new List<double> { 1, 1 }));
        
        
        /* Test XOR
        Console.WriteLine("Biais before learning={0}",p.Biais);
        p.Fit(data,y,0.0001,10000);
        Console.WriteLine("Biais after learning={0}",p.Biais);

        Console.WriteLine("x=(0,0),y={0}",p.Predict(new List<double> { 0,  0}));
        Console.WriteLine("x=(0,1),y={0}",p.Predict(new List<double> { 0,  1}));
        Console.WriteLine("x=(1,0),y={0}",p.Predict(new List<double> { 1,  0}));
        Console.WriteLine("x=(1,1),y={0}", p.Predict(new List<double> { 1, 1 }));*/
    }
}