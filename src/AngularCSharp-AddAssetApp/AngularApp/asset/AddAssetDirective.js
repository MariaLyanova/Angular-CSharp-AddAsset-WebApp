(function () {
    "use strict";

    window.app.directive('addAsset', addAsset);

    function addAsset() {
        return {
            scope: {},
            templateUrl: '/angularapp/asset/templates/addAssetTemplate.html',
            controller: controller,
            controllerAs: 'addAssetCtrl'
        }
    }

    controller.$inject = ['$scope', 'AssetService'];
    function controller($scope, assetService) {
        var addAssetCtrl = this;
        addAssetCtrl.errorMessage = null;
        addAssetCtrl.save = save;

        addAssetCtrl.asset = {
            title: "",
            countryName: "",
            createdBy: "",
            description: "",
            eamil: "",
            mimeType: ""
        };

        function save() {
            assetService.addAsset(addAssetCtrl.asset).then(
               function (createdAssetId) {
                   addAssetCtrl.asset.assetId = createdAssetId;
                   $scope.$parent.$emit("assetAddedEvent", addAssetCtrl.asset);
                   $scope.$parent.$close();
               }, function (err) {
                   addAssetCtrl.errorMessage = 'There was a problem saving changes to the asset: ' + err.data;
               });
        }
    }
})();