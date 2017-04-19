app.directive('secret', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, mCtrl) {
            function validation(value) {
                if (value.indexOf("s3crt") == 0) {
                    mCtrl.$setValidity('charE', true);
                } else {
                    mCtrl.$setValidity('charE', false);
                }
                return value;
            }
            mCtrl.$parsers.push(validation);
        }
    };
});