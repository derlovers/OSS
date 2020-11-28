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
using System.Collections;
using Microsoft.Win32;

namespace lab1wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int k = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            List<int> mass = new List<int>();
            int n = Convert.ToInt32(textBox.Text);
            Random rand = new Random();
            Window1 wind = new Window1();
            
            int count = 0;
            int i = 0;
            for (i = 0; i <= n; i++)
            {
                mass.Add(-100 + rand.Next(200));
            }
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    listBox.Items.Clear();
                    for(i = 1; i <= n; i++)
                    {
                        listBox.Items.Add(mass[i]);
                        if (i != 0 && i != n)
                        {
                            if ((mass[i] > mass[i - 1]) && (mass[i] > mass[i + 1]))
                            {
                                count++;
                            }
                        }
                    }
                    listBox.Items.Add("");
                    listBox.Items.Add(count);
                    break;
                case 1:
                    listBox.Items.Clear();
                   
                    
                    for (i = 0; i < n; i++)
                    {
                        listBox.Items.Add(mass[i]);
                    }   
                    listBox.Items.Add(" ");
                    
                        for (i = 0; i < n; i++)
                        {
                        if (mass[i] > 25) { listBox.Items.Add(i); break; }
                        }
                    
                    break;
                case 2:
                    listBox.Items.Clear();
                    for(i = 0; i < n; i++)
                    {
                        listBox.Items.Add(mass[i]);
                    }
                    listBox.Items.Add(" ");
                    for (i = 2; i < n; i++)
                    {
                        count += mass[i];
                    }
                    listBox.Items.Add(Convert.ToString(count));
                    break;
                case 3:
                    for (i = 0; i < n; i++)
                    {
                        listBox.Items.Add(mass[i]);
                    }
                    listBox.Items.Add(" ");
                    wind.ShowDialog();
                    if (wind.flag == 1)
                    {
                        k = Convert.ToInt32(wind.textBox.Text);
                        
                    }
                    else { MessageBox.Show("ATTENTION!1!!11!!!!!!","ATTENTION!!Z!z!Z!!Z!Z!!Z", MessageBoxButton.OK, MessageBoxImage.Error); }


                    for (i = 0; i < n; i++)
                    {
                        if (mass[i] > k) { listBox.Items.Add(i); break; }
                    }
                    break;
                case 4:
                    for (i = 0; i < n; i++)
                    {
                        listBox.Items.Add(mass[i]);
                    }
                    listBox.Items.Add(" ");
                    wind.ShowDialog();
                    if (wind.flag == 1)
                    {
                        k = Convert.ToInt32(wind.textBox.Text);
                        
                    }
                    else { MessageBox.Show("ATTENTION!1!!11!!!!!!", "ATTENTION!!Z!z!Z!!Z!Z!!Z", MessageBoxButton.OK, MessageBoxImage.Error); }

                    count = 0;
                    for (i = 0; i < n; i++)
                    {
                        if (mass[i] > mass[k]) { count++; }
                    }
                    listBox.Items.Add(count);
                    break;
                case 5:
                    List<int> mass_x = new List<int>();
                    listBox.Items.Clear();
                    int j = 0;
                    for (i = 0; i <= n; i++)
                    {
                        
                        if (i != 0 && i != n)
                        {
                            if ((mass[i] > mass[i - 1]) && (mass[i] > mass[i + 1]))
                            {
                                listBox.Items.Add("(" + mass[i] + ")");
                                //mass_x[i] = mass[i];
                                continue;

                            }
                        }
                        listBox.Items.Add(mass[i]);
                    }
                    
                    //for(i = 0; i < n; i++)
                    //{
                    //    listBox.Items.Add(mass[i]);
                    //    if(mass_x[j] == mass[i])
                    //    {
                    //        j++;
                    //        listBox.Items.Add("("+mass[i]+")");
                    //    }
                    //}
                   
                    
                    break;
                default:
                    break;

            }
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ArrayList myAL = new ArrayList();
            
            int itemCount = Convert.ToInt32(textBox.Text);
            Random rnd1 = new Random();
            int number;
            listBox.Items.Add("Исходный массив");
            for (int i = 1; i <= itemCount; i++)
            {
                number = -100 + rnd1.Next(200);
                myAL.Add(number);
                listBox.Items.Add(number);
            }
            listBox.Items.Add("Sorted mass");
            myAL.Sort();
            foreach(int k in myAL)
            { 
                listBox.Items.Add(k);
            }
        }


        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in listBox.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }


        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
