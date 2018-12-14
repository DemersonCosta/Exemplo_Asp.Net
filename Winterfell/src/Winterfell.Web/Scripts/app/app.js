(function () {
    "use strict";

    /**
     * Obs.: A ordem dos módulos e plugins/dependências importa para correta injeção de dependência no angularjs
     */
    angular.module("winterfell",       [
         
        "datetime",
        "ngValidate"
           
        ]);

})();