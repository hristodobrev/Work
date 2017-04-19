angular.module('App')
.controller('MessagesController', function () {
    var model = this;

    model.heading = 'Messages Page';
    model.mainMessage = 'Welcome to messages page.';
});