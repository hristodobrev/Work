app.controller('myCtrl', function ($scope, $http) {
    $http.get('customers.aspx')
    .then(function (response) {
        $scope.names = response.data.records;
    });

    $scope.reverse = false;

    $scope.orderKey = 'Name';
    $scope.reorderBy = function (key) {
        $scope.reverse = $scope.orderKey == key ? !$scope.reverse : false;
        $scope.orderKey = key;
    };
});