(function () {
    angular.module("winterfell", ["datetime"]).filter("dateFilter", function () {
        return function (item) {
            if (item !== null) {
                return new Date(parseInt(item.substr(6)));
            }

            return "";
        };
    })
        .controller("AdministrativoController", ["$scope", "$http", "$filter", "datetime", function ($scope, $http, $filter, datetime) {
            $scope.nome = "Administrativo";
            $scope.viewdata = {};

            $scope.getViewData = function () {
                $http({ method: "POST", url: "/Administrativo/GetViewData" }).then(function success(response) {
                    console.log(response);
                    $scope.viewdata.list = response.data;
                });
            };

            /********************* F U N Ç Õ E S **************************/

            $scope.getViewData();

            
        }]);
})();