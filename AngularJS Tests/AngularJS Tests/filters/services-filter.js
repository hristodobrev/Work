app.filter('hex', ['hexafy', function (hexafy) {
    return function (x) {
        return hexafy.convertToHex(x);
    }
}]);