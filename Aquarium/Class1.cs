using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium
{
    internal class Class1
    {
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ForMyFuture2
{
    class Class2
    {
        static void Main(string[] args)
        {
            string header = "Аквариум\n";
            bool isWork = true;

            int maxCount = 5;
            int hight = maxCount + 2;
            int beginAquariumY = 3;

            Random rand = new Random();
            int nowCount = rand.Next(0, maxCount);

            Aquarium aquarium = new Aquarium(nowCount, maxCount, hight, beginAquariumY);

            while (isWork)
            {
                Console.Clear();

                Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, 0);
                Console.WriteLine(header);

                Console.SetCursorPosition(0, beginAquariumY);
                aquarium.DrawAquarium();
                aquarium.DrawFish();


                Console.WriteLine($"Содержание Аквариума: ");
                if (nowCount == 0) Console.WriteLine($"Сейчас аквариум пуст, добавте в него рыб ");
                aquarium.ShowInfo();

                Console.WriteLine("\nВведите одну из команд:");
                Console.WriteLine("1 - Добавить рыбу");
                Console.WriteLine("2 - Удалить рыбу");
                Console.WriteLine("3 - Перейти на следующую итерацию (Повысив возрвст и передвинув рыб)");
                Console.WriteLine("4 - выход\n");

                Console.Write("Команда: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        aquarium.Add();
                        nowCount++;
                        break;
                    case "2":
                        aquarium.Delete();
                        nowCount--;
                        break;
                    case "3":
                        aquarium.UpAge();
                        aquarium.MoveFish();
                        continue;
                    case "4":
                        isWork = false;
                        Console.Clear();
                        Console.WriteLine("Завершение работы");
                        continue;
                    default:
                        Console.WriteLine("Неверный ввод!\n" +
                                          "Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                        continue;
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();

            }

            Console.ReadKey();
        }

    }

    class Aquarium
    {
        private int _maxSize;
        private int _nowCount;
        private int _hight;
        private int _beginAquariumY;
        private int _endAquariumY;
        private Fish[] _dataBase;


        public Aquarium(int nowCount, int maxSize, int hight, int beginAquariumY)
        {
            _nowCount = nowCount;
            _maxSize = maxSize;
            _hight = hight;
            _beginAquariumY = beginAquariumY;
            _endAquariumY = beginAquariumY + hight;
            _dataBase = new Fish[_maxSize];

            Random rand = new Random();

            for (int i = 0; i < _nowCount; i++)
            {
                AddOne(rand.Next(0, 2), i, 0);
            }

        }

        public void Add()
        {
            if (_nowCount < _maxSize)
            {
                Console.Write("Введите текущий возраст рыбы: ");
                int nowAge = Convert.ToInt32(Console.ReadLine());

                Console.Write("Введите тип рыбы: 0 - @, 1 - # ");
                int numType = Convert.ToInt32(Console.ReadLine());

                _nowCount++;

                AddOne(numType, _nowCount - 1, nowAge);
                Console.WriteLine("\nНовая рыба добавлена в аквариум");

            }
            else
            {
                Console.WriteLine("В аквариуме максимальное количество рыб!");
            }

        }
        public void AddOne(int numType, int num, int nowAge)
        {
            if (numType == 0) _dataBase[num] = new At(num + 1, nowAge, _beginAquariumY);
            else _dataBase[num] = new Sharp(num + 1, nowAge, _beginAquariumY);

        }
        public void Delete()
        {
            if (_nowCount > 0)
            {
                Console.Write("Введите номер удаляемой рыбы: ");
                int number = Convert.ToInt32(Console.ReadLine());

                _nowCount--;
                ChangeDataBase(_dataBase.Length, number);
                for (int i = 0; i < _nowCount; i++)
                {
                    _dataBase[i].ChangeNumber(i + 1);
                }

                Console.WriteLine("\nРыба удалена из аквариума");
            }
            else
            {
                Console.WriteLine("В аквариуме нет рыб!");
            }

        }

        public void ChangeDataBase(int newSize, int deleteNumber = 0)
        {
            int j = 0;
            Fish[] tempArray = new Fish[newSize];
            for (int i = 0; i < _dataBase.Length; i++)
            {
                if (i != deleteNumber - 1)
                {
                    tempArray[j] = _dataBase[i];
                    j++;
                }
            }
            _dataBase = tempArray;
        }

        public void UpAge()
        {
            for (int i = 0; i < _nowCount; i++)
            {
                _dataBase[i].UpAge();
            }
        }

        public void ShowInfo()
        {
            for (int i = 0; i < _nowCount; i++)
            {
                Console.WriteLine(_dataBase[i].Info());
            }
        }

        public void DrawAquarium()
        {
            ConsoleColor defaultBackColor = Console.BackgroundColor;

            for (int i = 0; i < _hight; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    if (i == 0 || i == _hight - 1) Console.Write('-');
                    else if (j == 0 || j == Console.WindowWidth - 1) Console.Write('|');
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(' ');
                        Console.BackgroundColor = defaultBackColor;
                    }
                }

            }
            Console.WriteLine();

        }
        public void DrawFish()
        {
            ConsoleColor defaultBackColor = Console.BackgroundColor;
            ConsoleColor defaultForeColor = Console.ForegroundColor;


            Console.BackgroundColor = ConsoleColor.DarkBlue;

            for (int i = 0; i < _nowCount; i++)
            {
                _dataBase[i].Draw();

            }

            Console.BackgroundColor = defaultBackColor;
            Console.ForegroundColor = defaultForeColor;

            Console.SetCursorPosition(0, _endAquariumY);

        }
        public void MoveFish()
        {
            for (int i = 0; i < _nowCount; i++)
            {
                _dataBase[i].Move(_endAquariumY);

            }
        }


    }

    class Fish
    {
        protected int X;
        protected int Y;
        protected int DirectX;
        protected int DirectY;
        protected char Symbol;
        protected ConsoleColor _color;

        private int _beginAquariumY;

        private int _number;
        private int _age;
        private bool _isAlive = true;
        private string _isAliveInfo = "Жива";

        private const int _maxAge = 30;



        public Fish(int number, int age, int beginAquariumY)
        {
            _number = number;
            _age = age;
            _beginAquariumY = beginAquariumY;
            Y = _beginAquariumY + number;
        }

        public void UpAge()
        {
            if (_age < _maxAge) _age++;
            else if (_age >= _maxAge)
            {
                _isAlive = false;
                _isAliveInfo = "Мертва";
                Symbol = 'X';
            }

        }

        public void ChangeNumber(int newNumer)
        {
            _number = newNumer;
            Y = _beginAquariumY + newNumer;
        }
        public string Info()
        {
            string info = $"Рыба № {_number} - Возраст: {_age}, Тип: {Symbol}, Статус: {_isAliveInfo}";
            return info;
        }
        public void Draw()
        {
            Console.ForegroundColor = _color;
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
        public virtual void Move(int endAquariumY)
        {
            if (_isAlive)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(' ');

                if (Console.CursorLeft + DirectX <= 1 || Console.CursorLeft + DirectX >= Console.WindowWidth - 2) DirectX *= -1;
                else if (Console.CursorTop + DirectY <= _beginAquariumY || Console.CursorTop + DirectY >= endAquariumY - 1) DirectY *= -1;

                X += DirectX;
                Y += DirectY;

                Console.SetCursorPosition(X, Y);
                Console.Write(Symbol);
            }

        }

    }
    class At : Fish
    {

        public At(int number, int age, int y) : base(number, age, y)
        {
            X = 1;
            DirectX = 1;
            DirectY = 1;
            Symbol = '@';
            _color = ConsoleColor.Red;
        }
    }
    class Sharp : Fish
    {
        public Sharp(int number, int age, int y) : base(number, age, y)
        {
            X = Console.WindowWidth - 2;
            DirectX = 1;
            DirectY = 0;
            Symbol = '#';
            _color = ConsoleColor.Yellow;
        }

    }


}