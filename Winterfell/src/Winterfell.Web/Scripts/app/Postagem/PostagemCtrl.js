(function () {
    "use strict";

    noticiaCtrl.$inject = ["$scope", "$http", "$window", "$filter", "toastr", "configSrv"];

    function noticiaCtrl($scope, $http, $window, $filter, toastr, configSrv) {

        $(".summernote").summernote({ height: 320 });

        $scope.view = {
            dtOptions: configSrv.getDtOptions("Nenhum registro encontrado.")
        };

        $scope.viewdata = {};

        $scope.validaForm = function (form) {
            if (form.validate()) {
                return true;
            }

            return false;
        }

        $scope.novaNoticia = function () {
            $scope.viewdata.noticia = {};
            $scope.viewdata.noticia.Ordem = 10;
            $("#modalNoticia").modal("show");
        }

        $scope.editar = function (item) {

            $scope.viewdata.noticia = angular.copy(item);
            $scope.viewdata.noticia.Publicacao = $filter("jsdate")($scope.viewdata.noticia.Publicacao);

            $(".summernote").summernote("code", $scope.viewdata.noticia.Texto);

            $("#modalNoticia").modal("show");
        }

        $scope.setup = function () {

            $scope.viewdata.noticia = {};

            $scope.view.loadingList = true;

            $http({ method: "POST", url: "/Admin/Noticia/GetViewData" })
                .then(function success(response) {
                    $scope.view.loadingList = false;
                    $scope.viewdata.list = response.data;
                },
                    function error(response) {
                        $scope.view.loadingList = false;
                    });
        }

        $scope.salvar = function (item) {

            $scope.view.loading = true;

            var model = angular.copy(item);

            model.Texto = $(".summernote").summernote("code");

            $http({
                method: "POST",
                url: "/Admin/Noticia/Salvar",
                data: model
            }).then(function successCallback(response) {
                $scope.view.loading = false;
                toastr.success("Operação realizada com sucesso.", "Notícia Cadastrada");

                $scope.setup();

                $("#modalNoticia").modal("hide");

            }, function errorCallback(response) {
                $scope.view.loading = false;
                toastr.error("Serviço indisponível no momento.", "Atenção");
            });
        }

        $scope.inativar = function (item) {

            var noticia = angular.copy(item);

            noticia.Publicacao = $filter("jsdate")(noticia.Publicacao);

            bootbox.confirm({
                size: "small",
                title: "Atenção",
                message: "Confirmar inativação?",
                callback: function (result) {
                    if (!result) return;
                    $http({
                        method: "POST",
                        url: "/Admin/Noticia/Inativar",
                        data: noticia
                    }).then(function successCallback(response) {
                        toastr.success("Operação realizada com sucesso.", "Notícia Inativada");

                        $scope.setup();
                    },
                        function errorCallback(response) {
                            toastr.error("Serviço indisponível no momento.", "Atenção");
                        });
                }
            });
        }


        // Global handler for onSuccess that adds the uploaded files to the list
        $scope.onGlobalSuccess = function (response) {
            var item = angular.fromJson(response.data);

            $scope.view.loading = false;
            toastr.success("Operação realizada com sucesso.", "Notícia Cadastrada");

            $scope.setup();

            $("#modalNoticia").modal("hide");
        };

        $scope.onUpload = function (files) {
            $scope.uploading = true;
        };

        $scope.onError = function (response) {
            console.log(response);
            toastr.error("Arquivo muito grande ou incompatível.", "Atenção");
        };

        $scope.onComplete = function (response) {
            $scope.uploading = false;
        };

    }

    angular
        .module("scsi")
        .controller("noticiaCtrl", noticiaCtrl);
})();
