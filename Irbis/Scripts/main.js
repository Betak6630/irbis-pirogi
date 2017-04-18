(function (irbis, $, undefined) {
    irbis.product = irbis.product || {};

    irbis.product.addToCart = function () {
        alert("Товар добавлен в корзину");
    };


}(window.irbis = window.irbis || {}, jQuery));


$(document).ready(function () {
    console.log("Document loaded");
});