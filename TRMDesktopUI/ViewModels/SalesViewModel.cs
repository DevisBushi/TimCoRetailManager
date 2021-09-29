using Caliburn.Micro;
using System.ComponentModel;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;

        public BindingList<string> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);

            }
        }

        private string _itemQuanity;

        public string ItemQuantity
        {
            get { return _itemQuanity; }
            set
            {
                _itemQuanity = value;
                NotifyOfPropertyChange(() => ItemQuantity);

            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public string SubTotal
        {
            get
            {
                //TODO - Replace with calculations
                return "$0.00";
            }
        }

        public string Tax
        {
            get
            {
                //TODO - Replace with calculations
                return "$0.00";
            }
        }

        public string Total
        {
            get
            {
                //TODO - Replace with calculations
                return "$0.00";
            }
        }


        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                
                // TODO - Make sure something is Selected
                // TODO - Make sure there is an item quantity
                


                return output;
            }
        }

        public void AddToCart()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;


                // TODO - Make sure something is Selected


                return output;
            }
        }


        public void RemoveFromCart()
        {

        }

        public bool CanCheckout
        {
            get
            {
                bool output = false;


                // TODO - Make sure something is in the cart


                return output;
            }
        }


        public void Checkout()
        {

        }


    }
   

}
