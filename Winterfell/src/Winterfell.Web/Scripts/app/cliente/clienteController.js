
(function()
{
    angular.module("winterfell", ["datetime"]).filter("dateFilter", function ()
    {
        return function (item)
        {
            if (item != null)
            {
                return new Date(parseInt(item.substr(6) ) );
            }

            return "";
        };
    })
    .controller("ClienteController", ["$scope", "$http", "$filter", "datetime", function ($scope, $http, $filter, datetime)
    {
        $scope.nome = "Ricardo";
        $scope.viewdata = {};

        $scope.getViewData = function ()
        {
            $http({ method: "POST", url:"/Cliente/GetViewData" }).then(function success(response)
            {
                $scope.viewdata.clientes = response.data;
            });
        }

        /********************* F U N Ç Õ E S **************************/

        $scope.getViewData();
        

        // S A L V A R
        $scope.salvar = function ()
        {
            $http ({
                method: "POST",
                url: "/Cliente/Salvar",
                data: $scope.viewdata.cliente
            }).

            then(function successCallback(response)
            {
                $scope.viewdata.cliente = {};
                $scope.getViewData();
            },

            function errorCallback(response)
            {
                
            });
        }


        // E X C L U I R

        $scope.excluir = function (item)
        {
            bootbox.confirm
            ({
                size: "small",
                title: "Atenção",
                message: "Confirmar exclusão?",

                callback: function (result)
                {
                    if (!result) return;

                    $http ({
                        method: "POST",
                        url: "/Cliente/Excluir",
                        data: item
                    }).

                    then(function successCallback(response)
                    {
                        $scope.viewdata.cliente = {};
                        $scope.getViewData();
                    },

                    function errorCallback(response)
                    {

                    });
                }
            });
        }


        // E D I T A R

        $scope.editar = function (item)
        {
            date = $filter("dateFilter")(item.Nascimento, "dd/MM/yyyy"); 
            var parser = datetime("dd/MM/yyyy");
            parser.setDate(date);

            
            $scope.viewdata.cliente.Nascimento = parser.getText();
            $scope.viewdata.cliente = angular.copy(item);
        }
    }]);
})();

