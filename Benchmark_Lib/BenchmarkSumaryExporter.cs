using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark_Lib
{
    public static class BenchmarkSumaryExporter
    {
        private static string[] _sumaryProperties = {"Sumaries", "FirstRunElapsed", "Mean", "Max", "Min", "LauchedCount", "ExceptFirstRun" };
        public static void ExportToExcel(ICollection<BenchmarkSumary> sumaries, int workSheet = 0, string filePath = "")
        {
            filePath += "\\EFBenchmark_Result.xlsx";
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(filePath);
            Worksheet worksheet = workbook.Worksheets[workSheet];
            int lastFilledRow = worksheet.LastRow;
            if (lastFilledRow > 5000)
                lastFilledRow = -1;

            char colPos = 'A';
            int rowPos = lastFilledRow + 2;
            foreach (var item in _sumaryProperties)
            {
                worksheet.Range[colPos.ToString() + rowPos].Text = item;
                rowPos++;
            }

            foreach (var item in sumaries)
            {
                colPos = (char)((int)colPos + 1);
                rowPos = lastFilledRow + 2;
                worksheet.Name = item.Name.Split('.')[0];
                worksheet.Range[colPos.ToString() + rowPos].Text = item.Name.Split('.')[1];
                rowPos++;
                worksheet.Range[colPos.ToString() + rowPos].NumberValue = item.FirstRunElapsed;
                rowPos++;
                worksheet.Range[colPos.ToString() + rowPos].NumberValue = item.Mean;
                rowPos++;
                worksheet.Range[colPos.ToString() + rowPos].NumberValue = item.Max;
                rowPos++;
                worksheet.Range[colPos.ToString() + rowPos].NumberValue = item.Min;
                rowPos++;
                worksheet.Range[colPos.ToString() + rowPos].Text = item.LauchedCount.ToString();
                rowPos++;
                worksheet.Range[colPos.ToString() + rowPos].Text = item.ExceptFirstRun.ToString();
                rowPos++;
            }

            worksheet.AllocatedRange.AutoFitColumns();
            worksheet.AllocatedRange.AutoFitRows();

            int topRow = lastFilledRow + 2;
            int botRow = rowPos - 3;
            Chart chart = worksheet.Charts.Add();
            chart.DataRange = worksheet.Range["A" + topRow.ToString() + ":" + colPos.ToString() + botRow.ToString()];
            chart.SeriesDataFromRange = false;
            chart.LeftColumn = colPos - 'A' + 3;
            chart.TopRow = topRow;
            chart.RightColumn = chart.LeftColumn + (colPos - 'A') * 3 + 3;
            chart.BottomRow = botRow + 10;
            chart.ChartTitle = worksheet.Name;
            worksheet.Range["A" + chart.BottomRow].Text = ".";

            workbook.SaveToFile(filePath, ExcelVersion.Version2016);
        }
    }
}
