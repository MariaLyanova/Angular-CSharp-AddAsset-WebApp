(function () {
    "use strict";

    window.app.directive('assetDetails', assetDetails);

    function assetDetails() {
        return {
            scope: {
                formName: "=",
                asset: "="
            },
            templateUrl: '/angularapp/asset/templates/assetDetailsTemplate.html'
        }
    }
})();