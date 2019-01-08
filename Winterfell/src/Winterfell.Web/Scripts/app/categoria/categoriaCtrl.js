(function () {
    "use strict";

    categoriaCtrl.$inject = ["$scope", "$http", "$filter", "toastr"];

    function categoriaCtrl($scope, $http,  $filter, toastr) {

      
        $scope.viewdata = {};

        $scope.validaForm = function (form) {
            if (form.validate()) {
                return true;
            }

            return false;
        }

        $scope.novaCtegoria = function () {
            $scope.viewdata.categoria = {};
            $("#modalCategoria").modal("show");
        }

        $scope.editar = function (item) {

            $scope.viewdata.categoria = angular.copy(item);          

            $("#modalCategoria").modal("show");
        }

        $scope.setup = function () {     

            $http({
                method: "POST", url: "/Categoria/GetViewData" })
                .then(function success(response) {                   
                    $scope.viewdata.list = response.data;
                },
                function error(response) {
                       
                });
        }

        $scope.salvar = function (item) {

            $http({
                method: "POST",
                url: "/Categoria/Salvar",
                data: model
            }).then(function successCallback(response) {
               
                toastr.success("Operação realizada com sucesso.", "Notícia Cadastrada");

                $scope.setup();

                $("#modalCategoria").modal("hide");

            }, function errorCallback(response) {
               
                toastr.error("Serviço indisponível no momento.", "Atenção");
            });
        }       

    }

    angular
        .module("scsi")
        .controller("categoriaCtrl", categoriaCtrl);
})();
