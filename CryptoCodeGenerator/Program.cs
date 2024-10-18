﻿using System;

namespace CryptoCodeGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var requirements = new CodeRequirements(4, 9, 3);
            var distanceCalculator = new HammingDistanceCalculator();
            var variationsGenerator = new VariationsGenerator();
            var codeGeneraor = new CodeGenerator(variationsGenerator, distanceCalculator);
            foreach (var generateCodeSpecifiedByRequirement in codeGeneraor.GenerateCodeSpecifiedByRequirements(requirements, new[] {'0', '1', '2'}))
            {
                Console.WriteLine(generateCodeSpecifiedByRequirement);
            }

        }
    }
}
