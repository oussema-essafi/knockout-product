﻿using knockout_product.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace knockout_product.Controllers
{
    public class ProductController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        public IEnumerable GetAllProducts()
        {
            return repository.GetAll();
        }
        public Product PostProduct(Product item)
        {
            return repository.Add(item);
        }
        public IEnumerable PutProduct(int id, Product product)
        {
            product.Id = id;
            if (repository.Update(product))
            {
                return repository.GetAll();
            }
            else
            {
                return null;
            }
        }
        public bool DeleteProduct(int id)
        {
            if (repository.Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}