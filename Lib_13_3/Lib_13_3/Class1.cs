namespace Lib_13_3
{
    public class prakt3
    {
       /// <summary>
       /// Функция для возвращения количества меньших среднего чисел строки
       /// </summary>
       /// <param name="matr">матрица</param>
       /// <returns>строку с количеством меьших каждой строки матрицы</returns>
        public static string KolMatr(int[,] matr)
        {
            string str = "Количество чисел, которые меньше среднего арифметического: " ;
            int kol = 0;//количество чисел в строке
            double sr = 0;//среднее
            int men = 0;//количество меньших чисел
            int M = matr.GetLength(0);
            int N = matr.GetLength(1);
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)//считаем количество чисел в строке и прибавляем все значения, затем рассчитываем среднее
                {
                    kol++;
                    sr = sr + matr[i, j];
                }
                sr = sr / kol;
                for(int j = 0; j < N; j++)//снова проходим строку, вычисляя меньшие среднего значения и суммируя их
                {
                    if (matr[i,j]<sr)
                    {
                        men++;
                    }
                }
                sr = 0;//обнуляем среднее, записываем в строку новое значение, обнуляем количество меньших
                str += men + " ";
                men = 0;
                kol = 0;
            }
            return str;
        }
    }
}
