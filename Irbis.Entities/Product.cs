namespace Irbis.Entities
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
        public string Title { get; set; }

        /// <summary>
        /// Описанипе продукта
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип продукта
        /// </summary>
        public ProductType Type { get; set; }
    }
}