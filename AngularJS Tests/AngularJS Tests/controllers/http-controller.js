app.controller('myCtrl', function ($scope, $http) {
    $http.get('welcome.htm')
    .then(function (response) {
        $scope.data = response.data;
        $scope.status = response.status;
        $scope.statusText = response.statusText;
    }, function (response) {
        $scope.welcomeMessage = response.statusText;
    });

    $.getJSON('/customers.json', function (data) { 
        console.log(data);
    });
});