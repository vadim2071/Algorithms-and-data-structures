using System;
using System.Collections.Generic;
using System.IO;

/*
External sort
Extertnal sort — расширение блочной сортировки (но без особенности, что в каждом блоке элементы должны быть меньше, чем в следующем), для решения проблемы, когда массив не помещается в оперативную память и его хранят на внешней памяти, например просто на жестком диске. В этом алгоритме применяются следующие шаги:
Определение максимального размера блока.
Чтение данных из файла в блок.
Сортировка данных в блоке.
Сохранение содержимого блока в отдельный временный файл.
Если файл был прочитан не полностью, вернуться к пункту 2.
Постепенное чтение отсортированных блоков из ранее сохранённых файлов, и запись читаемых (в порядке сортировки) данных в финальный файл (стадия merge из mergesort).
*/

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePass = Directory.GetCurrentDirectory() + "\\"; //определяем текущее места запуска проекта для сохранения файлов сортирвокм
            // создаем "Большой" файл для хранения данных которые необходимо сортировать, если он есть, то он перезаписывается
            string file_sort = FilePass + "NeedSort.txt";
            File.Create(file_sort).Close();
            int num = 10000; //- количество элементовв файле для сортировки
            Random rand = new Random();

            //заполняем файл случайными числами
            int v = rand.Next(1000);
            File.AppendAllText(file_sort, v.ToString());
            for (int i = 0; i < num-1; i++) 
            {
                File.AppendAllText(file_sort, Environment.NewLine);
                v = rand.Next(1000);
                File.AppendAllText(file_sort, v.ToString());
            }

            int countTempFiles = GetCountFiles(file_sort);

            //предполагаем что файлов для хранения временных файлов для сортировки достаточно 10, создаем их
            string file_100 = "FilePass + file_100.txt";
            string file_200 = "FilePass + file_200.txt";
            string file_300 = "FilePass + file_300.txt";
            string file_400 = "FilePass + file_400.txt";
            string file_500 = "FilePass + file_500.txt";
            string file_600 = "FilePass + file_600.txt";
            string file_700 = "FilePass + file_700.txt";
            string file_800 = "FilePass + file_800.txt";
            string file_900 = "FilePass + file_900.txt";
            string file_1000 = "FilePass + file_1000.txt";

            BigFileToSmallFile(file_sort);
            File.Create(file_sort).Close(); //очищаем Большой файл

            Console.WriteLine("нажмите Ентер для сортиовки малых файлов");
            Console.ReadLine();

            SortSmallFile(file_100);
            SortSmallFile(file_200);
            SortSmallFile(file_300);
            SortSmallFile(file_400);
            SortSmallFile(file_500);
            SortSmallFile(file_600);
            SortSmallFile(file_700);
            SortSmallFile(file_800);
            SortSmallFile(file_900);
            SortSmallFile(file_1000);

            SmallFileToBig(file_sort);


            int GetCountFiles(string SortFile) //метод который анализирует сортируемый файл и выдает количество временных файлов для сортировки
            {
                return 10; // в нашем случае не реализовано, предполагаем что надо 10 файлов
            }

            void BigFileToSmallFile(string sortFile) // метод сохраняет 10 файлов с набором чисел в одном диапазоне с  шагом 100

            {
                File.Create(file_100).Close();
                File.Create(file_200).Close();
                File.Create(file_300).Close();
                File.Create(file_400).Close();
                File.Create(file_500).Close();
                File.Create(file_600).Close();
                File.Create(file_700).Close();
                File.Create(file_800).Close();
                File.Create(file_900).Close();
                File.Create(file_1000).Close();

                int num_temp;
                StreamReader file = new StreamReader(sortFile);
                StreamWriter Sfile_100 = new StreamWriter(file_100);
                StreamWriter Sfile_200 = new StreamWriter(file_200);
                StreamWriter Sfile_300 = new StreamWriter(file_300);
                StreamWriter Sfile_400 = new StreamWriter(file_400);
                StreamWriter Sfile_500 = new StreamWriter(file_500);
                StreamWriter Sfile_600 = new StreamWriter(file_600);
                StreamWriter Sfile_700 = new StreamWriter(file_700);
                StreamWriter Sfile_800 = new StreamWriter(file_800);
                StreamWriter Sfile_900 = new StreamWriter(file_900);
                StreamWriter Sfile_1000 = new StreamWriter(file_1000);

                string line; //для хранения прочитанной строчки из большого файла

                while ((line = file.ReadLine()) != null)
                {
                    num_temp = Convert.ToInt32(line);
                    if (num_temp >= 0 & num_temp <= 100) Sfile_100.WriteLine(num_temp);
                    else if (num_temp > 100 & num_temp <= 200) Sfile_200.WriteLine(num_temp);
                    else if (num_temp > 200 & num_temp <= 300) Sfile_300.WriteLine(num_temp);
                    else if (num_temp > 300 & num_temp <= 400) Sfile_400.WriteLine(num_temp);
                    else if (num_temp > 400 & num_temp <= 500) Sfile_500.WriteLine(num_temp);
                    else if (num_temp > 500 & num_temp <= 600) Sfile_600.WriteLine(num_temp);
                    else if (num_temp > 600 & num_temp <= 700) Sfile_700.WriteLine(num_temp);
                    else if (num_temp > 700 & num_temp <= 800) Sfile_800.WriteLine(num_temp);
                    else if (num_temp > 800 & num_temp <= 900) Sfile_900.WriteLine(num_temp);
                    else if (num_temp > 900 & num_temp <= 1000) Sfile_1000.WriteLine(num_temp);
                }
                file.Close();
                Sfile_100.Close();
                Sfile_200.Close();
                Sfile_300.Close();
                Sfile_400.Close();
                Sfile_500.Close();
                Sfile_600.Close();
                Sfile_700.Close();
                Sfile_800.Close();
                Sfile_900.Close();
                Sfile_1000.Close();
            }

            void SortSmallFile(string sort_file) //метод сортировки файла с помощью списков и быстрой сортировки
            {
                List<int> SortList = new List<int>();
                StreamReader file_R = new StreamReader(sort_file);
                string nextLine;
                while ((nextLine = file_R.ReadLine()) != null) SortList.Add(Convert.ToInt32(nextLine)); //переносим содержимое файла в список

                int count = SortList.Count;
                QuickSort(SortList, 0, count-1); //сортируем список
                file_R.Close();
                File.Create(sort_file).Close();         //стираю старый файл 
                StreamWriter file_W = new StreamWriter(sort_file);
                for (int i =0; i < count; i++) file_W.WriteLine(SortList[i]); //возвращаем отсортированные данные обратно в файл
                file_W.Close();
            }

            void SmallFileToBig(string PathFile)  // метод сбора маленьких файлов в большой
            {
                int num_temp;
                StreamWriter file = new StreamWriter(PathFile);
                StreamReader Sfile_100 = new StreamReader(file_100);
                StreamReader Sfile_200 = new StreamReader(file_200);
                StreamReader Sfile_300 = new StreamReader(file_300);
                StreamReader Sfile_400 = new StreamReader(file_400);
                StreamReader Sfile_500 = new StreamReader(file_500);
                StreamReader Sfile_600 = new StreamReader(file_600);
                StreamReader Sfile_700 = new StreamReader(file_700);
                StreamReader Sfile_800 = new StreamReader(file_800);
                StreamReader Sfile_900 = new StreamReader(file_900);
                StreamReader Sfile_1000 = new StreamReader(file_1000);

                string line; //для хранения прочитанной строчки из большого файла

                while ((line = Sfile_100.ReadLine()) != null) file.WriteLine(line);
                while ((line = Sfile_200.ReadLine()) != null) file.WriteLine(line);
                while ((line = Sfile_300.ReadLine()) != null) file.WriteLine(line);
                while ((line = Sfile_400.ReadLine()) != null) file.WriteLine(line);
                while ((line = Sfile_500.ReadLine()) != null) file.WriteLine(line);
                while ((line = Sfile_600.ReadLine()) != null) file.WriteLine(line);
                while ((line = Sfile_700.ReadLine()) != null) file.WriteLine(line);
                while ((line = Sfile_800.ReadLine()) != null) file.WriteLine(line);
                while ((line = Sfile_900.ReadLine()) != null) file.WriteLine(line);
                while ((line = Sfile_1000.ReadLine()) != null) file.WriteLine(line);

                file.Close();
                Sfile_100.Close();
                Sfile_200.Close();
                Sfile_300.Close();
                Sfile_400.Close();
                Sfile_500.Close();
                Sfile_600.Close();
                Sfile_700.Close();
                Sfile_800.Close();
                Sfile_900.Close();
                Sfile_1000.Close();
            }


            static void QuickSort(List<int> list, int first, int last) //метод быстройсортировки
            {
                if (list.Count == 0) return;
                int i = first, j = last, x = list[(first + last) / 2];

                do
                {
                    while (list[i] < x)
                        i++;
                    while (list[j] > x)
                        j--;

                    if (i <= j)
                    {
                        if (list[i] > list[j])
                        {
                            var tmp = list[i];
                            list[i] = list[j];
                            list[j] = tmp;
                        }

                        i++;
                        j--;
                    }
                } while (i <= j);

                if (i < last)
                    QuickSort(list, i, last);
                if (first < j)
                    QuickSort(list, first, j);
            }
        }
    }
}