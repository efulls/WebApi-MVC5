using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            BeratBadan bb = new BeratBadan();
            try
            {
                bb.showBeratBadan();
            }
            catch (TidakIdealException e)
            {
                Console.WriteLine("TidakIdealException: {0}", e.Message);
            }
            Console.ReadLine();
        }


    }

    public class TidakIdealException : Exception
    {

        public TidakIdealException(string message) : base(message)
        {

        }
    }
    public class BeratBadan
    {
        float beratbadan = 55;
        float tinggibadan = 170;


        public void showBeratBadan()
        {

            float ideal = ((tinggibadan - 100) - ((tinggibadan - 100) / 100));

            if (beratbadan != ideal)
            {
                throw (new TidakIdealException("Berat Badan Anda Tidak Ideal, Berat badan ideal anda adalah :" + ideal));
            }
            else
            {
                Console.WriteLine("Berat badan anda ideal: {0}", beratbadan);
            }
        }
    }


}
