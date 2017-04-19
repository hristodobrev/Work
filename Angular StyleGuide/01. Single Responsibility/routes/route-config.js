(function () {
    angular
        .module('app')
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