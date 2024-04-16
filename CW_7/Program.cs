using System;

public class Array : IOutput, IMath, ISort
{
    private int[] data;

    public Array(int[] data)
    {
        this.data = data;
    }
    public void Show()  // методи IOutput
    {
        Console.WriteLine("Елементи масиву:");
        foreach (var item in data)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public void Show(string info)
    {
        Console.WriteLine("Елементи масиву:");
        foreach (var item in data)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        Console.WriteLine(info);
    }


    public int Max() // методи IMath
    {
        int max = data[0];
        foreach (var item in data)
        {
            if (item > max)
            {
                max = item;
            }
        }
        return max;
    }
    public int Min()
    {
        int min = data[0];
        foreach (var item in data)
        {
            if (item < min)
            {
                min = item;
            }
        }
        return min;
    }
    public float Avg()
    {
        float sum = 0;
        foreach (var item in data)
        {
            sum += item;
        }
        return sum / data.Length;
    }
    public bool Search(int valueToSearch)
    {
        foreach (var item in data)
        {
            if (item == valueToSearch)
            {
                return true;
            }
        }
        return false;
    }
    public void SortAsc()
    {
        // сорт. Бульбашкою < nim to max
        bool sort;
        do
        {
            sort = false;
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i] > data[i + 1])
                {
                    int temp = data[i];
                    data[i] = data[i + 1];
                    data[i + 1] = temp;
                    sort = true;
                }
            }
        } while (sort);
    }

    public void SortDesc()
    {
        // сорт. Бульбашкою > max to min
        bool sort;
        do
        {
            sort = false;
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i] < data[i + 1])
                {
                    int temp = data[i];
                    data[i] = data[i + 1];
                    data[i + 1] = temp;
                    sort = true;
                }
            }
        } while (sort);
    }



    public void SortByParam(bool isAsc)
    {

        if (isAsc) // true < : false >
        {
            SortAsc();
        }
        else
        {
            SortDesc();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] myArray = { 345, 8756, 2758, 25, 607, 535 };
        Array array = new Array(myArray);

        // Тест I IOutput
        Console.WriteLine("\nТест IOutput:");
        array.Show();
        array.Show("Тест Show з повiдомленням\n");

        // Тест I IMath
        Console.WriteLine("Тест IMath:");
        Console.WriteLine("Максимум: " + array.Max());
        Console.WriteLine("Мiнiмум: " + array.Min());
        Console.WriteLine("Середньоарифметичне: " + array.Avg());
        Console.WriteLine("Пошук 607: " + (array.Search(607) ? "Знайшлось" : "Не знайшлось"));
        Console.WriteLine("Пошук 1000: " + (array.Search(1000) ? "Знайшлось" : "Не знайшлось"));

        // Тест I ISort
        Console.WriteLine("\nТест ISort:");
        Console.WriteLine("Масив до сортування:");
        array.Show();

        array.SortAsc();
        Console.WriteLine("Масив пiсля сортування min to max:");
        array.Show();

        array.SortDesc();
        Console.WriteLine("Масив пiсля сортування max to min:");
        array.Show();

        array.SortByParam(true);  // if True< or False>     
        Console.WriteLine("Масив пiсля сортування if True:");    // <
        array.Show();

        array.SortByParam(false);
        Console.WriteLine("Масив пiсля сортування if False:");  // >
        array.Show();
    }
}
