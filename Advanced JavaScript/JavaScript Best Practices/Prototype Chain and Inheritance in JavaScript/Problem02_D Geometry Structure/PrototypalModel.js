var geometry = (function() {
    var pointPrototype,
        shapePrototype,
        circlePrototype,
        rectanglePrototype,
        trianglePrototype,
        linePrototype,
        segmentPrototype;

    function checkColor(color) {
        var pattern = /^#[A-F,a-f,0-9]{6}/g;

        if(!pattern.test(color)) {
            throw  new Error('Invalid color. Color has to be in HEX format "#XXXXXX"');
        }
    }

    function checkPoint(point) {
        return (Object.getPrototypeOf(point) === pointPrototype);
    }

    function checkLength(length) {
        return (typeof (length) == 'number') && length > 0;
    }

    function checkTriangle(pointA, pointB, pointC) {
        var a = calculateDistance(pointB, pointC),
            b = calculateDistance(pointA, pointC),
            c = calculateDistance(pointA, pointB);

        if ((a + b) <= c || (a + c) <= b || (b + c) <= a) {
            throw  new Error('Given points do not form a triangle');
        }
    }

    function calculateDistance(pointA, pointB) {
        return Math.sqrt(Math.pow((pointA.x - pointB.x), 2) + Math.pow((pointA.y - pointB.y), 2));
    }

    pointPrototype = {
        constructor: function(x, y) {
            if (typeof x != 'number' || typeof  y != 'number') {
                throw  new Error('invalid coordinates');
            }

            this.x = x;
            this.y = y;
        },

        toString: function() {
            return '(' + this.x + ', ' + this.y + ')';
        },

        equals: function(PointB) {
            return (this.x == PointB.x) && this.y == PointB.y;
        }
    }

    shapePrototype = {
        constructor: function(color) {
            checkColor(color);
            this.color = color;
        },

        toString: function() {
            var output = 'Shape: ' + this._name + '<br/>';
            output += 'Color: ' + this.color;
            return output;
        }
    }

    circlePrototype = Object.create(shapePrototype);
    circlePrototype.constructor = function(centre, radius, color) {
        if (!checkPoint(centre)) {
            throw new Error('Centre has to be a point');
        }

        if (!checkLength(radius)) {
            throw new Error('Invalid radius');
        }

        shapePrototype.constructor.call(this, color);
        this.centre = centre;
        this.radius = radius;
        this._name = 'Circle';
    }

    circlePrototype.toString = function() {
        var output = shapePrototype.toString.call(this);
        
        output += 'Centre coordinates: ' + this.centre.toString() + '<br/>';
        output += 'Radius: ' + this.radius;
        return output;
    }

    rectanglePrototype = Object.create(shapePrototype);
    rectanglePrototype.constructor = function (topLeftCorner, width, height, color) {
        if (!checkPoint(topLeftCorner)) {
            throw new Error('Top left corner has to be a point');
        }

        if (!checkLength(width)) {
            throw new Error('Invalid width');
        }

        if (!checkLength(width)) {
            throw new Error('Invalid height');
        }

        shapePrototype.constructor.call(this, color);
        this.topLeftCorner = topLeftCorner;
        this.width = width;
        this.height = height;
        this._name = 'Rectangle'
    }

    rectanglePrototype.toString = function() {
        var output = shapePrototype.toString.call(this) + '<br/>';
        output += 'Top left corner: ' + this.topLeftCorner.toString() + '<br/>';
        output += 'Width: ' + this.width + '<br/>';
        output += 'Height: ' + this.height;
        return output;
    }

    trianglePrototype = Object.create(shapePrototype);
    trianglePrototype.constructor = function (pointA, pointB, pointC, color) {
        if (!checkPoint(pointA) || !checkPoint(pointB) || !checkPoint(pointC)) {
            throw  new Error('Some of the points are not valid');
        }

        checkTriangle(pointA, pointB, pointC);

        shapePrototype.constructor.call(this, color);
        this.pointA = pointA;
        this.pointB = pointB;
        this.pointC = pointC;
        this._name = 'Rectangle';
    }

    trianglePrototype.toString = function() {
        var output = shapePrototype.toString.call(this) + '<br/>';
        output += 'A:' + this.pointA + '<br/>';
        output += 'B:' + this.pointB + '<br/>';
        output += 'C:' + this.pointC;

        return output;
    }

    linePrototype = Object.create(shapePrototype);
    linePrototype.constructor = function(pointA, pointB, color) {
        if (!checkPoint(pointA) || !checkPoint(pointB)) {
            throw  new Error('Some of the points are not valid');
        }

        if (pointA.equals(pointB)) {
            throw  new Error('The points are equal and do not form a line');
        }

        shapePrototype.constructor.call(this, color);
        this.pointA = pointA;
        this.pointB = pointB;
        this._name = 'Line'
    }

    linePrototype.toString = function() {
        var output = shapePrototype.toString.call(this) + '<br/>';
        
        output += 'A:' + this.pointA + '<br/>';
        output += 'B:' + this.pointB;
        return output;
    }

    segmentPrototype = Object.create(shapePrototype);
    segmentPrototype.constructor = function(pointA, pointB, color) {
        if (!checkPoint(pointA) || !checkPoint(pointB)) {
            throw  new Error('Some of the points are not valid');
        }

        shapePrototype.constructor.call(this, color);
        this.pointA = pointA;
        this.pointB = pointB;
        this._name = 'Segment'
    }

    segmentPrototype.toString = function() {
        var output = shapePrototype.toString.call(this) + '<br/>';
        output += 'A:' + this.pointA + '<br/>';
        output += 'B:' + this.pointB;
        return output;
    }

    return {
        pointPrototype: pointPrototype,
        circlePrototype: circlePrototype,
        rectanglePrototype: rectanglePrototype,
        trianglePrototype: trianglePrototype,
        linePrototype: linePrototype,
        segmentPrototype: segmentPrototype
    }
})();

var point = Object.create(geometry.pointPrototype);
point.constructor(0, 0);

var pointB = Object.create(geometry.pointPrototype);
pointB.constructor(1, 1);

var pointC = Object.create(geometry.pointPrototype);
pointC.constructor(2, 1);

var color = '#AAAAAA';


//var circle = Object.create(geometry.circlePrototype);
//circle.constructor(point, 5, '#AAAAAA');
//console.log(circle.toString());

//var rectangle = Object.create(geometry.rectanglePrototype);
//rectangle.constructor(point, 3, 4, '#AAAAAA');
//console.log(rectangle.toString());
//
//var triangle = Object.create(geometry.trianglePrototype);
//triangle.constructor(point, pointB, pointC, color);
//console.log(triangle.toString());

//var line = Object.create(geometry.linePrototype);
//line.constructor(pointB, pointC, color);
//console.log(line.toString());

var segment = Object.create(geometry.segmentPrototype);
segment.constructor(pointB, pointC, color);
console.log(segment.toString());