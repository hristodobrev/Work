app.controller('myCtrl', function ($scope) {
    $scope.names = ['Emil', 'Tobias', 'Linus'];

    $scope.cars = [
        { model: 'Subaru Imprezza', color: 'blue' },
        { model: 'Mitsubishi Lancer Evolution IV', color: 'red' },
        { model: 'Nissan GTR', color: 'lightblue' }
    ];

    $scope.carsObj = {
        car1: 'Subaru',
        car2: 'Mitsubishi',
        car3: 'Nissan'
    };

    $scope.carsPairs = {
        car1: { brand: 'Subaru', model: 'Imprezza', color: 'Blue' },
        car2: { brand: 'Mitsubishi', model: 'Lancer Evolution', color: 'Red' },
        car3: { brand: 'Nissan', model: 'GTR', color: 'Lightblue' }
    };
});