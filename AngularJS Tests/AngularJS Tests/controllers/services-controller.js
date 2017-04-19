app.controller('myCtrl', function ($scope, $location, $http,
            $timeout, $interval, hexafy) {
    $scope.myUrl = $location.absUrl();

    $http.get('welcome.htm').then(function (response) {
        $scope.myWelcome = response.data;
    });

    $scope.myHeader = 'Hello!';
    $timeout(function () {
        $scope.myHeader = 'How are you?';
    }, 2000);

    $scope.theTime = new Date().toLocaleTimeString();
    $interval(function () {
        $scope.theTime = new Date().toLocaleTimeString();
    }, 1000);

    $scope.dec = 20;
    $scope.changeHex = function () {
        $scope.hex = hexafy.convertToHex($scope.dec);
    }

    $scope.changeHex();

    $scope.numbers = [11, 42, 27, 32];
});