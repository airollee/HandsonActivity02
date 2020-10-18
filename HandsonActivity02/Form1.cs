using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;
        BindingSource showProductList;

        public frmAddProduct()
        {
            showProductList = new BindingSource();

            InitializeComponent();
        }
        class NumberFormatException : Exception
        {
            public NumberFormatException(string ex) : base(ex) {
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            {
                string[] ListOfProductCategory = new string[]{
                    "Beverages",
                    "Bread/Bakery",
                    "Canned/Jarred Goods",
                    "Dairy",
                    "Frozen Goods",
                    "Meat",
                    "Personal Care",
                    "Other"
            };
                    foreach (string Items in ListOfProductCategory)
                {
                    cbCategory.Items.Add(Items);
                }
            }
        }
            public string Product_Name(string name)
            {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                //Exception here
                try
                {
                    _ProductName = (txtQuantity.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Product Name");
                }
            return name;
            }
            public int Quantity(string qty)
            {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
                //Exception here
                try
                {
                    _Quantity = Int32.Parse(txtQuantity.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Quantity");
                }

            return _Quantity;
            }

            public double SellingPrice(string price)
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                //Exception here
                try
                {
                    _SellPrice = Int32.Parse(txtSellPrice.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Selling Price");
                }
            return _SellPrice;
            }

        private void btnAddproduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
            _ExpDate, _SellPrice, _Quantity, _Description));
            gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewProductList.DataSource = showProductList;
        }
    }
}
