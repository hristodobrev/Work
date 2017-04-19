app.controller('myCtrl', function ($scope, $interval) {
    $scope.btnSwitch = true;
    $scope.minutes = new Date().getMinutes();
    $scope.hours = new Date().getHours();
    $scope.time = new Date().toLocaleTimeString();

    $interval(function () {
        $scope.minutes = new Date().getMinutes();
        $scope.hours = new Date().getHours();
        $scope.time = new Date().toLocaleTimeString();
    }, 1000);
});