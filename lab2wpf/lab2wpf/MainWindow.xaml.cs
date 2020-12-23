using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        public static int[] sort(int[] mass, int per)
        {
            bool flag = false;
            int i;
            
                for ( i = 0; i < mass.Length - 1; i++)
                {
                if (mass[i] > mass[i + 1])
                {
                    per = mass[i];
                    mass[i] = mass[i + 1];
                    mass[i + 1] = per;
                }
                else continue;
                }
            for( i = 0; i < mass.Length - 1; i++)
            {
                if (mass[i] <= mass[i + 1]) flag = true;
                else
                {
                    flag = false;
                    break; 
                }
            }
            if (flag == true) return mass;
            else return sort(mass, per);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            int[] mass = new int[n];
            List<int> mass_x = new List<int>(); 
            int count = 0, i, sum = 0;
            int j = 0;
            for(i = 0; i < n; i++)
            {
                mass[i] = rand.Next(32);
            }
            listBox.Items.Clear();
            
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    listBox.Items.Clear();
                string star = "";
                    for ( i = 0; i < n; i++)
                    {
                        mass[i] = rand.Next(32);

                        for (j = 0; j < mass[i]; j++)
                        {
                            star += "■";
                        }
                    listBox.Items.Add(star + " " + mass[i]);
                    star = "";
                }
                    break;

                case 1:
                    listBox.Items.Clear();
                    for ( i = 1; i < n; i++)
                    {
                        
                        listBox.Items.Add(mass[i]);
                        
                       
                            if(i != 0 && i!= n)
                            {
                                if ((mass[i] < mass[i - 1]) && (mass[i] < mass[i + 1])) count++;
                            }
                            
                        
                    }
                    if ((mass[n-1] < mass[n - 2]) && (mass[n-1] < mass[0])) count++;
                    if (    (mass[0] < mass[1]) && (mass[0] < mass[n-1])) count++;
                    listBox.Items.Add("");
                    listBox.Items.Add(count);
                    break;
                case 2:
                    listBox.Items.Clear();
                    for(i = 0; i < n; i++)
                    {
                        listBox.Items.Add(i + "-й элемент массива: " +mass[i]);
                        sum += mass[i];
                    }
                    sum = sum / n;
                    int min = 9999;
                    int minn = 0;
                    for(i = 0; i < n; i++)
                    {
                        if((mass[i] > sum) && (mass[i]) < min)
                        {
                            min = mass[i];
                            minn = i;
                        }
                    }
                    listBox.Items.Add("            ");
                    listBox.Items.Add("Среднее значение: "+sum);
                    listBox.Items.Add("Минимальный элемент: "+min);
                    listBox.Items.Add("Индекс элемента: "+minn);
                    break;
                case 3:
                    listBox.Items.Clear();
                    count = 0;
                    for(i = 0; i < n; i++)
                    {
                        listBox.Items.Add(mass[i]);
                    }
                    for(i = 1; i < n-1; i++)
                    {
                        if (i != 0 && i != n)
                        {
                            if ((mass[i] > mass[i - 1]) && (mass[i] < mass[i + 1]))
                            {
                                count++;
                            }
                        }
                        if (i != 0 && i != n)
                        {
                            if ((mass[i] < mass[i - 1]) && (mass[i] > mass[i + 1]))
                            {
                                count++;
                            }
                        }
                    }
                    if ((mass[0] < mass[1]) && (mass[0] > mass[n - 1]) || (mass[0] > mass[1]) && (mass[0] < mass[n -1])) count++;
                    if ((mass[n - 1] < mass[n - 2]) && (mass[n - 1] > mass[0]) || (mass[n - 1] > mass[n - 2]) && (mass[n - 1] < mass[0])) count++;
                    listBox.Items.Add("");
                    listBox.Items.Add(count);
                    break;
                case 4:
                    listBox.Items.Clear();
                    count = 0;
                    int per = 0;
                    j = 1;
                    for (i = 0; i < n; i++)
                    {
                        listBox.Items.Add(mass[i]);
                    }
                    listBox.Items.Add("");
                    sort(mass, per);
                    for(i = 0; i < n; i++)
                    {
                        if(i == (n/2 + 1))
                        {
                            per = mass[i];
                            mass[i] = mass[n - j];
                            mass[n - j] = per;
                            j++;
                            if (i == j) break;
                        }
                        

                    }
                    mass[n - 1] *= -1;
                    for(i = 0; i < n; i++)
                    {
                        listBox.Items.Add(mass[i]);
                    }
                    break;
                case 5:
                    listBox.Items.Clear();
                    sum = 0;
                    for (i = 0; i < n; i++)
                    {
                        sum += (mass[i] / n);
                    }
                    for(i = 0; i < n; i++)
                    {
                        
                        mass_x.Add(mass[i] - sum);
                        listBox.Items.Add(i + "-й элемент массива: " + mass[i] + " Отклонение от срднего значения: " +mass_x[i]);
                    }
                    listBox.Items.Add("Среднее значение: " + sum);
                    break;
                case 6:
                    int result = 0;
                    for (i = 1; i < n - 1; i++)
                    {
                        if (mass[i] < mass[i + 1] && mass[i] < mass[i - 1])
                        {
                            result++;
                        }

                    }
                    listBox.Items.Add("Кол-во: " + result);
                    break;
                case 7:
                    int tempindex = 0;
                    min = 999999;
                    for (i = 0; i < n; i++)
                    {
                        mass[i] = -100 + rand.Next(200);

                        sum += mass[i];
                    }
                    int sr = sum / n;
                    for ( i = 0; i < n; i++)
                    {

                        if (mass[i] > sr)
                        {
                            if (mass[i] < min)
                            {
                                min = mass[i];
                                tempindex = i;
                            }
                        }
                    }
                    listBox.Items.Add("Индекс минимального значения: " + tempindex);
                    break;
                case 8:
                    result = 0;
                    for (i = 0; i < n - 1; i++)
                    {
                        if ((mass[i] > mass[i + 1]) || (mass[i] < mass[i + 1]))
                        {
                            result++;
                        }
                    }
                    listBox.Items.Add("Кол-во последовательностей: " + result);
                    break;
                case 9:
                    per = 0;
                    j = 1;
                    sort(mass, per);
                    for ( i = 0; i < n; i++)
                    {
                        if (i == (n / 2 + 1))
                        {
                            per = mass[i];
                            mass[i] = mass[n - j];
                            mass[n - j] = per;
                            j++;
                            if (i == j) break;
                        }

                    }
                    mass[n - 1] *= -1;
                    listBox.Items.Add("------------------");
                    for (i = 0; i < n; i++)
                    {
                        listBox.Items.Add(mass[i]);

                    }
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
                default:
                    break;
            }
        }
    }
}
