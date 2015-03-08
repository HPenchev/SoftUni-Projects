function add(num) {
    var totalSum = 0;
    function inner(numToAdd) {

        return add(num + numToAdd);
    }

    inner.valueOf = function(){
        return num;
    }

    return inner;
}

console.log(add(1));
console.log(add(2)(3));
console.log(add(1)(1)(1)(1)(1));
console.log(add(1)(0)(-1)(-1));

var addTwo = add(2);
console.log(addTwo);
console.log(addTwo(3));
