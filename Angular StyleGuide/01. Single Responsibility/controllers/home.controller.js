(function () {
    angular
        .module('app')
        .controller('HomeController', ['$scope', '$log', 'HomeFactory', HomeController]);

    function HomeController($scope, $log, HomeFactory) {
        let model = this;

        model.articles = [
            { title: 'Some Article', content: 'This is the content of the first article' },
            { title: 'Some Another Article', content: 'This is the content of the second article' }
        ];

        model.setVariable = function () {
            model.variable = 'Some variable';
        };

        model.setVariable();

        model.inputValue = 'Example';

        $scope.$watch('vm.title', function (current, original) {
            $log.info('vm.title was %s', original);
            $log.info('vm.title is now %s', current);
        });

        HomeFactory.logHello();

        model.people = HomeFactory.getPeopleData();


        $scope.max = 200;

        $scope.random = function () {
            var value = Math.floor(Math.random() * 100 + 1);
            var type;

            if (value < 25) {
                type = 'success';
            } else if (value < 50) {
                type = 'info';
            } else if (value < 75) {
                type = 'warning';
            } else {
                type = 'danger';
            }

            $scope.showWarning = type === 'danger' || type === 'warning';

            $scope.dynamic = value;
            $scope.type = type;
        };

        $scope.random();

        $scope.randomStacked = function () {
            $scope.stacked = [];
            var types = ['success', 'info', 'warning', 'danger'];

            for (var i = 0, n = Math.floor(Math.random() * 4 + 1) ; i < n; i++) {
                var index = Math.floor(Math.random() * 4);
                $scope.stacked.push({
                    value: Math.floor(Math.random() * 30 + 1),
                    type: types[index]
                });
            }
        };

        $scope.randomStacked();
    }
})();