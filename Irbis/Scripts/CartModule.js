angular.module('CartModule',[])

    .controller('cartCtr', ['$scope', 'CartNetworkServices', function ($scope, CartNetworkServices) {
        var data = CartNetworkServices.getCart();
        console.log(data);

        $scope.model = {
            cartItems: data
        };

        console.log($scope.model.cartItems);

    }]);