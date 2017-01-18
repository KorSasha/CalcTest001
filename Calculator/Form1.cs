using Console1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Calc Calc { get; set; }
        private IEnumerable<string> OperationName { get; set; }
        public string oper { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            var operations = new List<IOperation>();
            //Найти файлы .dll и exe в текущей директории
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.exe")
            .Union(Directory.GetFiles(Environment.CurrentDirectory, "*.dll"));
            //Загрузить их
            #region 
            foreach (var file in files)
            {
                //
                var assebly = Assembly.LoadFile(file);//сборка
                var types = assebly.GetTypes();

                foreach (var type in types)
                {
                    var interfaces = type.GetInterfaces();
                    //найти реализацию интерфейса IOperation
                    if (interfaces.Contains(typeof(IOperation)))
                    {
                        Console.WriteLine(type.Name);
                        //создаем экземпляр класса и приводим к нужному интерфейсу
                        var oper = Activator.CreateInstance(type) as IOperation; // as - приведение к типу
                        if (oper != null)
                        {
                            operations.Add(oper);
                        }
                    }
                }
                Console.WriteLine(file);
                //Создать экземпляр класса
                //и все эти экземляры передаем в Calc
            }
            #endregion
            Calc = new Calc(operations);
            OperationName = Calc.GetOperationNames();
            FillCombobox();
        }
        private void FillCombobox()
        {
            this.comboBox1.Items.AddRange(OperationName.ToArray());

        }

        private void button1_Click(object sender, EventArgs e)
        {

            object[] argument = new object[4]; ;
            //if ((comboBox1.Text.ToString() == "Sum"))
            {
                if (textBox1.Text.ToString() == "")
                {
                    if ((comboBox1.Text.ToString() == "pi")|| (comboBox1.Text.ToString() == "Pi"))
                    {
                        lblResult.Text = Calc.Execute(comboBox1.Text.ToString(), argument).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Введите параметры");
                        lblResult.Text = "eror";
                    }
                }
                 else
                {
                    argument[0] = textBox1.Text.ToString();
                    if (textBox2.Text.ToString() == "")
                    {
                        lblResult.Text = Calc.Execute(comboBox1.Text.ToString(), argument).ToString();
                    }
                    else
                    {
                        argument[0] = textBox1.Text.ToString();
                        argument[1] = textBox2.Text.ToString();
                        if (textBox3.Text.ToString() == "")
                        {
                            lblResult.Text = Calc.Execute(comboBox1.Text.ToString(), argument).ToString();
                        }
                        else
                        {
                            argument[0] = textBox1.Text.ToString();
                            argument[1] = textBox2.Text.ToString();
                            argument[2] = textBox3.Text.ToString();
                            if (textBox4.Text.ToString() == "")
                            {
                                lblResult.Text = Calc.Execute(comboBox1.Text.ToString(), argument).ToString();
                            }
                            else
                            {
                                argument[0] = textBox1.Text.ToString();
                                argument[1] = textBox2.Text.ToString();
                                argument[2] = textBox3.Text.ToString();
                                argument[3] = textBox4.Text.ToString();
                                lblResult.Text = Calc.Execute(comboBox1.Text.ToString(), argument).ToString();
                            }
                        }
                    }
                }
            }
            //lblResult.Text = Calc.Execute(comboBox1.Text.ToString(), argument).ToString();
            //MessageBox.Show


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
