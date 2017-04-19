app.controller('myCtrl', function ($scope) {
    $scope.firstName = 'John';
    $scope.lastName = 'Doe';

    $scope.fullName = function () {
        return $scope.firstName + ' ' + $scope.lastName;
    };
});

app.controller('myAnotherCtrl', function ($scope) {
    $scope.firstName = 'Jane';
    $scope.lastName = 'Doe';
});