using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;


namespace MedicineStorage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private readonly string PATH = $"{Environment.CurrentDirectory}\\medData.json";
        private BindingList<Medicine> medicineStorage;
        private FileIOservise FileIOservise;
        private void MedicineStorage_Loaded(object sender, RoutedEventArgs e)
        {
            FileIOservise = new FileIOservise(PATH);
            try
            {
                medicineStorage = FileIOservise.Load();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            MedicineStorage.ItemsSource = medicineStorage;
            medicineStorage.ListChanged += MedicineStorage_ListChanged;
        }
       
        private void MedicineStorage_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                
                try
                {
                    FileIOservise.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        public void Update()
        {
            MedicineStorage.Items.Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var i in medicineStorage)
            {
                if (DateTime.Now > i.Date)
                {
                    i.Condition = "Не придатний ";
                }
                else if (DateTime.Now.AddDays(14) >= i.Date)
                {
                    i.Condition = "Скоро зіпсується ";
                }
                else
                {
                    i.Condition = " ";
                }
                i.Still = i.Cams - i.Go;
            }
            MedicineStorage.Items.Refresh();
        }

    }
}
