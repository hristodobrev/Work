angular.module('App')
.controller('MainController', ['MessagesService', function (MessagesService) {
    var model = this;

    model.heading = 'Main Page';
    model.mainMessage = 'Welcome to main page.';

    model.loadMessages = loadMessages;
    model.addMessage = addMessage;
    model.sendMessage = sendMessage;

    init();

    function init()
    {
        model.loadMessages();
    }

    function loadMessages()
    {
        MessagesService.loadMessages()
        .then(function (data) {
            model.messages = data.data.messages;

            //setTimeout(model.loadMessages, 2000);
        });
    }

    function addMessage(message) {
        console.log('test');
        MessagesService.addMessage(message)
        .then(function () {
            model.loadMessages();
        });
    }

    function sendMessage()
    {
        if ($('#message').val().trim() != "") {
            model.addMessage($('#message').val().trim());
            $('#message').val('');
        }
    }
}]);

angular.module('App')
.factory('MessagesService', ['$http', '$q', function ($http, $q) {
    var service = {
        loadMessages: loadMessages,
        addMessage: addMessage
    };

    return service;

    function loadMessages()
    {
        var deferred = $q.defer();

        $http.get('Home/GetMessages')
        .then(function (success) {
            deferred.resolve(success)
        }, function (error) {
            deferred.reject(error);
        });

        return deferred.promise;
    }

    function addMessage(message)
    {
        var deferred = $q.defer();

        $http.post('Home/AddMessage', { message: message })
        .then(function (success) {
            deferred.resolve(success)
        }, function (error) {
            deferred.reject(error);
        });

        return deferred.promise;
    }
}]);