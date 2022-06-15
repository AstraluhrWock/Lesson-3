/* Любовь Соколова */

using System;

namespace Lesson_3
{
    class Program
    {
        /// <summary>
        ///1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.
        // Продемонстрировать работу структуры.
        /// </summary>
        internal struct StructOfComplexNumbers 
        {
            public double re;
            public double im;
            public StructOfComplexNumbers Addition(StructOfComplexNumbers number)
            {
                StructOfComplexNumbers result;
                result.re = re + number.re;
                result.im = im + number.im;
                return result;
            }

            public StructOfComplexNumbers Subtraction(StructOfComplexNumbers number)
            {
                StructOfComplexNumbers result;
                result.re = re - number.re;
                result.im = im - number.im;
                return result;
            }

            public override string ToString()
            {
                return $"{re}+{im}i";
            }
        }

        /// <summary>
        /// 1. б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить
        /// работу класса
        /// </summary>
        internal class ClassOfComplexNumbers
        {
            private double _re;
            private double _im;
            
            public ClassOfComplexNumbers(double re, double im)
            {
                _re = re;
                _im = im;
            }

            public ClassOfComplexNumbers()
            {
               
            }

            public static ClassOfComplexNumbers Addition(ClassOfComplexNumbers num1, ClassOfComplexNumbers num2)
            {
                ClassOfComplexNumbers result = new ClassOfComplexNumbers(num1._re + num2._re, num1._im + num2._im);
                return result;
            }

            public static ClassOfComplexNumbers Subtraction(ClassOfComplexNumbers num1, ClassOfComplexNumbers num2)
            {
                ClassOfComplexNumbers result = new ClassOfComplexNumbers(num1._re - num2._re, num1._im - num2._im);
                return result;
            }

            public static ClassOfComplexNumbers Multiplication(ClassOfComplexNumbers num1, ClassOfComplexNumbers num2)
            {
                ClassOfComplexNumbers result = new ClassOfComplexNumbers((num1._re * num2._re - num1._im*num2._im), (num1._im * num2._re + num1._re*num2._im));
                return result;
            }

            /// <summary>
            /// 1. в) Добавить диалог с использованием switch демонстрирующий работу класса.
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns></returns>
            public static ClassOfComplexNumbers SwitchingOperation(ClassOfComplexNumbers num1, ClassOfComplexNumbers num2)
            {
                int caseSwitch = 0;
                ClassOfComplexNumbers result = new ClassOfComplexNumbers();
                Console.WriteLine("Введите число для выбора операции, где 1 - сложение, 2 - вычитание, 3 - умножение");
                caseSwitch = int.Parse(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine("Сложить два комплексных числа: ");
                        result = ClassOfComplexNumbers.Addition(num1, num2);
                        Console.WriteLine($"({num1}) + ({num2}) = {result}");
                        break;

                    case 2:
                        Console.WriteLine("Вычитание двух комплексных чисел: ");
                        result = ClassOfComplexNumbers.Subtraction(num1, num2);
                        Console.WriteLine($"({num1}) - ({num2}) = {result}");
                        break;

                    case 3:
                        Console.WriteLine("Умножение двух комплексных чисел: ");
                        result = ClassOfComplexNumbers.Multiplication(num1, num2);
                        Console.WriteLine($"({num1}) * ({num2}) = {result}");
                        break;
                    default:
                        Console.WriteLine("Введите число для выбора операции, где 1 - сложение, 2 - вычитание, 3 - умножение");
                        break;
                }
                return result;
            }

            public override string ToString()
            {
                return $"{_re}+{_im}i";
            }

        }

        /// <summary>
        /// 2. а) С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке).
        /// Требуется подсчитать сумму всех нечётных положительных чисел.Сами числа и сумму
        /// вывести на экран, используя tryParse
        /// </summary>
        static void SumOddNumbers()
        {
            int sum = 0;
            while (true)
            {
                string str = Console.ReadLine();
                if (!int.TryParse(str, out int num))
                {
                    Console.WriteLine("Неподдерживаемый тип данных");
                }
                if (num == 0)
                    break;
                if (num % 2 == 1 && num > 0)
                    sum += num;
            }
            Console.WriteLine(sum);
        }


        /// <summary>
        /// 3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
        /// Предусмотреть методы сложения, вычитания, умножения и деления дробей.Написать
        /// программу, демонстрирующую все разработанные элементы класса.
        /// </summary>
        internal class FractionalNumbers
        {
            private double _numerator;
            private double _denominator;

            public FractionalNumbers(double n, double d) 
            {
                if (d == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
                _numerator = n;
                _denominator = d;
            }

            public FractionalNumbers()
            {  }

        

            /// <summary>
            /// 3. * Добавить свойства типа int для доступа к числителю и знаменателю;
            /// </summary>
            public int Numerator
            {
               get { return Convert.ToInt32(_numerator); }
               set
                {
                    if (value == 0)
                        throw new Exception("Числитель не может быть равен 0");
                    _numerator = value;
                }
            }

            public int Denominator
            {
                get { return Convert.ToInt32(_denominator); }
                set
                {
                    if (value == 0)
                        throw new Exception("Знаминатель не может быть равен 0");
                    _denominator = value;
                }
            }

            /// <summary>
            /// 3. * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
            /// </summary>
            public double NumeratorDouble
            {
                get { return Convert.ToDouble(_numerator) ; }
            }

            public double DenominatorDouble
            {
                get { return Convert.ToDouble(_denominator); }
            }


            public static FractionalNumbers Addition(FractionalNumbers num1, FractionalNumbers num2)
            {
                FractionalNumbers result = new FractionalNumbers();
                if (num1._denominator == num2._denominator)
                {
                    result = new FractionalNumbers((num1._numerator + num2._numerator), num1._denominator);
                }
                else
                {
                    result = new FractionalNumbers((num1._numerator * num2._denominator + num2._numerator * num1._denominator), (num1._denominator * num2._denominator));
                }
                return result;
            }

            public static FractionalNumbers Subtraction(FractionalNumbers num1, FractionalNumbers num2)
            {
                FractionalNumbers result = new FractionalNumbers();
                if (num1._denominator == num2._denominator)
                {
                    result = new FractionalNumbers((num1._numerator - num2._numerator), num1._denominator);
                }
                else
                {
                    result = new FractionalNumbers((num1._numerator * num2._denominator - num2._numerator * num1._denominator), (num1._denominator * num2._denominator));
                }
                return result;
            }

            public static FractionalNumbers Multiplication(FractionalNumbers num1, FractionalNumbers num2)
            {
                FractionalNumbers result = new FractionalNumbers(num1._numerator * num2._numerator, num1._denominator * num2._denominator);
                return result;
            }

            public static FractionalNumbers Division(FractionalNumbers num1, FractionalNumbers num2)
            {
                FractionalNumbers result = new FractionalNumbers(num1._numerator * num2._denominator, num1._denominator * num2._numerator);
                return result;
            }

            /// <summary>
            /// 3. *** Добавить упрощение дробей
            /// </summary>
            /// <param name="num1"></param>
            /// <returns></returns>
            public static FractionalNumbers ReduceFractions(FractionalNumbers num1)
            {
                FractionalNumbers GCD = new FractionalNumbers();
                while (num1._numerator != num1._denominator)
                {
                    if (num1._numerator > num1._denominator)
                        num1._numerator -= num1._denominator;
                    else num1._denominator -= num1._numerator;
                }
                GCD._numerator = num1._numerator;
                // верно считает НОД, но вычисления происходят с измененными данными
                FractionalNumbers result = new FractionalNumbers(num1._numerator / GCD._numerator, num1._denominator / GCD._numerator);
                return result;
            }

            public override string ToString()
            {
                return $"{_numerator}/{_denominator}";
            }

        }

        static void Main(string[] args)
        {

            //SumOddNumbers();
            ////StructOfComplexNumbers num1;
            ////num1.re = 5;
            ////num1.im = 3;

            ////StructOfComplexNumbers num2;
            ////num2.re = 2;
            ////num2.im = 1;

            ////StructOfComplexNumbers num3 = num1.Subtraction(num2);

            ////ClassOfComplexNumbers com1 = new ClassOfComplexNumbers(5, 3);
            ////ClassOfComplexNumbers com2 = new ClassOfComplexNumbers(1, 2);
            ////ClassOfComplexNumbers com3 = ClassOfComplexNumbers.SwitchingOperation(com1, com2);

            FractionalNumbers f1 = new FractionalNumbers(10, 2);
            //FractionalNumbers f2 = new FractionalNumbers(1, 15);
            
            FractionalNumbers f3 = FractionalNumbers.ReduceFractions(f1);

            //Console.WriteLine($"({f1}) - ({f2}) = {f3}");
           Console.WriteLine($"{f3}");

            //Console.WriteLine($"({com1}) * ({com2}) = {com3}");
        }
    }
}
