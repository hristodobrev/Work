app.controller('myCtrl', function ($scope) {
    $scope.copied = false;
    $scope.copy = function (e) {
        e.preventDefault();
        $scope.copied = true;
    };

    $scope.hoverCount = 0;
    $scope.hovered = function () {
        $scope.hoverCount++;
    };

    $scope.clickCount = 0;
    $scope.clicked = function () {
        $scope.clickCount++;
    };

    $scope.showMenu = false;
    $scope.toggleMenu = function () {
        $scope.showMenu = !$scope.showMenu;
    };
});