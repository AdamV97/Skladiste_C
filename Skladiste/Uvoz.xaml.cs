using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;


namespace Skladiste
{
    /// <summary>
    /// Interaction logic for Uvoz.xaml
    /// </summary>
    public partial class Uvoz : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Programiranje\Visual Studio\Skladiste\Skladiste\Database1.mdf");


        public Uvoz()

        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Skladiste.Database1DataSet database1DataSet = ((Skladiste.Database1DataSet)(this.FindResource("database1DataSet")));
            // Load data into the table Trgovina. You can modify this code as needed.
            Skladiste.Database1DataSetTableAdapters.TrgovinaTableAdapter database1DataSetTrgovinaTableAdapter = new Skladiste.Database1DataSetTableAdapters.TrgovinaTableAdapter();
            database1DataSetTrgovinaTableAdapter.Fill(database1DataSet.Trgovina);
            System.Windows.Data.CollectionViewSource trgovinaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("trgovinaViewSource")));
            trgovinaViewSource.View.MoveCurrentToFirst();
            // Load data into the table Polica. You can modify this code as needed.
            Skladiste.Database1DataSetTableAdapters.PolicaTableAdapter database1DataSetPolicaTableAdapter = new Skladiste.Database1DataSetTableAdapters.PolicaTableAdapter();
            database1DataSetPolicaTableAdapter.Fill(database1DataSet.Polica);
            System.Windows.Data.CollectionViewSource trgovinaPolicaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("trgovinaPolicaViewSource")));
            trgovinaPolicaViewSource.View.MoveCurrentToFirst();
            // Load data into the table Roba. You can modify this code as needed.
            Skladiste.Database1DataSetTableAdapters.RobaTableAdapter database1DataSetRobaTableAdapter = new Skladiste.Database1DataSetTableAdapters.RobaTableAdapter();
            database1DataSetRobaTableAdapter.Fill(database1DataSet.Roba);
            System.Windows.Data.CollectionViewSource trgovinaPolicaRobaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("trgovinaPolicaRobaViewSource")));
            trgovinaPolicaRobaViewSource.View.MoveCurrentToFirst();
        }

        private void btnUvezi_Click(object sender, RoutedEventArgs e)
        {
            int a = 1;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Roba values('"+txtIdRobe+"','"  +txtOznaka+ "','" + txtMasa + "','" + txtVrijednost + "','"+ cmbPolica1 + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Uveženo");
         

        }


    }
}
