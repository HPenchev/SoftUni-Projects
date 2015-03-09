Array.prototype.flatten = function() {
    var originalArray = this;
    var newArray = [];
    var i = 0;
    var j = 0;
    var element;
    var temp;

    for (i = 0; i < originalArray.length; i+=1) {
        element = originalArray[i];
        if (element.constructor !== Array) {
            newArray.push(element);
        } else {
            temp = element.flatten();
            for (j = 0; j < temp.length; j++) {
                newArray.push(temp[j]);
            }
        }
    }

    return newArray;
}

var array;

array = [1, 2, 3, 4];
console.log(array.flatten())

array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed

array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());

