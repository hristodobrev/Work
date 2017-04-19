app.directive('globalizeFormat', function () {
    // Restrict the directive to show only on specified elements
    // Default: EA
    // E - element
    // A - attribute
    // C - class
    // M - comment

    return function (scope, element, attr) {
        console.log(scope);
        console.log(element);
        console.log(attr);

        //element.text('value=' + attr.dataValue);
    };
})

.directive('formatData', function () {
    return function (scope, element, attr) {
        element.text((attr.prepend ? attr.prepend : '') + element.text() + (attr.append ? attr.append : ''));
    };
})

.directive('circle', function () {
    return function (sc, el, attr) {
        if (!attr.radius) {
            throw new Error('Circle must have a radius.');
        }
        var radius = parseInt(attr.radius);
        var canvas = document.createElement('canvas');
        var ctx = canvas.getContext('2d');
        var thickness = 1;
        var percent = 100;
        if (attr.thickness) {
            thickness = parseInt(attr.thickness);
        }
        if (attr.percent) {
            percent = parseInt(attr.percent);
        }
        canvas.width = radius * 2 + thickness;
        canvas.height = radius * 2 + thickness;
        var x = radius + thickness / 2;
        var y = radius + thickness / 2;
        
        ctx.beginPath();
        if (attr.color) {
            ctx.strokeStyle = attr.color;
        }
        if (attr.thickness) {
            ctx.lineWidth = thickness;
        }
        ctx.arc(x, y, radius, 0, ((Math.PI * 2) * percent / 100));
        ctx.stroke();

        if (attr.text) {
            var textSize = Math.round(radius / 2);
            ctx.font = textSize + 'px Arial';
            ctx.fillText(attr.text, x, radius - thickness + textSize / 2);
        }

        var container = $('<div>');
        var text = $('<span>').text('Text');
        container.append(canvas);
        container.append(text);
        el.html(container);
    }
});