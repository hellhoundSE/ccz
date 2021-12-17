using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
            var runPipeline = new Pipeline();
            string resourceGroup = "RuslanResourceGroup";
            string dataFactoryName = "ruslandf";
            if (args == null) {
                Console.WriteLine("args is null");
            } else {
                runPipeline.StartPipeline(resourceGroup, dataFactoryName, args[0]);
            }




        }

    }
}
