(function () {

     "use strict";

     usuarioCtrl.$inject = ["$scope", "$http", "$filter"];

     function usuarioCtrl($scope, $http, $filter) {

         $scope.viewdata = {};
         dataAtual();
         var form = document.forms.formUsuario; 
         
        $scope.validaForm = function (form) {
            if (form.validate()) {
                return true;
            }
            return false;
        }

        $scope.nome = "Ricardo";

        $scope.setup = function () {

            $scope.viewdata.usuario = {};
           
            $http({ method: "POST", url: "Usuario/GetViewData" })
                .then(function success(response) {
                    $scope.viewdata.list = response.data;

            });
         }    
         //## LIMPAR FORMULARIO##
         $scope.limparFormulario = function () {
             $scope.viewdata.usuario = {};
             dataAtual();     
         }  
         
         // ####### DATA ####### 
               
         function dataAtual() {
             $(document).ready(function () {
                 var now = new Date();
                 var month = (now.getMonth() + 1);
                 var day = now.getDate();
                 if (month < 10)
                     month = "0" + month;
                 if (day < 10)
                     day = "0" + day;
                 var today = day + '/' + month + '/' + now.getFullYear();
                 $('#datePicker').val(today);
             });
         }                  
         //######################

        /********************* F U N Ç Õ E S   C R U D **************************/

        
        // S A L V A R
        $scope.salvar = function (item) {           

            $http({
                method: "POST",
                url: "/Usuario/Salvar",
                data: item
            }).
                then(function successCallback(response) {
                $scope.limparFormulario();
                $scope.setup();
            },
            function errorCallback(response) {

            });
        };


        // E X C L U I R
        $scope.excluir = function (item) {
            bootbox.confirm
                ({
                    size: "small",
                    title: "Atenção",
                    message: "Confirmar exclusão?",

                    callback: function (result) {
                        if (!result) return;

                        $http({
                            method: "POST",
                            url: "/Usuario/Excluir",
                            data: item
                        }).

                            then(function successCallback(response) {
                                $scope.viewdata.usuario = {};
                                $scope.setup();
                            },

                            function errorCallback(response) {

                            });
                    }
                });
        };


        // E D I T A R

        $scope.editar = function (item) {

            $scope.viewdata.usuario = angular.copy(item);
            $scope.viewdata.usuario.DataCadastro = $filter("jsdate")($scope.viewdata.usuario.DataCadastro);
            //date = $filter("dateFilter")(item.DataCadastro, "dd/MM/yyyy");

            //var parser = datetime("dd/MM/yyyy");
            //parser.setDate(date);
            //console.log(parser.getText())

            ////$scope.viewdata.usuario.DataCadastro = parser.getText();

            //$scope.viewdata.usuario = angular.copy(item);
        };

    }
    angular
        .module("winterfell")
        .controller("usuarioCtrl", usuarioCtrl);

})();