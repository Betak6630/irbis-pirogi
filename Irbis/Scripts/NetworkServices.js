angular.module('NetworkServices', [])
    .factory('CartNetworkServices',
    [
        '$resource', function($resource) {
            return $resource('/Cart/:action',
                null,
                {
                    getCart: { params: { action: 'GetCart' }, method: 'GET' },
                    addProduct: { params: { action: 'AddProduct' }, method: 'POST' },
                    removeProduct: { params: { action: 'RemoveProduct' }, method: 'POST' }
                });
        }
    ]);