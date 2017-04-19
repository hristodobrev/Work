app.filter('myFilter', function () {
    return function (x) {
        let i, c, txt = '';
        for (i = 0; i < x.length; i++) {
            c = x[i];
            if (i % 2 == 0) {
                c = c.toUpperCase();
            }

            txt += c;
        }

        return txt;
    };
});

app.filter('singleWord', function () {
    return function (arr) {
        let filtered = [];

        for (let i = 0; i < arr.length; i++) {
            if (arr[i].split(' ').length == 1) {
                filtered.push(arr[i]);
            }
        }

        return filtered;
    };
});