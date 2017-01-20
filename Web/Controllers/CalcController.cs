using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Console1;
using Web.Models;
using SuperOperations;
using UmnSumOperation;
using System.IO;
using System.Web.Hosting;
using System.Reflection;

namespace Web.Controllers
{
    //фильтры
   // [Authorize]
    public class CalcController : Controller
    {
        public Calc Calculator { get; private set; }

        public CalcController()
        {
            var operations = new List<IOperation>();

            #region Получение всех возможных операций
            // найти файлы dll и exe в текущей директории
            var files = Directory.GetFiles(HostingEnvironment.MapPath("~/") + "\\App_Data", "*.exe");

            //загрузить их
            foreach (var file in files)
            {
                //Console.WriteLine(file);
                var assembly = Assembly.LoadFile(file);

                foreach (var type in assembly.GetTypes().Where(t => t.IsClass))
                {
                    //найти реализацюию интерфейса IOperation
                    var interfaces = type.GetInterfaces();
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        //создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation;
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }
                }
            }
            #endregion

            Calculator = new Calc(operations);
        }

        // GET: Calc
        public ActionResult Index()
        {
            // ViewData.Model = new OperationModel();
            //return View(new OperationModel());
            var opers = Calculator.GetOperationNames().Select(o => new SelectListItem() { Text = o, Value = o });
            ViewBag.Operations = opers;
            return View(new OperationModel());
        }

        public ActionResult Execute( OperationModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            if (model.Name.ToUpper() == "Sum".ToUpper())
            {
                var calc = new Calc(new IOperation[] { new SumOperation() });
                //var result = calc.Execute(model.Name, model.GeParameters());
                var result = Calculator.Execute(model.Name, model.GeParameters());
                // var result = calc.Execute(Convert.ToString(model.GeOperation()).ToUpper(), model.GeParameters());
                ViewData.Model = $"result = {result}";
            }
            if (model.Name.ToUpper() == "Summ".ToUpper())
            {
                var calc = new Calc(new IOperation[] { new DivOperation() });
                var result = calc.Execute(model.Name, model.GeParameters());
                // var result = calc.Execute(Convert.ToString(model.GeOperation()).ToUpper(), model.GeParameters());
                ViewData.Model = $"result = {result}";
            }

            if (model.Name.ToUpper() == "Raz".ToUpper())
            {
                var raz = new Calc(new IOperation[] { new RazOperation() });
                var result = raz.Execute(model.Name, model.GeParameters());
                ViewData.Model = $"result = {result}";
            }

            if (model.Name.ToUpper() == "RazSum".ToUpper())
            {
                var raz = new Calc(new IOperation[] { new Therma() });
                var result = raz.Execute(model.Name, model.GeParameters());
                ViewData.Model = $"result = {result}";
            }

            if(model.Name.ToUpper() == "DelSum1".ToUpper())
            {
                var raz = new Calc(new IOperation[] { new UmnSumar() });
                var result = raz.Execute(model.Name, model.GeParameters());
                ViewData.Model = $"result = {result}";
            }

            if (model.Name.ToUpper() == "Single".ToUpper())
            {
                var raz = new Calc(new IOperation[] { new UmnSumOperation.UmnSum() });
                var result = raz.Execute(model.Name, model.GeParameters());
                ViewData.Model = $"result = {result}";
            }

            if (model.Name.ToUpper() == "DelSum".ToUpper())
            {
                var raz = new Calc(new IOperation[] { new DelSum.DelSum() });
                var result = raz.Execute(model.Name, model.GeParameters());
                ViewData.Model = $"result = {result}";
            }

            return View();
           //return $"result = result";
        }
        

    }
}