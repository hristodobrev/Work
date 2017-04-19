app.controller('myCtrl', function ($scope) {
    $scope.name = 'John';
    $scope.lowerName = angular.lowercase($scope.name);
    $scope.upperName = angular.uppercase($scope.name);

    $scope.str = 'Some string';
    $scope.num = 12;
    $scope.strIsString = angular.isString($scope.str);
    $scope.numIsString = angular.isString($scope.num);
    $scope.strIsNumber = angular.isNumber($scope.str);
    $scope.numIsNumber = angular.isNumber($scope.num);
});