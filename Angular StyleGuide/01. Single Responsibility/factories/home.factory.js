(function () {
    angular
        .module('app')
        .factory('HomeFactory', homeFactory);

    function homeFactory() {
        return {
            logHello: logHello,
            getPeopleData: getPeopleData
        }

        function logHello() {
            console.log('Hello from the home factory!!!');
        }

        function getPeopleData() {
            return [
                { name: 'Franklin', country: 'Canada' },
                { name: 'Chai', country: 'China' },
                { name: 'David', country: 'France' },
                { name: 'Vladimir', country: 'Russia' },
                { name: 'Petros', country: 'Greece' }
            ];
        }
    }
})();