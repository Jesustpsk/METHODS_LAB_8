using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using MathNet.Numerics;

namespace METHODS_LAB_8;

public class LeastSquareMethod
{
    // Метод наименьших квадратов для линейной функции: y = mx + b
    public static List<double[]> linearLeastSquares(double[] x, double[] y)
    {
        var linearParameters = Fit.Line(x, y);
        double _a = linearParameters.Item1;
        double _b = linearParameters.Item2;
        double[] fittedY = new double[x.Length];
        for (int i = 0; i < x.Length; i++)
        {
            fittedY[i] = _a * x[i] + _b;
        }

        double[] A = { _a };
        double[] B = { _b };
        var list = new List<double[]> { fittedY, A, B };
        return list;
        /*plot.Plot.PlotScatter(x, y, label: "Исходные данные");
        plot.Plot.PlotScatter(x, fittedY, label: $"Линейная функция: y = {_a:F2}x + {_b:F2}", color: Color.Red);
        plot.Plot.XLabel("X");
        plot.Plot.YLabel("Y");
        plot.Plot.Legend();
        plot.Plot.AxisAuto();
        plot.Plot.Grid(true);
        plot.Render();*/
    }

// Метод наименьших квадратов для степенной функции: y = a * x^b
    public static List<double[]> powerLeastSquares(double[] x, double[] y)
    {
        var powerFit = Fit.Power(x, y);
        double _a = powerFit.Item1;
        double _b = powerFit.Item2;

        double[] fittedY = new double[x.Length];
        for (int i = 0; i < x.Length; i++)
        {
            fittedY[i] = Math.Pow(x[i], _a) * _b;
        }

        double[] A = { _a };
        double[] B = { _b };
        var list = new List<double[]> { fittedY, A, B };
        return list;
        
        /*plot.Plot.PlotScatter(x, fittedY, label: $"Степенная функция: y = {b:F2} * x^{a:F2}");
        plot.Plot.XLabel("X");
        plot.Plot.YLabel("Y");
        plot.Plot.Legend();
        plot.Plot.AxisAuto();
        plot.Plot.Grid(true);
        plot.Render();*/
    }

// Метод наименьших квадратов для показательной функции: y = a * e^(bx)
    public static List<double[]> exponentialLeastSquares(double[] x, double[] y)
    {
        var exponentialFit = Fit.Exponential(x, y);
        double _a = exponentialFit.Item1;
        double _b = exponentialFit.Item2;

        double[] fittedY = new double[x.Length];
        for (int i = 0; i < x.Length; i++)
        {
            fittedY[i] = _b * Math.Exp(_a * x[i]);
        }

        double[] A = { _a };
        double[] B = { _b };
        var list = new List<double[]> { fittedY, A, B };
        return list;
        
        /*plot.Plot.PlotScatter(x, fittedY, label: $"Показательная функция: y = {b:F2} * e^({a:F2} * x)");
        plot.Plot.XLabel("X");
        plot.Plot.YLabel("Y");
        plot.Plot.Legend();
        plot.Plot.AxisAuto();
        plot.Plot.Grid(true);
        plot.Render();*/
    }

    public static void Render(double[] x, double[] y, ScottPlot.WpfPlot plot)
    {
        var linear = linearLeastSquares(x, y);
        var power = powerLeastSquares(x, y);
        var exp = exponentialLeastSquares(x, y);
        
        plot.Plot.PlotScatter(x, y, label: "Исходные данные");
        string message = "";
        if (linear[0].Any(a => double.IsInfinity(a) || double.IsNaN(a)))
        {
            message += "Линейная функция содержит бесконечные или нечисловые значения.\n";
        }
        else
        {
            plot.Plot.PlotScatter(x, linear[0], label: $"Линейная функция: y = {linear[1][0]:F2}x + {linear[2][0]:F2}", color: Color.Red);
        }
        if (power[0].Any(a => double.IsInfinity(a) || double.IsNaN(a)))
        {
            message += "Степенная функция содержит бесконечные или нечисловые значения.\n";
        }
        else
        {
            plot.Plot.PlotScatter(x, power[0], label: $"Степенная функция: y = {power[2][0]:F2} * x^{power[1][0]:F2}", color: Color.Green);
        }
        if (exp[0].Any(a => double.IsInfinity(a) || double.IsNaN(a)))
        {
            message += "Показательная функция содержит бесконечные или нечисловые значения.\n";
        }
        else
        {
            plot.Plot.PlotScatter(x, exp[0], label: $"Показательная функция: y = {exp[2][0]:F2} * e^({exp[1][0]:F2} * x)", color: Color.Blue);
        }
        plot.Plot.XLabel("X");
        plot.Plot.YLabel("Y");
        plot.Plot.Legend();
        plot.Plot.AxisAuto();
        plot.Plot.Grid(true);
        plot.Render();

        if (message != "")
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
