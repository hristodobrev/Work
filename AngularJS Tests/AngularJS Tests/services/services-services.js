app.service('hexafy', function () {
    this.convertToHex = function (x) {
        return x.toString(16);
    };
});