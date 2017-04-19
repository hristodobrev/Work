var myApp = angular.module('eShop', ['ngRoute']);

myApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'main.html'
        })
        .when('/ads', {
            templateUrl: 'ads.html',
            controller: 'AdsController',
            controllerAs: 'model'
        })
        .otherwise({
            redirectTo: '/'
        });
}]);