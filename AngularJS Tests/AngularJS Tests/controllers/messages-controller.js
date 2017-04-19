var myApp = angular.module('Messages', []);

myApp.controller('MessagesController', function () {
    var model = this;
    model.emails = {};
    model.emails.messages = [{
        "from": "Steve Jobs",
        "subject": "I think I'm holding my phone wrong :/",
        "sent": "2013-10-01T08:05:59Z"
    },{
        "from": "Ellie Goulding",
        "subject": "I've got Starry Eyes, lulz",
        "sent": "2013-09-21T19:45:00Z"
    },{
        "from": "Michael Stipe",
        "subject": "Everybody hurts, sometimes.",
        "sent": "2013-09-12T11:38:30Z"
    },{
        "from": "Jeremy Clarkson",
        "subject": "Think I've found the best car... In the world",
        "sent": "2013-09-03T13:15:11Z"
    }];

    model.deleteMessage = function(index) {
        model.emails.messages.splice(index, 1);
    }
});