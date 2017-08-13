using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irbis.Entities
{
    /// <summary>
    /// Картинки
    /// </summary>
    public class ProductPicture
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Url картинки
        /// </summary>
        public string PictureUrl { get; set; }
    }
}
