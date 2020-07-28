using BikeShop;
using System.Windows.Controls;

namespace BikeShopApp
{
    /// <summary>
    /// ProductManagement.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ProductManagement : Page
    {
        ProductsFactory factory;

        public ProductManagement()
        {
            InitializeComponent();

            factory = new ProductsFactory();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GrdProduct.ItemsSource = factory.FindProducts(TxtSearch.Text);
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GrdProduct.ItemsSource = factory.FindProducts(TxtSearch.Text);
        }
    }
}
