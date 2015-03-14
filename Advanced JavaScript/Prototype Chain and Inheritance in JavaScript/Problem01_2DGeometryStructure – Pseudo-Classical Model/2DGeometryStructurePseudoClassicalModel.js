var geometry = (function() {

    function Point(x, y) {
        if (typeof x != "number" || typeof  y != "number") {
            throw  new Error("invalid coordinates");
        }

        this.x = x;
        this.y = y;
    }

    Point.prototype.toString = function () {
        return "(" + this.x + ", " + this.y + ")";
    }

    Point.prototype.equals = function (PointB) {
        if(this.x == PointB.x && this.y == PointB.y) {
            return true;
        } else {
            return false;
        }
    }

    function Shape(color) {
        checkColor(color);
        this.color = color;
    }

    Shape.prototype.toString = function () {
        var output = "Shape: " + this.constructor.name + "<br/>";
        output += "Color: " + this.color;
        return output;
    }

    function Circle(centre, radius, color) {
        if (!checkPoint(centre)) {
            throw new Error("Centre has to be a point");
        }

        if (!checkLength(radius)) {
            throw new Error("Invalid radius");
        }

        Shape.call(this, color);
        this.centre = centre;
        this.radius = radius;
    }

    Circle.prototype = Object.create(Shape.prototype);
    Circle.prototype.constructor = Circle;

    Circle.prototype.toString = function () {
        var output = Shape.prototype.toString.call(this) + "<br/>";
        output += "Centre coordinates: " + this.centre.toString() + "<br/>";
        output += "Radius: " + this.radius;
        return output;
    }

    function Rectangle(topLeftCorner, width, height, color) {
        if (!checkPoint(topLeftCorner)) {
            throw new Error("Top left corner has to be a point");
        }

        if (!checkLength(width)) {
            throw new Error("Invalid width");
        }

        if (!checkLength(width)) {
            throw new Error("Invalid height");
        }

        Shape.call(this, color);
        this.topLeftCorner = topLeftCorner;
        this.width = width;
        this.height = height;
    }

    Rectangle.prototype = Object.create(Shape.prototype);
    Rectangle.prototype.constructor = Rectangle;

    Rectangle.prototype.toString = function () {
        var output = Shape.prototype.toString.call(this) + "<br/>";
        output += "Top left corner: " + this.topLeftCorner.toString() + "<br/>";
        output += "Width: " + this.width + "<br/>";
        output += "Height: " + this.height;
        return output;
    }

    function Triangle(pointA, pointB, pointC, color) {
        if (!checkPoint(pointA) || !checkPoint(pointB) || !checkPoint(pointC)) {
            throw  new Error("Some of the points are not valid");
        }

        checkTriangle(pointA, pointB, pointC);

        Shape.call(this, color);
        this.pointA = pointA;
        this.pointB = pointB;
        this.pointC = pointC;
    }

    Triangle.prototype = Object.create(Shape.prototype);
    Triangle.prototype.constructor = Triangle;

    Triangle.prototype.toString = function () {
        var output = Shape.prototype.toString.call(this) + "<br/>";
        output += "A:" + this.pointA + "<br/>";
        output += "B:" + this.pointB + "<br/>";
        output += "C:" + this.pointC;

        return output;
    }

    function Line(pointA, pointB, color) {
        if (!checkPoint(pointA) || !checkPoint(pointB)) {
            throw  new Error("Some of the points are not valid");
        }

        if (pointA.equals(pointB)) {
            throw  new Error("The points are equal and don't form a line");
        }

        Shape.call(this, color);
        this.pointA = pointA;
        this.pointB = pointB;
    }

    Line.prototype = Object.create((Shape.prototype));
    Line.prototype.constructor = Line;

    Line.prototype.toString = function() {
        var output = Shape.prototype.toString.call(this) + "<br/>";
        output += "A:" + this.pointA + "<br/>";
        output += "B:" + this.pointB;
        return output;
    }

    function Segment(pointA, pointB, color) {
        if (!checkPoint(pointA) || !checkPoint(pointB)) {
            throw  new Error("Some of the points are not valid");
        }

        Shape.call(this, color);
        this.pointA = pointA;
        this.pointB = pointB;
    }

    Segment.prototype = Object.create((Shape.prototype));
    Segment.prototype.constructor = Segment;

    Segment.prototype.toString = function() {
        var output = Shape.prototype.toString.call(this) + "<br/>";
        output += "A:" + this.pointA + "<br/>";
        output += "B:" + this.pointB;
        return output
    }

    function checkPoint(point) {
        return (point instanceof Point)
    }

    function checkLength(length) {
        return (typeof (length) == "number") && length > 0;
    }

    function checkTriangle(pointA, pointB, pointC) {
        var a = calculateDistance(pointB, pointC);
        var b = calculateDistance(pointA, pointC);
        var c = calculateDistance(pointA, pointB);

        if ((a + b) <= c || (a + c) <= b || (b + c) <= a) {
            throw  new Error("Given points do not form a triangle");
        }
    }

    function calculateDistance(pointA, pointB) {
        return Math.sqrt(Math.pow((pointA.x - pointB.x), 2) + Math.pow((pointA.y - pointB.y), 2));
    }

    function checkColor(color) {
        var pattern = /^#[A-F,a-f,0-9]{6}/g;
        if(!pattern.test(color)) {
            throw  new Error('Invalid color. Color has to be in HEX format "#XXXXXX"');
        }
    }

    return {
        Point: Point,
        Circle: Circle,
        Rectangle: Rectangle,
        Triangle: Triangle,
        Line: Line,
        Segment: Segment
    };
})();

var pointA = new geometry.Point(0, 0);
var pointB = new geometry.Point(1, 1);

var segment = new geometry.Segment(pointA, pointB, "#AAAAAA");
console.log(segment.toString());

var circle = new geometry.Circle(pointA, 5, "#AAAAAA");
console.log(circle.toString());