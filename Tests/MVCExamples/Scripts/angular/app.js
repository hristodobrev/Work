angular.module('App', ['ngRoute']);

angular.module('App')

.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.caseInsensitiveMatch = true;
    $routeProvider
    .when('/Main', {
        templateUrl: '/Template/Main',
        controller: 'MainController',
        controllerAs: 'model'
    })
    .when('/Users', {
        templateUrl: '/Template/Users',
        controller: 'UsersController',
        controllerAs: 'model'
    })
    .when('/Messages', {
        templateUrl: '/Template/Messages',
        controller: 'MessagesController',
        controllerAs: 'model'
    });

    $locationProvider.html5Mode(true);
}]);