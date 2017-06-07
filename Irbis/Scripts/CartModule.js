angular.module('CartModule', [])

    .controller('cartCtr', ['$scope', 'CartNetworkServices', function ($scope, CartNetworkServices) {

        $scope.model = {
            cartItems: null
        };

        $scope.buttons = {
            plus: {
                enabled: true
            },
            minus: {
                disabled: false
            }
        }

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

        function updateProduct(product) {

           

            CartNetworkServices.updateProduct({ productId: product.productId, optionProduct: product.optionProduct, countProduct: product.countProduct },

                function () {
                    load();
                    $scope.buttons.minus.disabled = false;
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
            },
            updateProduct: function (p, command) {
                $scope.buttons.minus.disabled = true;
                var count = 0;

                if (command === "plus" && p.Count < 50) {
                    count++;
                }

                if (command === "minus" && p.Count > 1) {
                    count--;
                }

                var product = {
                    productId: p.ProductId,
                    optionProduct: p.ProductOptionId,
                    countProduct: count
                };

                updateProduct(product);
            }
        }

    }]);