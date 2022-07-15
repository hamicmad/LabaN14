using System.Text;

namespace LabaN14
{
    public class FileReader
    {
        public void WriteArr(string path, int[][] arr)
        {
            try
            {
                using var sw = new StreamWriter(path, true);
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        sw.Write(arr[i][j] + " ");
                    }
                    sw.WriteLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public int[][] ReadArrInt(string path)
        {
            string[] rows = File.ReadAllLines(path);
            int[][] array = new int[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                string[] numbers = rows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                array[i] = new int[numbers.Length];
                for (int j = 0; j < numbers.Length; j++)
                {
                    array[i][j] = int.Parse(numbers[j]);
                    Console.Write("{0} ", array[i][j]);
                }
                Console.WriteLine();
            }
            return array;
        }
        public string[] ReadArrString(string path)
        {
            using var sw = new StreamReader(path);
            return sw.ReadToEnd().Split('.',StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
