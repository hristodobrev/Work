(function () {
    angular
        .module('app', ['ngRoute', 'ui.bootstrap'])
        .config(config);

    function config($routeProvider) {
        $routeProvider
        .when('/test', {
            templateUrl: 'test.html',
            controller: 'Test',
            controllerAs: 'vm'
        });
    }
})();