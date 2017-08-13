using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Irbis.Models
{
    public class Product
    {
        /// <summary>
        /// Идетификатор продукта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  Название продукта 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описанипе продукта
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип продукта
        /// </summary>
        public int ProductTypeId { get; set; }

        public string PictureUrl { get; set; }

        public List<ProductOption> Option { get; set; }

    }
}