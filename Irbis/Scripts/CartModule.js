angular.module('CartModule', [])

    .controller('cartCtr', ['$scope', 'Notification', 'CartNetworkServices', function ($scope, Notification, CartNetworkServices) {

        $scope.model = {
            cartItems: null
        };

        $scope.checkoutModel = {
            user: {
                name: "",
                phone: "",
                email: "",
                address: "",
                comment: ""
            }
        }

        $scope.error = {
            isShowLabelName: false,
            isShowLabelPhone: false
        }

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

        function checkout(user) {

            if (user.name == "") {
                $scope.error.isShowLabelName = true;

                console.log("Укажите  имя");
                return;
            };

            if (user.phone == "") {
                $scope.error.isShowLabelPhone = true;
                console.log("Укажите  телефон");
                return;
            }

            CartNetworkServices.checkout({ name: user.name, phone: user.phone, address: user.address, comment: user.comment },

                function (response) {
                    location.href = "/order";
                });
        };

        $scope.events = {
            addToCart: function (productId) {

                var optionProduct = $('input[name="option_' + productId + '"]:checked').val();
                var countProduct = $("#product_" + productId + "_count").val();

                var product = {
                    productId: productId,
                    optionProduct: optionProduct,
                    countProduct: countProduct
                };

                addProduct(product);

                Notification.warning({ message: 'Товар добавлен в корзину', positionY: 'top', positionX: 'center', delay: 1000 });

            },
            removeProduct: function (p) {

                CartNetworkServices.removeProduct({ productId: p.ProductId, optionProductId: p.ProductOptionId },

                    function () {
                        load();
                    });

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
            },
            checkout: function () {
                checkout($scope.checkoutModel.user);

            },
            plus: function (id) {
                var input = $("#product_" + id + "_count");
                var val = input.val();

                if (val >= 50) {
                    return;
                }

                val++;
                input.val(val);
            },
            minus: function (id) {

                var input = $("#product_" + id + "_count");
                var val = input.val();

                if (val == 1) {
                    return;
                }

                val--;
                input.val(val);
            }
        }

    }]);