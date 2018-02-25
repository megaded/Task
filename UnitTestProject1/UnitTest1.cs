using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            Func<double[], double> areaSquare = (sides) =>
             {
                 return sides[0] * sides[1];
             };
             Func<double[], bool> identitySquare = (sides) =>
             {
                 if (sides.Length != 2)
                 {
                     return false;
                 }
                 if (sides[0] == sides[1])
                 {
                     return true;
                 }
                 return false;
             };
            AreaCalculation.AddFigure("Square", areaSquare, identitySquare);
        }

        [TestMethod]
        public void СalculatingAreaConcrectCircle()
        {
            var result = AreaCalculation.СalculatingAreaFigure("Circle", 2);
            Assert.AreEqual(12.566, result);
        }
        [TestMethod]
        public void СalculatingAreaConctectRightTriangle()
        {
            var result = AreaCalculation.СalculatingAreaFigure("RightTriangle", new double[] { 3, 4, 5 });
            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void СalculatingAreaCircle()
        {
            var result = AreaCalculation.СalculatingAreaFigure(2);
            Assert.AreEqual(12.566, result);
        }
        [TestMethod]
        public void СalculatingAreaRightTriangle()
        {
            var result = AreaCalculation.СalculatingAreaFigure(new double[] { 3, 4, 5 });
            Assert.AreEqual(6, result);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Название фигуры не может быть пустым или равным null")]
        public void AddFigureInvalidName()
        {
            AreaCalculation.AddFigure(null, null, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Функция вычисления площади не может быть равна null")]
        public void AddFigureInvalidAreaFunc()
        {
            AreaCalculation.AddFigure("Тест", null, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Функция определения типы фигуры не может быть равна null")]
        public void AddFigureInvalidIdentify()
        {
            AreaCalculation.AddFigure("Тест2", (x) => { return x[0]; }, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Параметры фигуры не могут быть меньше или равны нулю")]
        public void AddFigureInvalidParams()
        {
            AreaCalculation.СalculatingAreaFigure(-1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Неизвестный тип фигуры")]
        public void UnknowFigure()
        {
            AreaCalculation.СalculatingAreaFigure("Блабла", 1000);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Недопустимые параметры для расчета площади фигуры")]
        public void InvalidParams()
        {
            AreaCalculation.СalculatingAreaFigure("Circle", -10000);
        }
        [TestMethod]
        public void СalculatingAreaConcrectSquare()
        {
            var result=   AreaCalculation.СalculatingAreaFigure("Square",new double[] { 2, 2 });
            Assert.AreEqual(4, 4);
        }
        [TestMethod]
        public void СalculatingAreaSquare()
        {
            var result = AreaCalculation.СalculatingAreaFigure(new double[] { 2, 2 });
            Assert.AreEqual(4, 4);
        }
    }
}
