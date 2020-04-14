using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


		private int _itemQuantity;

		public int ItemQuantity
		{
			get { return _itemQuantity; }
			set 
			{ 
				_itemQuantity = value;
				NotifyOfPropertyChange(() => ItemQuantity);
			}
		}

		public string SubTotal
		{
			get => $"0.00";
		}

		public string Tax
		{
			get => $"0.00";
		}

		public string Total
		{
			get => $"0.00";
		}


		public bool CanAddToCart
		{
			get
			{
				return true;
			}
		}

		public void AddToCart()
		{

		}

		public bool CanCheckOut
		{
			get
			{
				return true;
			}
		}

		public void CheckOut()
		{

		}


	}
}
