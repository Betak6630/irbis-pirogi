angular.module('CartModule',[])

    .controller('cartCtr', ['$scope', function ($scope) {

        $scope.model.product= {
            Id: 0,
            Name: '',
            Description: '',

        }
    }]);