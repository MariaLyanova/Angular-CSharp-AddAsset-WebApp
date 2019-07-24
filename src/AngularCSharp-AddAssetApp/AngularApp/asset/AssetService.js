(function(){
    window.app.factory('AssetService', AssetService);

    AssetService.$inject = ['$http'];
    function AssetService($http) {

        var serviceApi = {
            getAllAssets: getAllAssets,
            addAsset: addAsset,
            updateAsset: updateAsset,
            deleteAsset: deleteAsset
        };

        return serviceApi;

        function getAllAssets() {
            return $http.get('/api/assets')
                 .then(function (response) {
                     return response.data;
                 });
        }

        function addAsset(newAsset) {
            return $http.post('api/assets', newAsset)
                        .then(function (response) {
                            return response.data;
                        });
        }

        function updateAsset(changedAsset) {
            return $http.put('api/assets', changedAsset)
                        .then(function (response) {
                            return response.data;
                        });
        }

        function deleteAsset(id) {
            return $http.delete('api/assets', { params: { 'id': id } })
                        .then(function (response) {
                            return response.data;
                        });
        }
    }
})();