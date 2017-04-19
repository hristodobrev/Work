myApp.controller('AdsController', function () {
    var model = this;

    model.getData = function () {
        $.getJSON('ads.txt', function (data) {
            model.data = data;
            console.log(model.data);
        });
    }

    model.ads = [
        {
            'title': 'Ground Zero GZRW30 SPL Extreme',
            'description': 'Very powerful subfoower! 1400W, 2x2Ohms, 12"'
        },{
            'title': 'Opel Astra F',
            'description': '90hpw, 1.6 Mono'
        },{
            'title': 'Lumia 650',
            'description': 'Very nice phone...'
        }
    ];
});