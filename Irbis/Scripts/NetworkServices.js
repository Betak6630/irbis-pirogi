angular.module('NetworkServices', [])
    .factory('CartNetworkServices',
    [
        '$resource', function($resource) {
            return $resource('/Cart/:action',
                null,
                {
                    getCart: { params: { action: 'GetCart' }, method: 'GET' }
                   
                });
        }
    ]);