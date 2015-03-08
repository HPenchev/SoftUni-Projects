function testContext() {
    console.log(this);
}

function outerFunction() {
    testContext();
}

var test = new testContext();

testContext();
outerFunction();
// When a function is called, it is in the global scope so it returns the global scope
test;
//When a function is an object it returns an object scope.
