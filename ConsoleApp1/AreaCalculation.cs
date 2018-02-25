using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class AreaCalculation
    {
        private class Figure
        {

            /// <summary>
            /// Создание новой фигуры
            /// </summary>
            /// <param name="figureName">Название фигуры</param>
            /// <param name="areaFunc">Функция вычисления площади</param>
            /// <param name="">Функции определения типа фигуры</param>
            public Figure(string figureName, Func<double[], double> areaFunc, Func<double[], bool> identifyFigure)
            {
                this.FigureName = figureName;
                this.areaFunc = areaFunc;
                this.identifyFigure = identifyFigure;
            }
            private Func<double[], double> areaFunc { get; set; }
            private Func<double[], bool> identifyFigure { get; set; }
            public string FigureName { get; }

            public double Area(params double[] sides)
            {
                return areaFunc(sides);
            }
            public bool Identify(params double[] sides)
            {
                return this.identifyFigure(sides);
            }
        }
        private static Dictionary<string, Figure> Figures { get; set; }
        static AreaCalculation()
        {
            Figures = new Dictionary<string, Figure>();
            Func<double[], double> areaCircle = (x) =>
             {
                 return Math.PI * Math.Pow(x[0], 2);
             };
            Func<double[], bool> identifyCircle = (sides) =>
             {
                 if (sides.Length != 1)
                 {
                     return false;
                 }
                 return true;

             };
            AddFigure("Circle", areaCircle, identifyCircle);
            Func<double[], double> areaRightTriangle = (sides) =>
            {
                if (sides[0] > sides[1] && sides[0] > sides[2])
                    return (sides[1] * sides[2]) / 2;
                if (sides[1] > sides[0] && sides[1] > sides[2])
                    return (sides[0] * sides[2]) / 2;
                return (sides[0] * sides[1]) / 2;
            };
            Func<double[], bool> identifyRightTriangle = (sides) =>
            {
                if (sides.Length != 3)
                {
                    return false;
                }
                if (Math.Pow(sides[0], 2) == (Math.Pow(sides[1], 2) + Math.Pow(sides[2], 2)))
                {
                    return true;
                }
                if (Math.Pow(sides[1], 2) == (Math.Pow(sides[0], 2) + Math.Pow(sides[2], 2)))
                {
                    return true;
                }
                if (Math.Pow(sides[2], 2) == (Math.Pow(sides[1], 2) + Math.Pow(sides[0], 2)))
                {
                    return true;
                }
                return false;
            };
            AddFigure("RightTriangle", areaRightTriangle, identifyRightTriangle);
        }
        /// <summary>
        /// Добавление новой фигуры
        /// </summary>
        /// <param name="figureName">Название фигуры</param>
        /// <param name="areaFunc">Функция вычисления площади</param>
        /// <param name="identifyFigure">Функции определения типа фигуры<</param>
        /// <returns>Если фигура с названием уже существует вернет false,иначе true </returns>
        public static bool AddFigure(string figureName, Func<double[], double> areaFunc, Func<double[], bool> identifyFigure)
        {
            if (string.IsNullOrEmpty(figureName))
            {
                throw new ArgumentException(message: "Название фигуры не может быть пустым или равным null", paramName: nameof(figureName));
            }
            if (Figures.ContainsKey(figureName))
            {
                return false;
            }
            if (areaFunc == null)
            {
                throw new ArgumentException(message: "Функция вычисления площади не может быть равна null", paramName: nameof(figureName));
            }
            if (identifyFigure == null)
            {
                throw new ArgumentException(message: "Функция определения типы фигуры не может быть равна null", paramName: nameof(figureName));
            }
            Figures.Add(figureName, new Figure(figureName, areaFunc, identifyFigure));
            return true;
        }
        /// <summary>
        /// Вычисление площади выбранной фигуры
        /// </summary>
        /// <param name="figureName">Название фигуры</param>
        /// <param name="sides">Параметры фигуры</param>
        /// <returns>Площадь</returns>
        public static double СalculatingAreaFigure(string figureName, params double[] sides)
        {
            if (sides.Any(x => x <= 0))
            {
                throw new ArgumentException("Параметры фигуры не могут быть меньше или равным нулю");
            }
            if (string.IsNullOrEmpty(figureName)||!Figures.ContainsKey(figureName))
            {
                throw new ArgumentException("Неизвестный тип фигуры");
            }
            var figure = Figures[figureName];
            if (!figure.Identify(sides))
            {
                throw new ArgumentException("Недопустимые параметры для расчета площади фигуры");
            }
            return Math.Round(figure.Area(sides), 3);
        }
        public static double СalculatingAreaFigure(params double[] sides)
        {
            if (sides.Any(x => x <= 0))
            {
                throw new ArgumentException("Параметры фигуры не могут быть меньше или равны нулю");
            }
            foreach (var figure in Figures)
            {
                if (figure.Value.Identify(sides))
                {
                    return Math.Round(figure.Value.Area(sides), 3);
                }
            }
            throw new ArgumentException("Неизвестный тип фигуры");
        }
        /// <summary>
        /// Получение списка названий фигур доступных для вычисления площади.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFigureNames()
        {
            return Figures.Select(x => x.Key).ToList();
        }
    }
}
