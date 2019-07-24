(function () {
    "use strict";

    window.app.directive('editAsset', editAsset);

    function editAsset() {
        return {
            scope: {
                asset: "="
            },
            templateUrl: '/angularapp/asset/templates/editAssetTemplate.html',
            controller: controller,
            controllerAs: 'editAssetCtrl'
        }
    }

    controller.$inject = ['$scope', 'AssetService'];
    function controller($scope, assetService) {
        var editAssetCtrl = this;
        editAssetCtrl.errorMessage = null;
        editAssetCtrl.save = save;

        editAssetCtrl.asset = angular.copy($scope.asset);

        function save() {

            assetService.updateAsset(editAssetCtrl.asset).then(
               function () {
                $scope.asset.title = angular.copy(editAssetCtrl.asset.title);
                $scope.asset.countryName = angular.copy(editAssetCtrl.asset.countryName);
                $scope.asset.createdBy = angular.copy(editAssetCtrl.asset.createdBy);
                $scope.asset.description = angular.copy(editAssetCtrl.asset.description);
                $scope.asset.eamil = angular.copy(editAssetCtrl.asset.email);
                $scope.asset.mimeType = angular.copy(editAssetCtrl.asset.mimeType);
                $scope.$parent.$close();
            }, function (err) {
                editAssetCtrl.errorMessage = 'There was a problem saving changes to the asset: ' + err.data;
            });
        }
    }
})();