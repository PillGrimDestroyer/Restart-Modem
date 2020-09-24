using System;
using System.IO.Ports;

namespace Restart_Modem
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort _serialPort;
            int selectedPosition;
            string selectedPort;

            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("Список найденых портов:");
            Console.WriteLine();

            for (int i = 1; i <= ports.Length; i++)
            {
                int index = i - 1;
                string port = ports[index];

                Console.WriteLine("{0}. {1}", i, port);
            }

            Console.WriteLine();
            Console.WriteLine("Введите номер нужного порта:");

            char key = Console.ReadKey().KeyChar;
            selectedPosition = Convert.ToInt32(key.ToString()) - 1;

            selectedPort = ports[selectedPosition];

            Console.WriteLine();
            Console.WriteLine("Начинаю работу");

            _serialPort = new SerialPort(selectedPort, 115200);
            Tools._pause(1000);

            while (true)
            {
                _serialPort.Open();
                Tools._pause(1000);

                _serialPort.Write("AT+CFUN=0\r\n");
                Tools._pause(2000);

                _serialPort.Write("AT+CFUN=1\r\n");
                Tools._pause(1000);

                _serialPort.Close();

                Tools._pause((60 * 1000) * 5);
            }
        }
    }
}
