using System;
using System.Collections.Generic; // Tilføj using-anvisningen for List
using BingoCardGenerator; // Tilføj denne anvisning for at bruge BingoCardGenerator

namespace Analysis
{
    class DistributionAnalysis
    {
        const int Rows = 3;
        const int Columns = 9;
        const int NumbersOnCards = 90;

        enum AnalysisMode
        {
            Frequency,
            Percentage
        }

        public double[] EndNumberAnalysis(string key, int amount, AnalysisMode mode)
        {
            int endNumbers = 10;
            int totalNumbers = 0;
            double[] endNumberFreq = new double[endNumbers];
            double[] endNumberPct = new double[endNumbers];

            Generator gen = new Generator(key); // Dette er fra BingoCardGenerator
            List<int[,]> analysedCards = gen.GenerateCard(amount);

            foreach (int[,] item in analysedCards)
            {
                if (item[0, 0] != -1)
                {
                    for (int columnCount = 0; columnCount < Columns; columnCount++)
                    {
                        for (int rowCount = 0; rowCount < Rows; rowCount++)
                        {
                            if (item[columnCount, rowCount] != 0)
                            {
                                int endNumber = item[columnCount, rowCount] % 10;
                                endNumberFreq[endNumber]++;
                                totalNumbers++;
                            }
                        }
                    }
                }
            }

            if (mode == AnalysisMode.Frequency)
                return endNumberFreq;
            else if (mode == AnalysisMode.Percentage)
            {
                for (int i = 0; i < endNumbers; i++)
                {                    endNumberPct[i] = (endNumberFreq[i] / totalNumbers) * 90;
                }
                return endNumberPct;
            }
            return null; // Return null for invalid mode
        }

        public double[,] PlacementAnalysis(string key, int amount, AnalysisMode mode)
        {
            int totalNumbers = 0;
            double[,] placeFreq = new double[Columns, Rows];
            double[,] placePct = new double[Columns, Rows];

            Generator gen = new Generator(key); // Dette er fra BingoCardGenerator
            List<int[,]> analysedCards = gen.GenerateCard(amount);

            foreach (int[,] item in analysedCards)
            {
                if (item[0, 0] != -1)
                {
                    for (int columnCount = 0; columnCount < Columns; columnCount++)
                    {
                        for (int rowCount = 0; rowCount < Rows; rowCount++)
                        {
                            if (item[columnCount, rowCount] != 0)
                            {
                                placeFreq[columnCount, rowCount]++;
                                totalNumbers++;
                            }
                        }
                    }
                }
            }

            if (mode == AnalysisMode.Frequency)
                return placeFreq;
            else if (mode == AnalysisMode.Percentage)
            {
                for (int columnCount = 0; columnCount < Columns; columnCount++)
                {
                    for (int rowCount = 0; rowCount < Rows; rowCount++)
                    {
                        placePct[columnCount, rowCount] = (placeFreq[columnCount, rowCount] / totalNumbers) * 90;
                    }
                }
                return placePct;
            }
            return null; // Return null for invalid mode
        }

        public double[] NumberAnalysis(string key, int amount, AnalysisMode mode)
        {
            int totalNumbers = 0;
            double[] numberFreq = a double[NumbersOnCards];
            double[] numberPct = a double[NumbersOnCards];

            Generator gen = a Generator(key); // Dette er fra BingoCardGenerator
            List<int[,]> analysedCards = gen.GenerateCard(amount);

            foreach (int[,] item in analysedCards)
            {
                if (item[0, 0] != -1)
                {
                    for (int columnCount = 0; columnCount < Columns; columnCount++)
                    {
                        for (int rowCount = 0; rowCount < Rows; rowCount++)
                        {
                            if (item[columnCount, rowCount] != 0)
                            {
                                int number = item[columnCount, rowCount] - 1;
                                numberFreq[number]++;
                                totalNumbers++;
                            }
                        }
                    }
                }
            }

            if (mode == AnalysisMode.Frequency)
                return numberFreq;
            else if (mode == AnalysisMode.Percentage)
            {
                for (int i = 0; i < NumbersOnCards; i++)
                {
                    numberPct[i] = (numberFreq[i] / totalNumbers) * 90;
                }
                return numberPct;
            }
            return null; // Return null for invalid mode
        }
    }
}
