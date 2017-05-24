(function (irbis, $, undefined) {
    irbis.product = irbis.product || {};

    irbis.product.addToCart = function (productId) {
        var product = $("#product-" + productId);
        var optionProduct = $('input[name="option_' + productId + '"]:checked').val();
        var countProduct = $("#product_" + productId + "_count").val();

        console.info("Add product to ShoppingCart");
        console.log("ProductId: " + productId);
        console.log("OptionProduct: " + optionProduct);
        console.log("CountProduct: " + countProduct);

        $.ajax({
            type: "post",
            url: "Shopping/AddProduct",
            data: { productId: productId, optionProduct: optionProduct, countProduct: countProduct },
            success: function(response) {
                console.log(response);
            },
            dataType: "json"
        });
    };


}(window.irbis = window.irbis || {}, jQuery));


$(document).ready(function () {
    console.log("Document loaded");
});