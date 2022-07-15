using LabaN14;

var fileReader = new FileReader();
#region CreateArray
int[][] myArr = new int[5][];
myArr[0] = new int[4];
myArr[1] = new int[6];
myArr[2] = new int[3];

var rnd = new Random();
for (int i = 0; i < 4; i++)
{
    myArr[0][i] = rnd.Next(0, 20);
}

Console.WriteLine();
for (int i = 0; i < 6; i++)
{
    myArr[1][i] = rnd.Next(0, 20);
}

Console.WriteLine();
for (int i = 0; i < 3; i++)
{
    myArr[2][i] = rnd.Next(0, 20);
}
#endregion

fileReader.WriteArr("input1.txt", myArr);

//1. Считать из файла input1.txt ступенчатый массив. Умножить минимальное на максимальное в каждой строки.
//И из этих числе найти среднее. Результат записать в файл output1.txt.

var arr1 = fileReader.ReadArrInt("input1.txt");
var Mins = arr1.Select(x => x.Min(m => m)).ToArray();
var Maxs = arr1.Select(x => x.Max(m => m)).ToArray();

using var sw = new StreamWriter("output1.txt");
double sum = 0.0;
for (int i = 0, j = 0; i < Mins.Length && j < Maxs.Length; i++, j++)
{
    sum += Mins[i] * Maxs[j];
}
sw.WriteLine(sum / arr1.Length);


// Считать из файла input1.txt ступенчатый массив. 
// Посчитать произведение в каждой строке из этих чисел найти среднее. Результат записать в файл output1.txt.
sw.WriteLine(arr1.Select(x => x.Aggregate((x, y) => x * y)).Average());

// Считать из файла input2.txt текст.
//    Отсортировать предложения по проценту гласных букв в нем. Вывести вначале те, где процент меньше, а затем те где их больше.

var res2 = fileReader.ReadArrString("input2.txt");
var vowels = "ауоыиэяюёе".ToCharArray();

res2 = res2.OrderBy(x => (double)x.Count(s => vowels.Contains(s)) / x.Length * 100).ToArray();
foreach (var str in res2)
    Console.WriteLine(str);

// Считать из файла input2.txt текст. Отсортировать слова в каждом предложении по алфавиту.
var res3 = fileReader.ReadArrString("input2.txt");
var res4 = res3.Select(x => x.Split(' ').OrderBy(x => x));

foreach (var str in res4)
    Console.WriteLine(string.Join(' ',str));






