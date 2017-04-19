app.controller('myCtrl', function ($scope) {
    $scope.firstName = 'John';
    $scope.lastName = 'Doe';

    $scope.people = [
        { name: 'Willam', country: 'Sweden' },
        { name: 'Grane', country: 'Poland' },
        { name: 'Tomas', country: 'Greece' },
        { name: 'Ryan', country: 'Italy' },
        { name: 'Peter', country: 'United Kingdom' },
        { name: 'Jeze', country: 'California' }
    ];

    $scope.price = 15.90;

    $scope.names = [
        'Jani',
        'Carl Ben',
        'Margareth',
        'Hege',
        'Joe',
        'Gustav Someone',
        'Birgit',
        'Mary',
        'Kai'
    ];

    $scope.orderKey = 'name';
});