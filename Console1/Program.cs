using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() == 0)
            {
                Console.WriteLine(" Console1.exe \"Razn\" \"3\" \"2\"");
                Console.ReadKey();
                return;
            }
            var operations = new List<IOperation>();
            //Найти файлы .dll и exe в текущей директории
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.exe")
            .Union(Directory.GetFiles(Environment.CurrentDirectory, "*.dll"));
            //Загрузить их
            #region 
            foreach (var file in files)
            {
                var assebly = Assembly.LoadFile(file);//сборка
                var types = assebly.GetTypes();
               
                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();
                    //найти реализацию интерфейса IOperation
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        //Console.WriteLine(type.Name);
                        //создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation; // as - приведение к типу
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }
                }
               //Console.WriteLine(file);
                //Создать экземпляр класса
                //и все эти экземляры передаем в Calc
            }
            #endregion


            var calc = new Calc(operations);

            var activeoper = args[0];
            var parameters = args.Skip(1).ToArray();

            var result = calc.Execute(activeoper, parameters);
            Console.WriteLine(string.Format("result = {0}", result));

            /* var calc = new Calc(new IOperation[] { new SumOperation(), new RazOperation(), new PowOperation(), new UmnsumOperation() });
            
            //int result = calc.Sum(1,2);
            var result = calc.Execute("Sum", new object[] { 1, 2 });
            var result2 = calc.Execute("Raz", new object[] { 3, 1 });
            var result3 = calc.Execute("Pow", new object[] { 3 });
            var result4 = calc.Execute("UmnSum", new object[] { 2, 3, 2 });
            //var result5 = calc.Execute(Console.ReadLine(), new object[] { 2, 3, 2 });

            Console.WriteLine(string.Format("result Sum = {0}",result));
            Console.WriteLine(string.Format("result Raz = {0}", result2));
            Console.WriteLine(string.Format("result Pow = {0}", result3));
            Console.WriteLine(string.Format("result UmnSum = {0}", result4));
            //Console.WriteLine(string.Format("result UmnSum = {0}", result5));*/
            // Console.WriteLine($"(result)");
            Console.ReadKey();
        }
    }
}
