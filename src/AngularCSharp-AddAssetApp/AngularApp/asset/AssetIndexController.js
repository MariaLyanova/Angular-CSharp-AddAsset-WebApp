(function () {
    window.app.controller('AssetIndexController', AssetIndexController);
    AssetIndexController.$inject = ['$scope', 'AssetService', '$uibModal','$timeout'];

    function AssetIndexController($scope, assetService, $modal, $timeout) {
        this.errorMessage = null;
        var currentCtrl = this;

        this.gridOptions = {
            paginationPageSizes: [10,20],
            paginationPageSize: 10,
            enableColumnMenus:false
        };

        this.gridOptions.columnDefs = [
         { name: 'assetId', visible: false },
         { name: 'mimeType', visible: false },
         { name: 'email', visible: false },
         { name: 'countryName', visible: false },
         { name: 'description', visible: false },
         { name: 'title', enableSorting: true },
         { name: 'createdBy', enableSorting: true },
         {
             name: 'editAction',
             displayName: '',
             cellTemplate: '<button class="btn btn-link" ng-click="grid.appScope.assetIndexCtrl.editAsset(grid, row)">Edit</button>'
         },
         {
            name: 'deleteAction',
            displayName: '',
            cellTemplate: '<button class="btn btn-link" ng-click="grid.appScope.assetIndexCtrl.deleteAsset(grid, row)">Delete</button>'
         }
        ];

        assetService.getAllAssets().then(function (assets) {
            currentCtrl.gridOptions.data = assets;
        });
        
        this.addAsset = function () {
            $modal.open({
                template: '<add-asset />',
                scope: angular.extend($scope.$new(true))
            });
        }

        this.editAsset = function (grid, row) {
            $modal.open({
                template: '<edit-asset asset="asset" />',
                scope: angular.extend($scope.$new(true), { asset: row.entity })
            });
        };

        this.deleteAsset = function (grid, row) {
            assetService.deleteAsset(row.entity.assetId).then(function () {
                var index = grid.options.data.indexOf(row.entity)
                grid.options.data.splice(index, 1);
            }, function (err) {
                currentCtrl.showError(err.data);
            });
        };

        this.showError = function (errMsg) {
            currentCtrl.errorMessage = errMsg;
            $timeout(function () { currentCtrl.errorMessage = null; }, 10000);
        }

        $scope.$on("assetAddedEvent", function (e, addedAsset) {
            currentCtrl.gridOptions.data.push(addedAsset);
        });
    }
})();