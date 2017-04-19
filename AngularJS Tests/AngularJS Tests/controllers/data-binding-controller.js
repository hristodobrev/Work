app.controller('myCtrl', function ($scope) {
    $scope.firstName = 'John';
    $scope.lastName = 'Doe';

    $scope.changeName = function () {
        if ($scope.firstName == 'John') {
            $scope.firstName = 'Nelly';
        } else {
            $scope.firstName = 'John';
        }
    };
});