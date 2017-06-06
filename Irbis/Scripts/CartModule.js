angular.module('CartModule', [])

    .controller('cartCtr', ['$scope', 'CartNetworkServices', function ($scope, CartNetworkServices) {

        $scope.model = {
            cartItems: null
        };

      

        var load = function () {
            return CartNetworkServices.getCart(function (data) {
                $scope.model = data;
            });
        }

        load();

        function addProduct(product) {

            CartNetworkServices.addProduct({ productId: product.productId, optionProduct: product.optionProduct, countProduct: product.countProduct },

                function () {
                    load();
                });
        }

        $scope.events = {
            checkout: function () {
                load(product);
            },
            addToCart: function (productId) {

                var optionProduct = $('input[name="option_' + productId + '"]:checked').val();
                var countProduct = $("#product_" + productId + "_count").val();

                var product = {
                    productId: productId,
                    optionProduct: optionProduct,
                    countProduct: countProduct
                };

                addProduct(product);
            },
            removeProduct: function (p) {

                CartNetworkServices.removeProduct({ productId: p.ProductId, optionProductId: p.ProductOptionId },

                    function () {
                        load();
                    });

            },
            addProduct: function (p) {

                var product = {
                    productId: p.ProductId,
                    optionProduct: p.ProductOptionId,
                    countProduct: 1
                };

                addProduct(product);
            }
        }

    }]);