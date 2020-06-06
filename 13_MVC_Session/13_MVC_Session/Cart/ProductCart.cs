using _13_MVC_Session.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _13_MVC_Session.Cart
{
    public class ProductCart
    {
        private Dictionary<int, ProductVM> _cart = null;

        public ProductCart()
        {
            _cart = new Dictionary<int, ProductVM>();
        }

        public List<ProductVM> CartProductList
        {
            get
            {
                return _cart.Values.ToList();
            }
        }
        #region Sepete Ekle
        public void AddCart(ProductVM item)
        {
            if (!_cart.ContainsKey(item.Id))
            {
                _cart.Add(item.Id, item);
            }
            else
            {
                _cart[item.Id].Quantity++;
            }
        }
        #endregion

        #region Sepetten Sil
        public void RemoveCart(int id)
        {
            _cart.Remove(id);
        }
        #endregion

        #region Sepetten Azalt
        public void DeCreaseCart(int id)
        {
            _cart[id].Quantity--;
            if (_cart[id].Quantity <= 0)
            {
                _cart.Remove(id);
            }
        }
        #endregion

        #region Sepette Adet Arttır
        public void InCreaseCart(int id)
        {
            _cart[id].Quantity++;
        }

        #endregion

    }
}