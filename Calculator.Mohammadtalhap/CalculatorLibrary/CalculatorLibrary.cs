﻿using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            //StreamWriter logfile = File.CreateText("calculator.log");
            //Trace.Listeners.Add(new TextWriterTraceListener(logfile));
            //Trace.AutoFlush = true;
            //Trace.WriteLine("Starting Calculator Log");
            //Trace.WriteLine(String.Format($"Started {System.DateTime.Now.ToString()}"));
            StreamWriter logfile = File.CreateText("calculatorlog.json");
            logfile.AutoFlush = true;
            writer = new JsonTextWriter(logfile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();

        }
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    //Trace.WriteLine($"{num1} + {num2} = {result}");
                    writer.WriteValue("Add");
                    break;

                case "s":
                    result = num1 - num2;
                    //Trace.WriteLine($"{num1} - {num2} = {result}");
                    writer.WriteValue("Subtract");
                    break;

                case "m":
                    result = num1 * num2;
                    //Trace.WriteLine($"{num1} * {num2} = {result}");
                    writer.WriteValue("Multiply");
                    break;

                case "d":
                    if (num2 != 0)
                            result = num1 / num2;
                    //Trace.WriteLine($"{num1} / {num2} = {result}");
                    writer.WriteValue("Divide");
                    break;

                default:
                    Console.WriteLine("Please enter an appropriate operator");
                    break;

            }

            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}
