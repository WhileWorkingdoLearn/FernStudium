
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Teilaufgabe_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /*
     Aus Zeitgründen habe ich es leider nicht mehr geschafft, die Load und Save Funktion zu implementieren. 
    Mein Ansatz wäre hier ähnlich wie der des Lernbuches mit den Punkten und dem BinaryReader gewesen
    Zudem Aktivieren und Deaktivieren sich die MenuItems Start und Stop nicht gegenseitig. 
     */
    public partial class MainWindow : Window
    {
        const int CELL_SIZE = 20; // width and height in pixels

        const int TIMER_INTERVAL = 500; // interval in milliseconds

        const int TIMER_INTERVAL_MAX = 1000; // max value in milliseconds

        const int TIMER_INTERVAL_MIN = 100; // min value in milliseconds

        const int TIMER_INTERVAL_INC = 100; // increment in milliseconds

        const int GAME_SIZE = 10;

        bool ShowCellStates;

        DispatcherTimer timer;

        private TimeSpan timespan;

        Universe universe;

        UniformGrid grid;


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            this.timer = new DispatcherTimer();
            this.universe = new Universe(GAME_SIZE,GAME_SIZE);
            this.grid = (UniformGrid) this.FindName("Test");
            initVisualGrid();

            timer.Interval = TimeSpan.FromMilliseconds(TIMER_INTERVAL);
            
            timer.Tick += dispatcherTimer_Tick;           
           }


        public void initVisualGrid()
        {
            this.grid.Children.Clear();
            this.universe.cellHandler((col, row) =>
            {
                Rectangle rect = new Rectangle
                {
                    Width = CELL_SIZE,
                    Height = CELL_SIZE
                };
                rect.SetValue(UniformGrid.ColumnsProperty, col);
                rect.SetValue(UniformGrid.RowsProperty, row);
                rect.StrokeThickness = 1;
                rect.Stroke = Brushes.Black;

                this.grid.Children.Add(rect);
            });

        }


        public void UpdateGrid() {


            this.universe.ComputeTransition();
   

            foreach (Rectangle rect in this.grid.Children)
            {
                int col = (int)rect.GetValue(UniformGrid.ColumnsProperty);

                int row = (int)rect.GetValue(UniformGrid.RowsProperty);

                Cell cell = this.universe.checkCell(col, row);

                if (this.ShowCellStates)
                {
                    
                    if (cell.IsAlive && cell.WillBeAlive)
                    {
                        rect.Fill = Brushes.Green;
                    }

                    if (cell.IsAlive && !cell.WillBeAlive)
                    {
                        rect.Fill = Brushes.Red;
                    }
                    if (!cell.IsAlive && cell.WillBeAlive)
                    {
                        rect.Fill = Brushes.GreenYellow;
                    }
                    if (!cell.IsAlive && !cell.WillBeAlive)
                    {
                        rect.Fill = Brushes.WhiteSmoke;
                    }

                }
                else
                {

                    rect.Fill = cell.IsAlive ? Brushes.Green : Brushes.WhiteSmoke;
                }

                
            }

            this.universe.MakeTransition();

        }

        void UpdateUI() {
            StatusBarItem Gitem = (StatusBarItem) this.FindName("GenerationValue");
            if (Gitem != null)
            {
                Gitem.Content = "" + this.universe.Generation;
            }
            StatusBarItem Titem = (StatusBarItem)this.FindName("TimeValue");
            if (Titem != null)
            {
               Titem.Content = "" + this.timer.Interval.TotalMilliseconds;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                UpdateGrid();
                UpdateUI();
            });

            Debug.WriteLine("Tick");
        }
        public void StartSimulation(object sender,RoutedEventArgs e)
        {
              timer.Start();
        }
        public  void StopSimulation(object sender, RoutedEventArgs e) { 
                timer.Stop();
        }

        public void AccelerateSimulation(object sender, RoutedEventArgs e) { 
            if(timer.Interval.TotalMilliseconds < TIMER_INTERVAL_MAX)
            {
                Debug.WriteLine("Added");
                timer.Interval = TimeSpan.FromMilliseconds(timer.Interval.TotalMilliseconds + TIMER_INTERVAL_INC);
           
            }       
        }

        public void DecelerateSimulation(object sender, RoutedEventArgs e) {
            if (timer.Interval.TotalMilliseconds > TIMER_INTERVAL_MIN)
            {
                Debug.WriteLine("Subtracted");
                timer.Interval = TimeSpan.FromMilliseconds(timer.Interval.TotalMilliseconds - TIMER_INTERVAL_INC);
            }
        }


        public void Save(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
            Stream myStream;
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\Saves";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = projectDirectory;
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
  

            if (saveFileDialog.ShowDialog() == true)
            {
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    FileStream fileStr = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    BinaryWriter binWriter = new BinaryWriter(fileStr);
                    // Anzahl der Punkte in die Datei schreiben

                    binWriter.Write(this.universe.Cols);
                    // die Point-Daten in die Datei schreiben
                    this.universe.cellHandler((col,row) =>
                    {
                      if(this.universe.Map[col,row].IsAlive = true)
                        {
                            binWriter.Write(col);
                            binWriter.Write(row);
                        }
                    });
                    binWriter.Close();
                }
            }
        }

        public void Load(object sender, RoutedEventArgs e) { 
            throw new NotImplementedException();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\Saves";
                openFileDialog.InitialDirectory = projectDirectory;
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Programmdateien (*.txt)|*.txt";
                openFileDialog.Title = "Open Game Files";
                openFileDialog.DefaultExt = "txt";

                if(openFileDialog.ShowDialog() == true)
                {
                
                }
        }

        public  void Window_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Space)
            {
                timer.IsEnabled = !timer.IsEnabled;
                Debug.WriteLine("" + e.Key + " pressed.");
            }
            if(e.Key == Key.Up) {
                AccelerateSimulation(sender, e);
            } 
            if (e.Key == Key.Down)
            {
                DecelerateSimulation(sender, e);
            }
        }

        public void Clear(object sender, RoutedEventArgs e) { 
            this.universe.Clear();
            UpdateGrid();
        }

        public void Exit(object sender, RoutedEventArgs e) {
            this.timer.Stop();
            Close();
        }

        private void CellClickedEventHandler(object sender, MouseButtonEventArgs e)
        {            
            Rectangle? rect = e.Source as Rectangle;
            if (rect != null)
            {
                int col = (int)rect.GetValue(UniformGrid.ColumnsProperty);
                int row = (int)rect.GetValue(UniformGrid.RowsProperty);
          
                Debug.WriteLine("Rectangle Clicked : " + col + " : " + row);
                Cell cell = this.universe.checkCell(col, row);
                cell.IsAlive = !cell.IsAlive;
                rect.Fill = cell.IsAlive ? Brushes.Green : Brushes.WhiteSmoke;
            }          
        }

        private void SetShowCellstate(object sender, ExecutedRoutedEventArgs e)
        {
            this.ShowCellStates = !this.ShowCellStates;
            Debug.WriteLine(this.ShowCellStates);
        }


     
    }
}
