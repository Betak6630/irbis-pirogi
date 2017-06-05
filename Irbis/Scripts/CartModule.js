angular.module('CartModule', [])

    .controller('cartCtr', ['$scope', 'CartNetworkServices', function ($scope, CartNetworkServices) {

        $scope.model = {
            cartItems: null
        };

        var load = function () {
            return CartNetworkServices.getCart(function (data) {
                $scope.model = data;
                console.log($scope.model);
            });
        }

        load();

        $scope.events = {
            checkout: function () {
                load();
                console.log("Clicked button checkout");
            },
            addToCart: function (productId) {

                var product = $("#product-" + productId);

                var optionProduct = $('input[name="option_' + productId + '"]:checked').val();
                var countProduct = $("#product_" + productId + "_count").val();

                console.info("Add product to ShoppingCart");
                console.log("ProductId: " + productId);
                console.log("OptionProduct: " + optionProduct);
                console.log("CountProduct: " + countProduct);

                CartNetworkServices.addProduct({ productId: productId, optionProduct: optionProduct, countProduct },

                    function (response) {
                        console.log(response);
                        load();
                    });

            },
            removeProduct: function (productId) {

                CartNetworkServices.removeProduct({ productId: productId},

                    function () {
                        console.log("Product Id=" + productId + " has been removed from the cart");
                        load();
                    }); 
            }
        }

    }]);